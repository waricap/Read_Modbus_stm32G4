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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series28 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series29 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series30 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series31 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series32 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series33 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series34 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series35 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series36 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.label_name_file_zamer = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button_open = new System.Windows.Forms.Button();
            this.label_error = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_stop_read = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox_scan_time = new System.Windows.Forms.CheckBox();
            this.listBox_COM_read = new System.Windows.Forms.ListBox();
            this.serialPort_read_data = new System.IO.Ports.SerialPort(this.components);
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
            this.label_out.Location = new System.Drawing.Point(1003, 34);
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
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            this.chart1.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea7.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea7.BackColor = System.Drawing.SystemColors.Info;
            chartArea7.InnerPlotPosition.Auto = false;
            chartArea7.InnerPlotPosition.Height = 100F;
            chartArea7.InnerPlotPosition.Width = 100F;
            chartArea7.Name = "ChartArea1";
            chartArea7.Position.Auto = false;
            chartArea7.Position.Height = 15.17F;
            chartArea7.Position.Width = 100F;
            chartArea7.Position.Y = 9F;
            chartArea8.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea8.InnerPlotPosition.Auto = false;
            chartArea8.InnerPlotPosition.Height = 100F;
            chartArea8.InnerPlotPosition.Width = 100F;
            chartArea8.Name = "ChartArea2";
            chartArea8.Position.Auto = false;
            chartArea8.Position.Height = 15.17F;
            chartArea8.Position.Width = 100F;
            chartArea8.Position.Y = 24.17F;
            chartArea9.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea9.BackColor = System.Drawing.SystemColors.Info;
            chartArea9.InnerPlotPosition.Auto = false;
            chartArea9.InnerPlotPosition.Height = 100F;
            chartArea9.InnerPlotPosition.Width = 100F;
            chartArea9.Name = "ChartArea3";
            chartArea9.Position.Auto = false;
            chartArea9.Position.Height = 15.17F;
            chartArea9.Position.Width = 100F;
            chartArea9.Position.Y = 39.34F;
            chartArea10.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea10.InnerPlotPosition.Auto = false;
            chartArea10.InnerPlotPosition.Height = 100F;
            chartArea10.InnerPlotPosition.Width = 100F;
            chartArea10.Name = "ChartArea4";
            chartArea10.Position.Auto = false;
            chartArea10.Position.Height = 15.17F;
            chartArea10.Position.Width = 100F;
            chartArea10.Position.Y = 54.51F;
            chartArea11.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea11.BackColor = System.Drawing.SystemColors.Info;
            chartArea11.InnerPlotPosition.Auto = false;
            chartArea11.InnerPlotPosition.Height = 100F;
            chartArea11.InnerPlotPosition.Width = 100F;
            chartArea11.Name = "ChartArea5";
            chartArea11.Position.Auto = false;
            chartArea11.Position.Height = 15.17F;
            chartArea11.Position.Width = 100F;
            chartArea11.Position.Y = 69.68F;
            chartArea12.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea12.InnerPlotPosition.Auto = false;
            chartArea12.InnerPlotPosition.Height = 100F;
            chartArea12.InnerPlotPosition.Width = 100F;
            chartArea12.Name = "ChartArea6";
            chartArea12.Position.Auto = false;
            chartArea12.Position.Height = 15.16F;
            chartArea12.Position.Width = 100F;
            chartArea12.Position.Y = 84.84F;
            this.chart1.ChartAreas.Add(chartArea7);
            this.chart1.ChartAreas.Add(chartArea8);
            this.chart1.ChartAreas.Add(chartArea9);
            this.chart1.ChartAreas.Add(chartArea10);
            this.chart1.ChartAreas.Add(chartArea11);
            this.chart1.ChartAreas.Add(chartArea12);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            legend2.BackColor = System.Drawing.SystemColors.Control;
            legend2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            legend2.ItemColumnSpacing = 100;
            legend2.Name = "Legend1";
            legend2.Position.Auto = false;
            legend2.Position.Height = 8.8F;
            legend2.Position.Width = 20F;
            legend2.Position.X = 80F;
            legend2.Position.Y = 0.1F;
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(230, 0);
            this.chart1.Name = "chart1";
            series19.BorderWidth = 3;
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series19.Color = System.Drawing.Color.Red;
            series19.LabelBorderWidth = 2;
            series19.Legend = "Legend1";
            series19.LegendText = "I_out";
            series19.Name = "Series1";
            series20.BorderWidth = 3;
            series20.ChartArea = "ChartArea2";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series20.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series20.LabelBorderWidth = 2;
            series20.Legend = "Legend1";
            series20.LegendText = "U_out";
            series20.Name = "Series2";
            series21.BorderWidth = 3;
            series21.ChartArea = "ChartArea3";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series21.Color = System.Drawing.Color.Blue;
            series21.LabelBorderWidth = 2;
            series21.Legend = "Legend1";
            series21.Name = "Series3";
            series22.BorderWidth = 3;
            series22.ChartArea = "ChartArea4";
            series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series22.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series22.LabelBorderWidth = 2;
            series22.Legend = "Legend1";
            series22.LegendText = "сс1";
            series22.Name = "Series4";
            series23.BorderWidth = 3;
            series23.ChartArea = "ChartArea5";
            series23.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series23.Color = System.Drawing.Color.Olive;
            series23.LabelBorderWidth = 2;
            series23.Legend = "Legend1";
            series23.Name = "Series5";
            series24.BorderWidth = 3;
            series24.ChartArea = "ChartArea6";
            series24.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series24.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series24.LabelBorderWidth = 2;
            series24.Legend = "Legend1";
            series24.Name = "Series6";
            series25.BorderWidth = 2;
            series25.ChartArea = "ChartArea1";
            series25.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series25.Color = System.Drawing.Color.Silver;
            series25.Legend = "Legend1";
            series25.Name = "Series7";
            series26.BorderWidth = 2;
            series26.ChartArea = "ChartArea2";
            series26.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series26.Color = System.Drawing.Color.Silver;
            series26.Legend = "Legend1";
            series26.Name = "Series8";
            series27.BorderWidth = 2;
            series27.ChartArea = "ChartArea3";
            series27.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series27.Color = System.Drawing.Color.Silver;
            series27.Legend = "Legend1";
            series27.Name = "Series9";
            series28.BorderWidth = 2;
            series28.ChartArea = "ChartArea4";
            series28.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series28.Color = System.Drawing.Color.Silver;
            series28.Legend = "Legend1";
            series28.Name = "Series10";
            series28.YValuesPerPoint = 4;
            series29.BorderWidth = 2;
            series29.ChartArea = "ChartArea5";
            series29.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series29.Color = System.Drawing.Color.Silver;
            series29.Legend = "Legend1";
            series29.Name = "Series11";
            series30.BorderWidth = 2;
            series30.ChartArea = "ChartArea6";
            series30.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series30.Color = System.Drawing.Color.Silver;
            series30.Legend = "Legend1";
            series30.Name = "Series12";
            series31.ChartArea = "ChartArea1";
            series31.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series31.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series31.Legend = "Legend1";
            series31.Name = "Series101";
            series32.ChartArea = "ChartArea2";
            series32.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series32.Color = System.Drawing.Color.Green;
            series32.Legend = "Legend1";
            series32.Name = "Series102";
            series33.ChartArea = "ChartArea3";
            series33.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series33.Color = System.Drawing.Color.Navy;
            series33.Legend = "Legend1";
            series33.Name = "Series103";
            series34.ChartArea = "ChartArea4";
            series34.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series34.Color = System.Drawing.Color.Purple;
            series34.Legend = "Legend1";
            series34.Name = "Series104";
            series35.ChartArea = "ChartArea5";
            series35.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series35.Color = System.Drawing.Color.Olive;
            series35.Legend = "Legend1";
            series35.Name = "Series105";
            series36.ChartArea = "ChartArea6";
            series36.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series36.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series36.Legend = "Legend1";
            series36.Name = "Series106";
            this.chart1.Series.Add(series19);
            this.chart1.Series.Add(series20);
            this.chart1.Series.Add(series21);
            this.chart1.Series.Add(series22);
            this.chart1.Series.Add(series23);
            this.chart1.Series.Add(series24);
            this.chart1.Series.Add(series25);
            this.chart1.Series.Add(series26);
            this.chart1.Series.Add(series27);
            this.chart1.Series.Add(series28);
            this.chart1.Series.Add(series29);
            this.chart1.Series.Add(series30);
            this.chart1.Series.Add(series31);
            this.chart1.Series.Add(series32);
            this.chart1.Series.Add(series33);
            this.chart1.Series.Add(series34);
            this.chart1.Series.Add(series35);
            this.chart1.Series.Add(series36);
            this.chart1.Size = new System.Drawing.Size(1625, 830);
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
            this.listBox_BaudRate.Size = new System.Drawing.Size(56, 121);
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
            this.button_on_gen_scan.Location = new System.Drawing.Point(683, 37);
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
            this.listBox_answer_one.Location = new System.Drawing.Point(12, 363);
            this.listBox_answer_one.Name = "listBox_answer_one";
            this.listBox_answer_one.Size = new System.Drawing.Size(56, 108);
            this.listBox_answer_one.TabIndex = 14;
            // 
            // textBox_Fstart
            // 
            this.textBox_Fstart.Location = new System.Drawing.Point(424, 6);
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
            this.label_Fstart.Location = new System.Drawing.Point(382, 10);
            this.label_Fstart.Name = "label_Fstart";
            this.label_Fstart.Size = new System.Drawing.Size(42, 13);
            this.label_Fstart.TabIndex = 16;
            this.label_Fstart.Text = "Fstart =";
            // 
            // label_step
            // 
            this.label_step.AutoSize = true;
            this.label_step.Location = new System.Drawing.Point(576, 10);
            this.label_step.Name = "label_step";
            this.label_step.Size = new System.Drawing.Size(55, 13);
            this.label_step.TabIndex = 18;
            this.label_step.Text = "step_Hz =";
            // 
            // textBox_Step
            // 
            this.textBox_Step.Location = new System.Drawing.Point(631, 6);
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
            this.label_NumPoint.Location = new System.Drawing.Point(682, 10);
            this.label_NumPoint.Name = "label_NumPoint";
            this.label_NumPoint.Size = new System.Drawing.Size(62, 13);
            this.label_NumPoint.TabIndex = 20;
            this.label_NumPoint.Text = "NumPoint =";
            // 
            // textBox_NumPoint
            // 
            this.textBox_NumPoint.Location = new System.Drawing.Point(744, 6);
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
            this.label_Power.Location = new System.Drawing.Point(280, 10);
            this.label_Power.Name = "label_Power";
            this.label_Power.Size = new System.Drawing.Size(54, 13);
            this.label_Power.TabIndex = 22;
            this.label_Power.Text = "Power% =";
            // 
            // textBox_Power
            // 
            this.textBox_Power.Location = new System.Drawing.Point(334, 6);
            this.textBox_Power.Name = "textBox_Power";
            this.textBox_Power.Size = new System.Drawing.Size(30, 20);
            this.textBox_Power.TabIndex = 16;
            this.textBox_Power.Text = "2";
            this.textBox_Power.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_Power_KeyUp);
            this.textBox_Power.Leave += new System.EventHandler(this.textBox_Power_Leave);
            // 
            // textBox_Tstep
            // 
            this.textBox_Tstep.Location = new System.Drawing.Point(872, 6);
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
            this.label_Tstep.Location = new System.Drawing.Point(802, 10);
            this.label_Tstep.Name = "label_Tstep";
            this.label_Tstep.Size = new System.Drawing.Size(70, 13);
            this.label_Tstep.TabIndex = 24;
            this.label_Tstep.Text = "T_step_mS =";
            // 
            // label_Fend
            // 
            this.label_Fend.AutoSize = true;
            this.label_Fend.Location = new System.Drawing.Point(474, 10);
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
            this.checkBox_ON_scan.Size = new System.Drawing.Size(98, 17);
            this.checkBox_ON_scan.TabIndex = 28;
            this.checkBox_ON_scan.Text = "ON_scan_Freq";
            this.checkBox_ON_scan.UseVisualStyleBackColor = true;
            this.checkBox_ON_scan.CheckedChanged += new System.EventHandler(this.checkBox_ON_scan_CheckedChanged);
            // 
            // button_cicle_read
            // 
            this.button_cicle_read.Location = new System.Drawing.Point(798, 37);
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
            this.numericUpDown_mouse.Location = new System.Drawing.Point(456, 835);
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
            // label_name_file_zamer
            // 
            this.label_name_file_zamer.Location = new System.Drawing.Point(65, 2);
            this.label_name_file_zamer.Name = "label_name_file_zamer";
            this.label_name_file_zamer.Size = new System.Drawing.Size(200, 14);
            this.label_name_file_zamer.TabIndex = 37;
            this.label_name_file_zamer.Text = "__file.tfx__";
            this.label_name_file_zamer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(192, 847);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(28, 13);
            this.label_error.TabIndex = 42;
            this.label_error.Text = "error";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // button_stop_read
            // 
            this.button_stop_read.Location = new System.Drawing.Point(898, 37);
            this.button_stop_read.Name = "button_stop_read";
            this.button_stop_read.Size = new System.Drawing.Size(100, 23);
            this.button_stop_read.TabIndex = 43;
            this.button_stop_read.Text = "STOP_Read";
            this.button_stop_read.UseVisualStyleBackColor = true;
            this.button_stop_read.Click += new System.EventHandler(this.button_stop_read_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1861, 130);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 44;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox_Phase_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1861, 252);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 45;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox_Phase_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(1861, 382);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 46;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox_Phase_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(1861, 507);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 47;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox_Phase_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(1861, 631);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 48;
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox_Phase_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(1861, 758);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 49;
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox_Phase_CheckedChanged);
            // 
            // checkBox_scan_time
            // 
            this.checkBox_scan_time.AutoSize = true;
            this.checkBox_scan_time.Location = new System.Drawing.Point(579, 43);
            this.checkBox_scan_time.Name = "checkBox_scan_time";
            this.checkBox_scan_time.Size = new System.Drawing.Size(74, 17);
            this.checkBox_scan_time.TabIndex = 50;
            this.checkBox_scan_time.Text = "scan_time";
            this.checkBox_scan_time.UseVisualStyleBackColor = true;
            this.checkBox_scan_time.CheckedChanged += new System.EventHandler(this.checkBox_scan_time_CheckedChanged);
            // 
            // listBox_COM_read
            // 
            this.listBox_COM_read.FormattingEnabled = true;
            this.listBox_COM_read.Location = new System.Drawing.Point(12, 283);
            this.listBox_COM_read.Name = "listBox_COM_read";
            this.listBox_COM_read.Size = new System.Drawing.Size(55, 69);
            this.listBox_COM_read.TabIndex = 51;
            this.listBox_COM_read.MouseEnter += new System.EventHandler(this.listBox_ComPort_MouseEnter);
            // 
            // serialPort_read_data
            // 
            this.serialPort_read_data.BaudRate = 921600;
            this.serialPort_read_data.PortName = "COM2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 861);
            this.Controls.Add(this.listBox_COM_read);
            this.Controls.Add(this.checkBox_scan_time);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button_stop_read);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.label_out);
            this.Controls.Add(this.label_name_file_zamer);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.button_Save);
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
            this.Controls.Add(this.button_read_ONE);
            this.Controls.Add(this.listBox1);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Label label_name_file_zamer;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_stop_read;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox_scan_time;
        private System.Windows.Forms.ListBox listBox_COM_read;
        private System.IO.Ports.SerialPort serialPort_read_data;
    }
}

