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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
                        if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 13)
            {

                button3_Click(sender, e);

            }
        }



        public void DayStatement()
        {


       


            string subject = DateTime.Now + " Attendance Sheet";
            string mailBody = "This is " + DateTime.Now + " Calculated Statement of Last Day.";





            //Resize DataGridView to full height.
            int height = dgvMark.Height;
            int width = dgvMark.Width;

            dgvMark.Width = width + 100;
            dgvMark.Height = (dgvMark.RowCount + 2) * dgvMark.RowTemplate.Height;
            // dataGridView1.Width = (dataGridView1.ColumnCount+1) * dataGridView1.Columns.;

            //Create a Bitmap and draw the DataGridView on it.
            Bitmap bitmap = new Bitmap(this.dgvMark.Width, this.dgvMark.Height);
            dgvMark.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dgvMark.Width - 100, this.dgvMark.Height));

            //Resize DataGridView back to original height.
            dgvMark.Height = height;
            dgvMark.Width = width;



            string Date = DateTime.Today.ToString();
          //  string path = "D:/Images/" + Date + " GridView.png";

            //Save the Bitmap to folder.
            bitmap.Save(@"D:\Gym Attendance Details\GridView.png");




            Email em = new Email(subject, mailBody);



        }

    }
}
