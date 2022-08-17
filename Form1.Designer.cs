namespace Read_Modbus_UsbCDC_stm32G4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_read_ONE = new System.Windows.Forms.Button();
            this.serialPort_MB = new System.IO.Ports.SerialPort(this.components);
            this.label_out = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox_BaudRate = new System.Windows.Forms.ListBox();
            this.label_baudrate = new System.Windows.Forms.Label();
            this.button_on_gen_scan = new System.Windows.Forms.Button();
            this.listBox_ComPort = new System.Windows.Forms.ListBox();
            this.label_ComPort = new System.Windows.Forms.Label();
            this.listBox_answer_one = new System.Windows.Forms.ListBox();
            this.textBox_Fstart = new System.Windows.Forms.TextBox();
            this.label_Fstart = new System.Windows.Forms.Label();
            this.label_step = new System.Windows.Forms.Label();
            this.textBox_Step = new System.Windows.Forms.TextBox();
            this.label_NumPoint = new System.Windows.Forms.Label();
            this.textBox_NumPoint = new System.Windows.Forms.TextBox();
            this.label_Power = new System.Windows.Forms.Label();
            this.textBox_Power = new System.Windows.Forms.TextBox();
            this.textBox_Tstep = new System.Windows.Forms.TextBox();
            this.label_Tstep = new System.Windows.Forms.Label();
            this.label_Fend = new System.Windows.Forms.Label();
            this.checkBox_ON_gen = new System.Windows.Forms.CheckBox();
            this.checkBox_Tx_Data_cicle = new System.Windows.Forms.CheckBox();
            this.checkBox_ON_scan = new System.Windows.Forms.CheckBox();
            this.button_cicle_read = new System.Windows.Forms.Button();
            this.label_chart1 = new System.Windows.Forms.Label();
            this.label_chart6 = new System.Windows.Forms.Label();
            this.label_chart2 = new System.Windows.Forms.Label();
            this.label_chart3 = new System.Windows.Forms.Label();
            this.label_chart4 = new System.Windows.Forms.Label();
            this.label_chart5 = new System.Windows.Forms.Label();
            this.numericUpDown_mouse = new System.Windows.Forms.NumericUpDown();
            this.label_message = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button_open = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mouse)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(105, 74);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 121);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.numeric_insert_List_Box_all);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numeric_insert_List_Box_all);
            // 
            // button_read_ONE
            // 
            this.button_read_ONE.Location = new System.Drawing.Point(12, 19);
            this.button_read_ONE.Name = "button_read_ONE";
            this.button_read_ONE.Size = new System.Drawing.Size(75, 23);
            this.button_read_ONE.TabIndex = 1;
            this.button_read_ONE.Text = "read_1";
            this.button_read_ONE.UseVisualStyleBackColor = true;
            this.button_read_ONE.Click += new System.EventHandler(this.button_read_ONE_Click);
            // 
            // serialPort_MB
            // 
            this.serialPort_MB.BaudRate = 921600;
            this.serialPort_MB.PortName = "COM8";
            // 
            // label_out
            // 
            this.label_out.AutoSize = true;
            this.label_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_out.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_out.Location = new System.Drawing.Point(769, 37);
            this.label_out.Name = "label_out";
            this.label_out.Size = new System.Drawing.Size(83, 29);
            this.label_out.TabIndex = 2;
            this.label_out.Text = "25000";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(105, 201);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 121);
            this.listBox2.TabIndex = 3;
            this.listBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numeric_insert_List_Box_all);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(105, 328);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 121);
            this.listBox3.TabIndex = 4;
            this.listBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numeric_insert_List_Box_all);
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(105, 455);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(120, 121);
            this.listBox4.TabIndex = 5;
            this.listBox4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numeric_insert_List_Box_all);
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.Location = new System.Drawing.Point(105, 582);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(120, 121);
            this.listBox5.TabIndex = 6;
            this.listBox5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numeric_insert_List_Box_all);
            // 
            // listBox6
            // 
            this.listBox6.FormattingEnabled = true;
            this.listBox6.Location = new System.Drawing.Point(105, 709);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(120, 121);
            this.listBox6.TabIndex = 7;
            this.listBox6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numeric_insert_List_Box_all);
            // 
            // chart1
            // 
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 100F;
            chartArea1.InnerPlotPosition.Width = 100F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 15F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 1F;
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 100F;
            chartArea2.InnerPlotPosition.Width = 100F;
            chartArea2.Name = "ChartArea2";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 15F;
            chartArea2.Position.Width = 100F;
            chartArea2.Position.Y = 17F;
            chartArea3.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea3.InnerPlotPosition.Auto = false;
            chartArea3.InnerPlotPosition.Height = 100F;
            chartArea3.InnerPlotPosition.Width = 100F;
            chartArea3.Name = "ChartArea3";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 15F;
            chartArea3.Position.Width = 100F;
            chartArea3.Position.Y = 33F;
            chartArea4.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea4.InnerPlotPosition.Auto = false;
            chartArea4.InnerPlotPosition.Height = 100F;
            chartArea4.InnerPlotPosition.Width = 100F;
            chartArea4.Name = "ChartArea4";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 15F;
            chartArea4.Position.Width = 100F;
            chartArea4.Position.Y = 49F;
            chartArea5.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea5.InnerPlotPosition.Auto = false;
            chartArea5.InnerPlotPosition.Height = 100F;
            chartArea5.InnerPlotPosition.Width = 100F;
            chartArea5.Name = "ChartArea5";
            chartArea5.Position.Auto = false;
            chartArea5.Position.Height = 15F;
            chartArea5.Position.Width = 100F;
            chartArea5.Position.Y = 65F;
            chartArea6.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea6.InnerPlotPosition.Auto = false;
            chartArea6.InnerPlotPosition.Height = 100F;
            chartArea6.InnerPlotPosition.Width = 100F;
            chartArea6.Name = "ChartArea6";
            chartArea6.Position.Auto = false;
            chartArea6.Position.Height = 15F;
            chartArea6.Position.Width = 100F;
            chartArea6.Position.Y = 81F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.ChartAreas.Add(chartArea6);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(230, 74);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.LabelBorderWidth = 2;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series2.LabelBorderWidth = 2;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea3";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Blue;
            series3.LabelBorderWidth = 2;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea4";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series4.LabelBorderWidth = 2;
            series4.Legend = "Legend1";
            series4.Name = "Series4";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea5";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Olive;
            series5.LabelBorderWidth = 2;
            series5.Legend = "Legend1";
            series5.Name = "Series5";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea6";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series6.LabelBorderWidth = 2;
            series6.Legend = "Legend1";
            series6.Name = "Series6";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(1600, 756);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.prorisovka_line_mouse_code);
            // 
            // listBox_BaudRate
            // 
            this.listBox_BaudRate.FormattingEnabled = true;
            this.listBox_BaudRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.listBox_BaudRate.Location = new System.Drawing.Point(12, 58);
            this.listBox_BaudRate.Name = "listBox_BaudRate";
            this.listBox_BaudRate.Size = new System.Drawing.Size(68, 121);
            this.listBox_BaudRate.TabIndex = 9;
            this.listBox_BaudRate.SelectedValueChanged += new System.EventHandler(this.listBox_BaudRate_SelectedValueChanged);
            // 
            // label_baudrate
            // 
            this.label_baudrate.AutoSize = true;
            this.label_baudrate.Location = new System.Drawing.Point(13, 43);
            this.label_baudrate.Name = "label_baudrate";
            this.label_baudrate.Size = new System.Drawing.Size(77, 13);
            this.label_baudrate.TabIndex = 10;
            this.label_baudrate.Text = "label_baudrate";
            // 
            // button_on_gen_scan
            // 
            this.button_on_gen_scan.Location = new System.Drawing.Point(529, 37);
            this.button_on_gen_scan.Name = "button_on_gen_scan";
            this.button_on_gen_scan.Size = new System.Drawing.Size(100, 23);
            this.button_on_gen_scan.TabIndex = 11;
            this.button_on_gen_scan.Text = "ON_gen_scan";
            this.button_on_gen_scan.UseVisualStyleBackColor = true;
            this.button_on_gen_scan.Click += new System.EventHandler(this.button_on_gen_scan_Click);
            // 
            // listBox_ComPort
            // 
            this.listBox_ComPort.FormattingEnabled = true;
            this.listBox_ComPort.Location = new System.Drawing.Point(13, 197);
            this.listBox_ComPort.Name = "listBox_ComPort";
            this.listBox_ComPort.Size = new System.Drawing.Size(55, 69);
            this.listBox_ComPort.TabIndex = 12;
            this.listBox_ComPort.SelectedValueChanged += new System.EventHandler(this.listBox_ComPort_SelectedValueChanged);
            this.listBox_ComPort.MouseEnter += new System.EventHandler(this.listBox_ComPort_MouseEnter);
            // 
            // label_ComPort
            // 
            this.label_ComPort.AutoSize = true;
            this.label_ComPort.Location = new System.Drawing.Point(12, 181);
            this.label_ComPort.Name = "label_ComPort";
            this.label_ComPort.Size = new System.Drawing.Size(35, 13);
            this.label_ComPort.TabIndex = 13;
            this.label_ComPort.Text = "label1";
            // 
            // listBox_answer_one
            // 
            this.listBox_answer_one.FormattingEnabled = true;
            this.listBox_answer_one.Items.AddRange(new object[] {
            "111",
            "222",
            "333",
            "444",
            "555",
            "666",
            "777",
            "888"});
            this.listBox_answer_one.Location = new System.Drawing.Point(12, 284);
            this.listBox_answer_one.Name = "listBox_answer_one";
            this.listBox_answer_one.Size = new System.Drawing.Size(68, 238);
            this.listBox_answer_one.TabIndex = 14;
            // 
            // textBox_Fstart
            // 
            this.textBox_Fstart.Location = new System.Drawing.Point(366, 6);
            this.textBox_Fstart.Name = "textBox_Fstart";
            this.textBox_Fstart.Size = new System.Drawing.Size(44, 20);
            this.textBox_Fstart.TabIndex = 15;
            this.textBox_Fstart.Text = "25000";
            this.textBox_Fstart.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_Fstart_KeyUp);
            this.textBox_Fstart.Leave += new System.EventHandler(this.textBox_Fstart_Leave);
            // 
            // label_Fstart
            // 
            this.label_Fstart.AutoSize = true;
            this.label_Fstart.Location = new System.Drawing.Point(324, 10);
            this.label_Fstart.Name = "label_Fstart";
            this.label_Fstart.Size = new System.Drawing.Size(42, 13);
            this.label_Fstart.TabIndex = 16;
            this.label_Fstart.Text = "Fstart =";
            // 
            // label_step
            // 
            this.label_step.AutoSize = true;
            this.label_step.Location = new System.Drawing.Point(545, 10);
            this.label_step.Name = "label_step";
            this.label_step.Size = new System.Drawing.Size(55, 13);
            this.label_step.TabIndex = 18;
            this.label_step.Text = "step_Hz =";
            // 
            // textBox_Step
            // 
            this.textBox_Step.Location = new System.Drawing.Point(600, 6);
            this.textBox_Step.Name = "textBox_Step";
            this.textBox_Step.Size = new System.Drawing.Size(27, 20);
            this.textBox_Step.TabIndex = 17;
            this.textBox_Step.Text = "5";
            this.textBox_Step.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_Step_KeyUp);
            this.textBox_Step.Leave += new System.EventHandler(this.textBox_Step_Leave);
            // 
            // label_NumPoint
            // 
            this.label_NumPoint.AutoSize = true;
            this.label_NumPoint.Location = new System.Drawing.Point(651, 10);
            this.label_NumPoint.Name = "label_NumPoint";
            this.label_NumPoint.Size = new System.Drawing.Size(62, 13);
            this.label_NumPoint.TabIndex = 20;
            this.label_NumPoint.Text = "NumPoint =";
            // 
            // textBox_NumPoint
            // 
            this.textBox_NumPoint.Location = new System.Drawing.Point(713, 6);
            this.textBox_NumPoint.Name = "textBox_NumPoint";
            this.textBox_NumPoint.Size = new System.Drawing.Size(39, 20);
            this.textBox_NumPoint.TabIndex = 18;
            this.textBox_NumPoint.Text = "1000";
            this.textBox_NumPoint.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_NumPoint_KeyUp);
            this.textBox_NumPoint.Leave += new System.EventHandler(this.textBox_NumPoint_Leave);
            // 
            // label_Power
            // 
            this.label_Power.AutoSize = true;
            this.label_Power.Location = new System.Drawing.Point(222, 10);
            this.label_Power.Name = "label_Power";
            this.label_Power.Size = new System.Drawing.Size(54, 13);
            this.label_Power.TabIndex = 22;
            this.label_Power.Text = "Power% =";
            // 
            // textBox_Power
            // 
            this.textBox_Power.Location = new System.Drawing.Point(276, 6);
            this.textBox_Power.Name = "textBox_Power";
            this.textBox_Power.Size = new System.Drawing.Size(30, 20);
            this.textBox_Power.TabIndex = 16;
            this.textBox_Power.Text = "2";
            this.textBox_Power.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_Power_KeyUp);
            this.textBox_Power.Leave += new System.EventHandler(this.textBox_Power_Leave);
            // 
            // textBox_Tstep
            // 
            this.textBox_Tstep.Location = new System.Drawing.Point(841, 6);
            this.textBox_Tstep.Name = "textBox_Tstep";
            this.textBox_Tstep.Size = new System.Drawing.Size(27, 20);
            this.textBox_Tstep.TabIndex = 19;
            this.textBox_Tstep.Text = "10";
            this.textBox_Tstep.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_Tstep_KeyUp);
            this.textBox_Tstep.Leave += new System.EventHandler(this.textBox_Tstep_Leave);
            // 
            // label_Tstep
            // 
            this.label_Tstep.AutoSize = true;
            this.label_Tstep.Location = new System.Drawing.Point(771, 10);
            this.label_Tstep.Name = "label_Tstep";
            this.label_Tstep.Size = new System.Drawing.Size(70, 13);
            this.label_Tstep.TabIndex = 24;
            this.label_Tstep.Text = "T_step_mS =";
            // 
            // label_Fend
            // 
            this.label_Fend.AutoSize = true;
            this.label_Fend.Location = new System.Drawing.Point(416, 10);
            this.label_Fend.Name = "label_Fend";
            this.label_Fend.Size = new System.Drawing.Size(40, 13);
            this.label_Fend.TabIndex = 25;
            this.label_Fend.Text = "Fend =";
            // 
            // checkBox_ON_gen
            // 
            this.checkBox_ON_gen.AutoSize = true;
            this.checkBox_ON_gen.Location = new System.Drawing.Point(242, 37);
            this.checkBox_ON_gen.Name = "checkBox_ON_gen";
            this.checkBox_ON_gen.Size = new System.Drawing.Size(66, 17);
            this.checkBox_ON_gen.TabIndex = 26;
            this.checkBox_ON_gen.Text = "ON_gen";
            this.checkBox_ON_gen.UseVisualStyleBackColor = true;
            this.checkBox_ON_gen.CheckedChanged += new System.EventHandler(this.checkBox_ON_gen_CheckedChanged);
            // 
            // checkBox_Tx_Data_cicle
            // 
            this.checkBox_Tx_Data_cicle.AutoSize = true;
            this.checkBox_Tx_Data_cicle.Location = new System.Drawing.Point(331, 37);
            this.checkBox_Tx_Data_cicle.Name = "checkBox_Tx_Data_cicle";
            this.checkBox_Tx_Data_cicle.Size = new System.Drawing.Size(95, 17);
            this.checkBox_Tx_Data_cicle.TabIndex = 27;
            this.checkBox_Tx_Data_cicle.Text = "Tx_Data_cicle";
            this.checkBox_Tx_Data_cicle.UseVisualStyleBackColor = true;
            this.checkBox_Tx_Data_cicle.CheckedChanged += new System.EventHandler(this.checkBox_Tx_Data_cicle_CheckedChanged);
            // 
            // checkBox_ON_scan
            // 
            this.checkBox_ON_scan.AutoSize = true;
            this.checkBox_ON_scan.Location = new System.Drawing.Point(452, 37);
            this.checkBox_ON_scan.Name = "checkBox_ON_scan";
            this.checkBox_ON_scan.Size = new System.Drawing.Size(71, 17);
            this.checkBox_ON_scan.TabIndex = 28;
            this.checkBox_ON_scan.Text = "ON_scan";
            this.checkBox_ON_scan.UseVisualStyleBackColor = true;
            this.checkBox_ON_scan.CheckedChanged += new System.EventHandler(this.checkBox_ON_scan_CheckedChanged);
            // 
            // button_cicle_read
            // 
            this.button_cicle_read.Location = new System.Drawing.Point(858, 40);
            this.button_cicle_read.Name = "button_cicle_read";
            this.button_cicle_read.Size = new System.Drawing.Size(100, 23);
            this.button_cicle_read.TabIndex = 29;
            this.button_cicle_read.Text = "Read_cicle";
            this.button_cicle_read.UseVisualStyleBackColor = true;
            this.button_cicle_read.Click += new System.EventHandler(this.button_cicle_read_Click);
            // 
            // label_chart1
            // 
            this.label_chart1.AutoSize = true;
            this.label_chart1.Location = new System.Drawing.Point(1830, 85);
            this.label_chart1.Name = "label_chart1";
            this.label_chart1.Size = new System.Drawing.Size(13, 13);
            this.label_chart1.TabIndex = 30;
            this.label_chart1.Text = "0";
            // 
            // label_chart6
            // 
            this.label_chart6.AutoSize = true;
            this.label_chart6.Location = new System.Drawing.Point(1830, 690);
            this.label_chart6.Name = "label_chart6";
            this.label_chart6.Size = new System.Drawing.Size(13, 13);
            this.label_chart6.TabIndex = 31;
            this.label_chart6.Text = "0";
            // 
            // label_chart2
            // 
            this.label_chart2.AutoSize = true;
            this.label_chart2.Location = new System.Drawing.Point(1830, 206);
            this.label_chart2.Name = "label_chart2";
            this.label_chart2.Size = new System.Drawing.Size(13, 13);
            this.label_chart2.TabIndex = 32;
            this.label_chart2.Text = "0";
            // 
            // label_chart3
            // 
            this.label_chart3.AutoSize = true;
            this.label_chart3.Location = new System.Drawing.Point(1830, 327);
            this.label_chart3.Name = "label_chart3";
            this.label_chart3.Size = new System.Drawing.Size(13, 13);
            this.label_chart3.TabIndex = 33;
            this.label_chart3.Text = "0";
            // 
            // label_chart4
            // 
            this.label_chart4.AutoSize = true;
            this.label_chart4.Location = new System.Drawing.Point(1830, 448);
            this.label_chart4.Name = "label_chart4";
            this.label_chart4.Size = new System.Drawing.Size(13, 13);
            this.label_chart4.TabIndex = 34;
            this.label_chart4.Text = "0";
            // 
            // label_chart5
            // 
            this.label_chart5.AutoSize = true;
            this.label_chart5.Location = new System.Drawing.Point(1830, 569);
            this.label_chart5.Name = "label_chart5";
            this.label_chart5.Size = new System.Drawing.Size(13, 13);
            this.label_chart5.TabIndex = 35;
            this.label_chart5.Text = "0";
            // 
            // numericUpDown_mouse
            // 
            this.numericUpDown_mouse.Location = new System.Drawing.Point(456, 810);
            this.numericUpDown_mouse.Maximum = new decimal(new int[] {
            43000,
            0,
            0,
            0});
            this.numericUpDown_mouse.Minimum = new decimal(new int[] {
            14500,
            0,
            0,
            0});
            this.numericUpDown_mouse.Name = "numericUpDown_mouse";
            this.numericUpDown_mouse.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown_mouse.TabIndex = 36;
            this.numericUpDown_mouse.Value = new decimal(new int[] {
            14500,
            0,
            0,
            0});
            this.numericUpDown_mouse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numericUpDown_mouse_MouseUp);
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Location = new System.Drawing.Point(241, 57);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(35, 13);
            this.label_message.TabIndex = 37;
            this.label_message.Text = "label1";
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Save.ForeColor = System.Drawing.Color.Purple;
            this.button_Save.Location = new System.Drawing.Point(105, 45);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(120, 23);
            this.button_Save.TabIndex = 38;
            this.button_Save.Text = "SaveAs...";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_open
            // 
            this.button_open.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_open.ForeColor = System.Drawing.Color.Blue;
            this.button_open.Location = new System.Drawing.Point(105, 18);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(120, 23);
            this.button_open.TabIndex = 39;
            this.button_open.Text = "Open";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 836);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "e.Location.Y ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 861);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.numericUpDown_mouse);
            this.Controls.Add(this.label_chart5);
            this.Controls.Add(this.label_chart4);
            this.Controls.Add(this.label_chart3);
            this.Controls.Add(this.label_chart2);
            this.Controls.Add(this.label_chart6);
            this.Controls.Add(this.label_chart1);
            this.Controls.Add(this.button_cicle_read);
            this.Controls.Add(this.checkBox_ON_scan);
            this.Controls.Add(this.checkBox_Tx_Data_cicle);
            this.Controls.Add(this.checkBox_ON_gen);
            this.Controls.Add(this.label_Fend);
            this.Controls.Add(this.label_Tstep);
            this.Controls.Add(this.textBox_Tstep);
            this.Controls.Add(this.label_Power);
            this.Controls.Add(this.textBox_Power);
            this.Controls.Add(this.label_NumPoint);
            this.Controls.Add(this.textBox_NumPoint);
            this.Controls.Add(this.label_step);
            this.Controls.Add(this.textBox_Step);
            this.Controls.Add(this.label_Fstart);
            this.Controls.Add(this.textBox_Fstart);
            this.Controls.Add(this.listBox_answer_one);
            this.Controls.Add(this.label_ComPort);
            this.Controls.Add(this.listBox_ComPort);
            this.Controls.Add(this.button_on_gen_scan);
            this.Controls.Add(this.label_baudrate);
            this.Controls.Add(this.listBox_BaudRate);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listBox6);
            this.Controls.Add(this.listBox5);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label_out);
            this.Controls.Add(this.button_read_ONE);
            this.Controls.Add(this.listBox1);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button_read_ONE;
        public System.IO.Ports.SerialPort serialPort_MB;
        private System.Windows.Forms.Label label_out;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.ListBox listBox6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox listBox_BaudRate;
        private System.Windows.Forms.Label label_baudrate;
        private System.Windows.Forms.Button button_on_gen_scan;
        private System.Windows.Forms.ListBox listBox_ComPort;
        private System.Windows.Forms.Label label_ComPort;
        private System.Windows.Forms.ListBox listBox_answer_one;
        private System.Windows.Forms.TextBox textBox_Fstart;
        private System.Windows.Forms.Label label_Fstart;
        private System.Windows.Forms.Label label_step;
        private System.Windows.Forms.TextBox textBox_Step;
        private System.Windows.Forms.Label label_NumPoint;
        private System.Windows.Forms.TextBox textBox_NumPoint;
        private System.Windows.Forms.Label label_Power;
        private System.Windows.Forms.TextBox textBox_Power;
        private System.Windows.Forms.TextBox textBox_Tstep;
        private System.Windows.Forms.Label label_Tstep;
        private System.Windows.Forms.Label label_Fend;
        private System.Windows.Forms.CheckBox checkBox_ON_gen;
        private System.Windows.Forms.CheckBox checkBox_Tx_Data_cicle;
        private System.Windows.Forms.CheckBox checkBox_ON_scan;
        private System.Windows.Forms.Button button_cicle_read;
        private System.Windows.Forms.Label label_chart1;
        private System.Windows.Forms.Label label_chart6;
        private System.Windows.Forms.Label label_chart2;
        private System.Windows.Forms.Label label_chart3;
        private System.Windows.Forms.Label label_chart4;
        private System.Windows.Forms.Label label_chart5;
        private System.Windows.Forms.NumericUpDown numericUpDown_mouse;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Label label1;
    }
}

