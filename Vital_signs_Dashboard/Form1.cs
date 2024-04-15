using System;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using ScottPlot;
using ScottPlot.WinForms;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Vital_signs_Dashboard
{
    public partial class DashBord : Form
    {
        static DateTime lastCheckTime = DateTime.Now;
        public DashBord()
        {
            InitializeComponent();
        }

        private void DashBord_Load(object sender, EventArgs e)
        {


            timer1.Start();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sizeable_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void get_P_Click(object sender, EventArgs e)
        {
            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                object id = null;
                string queryP_ID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryP_ID, connection))
                {
                    command.Parameters.AddWithValue("@room", room_nb.Text.ToString());
                    command.Parameters.AddWithValue("@bed", bed_nb.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }

                string queryP_data = "SELECT * FROM patient WHERE ID = @P_ID ORDER BY date DESC LIMIT 1";
                using (SQLiteCommand command = new SQLiteCommand(queryP_data, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader["patientname"].ToString();
                            string bt = reader["bt"].ToString();
                            string bp_sbp = reader["bp_sbp"].ToString();
                            string bp_dbp = reader["bp_dbp"].ToString();
                            string hr = reader["hr"].ToString();
                            string wt = reader["wt"].ToString();
                            string ht = reader["ht"].ToString();
                            string date = reader["date"].ToString();
                            P_name.Text = "患者:" + name;
                            BT.Text = "體溫:" + bt + " °C";
                            BP.Text = "血壓:" + bp_sbp + " mmHg" + "/" + bp_dbp + " mmHg";
                            HR.Text = "心率:" + hr + " bpm";
                            WT.Text = "體重:" + wt + " KG";
                            HT.Text = "身高:" + ht + " CM";
                            DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-ddTHH:mm:ss", null);
                            string dateString = dateTime.ToString("yyyy-MM-dd");
                            string timeString = dateTime.ToString("HH:mm:ss");
                            BT_DATE.Text = "上次檢測日期:" + dateString;
                            Time.Text = "上次檢測時間:" + timeString;
                        }
                        else
                        {
                            MessageBox.Show("查無此病人生命象徵資料", "提示");
                            return;
                        }
                    }
                }
                List<DateTime> times = new List<DateTime>();
                List<double> temperatures = new List<double>();

                string queryP_5D_data = "SELECT bt,date FROM patient WHERE ID = @P_ID AND date >= date('now', '-5 days')";
                using (SQLiteCommand command = new SQLiteCommand(queryP_5D_data, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double temperature = Convert.ToDouble(reader["bt"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                times.Add(date);
                                temperatures.Add(temperature);
                            }
                        }
                        else
                        {
                            MessageBox.Show("查無此病人歷史資料", "提示");
                            return;
                        }
                    }
                }


                DateTime[] xs = times.ToArray();
                double[] ys = temperatures.ToArray();

                Days5_BT.Plot.Clear();
                Days5_BT.Plot.Add.Scatter(xs, ys);
                Days5_BT.Plot.Add.Scatter(xs, ys).Label = "bt";
                Days5_BT.Plot.ShowLegend();
                Days5_BT.Plot.Axes.DateTimeTicksBottom();
                Days5_BT.Plot.Axes.Margins(bottom: 0);
                Days5_BT.Plot.RenderManager.RenderStarting += (s, e) =>
                {
                    Days5_BT.Plot.XLabel("TIME");
                    Days5_BT.Plot.YLabel("Temperature");
                    //X軸Label
                    Tick[] ticks = Days5_BT.Plot.Axes.Bottom.TickGenerator.Ticks;
                    for (int i = 0; i < ticks.Length; i++)
                    {
                        DateTime dt = DateTime.FromOADate(ticks[i].Position);
                        string label = $"{dt:M/dd HH:mm}";
                        ticks[i] = new Tick(ticks[i].Position, label);
                        Days5_BT.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
                        Days5_BT.Plot.Axes.Bottom.TickLabelStyle.OffsetY = -8;
                        Days5_BT.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    }
                    float largestLabelWidth = 0;
                    foreach (Tick tick in ticks)
                    {
                        PixelSize size = Days5_BT.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label);
                        largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                    }

                    // ensure axis panels do not get smaller than the largest label
                    Days5_BT.Plot.Axes.Bottom.MinimumSize = largestLabelWidth * 2;
                    Days5_BT.Plot.Axes.Right.MinimumSize = largestLabelWidth * 2;
                };
                Days5_BT.Plot.Axes.SetLimitsY(bottom: 0, top: 45);
                Days5_BT.Refresh();
            }


        }

        private void unusual_events_display_Paint(object sender, PaintEventArgs e)
        {

        }

        private void P_BT_history_Click(object sender, EventArgs e)
        {
            unusual_events_display.Visible = false;
            BT_HISTORY.Visible = true;
            BP_HISTORY.Visible = false;
            HR_HISTORY.Visible = false;
        }

        private void P_BP_history_Click(object sender, EventArgs e)
        {
            unusual_events_display.Visible = false;
            BT_HISTORY.Visible = false;
            BP_HISTORY.Visible = true;
            HR_HISTORY.Visible = false;
        }

        private void P_HR_history_Click(object sender, EventArgs e)
        {
            unusual_events_display.Visible = false;
            BT_HISTORY.Visible = false;
            BP_HISTORY.Visible = false;
            HR_HISTORY.Visible = true;
        }

        private void HR_research_Click(object sender, EventArgs e)
        {

            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                object id = null;
                string queryP_7Days_ID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7Days_ID, connection))
                {
                    command.Parameters.AddWithValue("@room", HR_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", HR_History_bed.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }

                string patientname_qu = "SELECT patientname FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(patientname_qu, connection))
                {
                    command.Parameters.AddWithValue("@room", HR_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", HR_History_bed.Text.ToString());
                    HR_History_name.Text = "患者:" + command.ExecuteScalar().ToString();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }

                List<DateTime> times = new List<DateTime>();
                List<double> hr = new List<double>();
                DateTime startDate = HR_starttime.Value.Date;
                DateTime endDate = HR_endtime.Value.Date.AddDays(1).AddSeconds(-1);
                // 將日期轉換為 SQL Server DateTime 格式的字符串
                string startDateString = startDate.ToString("yyyy-MM-ddTHH:mm:ss");
                string endDateString = endDate.ToString("yyyy-MM-ddTHH:mm:ss");

                string HR_research = "SELECT hr,date FROM patient WHERE ID = @P_ID AND date >= @StartDate AND date <= @EndDate";
                using (SQLiteCommand command = new SQLiteCommand(HR_research, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    command.Parameters.AddWithValue("@StartDate", startDateString);
                    command.Parameters.AddWithValue("@EndDate", endDateString);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double temperature = Convert.ToDouble(reader["hr"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                times.Add(date);
                                hr.Add(temperature);
                            }

                        }
                        else
                        {
                            MessageBox.Show("查無此病人歷史資料", "提示");
                            return;
                        }
                    }
                }


                DateTime[] xs = times.ToArray();
                double[] ys = hr.ToArray();

                HR_DATA.Plot.Clear();
                HR_DATA.Plot.Add.Scatter(xs, ys);
                HR_DATA.Plot.Add.Scatter(xs, ys).Label = "HR";
                HR_DATA.Plot.ShowLegend();
                HR_DATA.Plot.Axes.DateTimeTicksBottom();
                HR_DATA.Plot.RenderManager.RenderStarting += (s, e) =>
                {
                    HR_DATA.Plot.XLabel("TIME");
                    HR_DATA.Plot.YLabel("HR");
                    //X軸Label
                    Tick[] ticks = HR_DATA.Plot.Axes.Bottom.TickGenerator.Ticks;
                    for (int i = 0; i < ticks.Length; i++)
                    {
                        DateTime dt = DateTime.FromOADate(ticks[i].Position);
                        string label = $"{dt:M/dd HH:mm}";
                        ticks[i] = new Tick(ticks[i].Position, label);
                        HR_DATA.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
                        HR_DATA.Plot.Axes.Bottom.TickLabelStyle.OffsetY = -8;
                        HR_DATA.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    }
                    float largestLabelWidth = 0;
                    foreach (Tick tick in ticks)
                    {
                        PixelSize size = HR_DATA.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label);
                        largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                    }

                    // ensure axis panels do not get smaller than the largest label
                    HR_DATA.Plot.Axes.Bottom.MinimumSize = largestLabelWidth * 2;
                    HR_DATA.Plot.Axes.Right.MinimumSize = largestLabelWidth * 2;
                };
                HR_DATA.Plot.Axes.SetLimitsY(bottom: 0, top: 250);
                HR_DATA.Refresh();
            }


        }

        private void BT_research_Click(object sender, EventArgs e)
        {

            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                object id = null;
                string queryP_7Days_ID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7Days_ID, connection))
                {
                    command.Parameters.AddWithValue("@room", BT_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BT_History_bed.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }

                string patientname_qu = "SELECT patientname FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(patientname_qu, connection))
                {
                    command.Parameters.AddWithValue("@room", BT_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BT_History_bed.Text.ToString());
                    BT_History_name.Text = "患者:" + command.ExecuteScalar().ToString();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                List<DateTime> times = new List<DateTime>();
                List<double> hr = new List<double>();
                DateTime startDate = BT_starttime.Value.Date;
                DateTime endDate = BT_endtime.Value.Date.AddDays(1).AddSeconds(-1);
                // 將日期轉換為 SQL Server DateTime 格式的字符串
                string startDateString = startDate.ToString("yyyy-MM-ddTHH:mm:ss");
                string endDateString = endDate.ToString("yyyy-MM-ddTHH:mm:ss");

                string bt_research = "SELECT bt,date FROM patient WHERE ID = @P_ID AND date >= @StartDate AND date <= @EndDate";
                using (SQLiteCommand command = new SQLiteCommand(bt_research, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    command.Parameters.AddWithValue("@StartDate", startDateString);
                    command.Parameters.AddWithValue("@EndDate", endDateString);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double temperature = Convert.ToDouble(reader["bt"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                times.Add(date);
                                hr.Add(temperature);
                            }

                        }
                        else
                        {
                            MessageBox.Show("查無此病人歷史資料", "提示");
                            return;
                        }
                    }
                }


                DateTime[] xs = times.ToArray();
                double[] ys = hr.ToArray();

                BT_DATA.Plot.Clear();
                BT_DATA.Plot.Add.Scatter(xs, ys);
                BT_DATA.Plot.Add.Scatter(xs, ys).Label = "BT";
                BT_DATA.Plot.ShowLegend();
                BT_DATA.Plot.Axes.DateTimeTicksBottom();
                BT_DATA.Plot.RenderManager.RenderStarting += (s, e) =>
                {
                    BT_DATA.Plot.XLabel("TIME");
                    BT_DATA.Plot.YLabel("BT");
                    //X軸Label
                    Tick[] ticks = BT_DATA.Plot.Axes.Bottom.TickGenerator.Ticks;
                    for (int i = 0; i < ticks.Length; i++)
                    {
                        DateTime dt = DateTime.FromOADate(ticks[i].Position);
                        string label = $"{dt:M/dd HH:mm}";
                        ticks[i] = new Tick(ticks[i].Position, label);
                        BT_DATA.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
                        BT_DATA.Plot.Axes.Bottom.TickLabelStyle.OffsetY = -8;
                        BT_DATA.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    }
                    float largestLabelWidth = 0;
                    foreach (Tick tick in ticks)
                    {
                        PixelSize size = BT_DATA.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label);
                        largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                    }

                    // ensure axis panels do not get smaller than the largest label
                    BT_DATA.Plot.Axes.Bottom.MinimumSize = largestLabelWidth * 2;
                    BT_DATA.Plot.Axes.Right.MinimumSize = largestLabelWidth * 2;
                };
                BT_DATA.Plot.Axes.SetLimitsY(bottom: 0, top: 45);
                BT_DATA.Refresh();
            }
        }

        private void BP_research_Click(object sender, EventArgs e)
        {

            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                object id = null;
                string queryP_7Days_ID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7Days_ID, connection))
                {
                    command.Parameters.AddWithValue("@room", BP_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BP_History_bed.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                string patientname_qu = "SELECT patientname FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(patientname_qu, connection))
                {
                    command.Parameters.AddWithValue("@room", BP_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BP_History_bed.Text.ToString());
                    BP_History_name.Text = "患者:" + command.ExecuteScalar().ToString();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                List<DateTime> times = new List<DateTime>();
                List<double> bp_sbp = new List<double>();
                List<double> bp_dbp = new List<double>();
                DateTime startDate = BP_starttime.Value.Date;
                DateTime endDate = BP_endtime.Value.Date.AddDays(1).AddSeconds(-1);
                // 將日期轉換為 SQL Server DateTime 格式的字符串
                string startDateString = startDate.ToString("yyyy-MM-ddTHH:mm:ss");
                string endDateString = endDate.ToString("yyyy-MM-ddTHH:mm:ss");

                string BP_research = "SELECT bp_sbp,bp_dbp,date FROM patient WHERE ID = @P_ID AND date >= @StartDate AND date <= @EndDate";
                using (SQLiteCommand command = new SQLiteCommand(BP_research, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    command.Parameters.AddWithValue("@StartDate", startDateString);
                    command.Parameters.AddWithValue("@EndDate", endDateString);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double bp_sbp_ = Convert.ToDouble(reader["bp_sbp"]);
                                double bp_dbp_ = Convert.ToDouble(reader["bp_dbp"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                times.Add(date);
                                bp_sbp.Add(bp_sbp_);
                                bp_dbp.Add(bp_dbp_);
                            }

                        }
                        else
                        {
                            MessageBox.Show("查無此病人歷史資料", "提示");
                            return;
                        }
                    }
                }


                DateTime[] xs = times.ToArray();
                double[] ys = bp_sbp.ToArray();
                double[] ys2 = bp_dbp.ToArray();

                BP_DATA.Plot.Clear();
                BP_DATA.Plot.Add.Scatter(xs, ys);
                BP_DATA.Plot.Add.Scatter(xs, ys2);
                BP_DATA.Plot.Add.Scatter(xs, ys).Label = "bp_sbp.";
                BP_DATA.Plot.Add.Scatter(xs, ys2).Label = "bp_dbp";
                BP_DATA.Plot.ShowLegend();
                BP_DATA.Plot.Axes.DateTimeTicksBottom();
                BP_DATA.Plot.RenderManager.RenderStarting += (s, e) =>
                {
                    BP_DATA.Plot.XLabel("TIME");
                    BP_DATA.Plot.YLabel("BT");
                    //X軸Label
                    Tick[] ticks = BP_DATA.Plot.Axes.Bottom.TickGenerator.Ticks;
                    for (int i = 0; i < ticks.Length; i++)
                    {
                        DateTime dt = DateTime.FromOADate(ticks[i].Position);
                        string label = $"{dt:M/dd HH:mm}";
                        ticks[i] = new Tick(ticks[i].Position, label);
                        BP_DATA.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
                        BP_DATA.Plot.Axes.Bottom.TickLabelStyle.OffsetY = -8;
                        BP_DATA.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    }
                    float largestLabelWidth = 0;
                    foreach (Tick tick in ticks)
                    {
                        PixelSize size = BP_DATA.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label);
                        largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                    }

                    // ensure axis panels do not get smaller than the largest label
                    BP_DATA.Plot.Axes.Bottom.MinimumSize = largestLabelWidth * 2;
                    BP_DATA.Plot.Axes.Right.MinimumSize = largestLabelWidth * 2;
                };
                BP_DATA.Plot.Axes.SetLimitsY(bottom: 0, top: 300);
                BP_DATA.Refresh();
            }

        }

        private void Days7_HR_Click(object sender, EventArgs e)
        {
            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                object id = null;
                string queryP_7Days_ID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7Days_ID, connection))
                {
                    command.Parameters.AddWithValue("@room", HR_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", HR_History_bed.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                string patientname_qu = "SELECT patientname FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(patientname_qu, connection))
                {
                    command.Parameters.AddWithValue("@room", HR_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", HR_History_bed.Text.ToString());
                    HR_History_name.Text = "患者:" + command.ExecuteScalar().ToString();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                List<DateTime> times = new List<DateTime>();
                List<double> hr = new List<double>();

                string queryP_7D_data = "SELECT hr,date FROM patient WHERE ID = @P_ID AND date >= date('now', '-6 days')";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7D_data, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double temperature = Convert.ToDouble(reader["hr"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                times.Add(date);
                                hr.Add(temperature);
                            }

                        }
                        else
                        {
                            MessageBox.Show("查無此病人歷史資料", "提示");
                            return;
                        }
                    }
                }


                DateTime[] xs = times.ToArray();
                double[] ys = hr.ToArray();

                HR_DATA.Plot.Clear();
                HR_DATA.Plot.Add.Scatter(xs, ys);
                HR_DATA.Plot.Add.Scatter(xs, ys).Label = "HR";
                HR_DATA.Plot.ShowLegend();
                HR_DATA.Plot.Axes.DateTimeTicksBottom();
                HR_DATA.Plot.RenderManager.RenderStarting += (s, e) =>
                {
                    HR_DATA.Plot.XLabel("TIME");
                    HR_DATA.Plot.YLabel("HR");
                    //X軸Label
                    Tick[] ticks = HR_DATA.Plot.Axes.Bottom.TickGenerator.Ticks;
                    for (int i = 0; i < ticks.Length; i++)
                    {
                        DateTime dt = DateTime.FromOADate(ticks[i].Position);
                        string label = $"{dt:M/dd HH:mm}";
                        ticks[i] = new Tick(ticks[i].Position, label);
                        HR_DATA.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
                        HR_DATA.Plot.Axes.Bottom.TickLabelStyle.OffsetY = -8;
                        HR_DATA.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    }
                    float largestLabelWidth = 0;
                    foreach (Tick tick in ticks)
                    {
                        PixelSize size = HR_DATA.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label);
                        largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                    }

                    // ensure axis panels do not get smaller than the largest label
                    HR_DATA.Plot.Axes.Bottom.MinimumSize = largestLabelWidth * 2;
                    HR_DATA.Plot.Axes.Right.MinimumSize = largestLabelWidth * 2;
                };
                HR_DATA.Plot.Axes.SetLimitsY(bottom: 0, top: 250);
                HR_DATA.Refresh();
            }


        }

        private void Days30_HR_Click(object sender, EventArgs e)
        {

            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                object id = null;
                string queryP_7Days_ID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7Days_ID, connection))
                {
                    command.Parameters.AddWithValue("@room", HR_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", HR_History_bed.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                string patientname_qu = "SELECT patientname FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(patientname_qu, connection))
                {
                    command.Parameters.AddWithValue("@room", HR_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", HR_History_bed.Text.ToString());
                    HR_History_name.Text = "患者:" + command.ExecuteScalar().ToString();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                List<DateTime> times = new List<DateTime>();
                List<double> hr = new List<double>();

                string queryP_7D_data = "SELECT hr,date FROM patient WHERE ID = @P_ID AND date >= date('now', '-30 days')";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7D_data, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double temperature = Convert.ToDouble(reader["hr"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                times.Add(date);
                                hr.Add(temperature);
                            }

                        }
                        else
                        {
                            MessageBox.Show("查無此病人歷史資料", "提示");
                            return;
                        }
                    }
                }


                DateTime[] xs = times.ToArray();
                double[] ys = hr.ToArray();

                HR_DATA.Plot.Clear();
                HR_DATA.Plot.Add.Scatter(xs, ys);
                HR_DATA.Plot.Add.Scatter(xs, ys).Label = "HR";
                HR_DATA.Plot.ShowLegend();
                HR_DATA.Plot.Axes.DateTimeTicksBottom();
                HR_DATA.Plot.RenderManager.RenderStarting += (s, e) =>
                {
                    HR_DATA.Plot.XLabel("TIME");
                    HR_DATA.Plot.YLabel("HR");
                    //X軸Label
                    Tick[] ticks = HR_DATA.Plot.Axes.Bottom.TickGenerator.Ticks;
                    for (int i = 0; i < ticks.Length; i++)
                    {
                        DateTime dt = DateTime.FromOADate(ticks[i].Position);
                        string label = $"{dt:M/dd HH:mm}";
                        ticks[i] = new Tick(ticks[i].Position, label);
                        HR_DATA.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
                        HR_DATA.Plot.Axes.Bottom.TickLabelStyle.OffsetY = -8;
                        HR_DATA.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    }
                    float largestLabelWidth = 0;
                    foreach (Tick tick in ticks)
                    {
                        PixelSize size = HR_DATA.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label);
                        largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                    }

                    // ensure axis panels do not get smaller than the largest label
                    HR_DATA.Plot.Axes.Bottom.MinimumSize = largestLabelWidth * 2;
                    HR_DATA.Plot.Axes.Right.MinimumSize = largestLabelWidth * 2;
                };
                HR_DATA.Plot.Axes.SetLimitsY(bottom: 0, top: 250);
                HR_DATA.Refresh();
            }


        }

        private void Days7_BT_Click(object sender, EventArgs e)
        {
            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                object id = null;
                string queryP_7Days_ID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7Days_ID, connection))
                {
                    command.Parameters.AddWithValue("@room", BT_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BT_History_bed.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                string patientname_qu = "SELECT patientname FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(patientname_qu, connection))
                {
                    command.Parameters.AddWithValue("@room", BT_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BT_History_bed.Text.ToString());
                    BT_History_name.Text = "患者:" + command.ExecuteScalar().ToString();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                List<DateTime> times = new List<DateTime>();
                List<double> bt = new List<double>();

                string queryP_7D_data = "SELECT bt,date FROM patient WHERE ID = @P_ID AND date >= date('now', '-6 days')";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7D_data, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double temperature = Convert.ToDouble(reader["bt"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                times.Add(date);
                                bt.Add(temperature);
                            }

                        }
                        else
                        {
                            MessageBox.Show("查無此病人歷史資料", "提示");
                            return;
                        }
                    }
                }


                DateTime[] xs = times.ToArray();
                double[] ys = bt.ToArray();

                BT_DATA.Plot.Clear();
                BT_DATA.Plot.Add.Scatter(xs, ys);
                BT_DATA.Plot.Add.Scatter(xs, ys).Label = "BT";
                BT_DATA.Plot.ShowLegend();
                BT_DATA.Plot.Axes.DateTimeTicksBottom();
                BT_DATA.Plot.RenderManager.RenderStarting += (s, e) =>
                {
                    BT_DATA.Plot.XLabel("TIME");
                    BT_DATA.Plot.YLabel("BT");
                    //X軸Label
                    Tick[] ticks = BT_DATA.Plot.Axes.Bottom.TickGenerator.Ticks;
                    for (int i = 0; i < ticks.Length; i++)
                    {
                        DateTime dt = DateTime.FromOADate(ticks[i].Position);
                        string label = $"{dt:M/dd HH:mm}";
                        ticks[i] = new Tick(ticks[i].Position, label);
                        BT_DATA.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
                        BT_DATA.Plot.Axes.Bottom.TickLabelStyle.OffsetY = -8;
                        BT_DATA.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    }
                    float largestLabelWidth = 0;
                    foreach (Tick tick in ticks)
                    {
                        PixelSize size = BT_DATA.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label);
                        largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                    }

                    // ensure axis panels do not get smaller than the largest label
                    BT_DATA.Plot.Axes.Bottom.MinimumSize = largestLabelWidth * 2;
                    BT_DATA.Plot.Axes.Right.MinimumSize = largestLabelWidth * 2;
                };
                BT_DATA.Plot.Axes.SetLimitsY(bottom: 0, top: 45);
                BT_DATA.Refresh();
            }
        }

        private void Days30_BT_Click(object sender, EventArgs e)
        {
            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                object id = null;
                string queryP_7Days_ID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7Days_ID, connection))
                {
                    command.Parameters.AddWithValue("@room", BT_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BT_History_bed.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                string patientname_qu = "SELECT patientname FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(patientname_qu, connection))
                {
                    command.Parameters.AddWithValue("@room", BT_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BT_History_bed.Text.ToString());
                    BT_History_name.Text = "患者:" + command.ExecuteScalar().ToString();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                List<DateTime> times = new List<DateTime>();
                List<double> bt = new List<double>();

                string queryP_30D_data = "SELECT bt,date FROM patient WHERE ID = @P_ID AND date >= date('now', '-30 days')";
                using (SQLiteCommand command = new SQLiteCommand(queryP_30D_data, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double temperature = Convert.ToDouble(reader["bt"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                times.Add(date);
                                bt.Add(temperature);
                            }

                        }
                        else
                        {
                            MessageBox.Show("查無此病人歷史資料", "提示");
                            return;
                        }
                    }
                }


                DateTime[] xs = times.ToArray();
                double[] ys = bt.ToArray();

                BT_DATA.Plot.Clear();
                BT_DATA.Plot.Add.Scatter(xs, ys);
                BT_DATA.Plot.Add.Scatter(xs, ys).Label = "BT";
                BT_DATA.Plot.ShowLegend();
                BT_DATA.Plot.Axes.DateTimeTicksBottom();
                BT_DATA.Plot.RenderManager.RenderStarting += (s, e) =>
                {
                    BT_DATA.Plot.XLabel("TIME");
                    BT_DATA.Plot.YLabel("BT");
                    //X軸Label
                    Tick[] ticks = BT_DATA.Plot.Axes.Bottom.TickGenerator.Ticks;
                    for (int i = 0; i < ticks.Length; i++)
                    {
                        DateTime dt = DateTime.FromOADate(ticks[i].Position);
                        string label = $"{dt:M/dd HH:mm}";
                        ticks[i] = new Tick(ticks[i].Position, label);
                        BT_DATA.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
                        BT_DATA.Plot.Axes.Bottom.TickLabelStyle.OffsetY = -8;
                        BT_DATA.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    }
                    float largestLabelWidth = 0;
                    foreach (Tick tick in ticks)
                    {
                        PixelSize size = BT_DATA.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label);
                        largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                    }

                    // ensure axis panels do not get smaller than the largest label
                    BT_DATA.Plot.Axes.Bottom.MinimumSize = largestLabelWidth * 2;
                    BT_DATA.Plot.Axes.Right.MinimumSize = largestLabelWidth * 2;
                };
                BT_DATA.Plot.Axes.SetLimitsY(bottom: 0, top: 45);
                BT_DATA.Refresh();
            }
        }

        private void Days7_BP_Click(object sender, EventArgs e)
        {
            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                object id = null;
                string queryP_7Days_ID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7Days_ID, connection))
                {
                    command.Parameters.AddWithValue("@room", BP_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BP_History_bed.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                string patientname_qu = "SELECT patientname FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(patientname_qu, connection))
                {
                    command.Parameters.AddWithValue("@room", BP_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BP_History_bed.Text.ToString());
                    BP_History_name.Text = "患者:" + command.ExecuteScalar().ToString();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                List<DateTime> times = new List<DateTime>();
                List<double> bp_sbp = new List<double>();
                List<double> bp_dbp = new List<double>();

                string queryP_30D_data = "SELECT bp_sbp,bp_dbp,date FROM patient WHERE ID = @P_ID AND date >= date('now', '-6 days')";
                using (SQLiteCommand command = new SQLiteCommand(queryP_30D_data, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double bp_sbp_ = Convert.ToDouble(reader["bp_sbp"]);
                                double bp_dbp_ = Convert.ToDouble(reader["bp_dbp"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                times.Add(date);
                                bp_sbp.Add(bp_sbp_);
                                bp_dbp.Add(bp_dbp_);
                            }

                        }
                        else
                        {
                            MessageBox.Show("查無此病人歷史資料", "提示");
                            return;
                        }
                    }
                }


                DateTime[] xs = times.ToArray();
                double[] ys = bp_sbp.ToArray();
                double[] ys2 = bp_dbp.ToArray();
                var sig1 = BP_DATA.Plot.Add.Signal(ys);

                BP_DATA.Plot.Clear();
                BP_DATA.Plot.ShowLegend();
                BP_DATA.Plot.Add.Scatter(xs, ys);
                BP_DATA.Plot.Add.Scatter(xs, ys2);
                BP_DATA.Plot.Add.Scatter(xs, ys).Label = "bp_sbp.";
                BP_DATA.Plot.Add.Scatter(xs, ys2).Label = "bp_dbp";
                BP_DATA.Plot.Axes.DateTimeTicksBottom();
                BP_DATA.Plot.RenderManager.RenderStarting += (s, e) =>
                {
                    BP_DATA.Plot.XLabel("TIME");
                    BP_DATA.Plot.YLabel("BT");
                    //X軸Label
                    Tick[] ticks = BP_DATA.Plot.Axes.Bottom.TickGenerator.Ticks;
                    for (int i = 0; i < ticks.Length; i++)
                    {
                        DateTime dt = DateTime.FromOADate(ticks[i].Position);
                        string label = $"{dt:M/dd HH:mm}";
                        ticks[i] = new Tick(ticks[i].Position, label);
                        BP_DATA.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
                        BP_DATA.Plot.Axes.Bottom.TickLabelStyle.OffsetY = -8;
                        BP_DATA.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    }
                    float largestLabelWidth = 0;
                    foreach (Tick tick in ticks)
                    {
                        PixelSize size = BP_DATA.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label);
                        largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                    }

                    // ensure axis panels do not get smaller than the largest label
                    BP_DATA.Plot.Axes.Bottom.MinimumSize = largestLabelWidth * 2;
                    BP_DATA.Plot.Axes.Right.MinimumSize = largestLabelWidth * 2;
                };
                BP_DATA.Plot.Axes.SetLimitsY(bottom: 0, top: 300);
                BP_DATA.Refresh();
            }
        }

        private void Days30_BP_Click(object sender, EventArgs e)
        {
            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                object id = null;
                string queryP_7Days_ID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryP_7Days_ID, connection))
                {
                    command.Parameters.AddWithValue("@room", BP_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BP_History_bed.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                string patientname_qu = "SELECT patientname FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(patientname_qu, connection))
                {
                    command.Parameters.AddWithValue("@room", BP_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BP_History_bed.Text.ToString());
                    BP_History_name.Text = "患者:" + command.ExecuteScalar().ToString();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }
                List<DateTime> times = new List<DateTime>();
                List<double> bp_sbp = new List<double>();
                List<double> bp_dbp = new List<double>();

                string queryP_30D_data = "SELECT bp_sbp,bp_dbp,date FROM patient WHERE ID = @P_ID AND date >= date('now', '-30 days')";
                using (SQLiteCommand command = new SQLiteCommand(queryP_30D_data, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                double bp_sbp_ = Convert.ToDouble(reader["bp_sbp"]);
                                double bp_dbp_ = Convert.ToDouble(reader["bp_dbp"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                times.Add(date);
                                bp_sbp.Add(bp_sbp_);
                                bp_dbp.Add(bp_dbp_);
                            }

                        }
                        else
                        {
                            MessageBox.Show("查無此病人歷史資料", "提示");
                            return;
                        }
                    }
                }


                DateTime[] xs = times.ToArray();
                double[] ys = bp_sbp.ToArray();
                double[] ys2 = bp_dbp.ToArray();

                BP_DATA.Plot.Clear();
                BP_DATA.Plot.Add.Scatter(xs, ys);
                BP_DATA.Plot.Add.Scatter(xs, ys2);
                BP_DATA.Plot.Add.Scatter(xs, ys).Label = "bp_sbp.";
                BP_DATA.Plot.Add.Scatter(xs, ys2).Label = "bp_dbp";
                BP_DATA.Plot.ShowLegend();
                BP_DATA.Plot.Axes.DateTimeTicksBottom();
                BP_DATA.Plot.RenderManager.RenderStarting += (s, e) =>
                {
                    BP_DATA.Plot.XLabel("TIME");
                    BP_DATA.Plot.YLabel("BT");
                    //X軸Label
                    Tick[] ticks = BP_DATA.Plot.Axes.Bottom.TickGenerator.Ticks;
                    for (int i = 0; i < ticks.Length; i++)
                    {
                        DateTime dt = DateTime.FromOADate(ticks[i].Position);
                        string label = $"{dt:M/dd HH:mm}";
                        ticks[i] = new Tick(ticks[i].Position, label);
                        BP_DATA.Plot.Axes.Bottom.TickLabelStyle.Rotation = -45;
                        BP_DATA.Plot.Axes.Bottom.TickLabelStyle.OffsetY = -8;
                        BP_DATA.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.MiddleRight;
                    }
                    float largestLabelWidth = 0;
                    foreach (Tick tick in ticks)
                    {
                        PixelSize size = BP_DATA.Plot.Axes.Bottom.TickLabelStyle.Measure(tick.Label);
                        largestLabelWidth = Math.Max(largestLabelWidth, size.Width);
                    }

                    // ensure axis panels do not get smaller than the largest label
                    BP_DATA.Plot.Axes.Bottom.MinimumSize = largestLabelWidth * 2;
                    BP_DATA.Plot.Axes.Right.MinimumSize = largestLabelWidth * 2;
                };
                BP_DATA.Plot.Axes.SetLimitsY(bottom: 0, top: 300);
                BP_DATA.Refresh();
            }
        }

        private void unusual_events_Click(object sender, EventArgs e)
        {
            unusual_events_display.Visible = true;
            BT_HISTORY.Visible = false;
            BP_HISTORY.Visible = false;
            HR_HISTORY.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string lastCheckTimeformmat = lastCheckTime.ToString("yyyy-MM-ddTHH:mm:ss");
            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                string query = "SELECT * FROM patient WHERE date > @LastCheckTime";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LastCheckTime", lastCheckTimeformmat);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            string patientname = null;
                            string room_nb = null;
                            string bed_nb = null;
                            string result = "";
                            while (reader.Read())
                            {
                                double bt_ = Convert.ToDouble(reader["bt"]);
                                double hr_ = Convert.ToDouble(reader["hr"]);
                                double bp_sbp_ = Convert.ToDouble(reader["bp_sbp"]);
                                double bp_dbp_ = Convert.ToDouble(reader["bp_dbp"]);
                                DateTime date = Convert.ToDateTime(reader["date"]);
                                string id = Convert.ToString(reader["ID"]);

                                if (bt_ > 38)
                                {
                                    result = "體溫異常";
                                    string query_room = "SELECT * FROM room WHERE ID = @id";
                                    using (SQLiteCommand command1 = new SQLiteCommand(query_room, connection))
                                    {
                                        command1.Parameters.AddWithValue("@id", id);
                                        using (SQLiteDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                room_nb = reader1["room_nb"].ToString();
                                                bed_nb = reader1["bed_nb"].ToString();
                                                patientname = reader1["patientname"].ToString();
                                            }
                                            dataGridView1.Rows.Add(room_nb, bed_nb, patientname, result, date);
                                        }
                                    }

                                };
                                if (hr_ > 110)
                                {
                                    result = "心率異常";
                                    string query_room = "SELECT * FROM room WHERE ID = @id";
                                    using (SQLiteCommand command1 = new SQLiteCommand(query_room, connection))
                                    {
                                        command1.Parameters.AddWithValue("@id", id);
                                        using (SQLiteDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                room_nb = reader1["room_nb"].ToString();
                                                bed_nb = reader1["bed_nb"].ToString();
                                                patientname = reader1["patientname"].ToString();
                                            }
                                            dataGridView1.Rows.Add(room_nb, bed_nb, patientname, result, date);
                                        }
                                    }

                                };
                                if (bp_sbp_ > 120)
                                {
                                    result = "舒張壓異常";
                                    string query_room = "SELECT * FROM room WHERE ID = @id";
                                    using (SQLiteCommand command1 = new SQLiteCommand(query_room, connection))
                                    {
                                        command1.Parameters.AddWithValue("@id", id);
                                        using (SQLiteDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                room_nb = reader1["room_nb"].ToString();
                                                bed_nb = reader1["bed_nb"].ToString();
                                                patientname = reader1["patientname"].ToString();
                                            }
                                            dataGridView1.Rows.Add(room_nb, bed_nb, patientname, result, date);
                                        }
                                    }

                                };
                                if (bp_dbp_ > 80)
                                {
                                    result = "收縮壓異常";
                                    string query_room = "SELECT * FROM room WHERE ID = @id";
                                    using (SQLiteCommand command1 = new SQLiteCommand(query_room, connection))
                                    {
                                        command1.Parameters.AddWithValue("@id", id);
                                        using (SQLiteDataReader reader1 = command1.ExecuteReader())
                                        {
                                            while (reader1.Read())
                                            {
                                                room_nb = reader1["room_nb"].ToString();
                                                bed_nb = reader1["bed_nb"].ToString();
                                                patientname = reader1["patientname"].ToString();
                                            }
                                            dataGridView1.Rows.Add(room_nb, bed_nb, patientname, result, date);
                                        }
                                    }

                                };
                            }
                            lastCheckTime = DateTime.Now;
                        }
                        else
                        {
                            lastCheckTime = DateTime.Now;
                        }
                    }
                }
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            Form2 insert = new Form2();
            insert.Show();

        }

        private void circle_Click(object sender, EventArgs e)
        {
            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";
            int count = 0;
            int btcount = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                
                object id = null;
                string queryPID = "SELECT ID FROM room WHERE room_nb = @room AND bed_nb = @bed";
                using (SQLiteCommand command = new SQLiteCommand(queryPID, connection))
                {
                    command.Parameters.AddWithValue("@room", BT_History_room.Text.ToString());
                    command.Parameters.AddWithValue("@bed", BT_History_bed.Text.ToString());
                    id = command.ExecuteScalar();
                    if (id == null)
                    {
                        MessageBox.Show("查無此病人資料", "提示");
                        return;
                    }

                }

                List<DateTime> times = new List<DateTime>();
                List<double> hr = new List<double>();
                DateTime startDate = BT_starttime.Value.Date;
                DateTime endDate = BT_endtime.Value.Date.AddDays(1).AddSeconds(-1);
                // 將日期轉換為 SQL Server DateTime 格式的字符串
                string startDateString = startDate.ToString("yyyy-MM-ddTHH:mm:ss");
                string endDateString = endDate.ToString("yyyy-MM-ddTHH:mm:ss");
                double bt = 38.0;

                string countnm = "SELECT COUNT(*) FROM patient WHERE ID = @P_ID AND date >= @StartDate AND date <= @EndDate ";
                using (SQLiteCommand command = new SQLiteCommand(countnm, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    command.Parameters.AddWithValue("@StartDate", startDateString);
                    command.Parameters.AddWithValue("@EndDate", endDateString);
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
                string btcountnm = "SELECT COUNT(*) FROM patient WHERE ID = @P_ID AND date >= @StartDate AND date <= @EndDate AND bt > @bt ";
                using (SQLiteCommand command = new SQLiteCommand(btcountnm, connection))
                {
                    command.Parameters.AddWithValue("@P_ID", id.ToString());
                    command.Parameters.AddWithValue("@StartDate", startDateString);
                    command.Parameters.AddWithValue("@EndDate", endDateString);
                    command.Parameters.AddWithValue("@bt", bt);
                    btcount = Convert.ToInt32(command.ExecuteScalar());
                }
                
            }
            Form3 circle = new Form3(count,btcount);
            circle.Show();
        }
    }
}
