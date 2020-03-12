using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home
{
    public partial class ScanID : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");

        public ScanID()
        {
            InitializeComponent();
        }

        private void textBox1_AcceptsTabChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //correct Event 
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Cid = textBox1.Text;

            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 13)
            {

                conn.Open();

                string selqry = "SELECT * FROM Attendance where CardID = '" + Cid + "' OR EMPID = '" + Cid + "'";
                SqlCommand selcmd = new SqlCommand(selqry, conn);
                SqlDataReader reader = selcmd.ExecuteReader();
                reader.Read();

                string att = reader["Attended"].ToString();
                var arriveT = Convert.ToDateTime(reader["Arrive"]);
                var leaveT = DateTime.Now;
             


                var timespan = leaveT.Subtract(arriveT).TotalSeconds;
                var timespanMin = timespan / 60;

                reader.Close();

                if (att == "Present   ")
                {

                    string attLeaveqry = "UPDATE Attendance SET Leave = '" + DateTime.Now + "', Minutes = '"+ timespanMin +"' where CardID = '" + Cid + "' OR EMPID = '" + Cid + "'";
                    SqlCommand cmdLeave = new SqlCommand(attLeaveqry, conn);
                    cmdLeave.ExecuteNonQuery();

                }
                else
                {
                    string attArriveqry = "UPDATE Attendance SET Arrive = '" + DateTime.Now + "', Attended = 'Present', Mark = '1' where CardID = '" + Cid + "' OR EMPID = '" + Cid + "'";
                    SqlCommand cmdArrive = new SqlCommand(attArriveqry, conn);
                    cmdArrive.ExecuteNonQuery();
                }




                conn.Close();
                textBox1.Text = null;
                textBox1.Focus();
            }
                
        }

        private void ScanID_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void ScanID_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Focus();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Focus();
        }
    }
}
