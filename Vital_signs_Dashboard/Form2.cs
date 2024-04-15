using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vital_signs_Dashboard
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            string bt = bt_insert.Text;
            string hr = hr_insert.Text;
            string bp_sbp = bp_sbp_insert.Text;
            string bp_dbp = bp_dbp_insert.Text;
            string patientname = "王小明";
            string ID = "A186571227";
            string wt = "77.0";
            string ht = "179.0";
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-ddTHH:mm:ss");

            string databasePath = "db\\vitalsigns.db";
            string connectionString = $"Data Source={databasePath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insert_data = "INSERT INTO patient(ID,patientname,bt,hr,wt,ht,date,bp_sbp,bp_dbp) " +
                    "VALUES (@ID,@patientname, @bt,@hr,@wt,@ht,@date,@bp_sbp,@bp_dbp )";
                using (SQLiteCommand command = new SQLiteCommand(insert_data, connection))
                {
                    command.Parameters.AddWithValue("@ID",ID);
                    command.Parameters.AddWithValue("@patientname", patientname);
                    command.Parameters.AddWithValue("@bt",bt);
                    command.Parameters.AddWithValue("@hr",hr);
                    command.Parameters.AddWithValue("@wt",wt);
                    command.Parameters.AddWithValue("@ht",ht);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@bp_sbp", bp_sbp);
                    command.Parameters.AddWithValue("@bp_dbp", bp_dbp);
                    command.ExecuteNonQuery();
                }
            }
                
        }
    }
}
