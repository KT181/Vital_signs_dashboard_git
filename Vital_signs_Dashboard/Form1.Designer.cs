namespace Vital_signs_Dashboard
{
    partial class DashBord
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Close = new PictureBox();
            Sizeable = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            unusual_events = new Button();
            P_BT_history = new Button();
            P_BP_history = new Button();
            P_HR_history = new Button();
            unusual_events_display = new Panel();
            insert = new Button();
            Days5_BT = new ScottPlot.WinForms.FormsPlot();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            panel3 = new Panel();
            HR = new Label();
            WT = new Label();
            HT = new Label();
            BP = new Label();
            BT = new Label();
            panel2 = new Panel();
            Time = new Label();
            BT_DATE = new Label();
            P_name = new Label();
            get_P = new Button();
            label5 = new Label();
            bed_nb = new TextBox();
            label3 = new Label();
            room_nb = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            roomnb = new DataGridViewTextBoxColumn();
            bednb = new DataGridViewTextBoxColumn();
            patient = new DataGridViewTextBoxColumn();
            resault = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            BT_HISTORY = new Panel();
            circle = new Button();
            BT_History_bed = new TextBox();
            label9 = new Label();
            BT_History_room = new TextBox();
            label10 = new Label();
            BT_History_name = new Label();
            BT_DATA = new ScottPlot.WinForms.FormsPlot();
            BT_research = new Button();
            to = new Label();
            BT_endtime = new DateTimePicker();
            Days30_BT = new Button();
            Days7_BT = new Button();
            BT_starttime = new DateTimePicker();
            BP_HISTORY = new Panel();
            BP_History_bed = new TextBox();
            label12 = new Label();
            BP_History_room = new TextBox();
            label13 = new Label();
            BP_History_name = new Label();
            BP_DATA = new ScottPlot.WinForms.FormsPlot();
            BP_research = new Button();
            BP_endtime = new DateTimePicker();
            label7 = new Label();
            BP_starttime = new DateTimePicker();
            Days30_BP = new Button();
            Days7_BP = new Button();
            HR_HISTORY = new Panel();
            HR_History_bed = new TextBox();
            label4 = new Label();
            HR_History_room = new TextBox();
            label8 = new Label();
            HR_History_name = new Label();
            HR_DATA = new ScottPlot.WinForms.FormsPlot();
            HR_research = new Button();
            label6 = new Label();
            HR_endtime = new DateTimePicker();
            HR_starttime = new DateTimePicker();
            Days30_HR = new Button();
            Days7_HR = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Close).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Sizeable).BeginInit();
            panel1.SuspendLayout();
            unusual_events_display.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            BT_HISTORY.SuspendLayout();
            BP_HISTORY.SuspendLayout();
            HR_HISTORY.SuspendLayout();
            SuspendLayout();
            // 
            // Close
            // 
            Close.BackgroundImage = Properties.Resources.close;
            Close.BackgroundImageLayout = ImageLayout.Zoom;
            Close.Location = new Point(1337, 11);
            Close.Name = "Close";
            Close.Size = new Size(50, 50);
            Close.TabIndex = 1;
            Close.TabStop = false;
            Close.Click += Close_Click;
            // 
            // Sizeable
            // 
            Sizeable.BackgroundImage = Properties.Resources.sizeable;
            Sizeable.BackgroundImageLayout = ImageLayout.Zoom;
            Sizeable.Location = new Point(1281, 11);
            Sizeable.Name = "Sizeable";
            Sizeable.Size = new Size(50, 50);
            Sizeable.TabIndex = 2;
            Sizeable.TabStop = false;
            Sizeable.Click += Sizeable_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(246, 246, 246);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(unusual_events);
            panel1.Controls.Add(P_BT_history);
            panel1.Controls.Add(P_BP_history);
            panel1.Controls.Add(P_HR_history);
            panel1.Controls.Add(Sizeable);
            panel1.Controls.Add(Close);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1400, 72);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微軟正黑體", 36F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.Location = new Point(6, 3);
            label1.Name = "label1";
            label1.Size = new Size(411, 61);
            label1.TabIndex = 7;
            label1.Text = "患者生命特徵監控";
            // 
            // unusual_events
            // 
            unusual_events.BackColor = Color.FromArgb(0, 71, 171);
            unusual_events.FlatAppearance.BorderSize = 0;
            unusual_events.FlatStyle = FlatStyle.Flat;
            unusual_events.Font = new Font("微軟正黑體", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            unusual_events.ForeColor = SystemColors.ButtonFace;
            unusual_events.ImageAlign = ContentAlignment.MiddleLeft;
            unusual_events.Location = new Point(534, 11);
            unusual_events.Name = "unusual_events";
            unusual_events.Size = new Size(168, 50);
            unusual_events.TabIndex = 6;
            unusual_events.Text = "異常事件";
            unusual_events.UseVisualStyleBackColor = false;
            unusual_events.Click += unusual_events_Click;
            // 
            // P_BT_history
            // 
            P_BT_history.BackColor = Color.FromArgb(0, 71, 171);
            P_BT_history.FlatAppearance.BorderSize = 0;
            P_BT_history.FlatStyle = FlatStyle.Flat;
            P_BT_history.Font = new Font("微軟正黑體", 15F, FontStyle.Bold, GraphicsUnit.Point, 136);
            P_BT_history.ForeColor = Color.White;
            P_BT_history.Location = new Point(708, 11);
            P_BT_history.Name = "P_BT_history";
            P_BT_history.Size = new Size(168, 50);
            P_BT_history.TabIndex = 5;
            P_BT_history.Text = "體溫歷史數據";
            P_BT_history.UseVisualStyleBackColor = false;
            P_BT_history.Click += P_BT_history_Click;
            // 
            // P_BP_history
            // 
            P_BP_history.BackColor = Color.FromArgb(0, 71, 171);
            P_BP_history.FlatAppearance.BorderSize = 0;
            P_BP_history.FlatStyle = FlatStyle.Flat;
            P_BP_history.Font = new Font("微軟正黑體", 15F, FontStyle.Bold, GraphicsUnit.Point, 136);
            P_BP_history.ForeColor = Color.White;
            P_BP_history.Location = new Point(882, 11);
            P_BP_history.Name = "P_BP_history";
            P_BP_history.Size = new Size(168, 50);
            P_BP_history.TabIndex = 4;
            P_BP_history.Text = "血壓歷史數據";
            P_BP_history.UseVisualStyleBackColor = false;
            P_BP_history.Click += P_BP_history_Click;
            // 
            // P_HR_history
            // 
            P_HR_history.BackColor = Color.FromArgb(0, 71, 171);
            P_HR_history.FlatAppearance.BorderSize = 0;
            P_HR_history.FlatStyle = FlatStyle.Flat;
            P_HR_history.Font = new Font("微軟正黑體", 15F, FontStyle.Bold, GraphicsUnit.Point, 136);
            P_HR_history.ForeColor = Color.White;
            P_HR_history.Location = new Point(1056, 11);
            P_HR_history.Name = "P_HR_history";
            P_HR_history.Size = new Size(168, 50);
            P_HR_history.TabIndex = 3;
            P_HR_history.Text = "心率歷史數據";
            P_HR_history.UseVisualStyleBackColor = false;
            P_HR_history.Click += P_HR_history_Click;
            // 
            // unusual_events_display
            // 
            unusual_events_display.BackColor = Color.Silver;
            unusual_events_display.Controls.Add(insert);
            unusual_events_display.Controls.Add(Days5_BT);
            unusual_events_display.Controls.Add(plotView1);
            unusual_events_display.Controls.Add(panel3);
            unusual_events_display.Controls.Add(panel2);
            unusual_events_display.Controls.Add(get_P);
            unusual_events_display.Controls.Add(label5);
            unusual_events_display.Controls.Add(bed_nb);
            unusual_events_display.Controls.Add(label3);
            unusual_events_display.Controls.Add(room_nb);
            unusual_events_display.Controls.Add(label2);
            unusual_events_display.Controls.Add(dataGridView1);
            unusual_events_display.Location = new Point(0, 79);
            unusual_events_display.Name = "unusual_events_display";
            unusual_events_display.Size = new Size(1400, 722);
            unusual_events_display.TabIndex = 4;
            unusual_events_display.Paint += unusual_events_display_Paint;
            // 
            // insert
            // 
            insert.Location = new Point(1236, 19);
            insert.Name = "insert";
            insert.Size = new Size(75, 23);
            insert.TabIndex = 18;
            insert.Text = "新增";
            insert.UseVisualStyleBackColor = true;
            insert.Click += insert_Click;
            // 
            // Days5_BT
            // 
            Days5_BT.DisplayScale = 1F;
            Days5_BT.Location = new Point(3, 266);
            Days5_BT.Name = "Days5_BT";
            Days5_BT.Size = new Size(834, 451);
            Days5_BT.TabIndex = 17;
            // 
            // plotView1
            // 
            plotView1.Location = new Point(0, 0);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(0, 0);
            plotView1.TabIndex = 0;
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 192, 255);
            panel3.Controls.Add(HR);
            panel3.Controls.Add(WT);
            panel3.Controls.Add(HT);
            panel3.Controls.Add(BP);
            panel3.Controls.Add(BT);
            panel3.Location = new Point(0, 117);
            panel3.Name = "panel3";
            panel3.Size = new Size(837, 143);
            panel3.TabIndex = 16;
            // 
            // HR
            // 
            HR.AutoSize = true;
            HR.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            HR.Location = new Point(210, 90);
            HR.Name = "HR";
            HR.Size = new Size(68, 31);
            HR.TabIndex = 11;
            HR.Text = "心率:";
            // 
            // WT
            // 
            WT.AutoSize = true;
            WT.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            WT.Location = new Point(210, 29);
            WT.Name = "WT";
            WT.Size = new Size(68, 31);
            WT.TabIndex = 10;
            WT.Text = "體重:";
            // 
            // HT
            // 
            HT.AutoSize = true;
            HT.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            HT.Location = new Point(18, 29);
            HT.Name = "HT";
            HT.Size = new Size(68, 31);
            HT.TabIndex = 9;
            HT.Text = "身高:";
            // 
            // BP
            // 
            BP.AutoSize = true;
            BP.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BP.Location = new Point(412, 90);
            BP.Name = "BP";
            BP.Size = new Size(68, 31);
            BP.TabIndex = 8;
            BP.Text = "血壓:";
            // 
            // BT
            // 
            BT.AutoSize = true;
            BT.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BT.Location = new Point(18, 90);
            BT.Name = "BT";
            BT.Size = new Size(68, 31);
            BT.TabIndex = 7;
            BT.Text = "體溫:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Cyan;
            panel2.Controls.Add(Time);
            panel2.Controls.Add(BT_DATE);
            panel2.Controls.Add(P_name);
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(837, 58);
            panel2.TabIndex = 15;
            // 
            // Time
            // 
            Time.AutoSize = true;
            Time.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Time.Location = new Point(534, 12);
            Time.Name = "Time";
            Time.Size = new Size(164, 31);
            Time.TabIndex = 14;
            Time.Text = "上次檢測時間:";
            // 
            // BT_DATE
            // 
            BT_DATE.AutoSize = true;
            BT_DATE.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BT_DATE.Location = new Point(210, 12);
            BT_DATE.Name = "BT_DATE";
            BT_DATE.Size = new Size(164, 31);
            BT_DATE.TabIndex = 12;
            BT_DATE.Text = "上次檢測日期:";
            // 
            // P_name
            // 
            P_name.AutoSize = true;
            P_name.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            P_name.Location = new Point(18, 12);
            P_name.Name = "P_name";
            P_name.Size = new Size(68, 31);
            P_name.TabIndex = 5;
            P_name.Text = "患者:";
            // 
            // get_P
            // 
            get_P.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            get_P.Location = new Point(412, 15);
            get_P.Name = "get_P";
            get_P.Size = new Size(60, 30);
            get_P.TabIndex = 13;
            get_P.Text = "查詢";
            get_P.UseVisualStyleBackColor = true;
            get_P.Click += get_P_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微軟正黑體", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label5.Location = new Point(1077, 18);
            label5.Name = "label5";
            label5.Size = new Size(138, 26);
            label5.TabIndex = 6;
            label5.Text = "異常事件列表";
            // 
            // bed_nb
            // 
            bed_nb.Font = new Font("微軟正黑體", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            bed_nb.Location = new Point(323, 12);
            bed_nb.Name = "bed_nb";
            bed_nb.Size = new Size(63, 39);
            bed_nb.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label3.Location = new Point(249, 15);
            label3.Name = "label3";
            label3.Size = new Size(68, 31);
            label3.TabIndex = 3;
            label3.Text = "床號:";
            // 
            // room_nb
            // 
            room_nb.Font = new Font("微軟正黑體", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            room_nb.Location = new Point(109, 12);
            room_nb.Name = "room_nb";
            room_nb.Size = new Size(124, 39);
            room_nb.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(11, 15);
            label2.Name = "label2";
            label2.Size = new Size(92, 31);
            label2.TabIndex = 1;
            label2.Text = "病房號:";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { roomnb, bednb, patient, resault, date });
            dataGridView1.Location = new Point(844, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(544, 657);
            dataGridView1.TabIndex = 0;
            // 
            // roomnb
            // 
            roomnb.HeaderText = "病房號";
            roomnb.Name = "roomnb";
            roomnb.Width = 70;
            // 
            // bednb
            // 
            bednb.HeaderText = "床號";
            bednb.Name = "bednb";
            bednb.Width = 70;
            // 
            // patient
            // 
            patient.HeaderText = "患者";
            patient.Name = "patient";
            // 
            // resault
            // 
            resault.HeaderText = "原因";
            resault.Name = "resault";
            // 
            // date
            // 
            date.HeaderText = "日期";
            date.Name = "date";
            date.Width = 160;
            // 
            // BT_HISTORY
            // 
            BT_HISTORY.BackColor = Color.Sienna;
            BT_HISTORY.Controls.Add(circle);
            BT_HISTORY.Controls.Add(BT_History_bed);
            BT_HISTORY.Controls.Add(label9);
            BT_HISTORY.Controls.Add(BT_History_room);
            BT_HISTORY.Controls.Add(label10);
            BT_HISTORY.Controls.Add(BT_History_name);
            BT_HISTORY.Controls.Add(BT_DATA);
            BT_HISTORY.Controls.Add(BT_research);
            BT_HISTORY.Controls.Add(to);
            BT_HISTORY.Controls.Add(BT_endtime);
            BT_HISTORY.Controls.Add(Days30_BT);
            BT_HISTORY.Controls.Add(Days7_BT);
            BT_HISTORY.Controls.Add(BT_starttime);
            BT_HISTORY.Location = new Point(0, 79);
            BT_HISTORY.Name = "BT_HISTORY";
            BT_HISTORY.Size = new Size(1400, 722);
            BT_HISTORY.TabIndex = 5;
            // 
            // circle
            // 
            circle.Font = new Font("微軟正黑體", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            circle.Location = new Point(1230, 72);
            circle.Name = "circle";
            circle.Size = new Size(157, 41);
            circle.TabIndex = 27;
            circle.Text = "檢視區段異常比例";
            circle.UseVisualStyleBackColor = true;
            circle.Click += circle_Click;
            // 
            // BT_History_bed
            // 
            BT_History_bed.Font = new Font("微軟正黑體", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            BT_History_bed.Location = new Point(354, 17);
            BT_History_bed.Name = "BT_History_bed";
            BT_History_bed.Size = new Size(63, 39);
            BT_History_bed.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label9.Location = new Point(265, 21);
            label9.Name = "label9";
            label9.Size = new Size(68, 31);
            label9.TabIndex = 24;
            label9.Text = "床號:";
            // 
            // BT_History_room
            // 
            BT_History_room.Font = new Font("微軟正黑體", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            BT_History_room.Location = new Point(118, 16);
            BT_History_room.Name = "BT_History_room";
            BT_History_room.Size = new Size(124, 39);
            BT_History_room.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(18, 21);
            label10.Name = "label10";
            label10.Size = new Size(92, 31);
            label10.TabIndex = 22;
            label10.Text = "病房號:";
            // 
            // BT_History_name
            // 
            BT_History_name.AutoSize = true;
            BT_History_name.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BT_History_name.Location = new Point(477, 22);
            BT_History_name.Name = "BT_History_name";
            BT_History_name.Size = new Size(68, 31);
            BT_History_name.TabIndex = 26;
            BT_History_name.Text = "患者:";
            // 
            // BT_DATA
            // 
            BT_DATA.DisplayScale = 1F;
            BT_DATA.Location = new Point(18, 144);
            BT_DATA.Name = "BT_DATA";
            BT_DATA.Size = new Size(1369, 537);
            BT_DATA.TabIndex = 14;
            // 
            // BT_research
            // 
            BT_research.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BT_research.Location = new Point(1290, 16);
            BT_research.Name = "BT_research";
            BT_research.Size = new Size(103, 41);
            BT_research.TabIndex = 13;
            BT_research.Text = "查詢";
            BT_research.UseVisualStyleBackColor = true;
            BT_research.Click += BT_research_Click;
            // 
            // to
            // 
            to.AutoSize = true;
            to.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            to.Location = new Point(1013, 19);
            to.Name = "to";
            to.Size = new Size(37, 30);
            to.TabIndex = 12;
            to.Text = "到";
            // 
            // BT_endtime
            // 
            BT_endtime.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BT_endtime.Location = new Point(1056, 17);
            BT_endtime.Name = "BT_endtime";
            BT_endtime.Size = new Size(222, 38);
            BT_endtime.TabIndex = 11;
            // 
            // Days30_BT
            // 
            Days30_BT.BackColor = Color.Cyan;
            Days30_BT.FlatAppearance.BorderColor = Color.White;
            Days30_BT.FlatAppearance.BorderSize = 0;
            Days30_BT.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Days30_BT.Location = new Point(249, 72);
            Days30_BT.Name = "Days30_BT";
            Days30_BT.Size = new Size(226, 41);
            Days30_BT.TabIndex = 10;
            Days30_BT.Text = "30天體溫歷史數據";
            Days30_BT.UseVisualStyleBackColor = false;
            Days30_BT.Click += Days30_BT_Click;
            // 
            // Days7_BT
            // 
            Days7_BT.BackColor = Color.Cyan;
            Days7_BT.FlatAppearance.BorderColor = Color.White;
            Days7_BT.FlatAppearance.BorderSize = 0;
            Days7_BT.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Days7_BT.Location = new Point(18, 72);
            Days7_BT.Name = "Days7_BT";
            Days7_BT.Size = new Size(207, 41);
            Days7_BT.TabIndex = 9;
            Days7_BT.Text = "7天體溫歷史數據";
            Days7_BT.UseVisualStyleBackColor = false;
            Days7_BT.Click += Days7_BT_Click;
            // 
            // BT_starttime
            // 
            BT_starttime.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BT_starttime.Location = new Point(775, 16);
            BT_starttime.Name = "BT_starttime";
            BT_starttime.Size = new Size(222, 38);
            BT_starttime.TabIndex = 8;
            // 
            // BP_HISTORY
            // 
            BP_HISTORY.BackColor = Color.IndianRed;
            BP_HISTORY.Controls.Add(BP_History_bed);
            BP_HISTORY.Controls.Add(label12);
            BP_HISTORY.Controls.Add(BP_History_room);
            BP_HISTORY.Controls.Add(label13);
            BP_HISTORY.Controls.Add(BP_History_name);
            BP_HISTORY.Controls.Add(BP_DATA);
            BP_HISTORY.Controls.Add(BP_research);
            BP_HISTORY.Controls.Add(BP_endtime);
            BP_HISTORY.Controls.Add(label7);
            BP_HISTORY.Controls.Add(BP_starttime);
            BP_HISTORY.Controls.Add(Days30_BP);
            BP_HISTORY.Controls.Add(Days7_BP);
            BP_HISTORY.Location = new Point(0, 79);
            BP_HISTORY.Name = "BP_HISTORY";
            BP_HISTORY.Size = new Size(1400, 722);
            BP_HISTORY.TabIndex = 6;
            // 
            // BP_History_bed
            // 
            BP_History_bed.Font = new Font("微軟正黑體", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            BP_History_bed.Location = new Point(354, 18);
            BP_History_bed.Name = "BP_History_bed";
            BP_History_bed.Size = new Size(63, 39);
            BP_History_bed.TabIndex = 30;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label12.Location = new Point(265, 22);
            label12.Name = "label12";
            label12.Size = new Size(68, 31);
            label12.TabIndex = 29;
            label12.Text = "床號:";
            // 
            // BP_History_room
            // 
            BP_History_room.Font = new Font("微軟正黑體", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            BP_History_room.Location = new Point(118, 17);
            BP_History_room.Name = "BP_History_room";
            BP_History_room.Size = new Size(124, 39);
            BP_History_room.TabIndex = 28;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(18, 22);
            label13.Name = "label13";
            label13.Size = new Size(92, 31);
            label13.TabIndex = 27;
            label13.Text = "病房號:";
            // 
            // BP_History_name
            // 
            BP_History_name.AutoSize = true;
            BP_History_name.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BP_History_name.Location = new Point(477, 23);
            BP_History_name.Name = "BP_History_name";
            BP_History_name.Size = new Size(68, 31);
            BP_History_name.TabIndex = 31;
            BP_History_name.Text = "患者:";
            // 
            // BP_DATA
            // 
            BP_DATA.DisplayScale = 1F;
            BP_DATA.Location = new Point(18, 144);
            BP_DATA.Name = "BP_DATA";
            BP_DATA.Size = new Size(1369, 537);
            BP_DATA.TabIndex = 19;
            // 
            // BP_research
            // 
            BP_research.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BP_research.Location = new Point(1290, 17);
            BP_research.Name = "BP_research";
            BP_research.Size = new Size(103, 41);
            BP_research.TabIndex = 16;
            BP_research.Text = "查詢";
            BP_research.UseVisualStyleBackColor = true;
            BP_research.Click += BP_research_Click;
            // 
            // BP_endtime
            // 
            BP_endtime.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BP_endtime.Location = new Point(1056, 18);
            BP_endtime.Name = "BP_endtime";
            BP_endtime.Size = new Size(222, 38);
            BP_endtime.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label7.Location = new Point(1013, 22);
            label7.Name = "label7";
            label7.Size = new Size(37, 30);
            label7.TabIndex = 16;
            label7.Text = "到";
            // 
            // BP_starttime
            // 
            BP_starttime.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BP_starttime.Location = new Point(775, 17);
            BP_starttime.Name = "BP_starttime";
            BP_starttime.Size = new Size(222, 38);
            BP_starttime.TabIndex = 17;
            // 
            // Days30_BP
            // 
            Days30_BP.BackColor = Color.Cyan;
            Days30_BP.FlatAppearance.BorderColor = Color.White;
            Days30_BP.FlatAppearance.BorderSize = 0;
            Days30_BP.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Days30_BP.Location = new Point(246, 72);
            Days30_BP.Name = "Days30_BP";
            Days30_BP.Size = new Size(226, 41);
            Days30_BP.TabIndex = 16;
            Days30_BP.Text = "30天血壓歷史數據";
            Days30_BP.UseVisualStyleBackColor = false;
            Days30_BP.Click += Days30_BP_Click;
            // 
            // Days7_BP
            // 
            Days7_BP.BackColor = Color.Cyan;
            Days7_BP.FlatAppearance.BorderColor = Color.White;
            Days7_BP.FlatAppearance.BorderSize = 0;
            Days7_BP.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Days7_BP.Location = new Point(18, 72);
            Days7_BP.Name = "Days7_BP";
            Days7_BP.Size = new Size(207, 41);
            Days7_BP.TabIndex = 11;
            Days7_BP.Text = "7天血壓歷史數據";
            Days7_BP.UseVisualStyleBackColor = false;
            Days7_BP.Click += Days7_BP_Click;
            // 
            // HR_HISTORY
            // 
            HR_HISTORY.BackColor = Color.LightSalmon;
            HR_HISTORY.Controls.Add(HR_History_bed);
            HR_HISTORY.Controls.Add(label4);
            HR_HISTORY.Controls.Add(HR_History_room);
            HR_HISTORY.Controls.Add(label8);
            HR_HISTORY.Controls.Add(HR_History_name);
            HR_HISTORY.Controls.Add(HR_DATA);
            HR_HISTORY.Controls.Add(HR_research);
            HR_HISTORY.Controls.Add(label6);
            HR_HISTORY.Controls.Add(HR_endtime);
            HR_HISTORY.Controls.Add(HR_starttime);
            HR_HISTORY.Controls.Add(Days30_HR);
            HR_HISTORY.Controls.Add(Days7_HR);
            HR_HISTORY.Location = new Point(0, 79);
            HR_HISTORY.Name = "HR_HISTORY";
            HR_HISTORY.Size = new Size(1400, 722);
            HR_HISTORY.TabIndex = 7;
            // 
            // HR_History_bed
            // 
            HR_History_bed.Font = new Font("微軟正黑體", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            HR_History_bed.Location = new Point(354, 18);
            HR_History_bed.Name = "HR_History_bed";
            HR_History_bed.Size = new Size(63, 39);
            HR_History_bed.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label4.Location = new Point(265, 22);
            label4.Name = "label4";
            label4.Size = new Size(68, 31);
            label4.TabIndex = 19;
            label4.Text = "床號:";
            // 
            // HR_History_room
            // 
            HR_History_room.Font = new Font("微軟正黑體", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            HR_History_room.Location = new Point(118, 17);
            HR_History_room.Name = "HR_History_room";
            HR_History_room.Size = new Size(124, 39);
            HR_History_room.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(18, 22);
            label8.Name = "label8";
            label8.Size = new Size(92, 31);
            label8.TabIndex = 17;
            label8.Text = "病房號:";
            // 
            // HR_History_name
            // 
            HR_History_name.AutoSize = true;
            HR_History_name.Font = new Font("微軟正黑體", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            HR_History_name.Location = new Point(477, 23);
            HR_History_name.Name = "HR_History_name";
            HR_History_name.Size = new Size(68, 31);
            HR_History_name.TabIndex = 21;
            HR_History_name.Text = "患者:";
            // 
            // HR_DATA
            // 
            HR_DATA.DisplayScale = 1F;
            HR_DATA.Location = new Point(18, 144);
            HR_DATA.Name = "HR_DATA";
            HR_DATA.Size = new Size(1369, 537);
            HR_DATA.TabIndex = 16;
            // 
            // HR_research
            // 
            HR_research.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            HR_research.Location = new Point(1290, 12);
            HR_research.Name = "HR_research";
            HR_research.Size = new Size(103, 41);
            HR_research.TabIndex = 15;
            HR_research.Text = "查詢";
            HR_research.UseVisualStyleBackColor = true;
            HR_research.Click += HR_research_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label6.Location = new Point(1013, 20);
            label6.Name = "label6";
            label6.Size = new Size(37, 30);
            label6.TabIndex = 15;
            label6.Text = "到";
            // 
            // HR_endtime
            // 
            HR_endtime.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            HR_endtime.Location = new Point(1056, 14);
            HR_endtime.Name = "HR_endtime";
            HR_endtime.Size = new Size(222, 38);
            HR_endtime.TabIndex = 15;
            // 
            // HR_starttime
            // 
            HR_starttime.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            HR_starttime.Location = new Point(775, 16);
            HR_starttime.Name = "HR_starttime";
            HR_starttime.Size = new Size(222, 38);
            HR_starttime.TabIndex = 15;
            // 
            // Days30_HR
            // 
            Days30_HR.BackColor = Color.Cyan;
            Days30_HR.FlatAppearance.BorderColor = Color.White;
            Days30_HR.FlatAppearance.BorderSize = 0;
            Days30_HR.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Days30_HR.Location = new Point(249, 72);
            Days30_HR.Name = "Days30_HR";
            Days30_HR.Size = new Size(226, 41);
            Days30_HR.TabIndex = 11;
            Days30_HR.Text = "30天心率歷史數據";
            Days30_HR.UseVisualStyleBackColor = false;
            Days30_HR.Click += Days30_HR_Click;
            // 
            // Days7_HR
            // 
            Days7_HR.BackColor = Color.Cyan;
            Days7_HR.FlatAppearance.BorderColor = Color.White;
            Days7_HR.FlatAppearance.BorderSize = 0;
            Days7_HR.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Days7_HR.Location = new Point(18, 72);
            Days7_HR.Name = "Days7_HR";
            Days7_HR.Size = new Size(207, 41);
            Days7_HR.TabIndex = 10;
            Days7_HR.Text = "7天心率歷史數據";
            Days7_HR.UseVisualStyleBackColor = false;
            Days7_HR.Click += Days7_HR_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // DashBord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1400, 803);
            ControlBox = false;
            Controls.Add(unusual_events_display);
            Controls.Add(panel1);
            Controls.Add(BP_HISTORY);
            Controls.Add(HR_HISTORY);
            Controls.Add(BT_HISTORY);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DashBord";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DashBord";
            Load += DashBord_Load;
            ((System.ComponentModel.ISupportInitialize)Close).EndInit();
            ((System.ComponentModel.ISupportInitialize)Sizeable).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            unusual_events_display.ResumeLayout(false);
            unusual_events_display.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            BT_HISTORY.ResumeLayout(false);
            BT_HISTORY.PerformLayout();
            BP_HISTORY.ResumeLayout(false);
            BP_HISTORY.PerformLayout();
            HR_HISTORY.ResumeLayout(false);
            HR_HISTORY.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Close;
        private PictureBox Sizeable;
        private Panel panel1;
        private Button P_HR_history;
        private Button unusual_events;
        private Button P_BT_history;
        private Button P_BP_history;
        private Label label1;
        private Panel unusual_events_display;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private TextBox room_nb;
        private Label label5;
        private Label P_name;
        private TextBox bed_nb;
        private Label BT;
        private Label BT_DATE;
        private Label HR;
        private Label WT;
        private Label HT;
        private Label BP;
        private Button get_P;
        private Label Time;
        private Panel panel3;
        private Panel panel2;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private ScottPlot.WinForms.FormsPlot Days5_BT;
        private Panel BT_HISTORY;
        private Panel BP_HISTORY;
        private Panel HR_HISTORY;
        private Button Days7_BT;
        private DateTimePicker BT_starttime;
        private Button BT_research;
        private Label to;
        private DateTimePicker BT_endtime;
        private Button Days30_BT;
        private ScottPlot.WinForms.FormsPlot BT_DATA;
        private Button HR_research;
        private Label label6;
        private DateTimePicker HR_endtime;
        private DateTimePicker HR_starttime;
        private Button Days30_HR;
        private Button Days7_HR;
        private Button BP_research;
        private DateTimePicker BP_endtime;
        private Label label7;
        private DateTimePicker BP_starttime;
        private Button Days30_BP;
        private Button Days7_BP;
        private ScottPlot.WinForms.FormsPlot BP_DATA;
        private ScottPlot.WinForms.FormsPlot HR_DATA;
        private TextBox HR_History_bed;
        private Label label4;
        private TextBox HR_History_room;
        private Label label8;
        private Label HR_History_name;
        private TextBox BT_History_bed;
        private Label label9;
        private TextBox BT_History_room;
        private Label label10;
        private Label BT_History_name;
        private TextBox BP_History_bed;
        private Label label12;
        private TextBox BP_History_room;
        private Label label13;
        private Label BP_History_name;
        private DataGridViewTextBoxColumn roomnb;
        private DataGridViewTextBoxColumn bednb;
        private DataGridViewTextBoxColumn patient;
        private DataGridViewTextBoxColumn resault;
        private DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Timer timer1;
        private Button insert;
        private Button circle;
    }
}
