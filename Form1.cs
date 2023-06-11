using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SOFTWARE
{
    public partial class Form1 : Form
    {
        int i, cnt, error, sum, compare, ADC_value, time;
        double voltage, lux, mean;

        Byte[] CLOSED = { 0x43, 0x4C, 0x4F, 0x53 };

        Byte[] bSTX = { 0x02 };
        Byte[] bETX = { 0x03 };
        Byte[] bACK = { 0x06 };
        Byte[] bSYNC = { 0x16 };

        Byte[] bMOVL = { 0x4D, 0x4F, 0x56, 0x4C };
        Byte[] bGPOS = { 0x47, 0x50, 0x4F, 0x53 };
        Byte[] bGVEL = { 0x47, 0x56, 0x45, 0x4C };
        Byte[] bGSTT = { 0x47, 0x53, 0x54, 0x54 };

        Byte[] eLED = { 0x65, 0x4C, 0x45, 0x44 };
        Byte[] dLED = { 0x64, 0x4C, 0x45, 0x44 };
        Byte[] bONN = { 0x62, 0x4F, 0x4E, 0x4E };
        Byte[] bOFF = { 0x62, 0x4F, 0x46, 0x46 };
        Byte[] bTOG = { 0x62, 0x54, 0x4F, 0x47 };

        Byte[] eBTN = { 0x65, 0x42, 0x54, 0x4E };
        Byte[] dBTN = { 0x64, 0x42, 0x54, 0x4E };
        Byte[] Btn_SingleClick = { 0x53, 0x69, 0x6E, 0x67, 0x63, 0x6C, 0x69, 0x63 };
        Byte[] Btn_LongClick = { 0x4C, 0x6F, 0x6E, 0x67, 0x63, 0x6C, 0x69, 0x63 };
        bool btn = false;

        Byte[] eLIG = { 0x65, 0x4C, 0x49, 0x47 };
        Byte[] dLIG = { 0x64, 0x4C, 0x49, 0x47 };
        Byte[] rLIG = { 0x52, 0x55, 0x4E };
        Byte[] sLIG = { 0x53, 0x54, 0x4F };
        bool option = false;

        Byte[] ePWM = { 0x65, 0x50, 0x57, 0x4D };
        Byte[] dPWM = { 0x64, 0x50, 0x57, 0x4D };
        Byte[] bSET = { 0x53, 0x45, 0x54 };
        string Duty;

        Byte[] bOPT = { 0x00, 0x00, 0x00 };

        Byte[] bDATA = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        Byte[] Tx_Protocol = new Byte[18];
        Byte[] Rx_Protocol = new Byte[18];

        string Data_read;
        string strCmd;
        string strOpt;
        string strData;

        public Form1()
        {
            InitializeComponent();
            radio_Event.Enabled = false;
            radio_Timer.Enabled = false;
            txtTime.Enabled = false;
            btn_Start_Stop_BTL1.Enabled = false;
            grBox_BTL1.Enabled = false; 
            grBox_DIGITAL.Enabled = false;
            grBox_ANALOG.Enabled = false;
            grBox_LED.Enabled = false;
            grBox_SENSOR.Enabled = false;
            grBox_PWM.Enabled = false;
            string[] myport = SerialPort.GetPortNames();
            cbox_Port.Items.AddRange(myport);
            cbox_Baud.Text = "115200";
            cbox_DataBits.Text = "8";
            cbox_Parity.Text = "None";
            cbox_Stopbits.Text = "One";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Titles.Add("READ TEMT6000 SENSOR");
            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.LabelStyle.Format = "";
            chartArea.AxisY.LabelStyle.Format = "";
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = true;
            chartArea.AxisY.LabelStyle.IsEndLabelVisible = true;

            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 5;
            chartArea.AxisY.Minimum = 10;
            chartArea.AxisY.Maximum = 50;

            chartArea.AxisX.Interval = 1;
            chartArea.AxisY.Interval = 20;
            chartArea.AxisX.Title = "Time (s)";
            chartArea.AxisY.Title = "Light (Lux)";

            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].Color = Color.Red;
            chart1.Series[0].BorderWidth = 2;
            chart1.Series[0].IsVisibleInLegend = false;

            chart1.Series[1].ChartType = SeriesChartType.Line;
            chart1.Series[1].Color = Color.Blue;
            chart1.Series[1].BorderWidth = 2;
            chart1.Series[1].IsVisibleInLegend = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Send_Process(Tx_Protocol, bSTX, CLOSED, bOPT, bDATA, bSYNC, bETX);
        }

        private void btn_Con_Dis_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Con_Dis.Text == "Connect")
                {
                    serialPort1.PortName = cbox_Port.Text;
                    serialPort1.BaudRate = int.Parse(cbox_Baud.Text);
                    serialPort1.DataBits = int.Parse(cbox_DataBits.Text);
                    serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cbox_Parity.Text);
                    serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cbox_Stopbits.Text);
                    serialPort1.Open();
                    txtSent_Received.Text += "Serial Port Opened" + "\r\n\r\n";
                    btn_Con_Dis.Text = "Disconnect";
                    radio_Event.Enabled = true;
                    radio_Timer.Enabled = true;
                    cbox_Port.Enabled = false;
                    cbox_Baud.Enabled = false;
                    cbox_Parity.Enabled = false;
                    cbox_DataBits.Enabled = false;
                    cbox_Stopbits.Enabled = false;
                    grBox_BTL1.Enabled = true;
                    grBox_DIGITAL.Enabled = true;
                    grBox_ANALOG.Enabled = true;
                }
                else if (btn_Con_Dis.Text == "Disconnect")
                {
                    Send_Process(Tx_Protocol, bSTX, CLOSED, bOPT, bDATA, bSYNC, bETX);

                    serialPort1.Close();
                    txtSent_Received.Text += "Serial Port Closed" + "\r\n\r\n";
                    btn_Con_Dis.Text = "Connect";
                    radio_Event.Checked = false;
                    radio_Timer.Checked = false;
                    error = 0;
                    lbError.Text = error.ToString();
                    radio_Event.Enabled = false;
                    radio_Timer.Enabled = false;
                    btn_MOVL.Enabled = false;
                    btn_GPOS.Enabled = false;
                    btn_GSTT.Enabled = false;
                    btn_GVEL.Enabled = false;
                    cbox_Port.Enabled = true;
                    cbox_Baud.Enabled = true;
                    cbox_Parity.Enabled = true;
                    cbox_DataBits.Enabled = true;
                    cbox_Stopbits.Enabled = true;
                    grBox_BTL1.Enabled = false;
                    grBox_DIGITAL.Enabled = false;
                    grBox_ANALOG.Enabled = false;
                    grBox_LED.Enabled = false;
                    grBox_SENSOR.Enabled = false;
                    grBox_PWM.Enabled = false;
                    checkBox_Led.Checked = false;
                    checkBox_Button.Checked = false;
                    checkBox_Sensor.Checked = false;
                    checkBox_PWM.Checked = false;
                    radio_OnLed.Checked = false;
                    radio_OffLed.Checked = false;
                    radio_Toggle.Checked = false;
                    txtPV.Text = "";
                    txtMV.Text = "";
                    numeric_Duty.Value = 0;
                    chart1.Series[0].Points.Clear();
                    chart1.Series[1].Points.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void radio_Event_CheckedChanged(object sender, EventArgs e)
        {
            btn_MOVL.Enabled = true;
            btn_GPOS.Enabled = true;
            btn_GVEL.Enabled = true;
            btn_GSTT.Enabled = true;
            txtTime.Enabled = false;
            error = 0;
            lbError.Text = error.ToString();
            sum = 0;
            lbTong.Text = sum.ToString();
            btn_Start_Stop_BTL1.Enabled = false;
            txtTime.Text = "";
        }

        private void radio_Timer_CheckedChanged(object sender, EventArgs e)
        {
            txtTime.Enabled = true;
            btn_Start_Stop_BTL1.Enabled = true;
            btn_MOVL.Enabled = false;
            btn_GPOS.Enabled = false;
            btn_GSTT.Enabled = false;
            btn_GVEL.Enabled = false;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Data_read += serialPort1.ReadExisting();
            Invoke(new EventHandler(ShowData));
        }

        private void ShowData(object sender, EventArgs e)
        {
            try
            {
                if (Data_read[0] == bSTX[0] && Data_read[16] == bACK[0] && Data_read[17] == bETX[0])
                {
                    for (i = 1; i < 5; i++)
                    {
                        strCmd += Data_read[i].ToString();
                    }
                    for (i = 5; i < 8; i++)
                    {
                        strOpt += Data_read[i].ToString();
                    }
                    for (i = 8; i < 16; i++)
                    {
                        strData += Data_read[i].ToString();
                    }
                    Rx_Protocol = Encoding.ASCII.GetBytes(Data_read);
                    for(i = 1; i < 5; i++)
                    {
                        if (Rx_Protocol[i] != Tx_Protocol[i])
                        {
                            compare = 0;
                        }
                        else
                        {
                            compare = 1;
                        }
                    }
                    if (compare == 1)
                    {
                        if (strCmd == Encoding.UTF8.GetString(bMOVL))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n\r\n";
                        }
                        else if (strCmd == Encoding.UTF8.GetString(bGPOS))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n\r\n";
                        }
                        else if (strCmd == Encoding.UTF8.GetString(bGSTT))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n\r\n";
                        }
                        else if (strCmd == Encoding.UTF8.GetString(bGVEL))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n\r\n";
                        }
                        else if (strCmd == Encoding.UTF8.GetString(eLED))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                            txtSent_Received.Text += "LED connected" + "\r\n";
                        }
                        else if (strCmd == Encoding.UTF8.GetString(dLED))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                            txtSent_Received.Text += "LED disconnected" + "\r\n\r\n";
                        }
                        else if (strCmd == Encoding.UTF8.GetString(bONN))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                            txtSent_Received.Text += "LED ON" + "\r\n";
                        }
                        else if (strCmd == Encoding.UTF8.GetString(bOFF))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                            txtSent_Received.Text += "LED OFF" + "\r\n";
                        }
                        else if (strCmd == Encoding.UTF8.GetString(bTOG))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                            txtSent_Received.Text += "LED TOGGLE" + "\r\n";
                        }
                        else if (strCmd == Encoding.UTF8.GetString(eBTN))
                        {
                            if (btn == false)
                            {
                                txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                                txtSent_Received.Text += "BUTTON connected" + "\r\n";
                                btn = true;
                            }
                            if (strData == Encoding.UTF8.GetString(Btn_SingleClick))
                            {
                                txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                                txtSent_Received.Text += "SINGLE CLICK" + "\r\n";
                            }
                            else if (strData == Encoding.UTF8.GetString(Btn_LongClick))
                            {
                                txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                                txtSent_Received.Text += "LONG CLICK" + "\r\n";
                            }
                        }
                        else if (strCmd == Encoding.UTF8.GetString(dBTN))
                        {
                            if (btn == true)
                            {
                                txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                                txtSent_Received.Text += "BUTTON disconnected" + "\r\n\r\n";
                                btn = false;
                            }
                        }
                        else if (strCmd == Encoding.UTF8.GetString(eLIG))
                        {
                            if (strOpt == Encoding.UTF8.GetString(bOPT))
                            {
                                txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                                txtSent_Received.Text += "LIGHT SENSOR connected" + "\r\n";
                            }
                            else if (strOpt == Encoding.UTF8.GetString(rLIG))
                            {
                                if (option == false)
                                {
                                    txtSent_Received.Text += "START Read Sensor" + "\r\n";
                                    option = true;
                                }
                                txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                                ADC_value = int.Parse(strData);
                            }
                            else if (strOpt == Encoding.UTF8.GetString(sLIG))
                            {
                                txtSent_Received.Text += "STOP Read Sensor" + "\r\n";
                                txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n\r\n";
                                option = false;
                            }
                        }
                        else if (strCmd == Encoding.UTF8.GetString(dLIG))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                            txtSent_Received.Text += "LIGHT SENSOR disconnected" + "\r\n\r\n";
                        }
                        else if (strCmd == Encoding.UTF8.GetString(ePWM))
                        {
                            if (strOpt == Encoding.UTF8.GetString(bOPT))
                            {
                                txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                                txtSent_Received.Text += "PWM connected" + "\r\n";
                            }
                            else if (strOpt == Encoding.UTF8.GetString(bSET))
                            {
                                txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                                txtSent_Received.Text += "SET DUTY Successfull" + "\r\n";
                            }
                        }
                        else if (strCmd == Encoding.UTF8.GetString(dPWM))
                        {
                            txtSent_Received.Text += BitConverter.ToString(Rx_Protocol) + "\r\n";
                            txtSent_Received.Text += "PWM disconnected" + "\r\n\r\n";
                        }
                    }
                    else
                    {
                        error = error + 1;
                        lbError.Text = error.ToString();
                    }
                }
                ScrollToBottom(txtSent_Received);
                Data_read = "";
                strCmd = "";
                strOpt = "";
                strData = "";
            }
            catch (Exception ex) { }
        }

        private void PlotChart_Lux(double dataX, double dataY)
        {
            chart1.Series[0].Points.AddXY(dataX, dataY);
            var chartArea = chart1.ChartAreas[0];
            if (dataX > chartArea.AxisX.Maximum)
            {
                chartArea.AxisX.Maximum = dataX;
                if ((chartArea.AxisX.Maximum) / (chartArea.AxisX.Interval) >= 10)
                    chartArea.AxisX.Interval += 1;
            }
            if (dataX < chartArea.AxisX.Minimum)
            {
                chartArea.AxisX.Minimum = dataX;
                if ((chartArea.AxisX.Minimum) / (chartArea.AxisX.Interval) >= 10)
                    chartArea.AxisX.Interval += 1;
            }
            if (dataY > chartArea.AxisY.Maximum)
            {
                chartArea.AxisY.Maximum = Math.Floor(dataY + 20) ;
                if ((chartArea.AxisY.Maximum) / (chartArea.AxisY.Interval) >= 10)
                    chartArea.AxisY.Interval = Math.Floor((chartArea.AxisY.Maximum - chartArea.AxisY.Minimum) / 4);
            }
            if (dataY < chartArea.AxisY.Minimum)
            {
                chartArea.AxisY.Minimum = Math.Floor(dataY - 20);
                if ((chartArea.AxisY.Minimum) / (chartArea.AxisY.Interval) >= 10)
                    chartArea.AxisY.Interval = Math.Floor((chartArea.AxisY.Maximum - chartArea.AxisY.Minimum) / 4);
            }
        }

        private void PlotChart_Mean(double dataX, double dataY)
        {
            chart1.Series[1].Points.AddXY(dataX, dataY);
            var chartArea1 = chart1.ChartAreas[0];
            if (dataX > chartArea1.AxisX.Maximum)
            {
                chartArea1.AxisX.Maximum = dataX;
                if ((chartArea1.AxisX.Maximum) / (chartArea1.AxisX.Interval) >= 10)
                    chartArea1.AxisX.Interval += 1;
            }
            if (dataX < chartArea1.AxisX.Minimum)
            {
                chartArea1.AxisX.Minimum = dataX;
                if ((chartArea1.AxisX.Minimum) / (chartArea1.AxisX.Interval) >= 10)
                    chartArea1.AxisX.Interval += 1;
            }
        }

        private void checkBox_Led_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_Button.Checked == true || checkBox_Sensor.Checked == true || checkBox_PWM.Checked == true || btn_Start_Stop_BTL1.Text == "Stop")
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBox_Led.Checked = false;
                }
                else if (checkBox_Led.Checked == true && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, eLED, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                    grBox_LED.Enabled = true;
                    radio_Event.Checked = false;
                    radio_Timer.Checked = false;
                    txtTime.Text = "";
                    txtTime.Enabled = false;
                    btn_Start_Stop_BTL1.Enabled = false;
                    grBox_BTL1.Enabled = false;
                }
                else if (checkBox_Led.Checked == false && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, dLED, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                    grBox_LED.Enabled = false;
                    radio_OnLed.Checked = false;
                    radio_OffLed.Checked = false;
                    radio_Toggle.Checked = false;
                    grBox_BTL1.Enabled = true;
                }
            }
            catch (Exception ex) { }
        }

        private void radio_OnLed_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio_OnLed.Checked == true && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, bONN, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                }
            }
            catch (Exception ex) { }
        }

        private void radio_OffLed_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio_OffLed.Checked == true && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, bOFF, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                }
            }
            catch (Exception ex) { }
        }

        private void radio_Toggle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio_Toggle.Checked == true && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, bTOG, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                }
            }
            catch (Exception ex) { }
        }

        private void checkBox_Button_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_Led.Checked == true || checkBox_Sensor.Checked == true || checkBox_PWM.Checked == true || btn_Start_Stop_BTL1.Text == "Stop")
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBox_Button.Checked = false;
                }
                else if (checkBox_Button.Checked == true && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, eBTN, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                    radio_Event.Checked = false;
                    radio_Timer.Checked = false;
                    txtTime.Text = "";
                    txtTime.Enabled = false;
                    btn_Start_Stop_BTL1.Enabled = false;
                    grBox_BTL1.Enabled = false;
                }
                else if (checkBox_Button.Checked == false && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, dBTN, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                    grBox_BTL1.Enabled = true;
                }
            }
            catch (Exception ex) { }
        }

        private void checkBox_Sensor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_Led.Checked == true || checkBox_Button.Checked == true || checkBox_PWM.Checked == true || btn_Start_Stop_BTL1.Text == "Stop")
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBox_Sensor.Checked = false;
                }
                else if (btn_Start_Stop_Sensor.Text == "Stop")
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBox_Sensor.Checked = true;
                }
                else if (checkBox_Sensor.Checked == true && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, eLIG, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                    btn_Start_Stop_Sensor.Enabled = true;
                    grBox_SENSOR.Enabled = true;
                    radio_Event.Checked = false;
                    radio_Timer.Checked = false;
                    txtTime.Text = "";
                    txtTime.Enabled = false;
                    btn_Start_Stop_BTL1.Enabled = false;
                    grBox_BTL1.Enabled = false;
                }
                else if (checkBox_Sensor.Checked == false && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, dLIG, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                    btn_Start_Stop_Sensor.Enabled = false;
                    grBox_SENSOR.Enabled = false;
                    grBox_BTL1.Enabled = true;
                }
            }
            catch (Exception ex) { }
        }

        private void btn_Start_Stop_Sensor_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Start_Stop_Sensor.Text == "Start")
                {
                    Send_Process(Tx_Protocol, bSTX, eLIG, rLIG, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                    btn_Start_Stop_Sensor.Text = "Stop";
                    btn_Con_Dis.Enabled = false;
                    chart1.Series[0].Points.Clear();
                    chart1.Series[1].Points.Clear();
                    time = 0;
                    mean = 0;
                    var chartArea = chart1.ChartAreas[0];
                    chartArea.AxisX.Minimum = 0;
                    chartArea.AxisX.Maximum = 5;
                    chartArea.AxisY.Minimum = 50;
                    chartArea.AxisY.Maximum = 150;

                    chartArea.AxisX.Interval = 1;
                    chartArea.AxisY.Interval = 20;
                    timControl.Enabled = true;
                }
                else if (btn_Start_Stop_Sensor.Text == "Stop")
                {
                    Send_Process(Tx_Protocol, bSTX, eLIG, sLIG, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                    btn_Start_Stop_Sensor.Text = "Start";
                    btn_Con_Dis.Enabled = true;
                    timControl.Enabled = false;
                    for (int k = 0; k <= time; k++)
                    {
                        PlotChart_Mean((double)timControl.Interval * (double)k / 1000, mean);
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            time = 0;
            mean = 0;
            txtPV.Text = "";
            txtMV.Text = "";
            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 10;
            chartArea.AxisY.Minimum = 50;
            chartArea.AxisY.Maximum = 150;

            chartArea.AxisX.Interval = 1;
            chartArea.AxisY.Interval = 20;
        }

        private void checkBox_PWM_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_Led.Checked == true || checkBox_Button.Checked == true || checkBox_Sensor.Checked == true || btn_Start_Stop_BTL1.Text == "Stop")
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBox_PWM.Checked = false;
                }
                else if (checkBox_PWM.Checked == true && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, ePWM, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                    grBox_PWM.Enabled = true;
                    radio_Event.Checked = false;
                    radio_Timer.Checked = false;
                    txtTime.Text = "";
                    txtTime.Enabled = false;
                    btn_Start_Stop_BTL1.Enabled = false;
                    grBox_BTL1.Enabled = false;
                }
                else if(checkBox_PWM.Checked == false && serialPort1.IsOpen)
                {
                    Send_Process(Tx_Protocol, bSTX, dPWM, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
                    grBox_PWM.Enabled = false;
                    grBox_BTL1.Enabled = true;
                    numeric_Duty.Value = 0;
                }
            }
            catch (Exception ex) { }
        }

        private void numeric_Duty_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_PWM.Checked == true && serialPort1.IsOpen)
            {
                Duty = numeric_Duty.Value.ToString();
                Send_Process(Tx_Protocol, bSTX, ePWM, bSET, Encoding.ASCII.GetBytes(Duty), bSYNC, bETX);
                txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\nReceived:\r\n";
            }
        }

        private void btn_MOVL_Click(object sender, EventArgs e)
        {
            try
            {
                Send_Process(Tx_Protocol,bSTX,bMOVL,bOPT,bDATA,bSYNC,bETX);
                txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Cmd: " + Encoding.UTF8.GetString(bMOVL) + "\r\nReceived:\r\n";
            }
            catch (Exception ex) { }
        }

        private void btn_GPOS_Click(object sender, EventArgs e)
        {
            try
            {
                Send_Process(Tx_Protocol, bSTX, bGPOS, bOPT, bDATA, bSYNC, bETX);
                txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Cmd: " + Encoding.UTF8.GetString(bGPOS) + "\r\nReceived:\r\n";
            }
            catch (Exception ex) { }
        }

        private void btn_GSTT_Click(object sender, EventArgs e)
        {
            try
            {
                Send_Process(Tx_Protocol, bSTX, bGSTT, bOPT, bDATA, bSYNC, bETX);
                txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Cmd: " + Encoding.UTF8.GetString(bGSTT) + "\r\nReceived:\r\n";
            }
            catch (Exception ex) { }
        }

        private void btn_GVEL_Click(object sender, EventArgs e)
        {
            try
            {
                Send_Process(Tx_Protocol, bSTX, bGVEL, bOPT, bDATA, bSYNC, bETX);
                txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Cmd: " + Encoding.UTF8.GetString(bGVEL) + "\r\nReceived:\r\n";
            }
            catch (Exception ex) { }
        }

        private void btn_Start_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Start_Stop_BTL1.Text == "Start")
                {
                    if (checkDigit(txtTime.Text) == true)
                    {
                        Send_Process(Tx_Protocol, bSTX, bMOVL, bOPT, bDATA, bSYNC, bETX);
                        txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Cmd: " + Encoding.UTF8.GetString(bMOVL) + "\r\nReceived:\r\n";
                        cnt = 2;
                        sum = 1;
                        lbTong.Text = sum.ToString();
                        timSerial.Interval = int.Parse(txtTime.Text);
                        timSerial.Enabled = true;
                        error = 0;
                        lbError.Text = error.ToString();
                        btn_Start_Stop_BTL1.Text = "Stop";
                        btn_Con_Dis.Enabled = false;
                        radio_Event.Enabled = false;
                        radio_Timer.Enabled = false;
                    }
                    else if (checkDigit(txtTime.Text) == false)
                    {
                        MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (btn_Start_Stop_BTL1.Text == "Stop")
                {
                    timSerial.Enabled = false;
                    btn_Con_Dis.Enabled = true;
                    btn_Start_Stop_BTL1.Text = "Start";
                    radio_Event.Enabled = true;
                    radio_Timer.Enabled = true;
                }
            }
            catch (Exception ex) { }
        }

        private void timControl_Tick(object sender, EventArgs e)
        {
            voltage = (double)ADC_value * 3300.0 / 4096.0;
            lux = voltage / (0.1 * 10);
            mean = (mean + lux) / 2;
            txtPV.Text = lux.ToString();
            txtMV.Text = mean.ToString();
            PlotChart_Lux((double)timControl.Interval * (double)time / 1000, lux);
            time++;
        }

        private void timSerial_Tick(object sender, EventArgs e)
        {
            try
            {
                if (cnt == 1)
                {
                    Send_Process(Tx_Protocol, bSTX, bMOVL, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Cmd: " + Encoding.UTF8.GetString(bMOVL) + "\r\nReceived:\r\n";
                    cnt++;
                }
                else if (cnt == 2)
                {
                    Send_Process(Tx_Protocol, bSTX, bGPOS, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Cmd: " + Encoding.UTF8.GetString(bGPOS) + "\r\nReceived:\r\n";
                    cnt++;
                }
                else if (cnt == 3)
                {
                    Send_Process(Tx_Protocol, bSTX, bGSTT, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Cmd: " + Encoding.UTF8.GetString(bGSTT) + "\r\nReceived:\r\n";
                    cnt++;
                }
                else if (cnt == 4)
                {
                    Send_Process(Tx_Protocol, bSTX, bGVEL, bOPT, bDATA, bSYNC, bETX);
                    txtSent_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Cmd: " + Encoding.UTF8.GetString(bGVEL) + "\r\nReceived:\r\n";
                    cnt = 1;
                }
                sum++;
                lbTong.Text = sum.ToString();
            }
            catch (Exception ex) { }
        }

        private void Send_Process(Byte[] pBuff, Byte[] pSTX, Byte[] pCommand, Byte[] pOpt, Byte[] pData, Byte[] pSYNC, Byte[] pETX)
        {
            try
            {
                Array.Clear(pBuff, 0, pBuff.Length);
                pSTX.CopyTo(pBuff, 0);
                pCommand.CopyTo(pBuff, 1);
                pOpt.CopyTo(pBuff, 5);
                pData.CopyTo(pBuff, 8);
                pSYNC.CopyTo(pBuff, 16);
                pETX.CopyTo(pBuff, 17);
                serialPort1.Write(pBuff, 0, 18);
            }
            catch(Exception ex) { }
        }

        private bool checkDigit(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txtSent_Received.Text = "";
        }

        private void ScrollToBottom(System.Windows.Forms.TextBox textBox)
        {
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
            textBox.HideSelection = false;
        }
    }
}