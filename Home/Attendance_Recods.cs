using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Home
{
    public partial class Attendance_Recods : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");

        public Attendance_Recods()
        {
            InitializeComponent();
        }

        private void Attendance_Recods_Load(object sender, EventArgs e)
        {
            conn.Open();


            string qry = "SELECT * From MonthlyAtt";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "MonthlyAtt");
            dgvAttRec.DataSource = ds.Tables["MonthlyAtt"];



            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();


            string qry = "SELECT EMPID,Name,Attended,Arrive,Leave,Minutes,Mark From Attendance where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Attendance");
            dgvAttRec.DataSource = ds.Tables["Attendance"];



            conn.Close();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 13)
            {

                button3_Click(sender, e);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Attendance_Recods_Load(sender, e);
        }
    }
}
