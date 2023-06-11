namespace SOFTWARE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtSent_Received = new System.Windows.Forms.TextBox();
            this.S_R = new System.Windows.Forms.GroupBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.Serial_Box = new System.Windows.Forms.GroupBox();
            this.btn_Con_Dis = new System.Windows.Forms.Button();
            this.cbox_Stopbits = new System.Windows.Forms.ComboBox();
            this.cbox_Parity = new System.Windows.Forms.ComboBox();
            this.cbox_DataBits = new System.Windows.Forms.ComboBox();
            this.cbox_Baud = new System.Windows.Forms.ComboBox();
            this.cbox_Port = new System.Windows.Forms.ComboBox();
            this.Stopp = new System.Windows.Forms.Label();
            this.Parityy = new System.Windows.Forms.Label();
            this.Data_sizee = new System.Windows.Forms.Label();
            this.Baudrate = new System.Windows.Forms.Label();
            this.Ports = new System.Windows.Forms.Label();
            this.grBox_BTL1 = new System.Windows.Forms.GroupBox();
            this.Lab = new System.Windows.Forms.Label();
            this.lbTong = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.Errorr = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.btn_GVEL = new System.Windows.Forms.Button();
            this.lbTime = new System.Windows.Forms.Label();
            this.btn_GPOS = new System.Windows.Forms.Button();
            this.btn_GSTT = new System.Windows.Forms.Button();
            this.btn_Start_Stop_BTL1 = new System.Windows.Forms.Button();
            this.radio_Timer = new System.Windows.Forms.RadioButton();
            this.btn_MOVL = new System.Windows.Forms.Button();
            this.radio_Event = new System.Windows.Forms.RadioButton();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timSerial = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grBox_DIGITAL = new System.Windows.Forms.GroupBox();
            this.checkBox_Button = new System.Windows.Forms.CheckBox();
            this.checkBox_Led = new System.Windows.Forms.CheckBox();
            this.checkBox_PWM = new System.Windows.Forms.CheckBox();
            this.checkBox_Sensor = new System.Windows.Forms.CheckBox();
            this.btn_Start_Stop_Sensor = new System.Windows.Forms.Button();
            this.lbPV = new System.Windows.Forms.Label();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.timControl = new System.Windows.Forms.Timer(this.components);
            this.grBox_SENSOR = new System.Windows.Forms.GroupBox();
            this.lbMV = new System.Windows.Forms.Label();
            this.txtMV = new System.Windows.Forms.TextBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.grBox_LED = new System.Windows.Forms.GroupBox();
            this.radio_Toggle = new System.Windows.Forms.RadioButton();
            this.radio_OffLed = new System.Windows.Forms.RadioButton();
            this.radio_OnLed = new System.Windows.Forms.RadioButton();
            this.grBox_ANALOG = new System.Windows.Forms.GroupBox();
            this.grBox_PWM = new System.Windows.Forms.GroupBox();
            this.numeric_Duty = new System.Windows.Forms.NumericUpDown();
            this.lbPercent = new System.Windows.Forms.Label();
            this.lbDuty = new System.Windows.Forms.Label();
            this.S_R.SuspendLayout();
            this.Serial_Box.SuspendLayout();
            this.grBox_BTL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.grBox_DIGITAL.SuspendLayout();
            this.grBox_SENSOR.SuspendLayout();
            this.grBox_LED.SuspendLayout();
            this.grBox_ANALOG.SuspendLayout();
            this.grBox_PWM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Duty)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSent_Received
            // 
            this.txtSent_Received.Location = new System.Drawing.Point(10, 28);
            this.txtSent_Received.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSent_Received.Multiline = true;
            this.txtSent_Received.Name = "txtSent_Received";
            this.txtSent_Received.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSent_Received.Size = new System.Drawing.Size(531, 487);
            this.txtSent_Received.TabIndex = 0;
            // 
            // S_R
            // 
            this.S_R.Controls.Add(this.btn_Clear);
            this.S_R.Controls.Add(this.txtSent_Received);
            this.S_R.Location = new System.Drawing.Point(12, 5);
            this.S_R.Name = "S_R";
            this.S_R.Size = new System.Drawing.Size(548, 569);
            this.S_R.TabIndex = 7;
            this.S_R.TabStop = false;
            this.S_R.Text = "Sent/Received";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(441, 522);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(101, 32);
            this.btn_Clear.TabIndex = 11;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // Serial_Box
            // 
            this.Serial_Box.Controls.Add(this.btn_Con_Dis);
            this.Serial_Box.Controls.Add(this.cbox_Stopbits);
            this.Serial_Box.Controls.Add(this.cbox_Parity);
            this.Serial_Box.Controls.Add(this.cbox_DataBits);
            this.Serial_Box.Controls.Add(this.cbox_Baud);
            this.Serial_Box.Controls.Add(this.cbox_Port);
            this.Serial_Box.Controls.Add(this.Stopp);
            this.Serial_Box.Controls.Add(this.Parityy);
            this.Serial_Box.Controls.Add(this.Data_sizee);
            this.Serial_Box.Controls.Add(this.Baudrate);
            this.Serial_Box.Controls.Add(this.Ports);
            this.Serial_Box.Location = new System.Drawing.Point(566, 5);
            this.Serial_Box.Name = "Serial_Box";
            this.Serial_Box.Size = new System.Drawing.Size(228, 296);
            this.Serial_Box.TabIndex = 8;
            this.Serial_Box.TabStop = false;
            this.Serial_Box.Text = "Serial";
            // 
            // btn_Con_Dis
            // 
            this.btn_Con_Dis.Location = new System.Drawing.Point(39, 242);
            this.btn_Con_Dis.Name = "btn_Con_Dis";
            this.btn_Con_Dis.Size = new System.Drawing.Size(149, 33);
            this.btn_Con_Dis.TabIndex = 10;
            this.btn_Con_Dis.Text = "Connect";
            this.btn_Con_Dis.UseVisualStyleBackColor = true;
            this.btn_Con_Dis.Click += new System.EventHandler(this.btn_Con_Dis_Click);
            // 
            // cbox_Stopbits
            // 
            this.cbox_Stopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Stopbits.FormattingEnabled = true;
            this.cbox_Stopbits.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.cbox_Stopbits.Location = new System.Drawing.Point(104, 190);
            this.cbox_Stopbits.Name = "cbox_Stopbits";
            this.cbox_Stopbits.Size = new System.Drawing.Size(105, 33);
            this.cbox_Stopbits.TabIndex = 9;
            // 
            // cbox_Parity
            // 
            this.cbox_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Parity.FormattingEnabled = true;
            this.cbox_Parity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark"});
            this.cbox_Parity.Location = new System.Drawing.Point(104, 151);
            this.cbox_Parity.Name = "cbox_Parity";
            this.cbox_Parity.Size = new System.Drawing.Size(105, 33);
            this.cbox_Parity.TabIndex = 8;
            // 
            // cbox_DataBits
            // 
            this.cbox_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_DataBits.FormattingEnabled = true;
            this.cbox_DataBits.Items.AddRange(new object[] {
            "7",
            "8"});
            this.cbox_DataBits.Location = new System.Drawing.Point(104, 112);
            this.cbox_DataBits.Name = "cbox_DataBits";
            this.cbox_DataBits.Size = new System.Drawing.Size(105, 33);
            this.cbox_DataBits.TabIndex = 7;
            // 
            // cbox_Baud
            // 
            this.cbox_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Baud.FormattingEnabled = true;
            this.cbox_Baud.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.cbox_Baud.Location = new System.Drawing.Point(104, 73);
            this.cbox_Baud.Name = "cbox_Baud";
            this.cbox_Baud.Size = new System.Drawing.Size(105, 33);
            this.cbox_Baud.TabIndex = 6;
            // 
            // cbox_Port
            // 
            this.cbox_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Port.FormattingEnabled = true;
            this.cbox_Port.Location = new System.Drawing.Point(104, 34);
            this.cbox_Port.Name = "cbox_Port";
            this.cbox_Port.Size = new System.Drawing.Size(105, 33);
            this.cbox_Port.TabIndex = 5;
            // 
            // Stopp
            // 
            this.Stopp.AutoSize = true;
            this.Stopp.Location = new System.Drawing.Point(18, 193);
            this.Stopp.Name = "Stopp";
            this.Stopp.Size = new System.Drawing.Size(87, 25);
            this.Stopp.TabIndex = 4;
            this.Stopp.Text = "StopBits";
            // 
            // Parityy
            // 
            this.Parityy.AutoSize = true;
            this.Parityy.Location = new System.Drawing.Point(18, 154);
            this.Parityy.Name = "Parityy";
            this.Parityy.Size = new System.Drawing.Size(64, 25);
            this.Parityy.TabIndex = 3;
            this.Parityy.Text = "Parity";
            // 
            // Data_sizee
            // 
            this.Data_sizee.AutoSize = true;
            this.Data_sizee.Location = new System.Drawing.Point(18, 115);
            this.Data_sizee.Name = "Data_sizee";
            this.Data_sizee.Size = new System.Drawing.Size(89, 25);
            this.Data_sizee.TabIndex = 2;
            this.Data_sizee.Text = "DataBits";
            // 
            // Baudrate
            // 
            this.Baudrate.AutoSize = true;
            this.Baudrate.Location = new System.Drawing.Point(18, 76);
            this.Baudrate.Name = "Baudrate";
            this.Baudrate.Size = new System.Drawing.Size(58, 25);
            this.Baudrate.TabIndex = 1;
            this.Baudrate.Text = "Baud";
            // 
            // Ports
            // 
            this.Ports.AutoSize = true;
            this.Ports.Location = new System.Drawing.Point(18, 37);
            this.Ports.Name = "Ports";
            this.Ports.Size = new System.Drawing.Size(48, 25);
            this.Ports.TabIndex = 0;
            this.Ports.Text = "Port";
            // 
            // grBox_BTL1
            // 
            this.grBox_BTL1.Controls.Add(this.Lab);
            this.grBox_BTL1.Controls.Add(this.lbTong);
            this.grBox_BTL1.Controls.Add(this.lbError);
            this.grBox_BTL1.Controls.Add(this.Errorr);
            this.grBox_BTL1.Controls.Add(this.txtTime);
            this.grBox_BTL1.Controls.Add(this.btn_GVEL);
            this.grBox_BTL1.Controls.Add(this.lbTime);
            this.grBox_BTL1.Controls.Add(this.btn_GPOS);
            this.grBox_BTL1.Controls.Add(this.btn_GSTT);
            this.grBox_BTL1.Controls.Add(this.btn_Start_Stop_BTL1);
            this.grBox_BTL1.Controls.Add(this.radio_Timer);
            this.grBox_BTL1.Controls.Add(this.btn_MOVL);
            this.grBox_BTL1.Controls.Add(this.radio_Event);
            this.grBox_BTL1.Location = new System.Drawing.Point(566, 309);
            this.grBox_BTL1.Name = "grBox_BTL1";
            this.grBox_BTL1.Size = new System.Drawing.Size(228, 265);
            this.grBox_BTL1.TabIndex = 9;
            this.grBox_BTL1.TabStop = false;
            this.grBox_BTL1.Text = "BTL_1";
            // 
            // Lab
            // 
            this.Lab.AutoSize = true;
            this.Lab.Location = new System.Drawing.Point(155, 111);
            this.Lab.Name = "Lab";
            this.Lab.Size = new System.Drawing.Size(18, 25);
            this.Lab.TabIndex = 18;
            this.Lab.Text = "/";
            this.Lab.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbTong
            // 
            this.lbTong.AutoSize = true;
            this.lbTong.Location = new System.Drawing.Point(179, 111);
            this.lbTong.Name = "lbTong";
            this.lbTong.Size = new System.Drawing.Size(23, 25);
            this.lbTong.TabIndex = 17;
            this.lbTong.Text = "0";
            this.lbTong.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.Location = new System.Drawing.Point(126, 111);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(23, 25);
            this.lbError.TabIndex = 16;
            this.lbError.Text = "0";
            // 
            // Errorr
            // 
            this.Errorr.AutoSize = true;
            this.Errorr.Location = new System.Drawing.Point(18, 111);
            this.Errorr.Name = "Errorr";
            this.Errorr.Size = new System.Drawing.Size(57, 25);
            this.Errorr.TabIndex = 15;
            this.Errorr.Text = "Error";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(121, 69);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(88, 33);
            this.txtTime.TabIndex = 12;
            // 
            // btn_GVEL
            // 
            this.btn_GVEL.Enabled = false;
            this.btn_GVEL.Location = new System.Drawing.Point(125, 217);
            this.btn_GVEL.Name = "btn_GVEL";
            this.btn_GVEL.Size = new System.Drawing.Size(97, 33);
            this.btn_GVEL.TabIndex = 16;
            this.btn_GVEL.Text = "GVEL";
            this.btn_GVEL.UseVisualStyleBackColor = true;
            this.btn_GVEL.Click += new System.EventHandler(this.btn_GVEL_Click);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(18, 72);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(102, 25);
            this.lbTime.TabIndex = 11;
            this.lbTime.Text = "Time (ms)";
            // 
            // btn_GPOS
            // 
            this.btn_GPOS.Enabled = false;
            this.btn_GPOS.Location = new System.Drawing.Point(125, 178);
            this.btn_GPOS.Name = "btn_GPOS";
            this.btn_GPOS.Size = new System.Drawing.Size(97, 33);
            this.btn_GPOS.TabIndex = 14;
            this.btn_GPOS.Text = "GPOS";
            this.btn_GPOS.UseVisualStyleBackColor = true;
            this.btn_GPOS.Click += new System.EventHandler(this.btn_GPOS_Click);
            // 
            // btn_GSTT
            // 
            this.btn_GSTT.Enabled = false;
            this.btn_GSTT.Location = new System.Drawing.Point(6, 218);
            this.btn_GSTT.Name = "btn_GSTT";
            this.btn_GSTT.Size = new System.Drawing.Size(102, 33);
            this.btn_GSTT.TabIndex = 15;
            this.btn_GSTT.Text = "GSTT";
            this.btn_GSTT.UseVisualStyleBackColor = true;
            this.btn_GSTT.Click += new System.EventHandler(this.btn_GSTT_Click);
            // 
            // btn_Start_Stop_BTL1
            // 
            this.btn_Start_Stop_BTL1.Location = new System.Drawing.Point(39, 139);
            this.btn_Start_Stop_BTL1.Name = "btn_Start_Stop_BTL1";
            this.btn_Start_Stop_BTL1.Size = new System.Drawing.Size(149, 33);
            this.btn_Start_Stop_BTL1.TabIndex = 11;
            this.btn_Start_Stop_BTL1.Text = "Start";
            this.btn_Start_Stop_BTL1.UseVisualStyleBackColor = true;
            this.btn_Start_Stop_BTL1.Click += new System.EventHandler(this.btn_Start_Stop_Click);
            // 
            // radio_Timer
            // 
            this.radio_Timer.AutoSize = true;
            this.radio_Timer.Location = new System.Drawing.Point(131, 32);
            this.radio_Timer.Name = "radio_Timer";
            this.radio_Timer.Size = new System.Drawing.Size(85, 29);
            this.radio_Timer.TabIndex = 1;
            this.radio_Timer.TabStop = true;
            this.radio_Timer.Text = "Timer";
            this.radio_Timer.UseVisualStyleBackColor = true;
            this.radio_Timer.CheckedChanged += new System.EventHandler(this.radio_Timer_CheckedChanged);
            // 
            // btn_MOVL
            // 
            this.btn_MOVL.Enabled = false;
            this.btn_MOVL.Location = new System.Drawing.Point(6, 179);
            this.btn_MOVL.Name = "btn_MOVL";
            this.btn_MOVL.Size = new System.Drawing.Size(102, 33);
            this.btn_MOVL.TabIndex = 13;
            this.btn_MOVL.Text = "MOVL";
            this.btn_MOVL.UseVisualStyleBackColor = true;
            this.btn_MOVL.Click += new System.EventHandler(this.btn_MOVL_Click);
            // 
            // radio_Event
            // 
            this.radio_Event.AutoSize = true;
            this.radio_Event.Location = new System.Drawing.Point(23, 32);
            this.radio_Event.Name = "radio_Event";
            this.radio_Event.Size = new System.Drawing.Size(83, 29);
            this.radio_Event.TabIndex = 0;
            this.radio_Event.TabStop = true;
            this.radio_Event.Text = "Event";
            this.radio_Event.UseVisualStyleBackColor = true;
            this.radio_Event.CheckedChanged += new System.EventHandler(this.radio_Event_CheckedChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.ReadTimeout = 1000;
            this.serialPort1.WriteTimeout = 1000;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timSerial
            // 
            this.timSerial.Tick += new System.EventHandler(this.timSerial_Tick);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(800, 229);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Mean (lx)";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Light Sensor (lx)";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(519, 345);
            this.chart1.TabIndex = 21;
            this.chart1.Text = "chart1";
            // 
            // grBox_DIGITAL
            // 
            this.grBox_DIGITAL.Controls.Add(this.checkBox_Button);
            this.grBox_DIGITAL.Controls.Add(this.checkBox_Led);
            this.grBox_DIGITAL.Location = new System.Drawing.Point(800, 5);
            this.grBox_DIGITAL.Name = "grBox_DIGITAL";
            this.grBox_DIGITAL.Size = new System.Drawing.Size(123, 106);
            this.grBox_DIGITAL.TabIndex = 22;
            this.grBox_DIGITAL.TabStop = false;
            this.grBox_DIGITAL.Text = "DIGITAL";
            // 
            // checkBox_Button
            // 
            this.checkBox_Button.AutoSize = true;
            this.checkBox_Button.Location = new System.Drawing.Point(6, 70);
            this.checkBox_Button.Name = "checkBox_Button";
            this.checkBox_Button.Size = new System.Drawing.Size(123, 29);
            this.checkBox_Button.TabIndex = 1;
            this.checkBox_Button.Text = "BUTTON";
            this.checkBox_Button.UseVisualStyleBackColor = true;
            this.checkBox_Button.CheckedChanged += new System.EventHandler(this.checkBox_Button_CheckedChanged);
            // 
            // checkBox_Led
            // 
            this.checkBox_Led.AutoSize = true;
            this.checkBox_Led.Location = new System.Drawing.Point(6, 35);
            this.checkBox_Led.Name = "checkBox_Led";
            this.checkBox_Led.Size = new System.Drawing.Size(75, 29);
            this.checkBox_Led.TabIndex = 0;
            this.checkBox_Led.Text = "LED";
            this.checkBox_Led.UseVisualStyleBackColor = true;
            this.checkBox_Led.CheckedChanged += new System.EventHandler(this.checkBox_Led_CheckedChanged);
            // 
            // checkBox_PWM
            // 
            this.checkBox_PWM.AutoSize = true;
            this.checkBox_PWM.Location = new System.Drawing.Point(6, 70);
            this.checkBox_PWM.Name = "checkBox_PWM";
            this.checkBox_PWM.Size = new System.Drawing.Size(85, 29);
            this.checkBox_PWM.TabIndex = 3;
            this.checkBox_PWM.Text = "PWM";
            this.checkBox_PWM.UseVisualStyleBackColor = true;
            this.checkBox_PWM.CheckedChanged += new System.EventHandler(this.checkBox_PWM_CheckedChanged);
            // 
            // checkBox_Sensor
            // 
            this.checkBox_Sensor.AutoSize = true;
            this.checkBox_Sensor.Location = new System.Drawing.Point(6, 35);
            this.checkBox_Sensor.Name = "checkBox_Sensor";
            this.checkBox_Sensor.Size = new System.Drawing.Size(117, 29);
            this.checkBox_Sensor.TabIndex = 2;
            this.checkBox_Sensor.Text = "SENSOR";
            this.checkBox_Sensor.UseVisualStyleBackColor = true;
            this.checkBox_Sensor.CheckedChanged += new System.EventHandler(this.checkBox_Sensor_CheckedChanged);
            // 
            // btn_Start_Stop_Sensor
            // 
            this.btn_Start_Stop_Sensor.Location = new System.Drawing.Point(120, 109);
            this.btn_Start_Stop_Sensor.Name = "btn_Start_Stop_Sensor";
            this.btn_Start_Stop_Sensor.Size = new System.Drawing.Size(63, 33);
            this.btn_Start_Stop_Sensor.TabIndex = 11;
            this.btn_Start_Stop_Sensor.Text = "Start";
            this.btn_Start_Stop_Sensor.UseVisualStyleBackColor = true;
            this.btn_Start_Stop_Sensor.Click += new System.EventHandler(this.btn_Start_Stop_Sensor_Click);
            // 
            // lbPV
            // 
            this.lbPV.AutoSize = true;
            this.lbPV.Location = new System.Drawing.Point(6, 37);
            this.lbPV.Name = "lbPV";
            this.lbPV.Size = new System.Drawing.Size(136, 25);
            this.lbPV.TabIndex = 23;
            this.lbPV.Text = "Process Value";
            // 
            // txtPV
            // 
            this.txtPV.Location = new System.Drawing.Point(120, 34);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(138, 33);
            this.txtPV.TabIndex = 22;
            // 
            // timControl
            // 
            this.timControl.Tick += new System.EventHandler(this.timControl_Tick);
            // 
            // grBox_SENSOR
            // 
            this.grBox_SENSOR.Controls.Add(this.lbMV);
            this.grBox_SENSOR.Controls.Add(this.txtMV);
            this.grBox_SENSOR.Controls.Add(this.btn_Reset);
            this.grBox_SENSOR.Controls.Add(this.txtPV);
            this.grBox_SENSOR.Controls.Add(this.lbPV);
            this.grBox_SENSOR.Controls.Add(this.btn_Start_Stop_Sensor);
            this.grBox_SENSOR.Location = new System.Drawing.Point(1048, 5);
            this.grBox_SENSOR.Name = "grBox_SENSOR";
            this.grBox_SENSOR.Size = new System.Drawing.Size(271, 145);
            this.grBox_SENSOR.TabIndex = 23;
            this.grBox_SENSOR.TabStop = false;
            this.grBox_SENSOR.Text = "SENSOR";
            // 
            // lbMV
            // 
            this.lbMV.AutoSize = true;
            this.lbMV.Location = new System.Drawing.Point(6, 76);
            this.lbMV.Name = "lbMV";
            this.lbMV.Size = new System.Drawing.Size(117, 25);
            this.lbMV.TabIndex = 26;
            this.lbMV.Text = "Mean Value";
            // 
            // txtMV
            // 
            this.txtMV.Location = new System.Drawing.Point(120, 73);
            this.txtMV.Name = "txtMV";
            this.txtMV.Size = new System.Drawing.Size(138, 33);
            this.txtMV.TabIndex = 25;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(189, 109);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(69, 33);
            this.btn_Reset.TabIndex = 24;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // grBox_LED
            // 
            this.grBox_LED.Controls.Add(this.radio_Toggle);
            this.grBox_LED.Controls.Add(this.radio_OffLed);
            this.grBox_LED.Controls.Add(this.radio_OnLed);
            this.grBox_LED.Location = new System.Drawing.Point(929, 5);
            this.grBox_LED.Name = "grBox_LED";
            this.grBox_LED.Size = new System.Drawing.Size(113, 145);
            this.grBox_LED.TabIndex = 24;
            this.grBox_LED.TabStop = false;
            this.grBox_LED.Text = "LED";
            // 
            // radio_Toggle
            // 
            this.radio_Toggle.AutoSize = true;
            this.radio_Toggle.Location = new System.Drawing.Point(13, 105);
            this.radio_Toggle.Name = "radio_Toggle";
            this.radio_Toggle.Size = new System.Drawing.Size(92, 29);
            this.radio_Toggle.TabIndex = 2;
            this.radio_Toggle.TabStop = true;
            this.radio_Toggle.Text = "Toggle";
            this.radio_Toggle.UseVisualStyleBackColor = true;
            this.radio_Toggle.CheckedChanged += new System.EventHandler(this.radio_Toggle_CheckedChanged);
            // 
            // radio_OffLed
            // 
            this.radio_OffLed.AutoSize = true;
            this.radio_OffLed.Location = new System.Drawing.Point(13, 70);
            this.radio_OffLed.Name = "radio_OffLed";
            this.radio_OffLed.Size = new System.Drawing.Size(63, 29);
            this.radio_OffLed.TabIndex = 1;
            this.radio_OffLed.TabStop = true;
            this.radio_OffLed.Text = "Off";
            this.radio_OffLed.UseVisualStyleBackColor = true;
            this.radio_OffLed.CheckedChanged += new System.EventHandler(this.radio_OffLed_CheckedChanged);
            // 
            // radio_OnLed
            // 
            this.radio_OnLed.AutoSize = true;
            this.radio_OnLed.Location = new System.Drawing.Point(13, 35);
            this.radio_OnLed.Name = "radio_OnLed";
            this.radio_OnLed.Size = new System.Drawing.Size(59, 29);
            this.radio_OnLed.TabIndex = 0;
            this.radio_OnLed.TabStop = true;
            this.radio_OnLed.Text = "On";
            this.radio_OnLed.UseVisualStyleBackColor = true;
            this.radio_OnLed.CheckedChanged += new System.EventHandler(this.radio_OnLed_CheckedChanged);
            // 
            // grBox_ANALOG
            // 
            this.grBox_ANALOG.Controls.Add(this.checkBox_PWM);
            this.grBox_ANALOG.Controls.Add(this.checkBox_Sensor);
            this.grBox_ANALOG.Location = new System.Drawing.Point(800, 117);
            this.grBox_ANALOG.Name = "grBox_ANALOG";
            this.grBox_ANALOG.Size = new System.Drawing.Size(123, 106);
            this.grBox_ANALOG.TabIndex = 23;
            this.grBox_ANALOG.TabStop = false;
            this.grBox_ANALOG.Text = "ANALOG";
            // 
            // grBox_PWM
            // 
            this.grBox_PWM.Controls.Add(this.numeric_Duty);
            this.grBox_PWM.Controls.Add(this.lbPercent);
            this.grBox_PWM.Controls.Add(this.lbDuty);
            this.grBox_PWM.Location = new System.Drawing.Point(929, 156);
            this.grBox_PWM.Name = "grBox_PWM";
            this.grBox_PWM.Size = new System.Drawing.Size(390, 67);
            this.grBox_PWM.TabIndex = 27;
            this.grBox_PWM.TabStop = false;
            this.grBox_PWM.Text = "PWM";
            // 
            // numeric_Duty
            // 
            this.numeric_Duty.Location = new System.Drawing.Point(172, 27);
            this.numeric_Duty.Name = "numeric_Duty";
            this.numeric_Duty.Size = new System.Drawing.Size(100, 33);
            this.numeric_Duty.TabIndex = 28;
            this.numeric_Duty.ValueChanged += new System.EventHandler(this.numeric_Duty_ValueChanged);
            // 
            // lbPercent
            // 
            this.lbPercent.AutoSize = true;
            this.lbPercent.Location = new System.Drawing.Point(313, 32);
            this.lbPercent.Name = "lbPercent";
            this.lbPercent.Size = new System.Drawing.Size(30, 25);
            this.lbPercent.TabIndex = 24;
            this.lbPercent.Text = "%";
            // 
            // lbDuty
            // 
            this.lbDuty.AutoSize = true;
            this.lbDuty.Location = new System.Drawing.Point(32, 31);
            this.lbDuty.Name = "lbDuty";
            this.lbDuty.Size = new System.Drawing.Size(114, 25);
            this.lbDuty.TabIndex = 23;
            this.lbDuty.Text = "Duty Cycle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 590);
            this.Controls.Add(this.grBox_PWM);
            this.Controls.Add(this.grBox_ANALOG);
            this.Controls.Add(this.grBox_LED);
            this.Controls.Add(this.grBox_SENSOR);
            this.Controls.Add(this.grBox_DIGITAL);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.grBox_BTL1);
            this.Controls.Add(this.Serial_Box);
            this.Controls.Add(this.S_R);
            this.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "BTL_DLMT_HuynhTuankiet_2010364";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.S_R.ResumeLayout(false);
            this.S_R.PerformLayout();
            this.Serial_Box.ResumeLayout(false);
            this.Serial_Box.PerformLayout();
            this.grBox_BTL1.ResumeLayout(false);
            this.grBox_BTL1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.grBox_DIGITAL.ResumeLayout(false);
            this.grBox_DIGITAL.PerformLayout();
            this.grBox_SENSOR.ResumeLayout(false);
            this.grBox_SENSOR.PerformLayout();
            this.grBox_LED.ResumeLayout(false);
            this.grBox_LED.PerformLayout();
            this.grBox_ANALOG.ResumeLayout(false);
            this.grBox_ANALOG.PerformLayout();
            this.grBox_PWM.ResumeLayout(false);
            this.grBox_PWM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Duty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSent_Received;
        private System.Windows.Forms.GroupBox S_R;
        private System.Windows.Forms.GroupBox Serial_Box;
        private System.Windows.Forms.Label Stopp;
        private System.Windows.Forms.Label Parityy;
        private System.Windows.Forms.Label Data_sizee;
        private System.Windows.Forms.Label Baudrate;
        private System.Windows.Forms.Label Ports;
        private System.Windows.Forms.Button btn_Con_Dis;
        private System.Windows.Forms.ComboBox cbox_Stopbits;
        private System.Windows.Forms.ComboBox cbox_Parity;
        private System.Windows.Forms.ComboBox cbox_DataBits;
        private System.Windows.Forms.ComboBox cbox_Baud;
        private System.Windows.Forms.ComboBox cbox_Port;
        private System.Windows.Forms.GroupBox grBox_BTL1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button btn_Start_Stop_BTL1;
        private System.Windows.Forms.RadioButton radio_Timer;
        private System.Windows.Forms.RadioButton radio_Event;
        private System.Windows.Forms.Label Errorr;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timSerial;
        private System.Windows.Forms.Button btn_MOVL;
        private System.Windows.Forms.Button btn_GPOS;
        private System.Windows.Forms.Button btn_GSTT;
        private System.Windows.Forms.Button btn_GVEL;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Label lbTong;
        private System.Windows.Forms.Label Lab;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox grBox_DIGITAL;
        private System.Windows.Forms.Label lbPV;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.Button btn_Start_Stop_Sensor;
        private System.Windows.Forms.Timer timControl;
        private System.Windows.Forms.GroupBox grBox_SENSOR;
        private System.Windows.Forms.CheckBox checkBox_PWM;
        private System.Windows.Forms.CheckBox checkBox_Sensor;
        private System.Windows.Forms.CheckBox checkBox_Button;
        private System.Windows.Forms.CheckBox checkBox_Led;
        private System.Windows.Forms.GroupBox grBox_LED;
        private System.Windows.Forms.RadioButton radio_OffLed;
        private System.Windows.Forms.RadioButton radio_OnLed;
        private System.Windows.Forms.RadioButton radio_Toggle;
        private System.Windows.Forms.GroupBox grBox_ANALOG;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.TextBox txtMV;
        private System.Windows.Forms.Label lbMV;
        private System.Windows.Forms.GroupBox grBox_PWM;
        private System.Windows.Forms.Label lbPercent;
        private System.Windows.Forms.Label lbDuty;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.NumericUpDown numeric_Duty;
    }
}

