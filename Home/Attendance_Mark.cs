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
    public partial class Attendance_Mark : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");

        public Attendance_Mark()
        {
            InitializeComponent();
        }

        private void Attendance_Mark_Load(object sender, EventArgs e)
        {
            conn.Open();


            string qry = "SELECT EMPID,Name,Attended,Arrive,Leave,Minutes,Mark From Attendance";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Attendance");
            dgvMark.DataSource = ds.Tables["Attendance"];



            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            conn.Open();


            string qry = "SELECT EMPID,Name,Attended,Arrive,Leave,Minutes,Mark From Attendance where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Attendance");
            dgvMark.DataSource = ds.Tables["Attendance"];



            conn.Close();


        }
    }
}
