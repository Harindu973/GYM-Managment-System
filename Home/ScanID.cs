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
                CheckPayment cp = new CheckPayment();
                int result = cp.Check(Cid);

                if (result == 1 || result == 2)
                {



                    //ScanID_Load(sender, e);
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

                        string attLeaveqry = "UPDATE Attendance SET Leave = '" + DateTime.Now + "', Minutes = '" + timespanMin + "' where CardID = '" + Cid + "' OR EMPID = '" + Cid + "'";
                        SqlCommand cmdLeave = new SqlCommand(attLeaveqry, conn);
                        cmdLeave.ExecuteNonQuery();

                    }
                    else
                    {
                        string attArriveqry = "UPDATE Attendance SET Arrive = '" + DateTime.Now + "', Attended = 'Present', Mark = '1' where CardID = '" + Cid + "' OR EMPID = '" + Cid + "'";
                        SqlCommand cmdArrive = new SqlCommand(attArriveqry, conn);
                        cmdArrive.ExecuteNonQuery();
                    }


                }





                conn.Close();
                textBox1.Text = null;
                dasboard db = new dasboard();
                db.Refresh();
                // ScanID_Load(sender, e);
                // textBox1.Focus();

            }
                
        }

        public void ScanID_Load(object sender, EventArgs e)
        {

            dataGridView2.Visible = false;


           this.WindowState = System.Windows.Forms.FormWindowState.Maximized;



           // textBox1.Focus();

            ShowGridView();




            int currentMonth = Convert.ToInt32(DateTime.Now.Month);
            int currentYear = Convert.ToInt32(DateTime.Now.Year);


            conn.Open();

            string timeqry = "SELECT * FROM TimeSchedule where Id = 1 ";
            SqlCommand timecmd = new SqlCommand(timeqry, conn);
            SqlDataReader readerA = timecmd.ExecuteReader();
            readerA.Read();


            var LastTime = Convert.ToDateTime(readerA["Time"]);
            int lastMonth = Convert.ToInt32(readerA["Month"]);
            int lastYear = Convert.ToInt32(readerA["Year"]);

            readerA.Close();




            conn.Close();


            if (lastYear < currentYear)
            {
                conn.Open();
                
                string Yearqry = "UPDATE TimeSchedule SET  Year = " + currentYear + " where Id = '1'";
                SqlCommand Yeahcmd = new SqlCommand(Yearqry, conn);
                Yeahcmd.ExecuteNonQuery();
          

                conn.Close();

                monthReset(currentMonth);
                MessageBox.Show("Happy New Year...!!! Best Wishes From Forcus Oeuvre...!!!");
                YearDateStatement();
                YearStatement();

            }
            else if(lastMonth < currentMonth)
            {

                monthReset(currentMonth);


            }










            conn.Open();
         





            if (DateTime.Today > LastTime)
            {

                //Code to Date collect


          


                string subject = "Attendance Sheet";
                string mailBody = "This is    " + DateTime.Now + " Attendace Sheet";
                




                //Resize DataGridView to full height.
                int height = dataGridView1.Height;
                int width = dataGridView1.Width;

                dataGridView1.Width = width + 100;
                dataGridView1.Height = (dataGridView1.RowCount + 2) * dataGridView1.RowTemplate.Height;
                // dataGridView1.Width = (dataGridView1.ColumnCount+1) * dataGridView1.Columns.;

                //Create a Bitmap and draw the DataGridView on it.
                Bitmap bitmap1 = new Bitmap(this.dataGridView1.Width-600, this.dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap1, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

                //Resize DataGridView back to original height.
                dataGridView1.Height = height;
                dataGridView1.Width = width;

                //Save the Bitmap to folder.

                const string i1Path = @"C:\ProgramData\GymManagementSoftware\DayStatement.png";
                bitmap1.Save(i1Path);
                
                



                Email em = new Email(subject, mailBody,i1Path);



                //Attendance table variables
                int attno;
                string EmpID;
                string Attended;
               


                //MonthlyAtt table variables
                int present;
                int absent;


                //Extra
                int ExPresent = 0;
                int ExAbsent = 0;


                //Incremted Variables
                int Inpresent;
                int Inabsent;
         

             



                for (attno = 0; attno < 100; attno++)
                {

                    string selqry = "SELECT * FROM Attendance where AttNO = '" + attno + "' ";
                    SqlCommand selcmd = new SqlCommand(selqry, conn);
                    SqlDataReader reader = selcmd.ExecuteReader();


                    if (reader.Read())
                    {

                        //attendance table
                        EmpID = reader["EMPID"].ToString();
                        Attended = reader["Attended"].ToString();




                        reader.Close();


                        string seltoUpqry = "SELECT * FROM MonthlyAtt where EMPID = '" + EmpID + "' ";
                        SqlCommand seltoUpcmd = new SqlCommand(seltoUpqry, conn);
                        SqlDataReader ra = seltoUpcmd.ExecuteReader();


                        ra.Read();
                        //MonthlyAtt

                        present = Convert.ToInt32(ra["PresentDays"]);
                        absent = Convert.ToInt32(ra["AbsentDays"]);


                        ra.Close();

                        if (Attended == "Present   ")
                        {
                            ExPresent = 1;
                            ExAbsent = 0;
                        }
                        else
                        {
                            ExPresent = 0;
                            ExAbsent = 1;
                        }

                        Inpresent = present + ExPresent;
                        Inabsent = absent + ExAbsent;


                        string attLeaveqry = "UPDATE MonthlyAtt SET PresentDays = '" + Inpresent + "', AbsentDays = '" + Inabsent + "'  WHERE EMPID = '" + EmpID + "'";
                        SqlCommand cmdLeave = new SqlCommand(attLeaveqry, conn);
                        cmdLeave.ExecuteNonQuery();
                        



                    }

                    reader.Close();





                }

                for (attno = 0; attno < 100; attno++)
                {

                    string attresetqry = "UPDATE Attendance SET Attended = 'Absent', Arrive = '', Leave = '', Mark = '0', Minutes = '0'  WHERE AttNO='" + attno + "'";
                    SqlCommand cmdattreset = new SqlCommand(attresetqry, conn);
                    cmdattreset.ExecuteNonQuery();


                }






                string Shedqry = "UPDATE TimeSchedule SET  Time = '" + DateTime.Today + "' where Id = '1'";
                SqlCommand Shedcmd = new SqlCommand(Shedqry, conn);
                Shedcmd.ExecuteNonQuery();




                ShowGridView();




                MessageBox.Show("Yesterday Calculated Successfully...! \nCheck Your Email for Statement...");




            }




            conn.Close();





        }

        private void ScanID_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Focus();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }




        public void monthReset(int cMonth)
        {
            conn.Open();

            string Monthqry = "UPDATE TimeSchedule SET  Month = " + cMonth + " where Id = '1'";
            SqlCommand Monthcmd = new SqlCommand(Monthqry, conn);
            Monthcmd.ExecuteNonQuery();
            conn.Close();

            MonthStatement();
            MessageBox.Show("Last Month Collected... Check Your Email for the statement...");


        }


        public void MonthStatement()
        {
            conn.Open();

            string qry = "SELECT * From MonthlyAtt";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "MonthlyAtt");
            dataGridView1.DataSource = ds.Tables["MonthlyAtt"];


            string subject = "Monthly Statement of  " + DateTime.Now;
            string mailBody = "This is " + DateTime.Now + " Monthly Statement";





            //Resize DataGridView to full height.
            int height = dataGridView1.Height;
            int width = dataGridView1.Width;

            dataGridView1.Width = width + 100;
            dataGridView1.Height = (dataGridView1.RowCount + 2) * dataGridView1.RowTemplate.Height;
            // dataGridView1.Width = (dataGridView1.ColumnCount+1) * dataGridView1.Columns.;

            //Create a Bitmap and draw the DataGridView on it.
            Bitmap bitmap = new Bitmap(this.dataGridView1.Width - 900, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            //Resize DataGridView back to original height.
            dataGridView1.Height = height;
            dataGridView1.Width = width;

            //Save the Bitmap to folder.
            const string i2Path = @"C:\ProgramData\GymManagementSoftware\MonthlyStatement.png";
            bitmap.Save(i2Path);


            Email em = new Email(subject, mailBody,i2Path);


            ShowGridView();
            conn.Close();

            

        }




        public void YearStatement()
        {
            conn.Open();
            dataGridView2.Visible = true;
            string qry = "SELECT * From PaymentFee";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "PaymentFee");
            dataGridView2.DataSource = ds.Tables["PaymentFee"];


            string subject = "Year Payment Fees Statement of  " + DateTime.Now;
            string mailBody = "This is " + DateTime.Now + " Year Statement";





            //Resize DataGridView to full height.
            int height = dataGridView2.Height;
            int width = dataGridView2.Width;

            dataGridView2.Width = width + 100;
            dataGridView2.Height = (dataGridView2.RowCount + 2) * dataGridView2.RowTemplate.Height;
            // dataGridView1.Width = (dataGridView1.ColumnCount+1) * dataGridView1.Columns.;

            //Create a Bitmap and draw the DataGridView on it.
            Bitmap bitmap = new Bitmap(this.dataGridView2.Width-250, this.dataGridView2.Height);
            dataGridView2.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView2.Width, this.dataGridView2.Height));

            //Resize DataGridView back to original height.
            dataGridView2.Height = height;
            dataGridView2.Width = width;

            //Save the Bitmap to folder.
            const string i3Path = @"C:\ProgramData\GymManagementSoftware\YearStatement.png";
            bitmap.Save(i3Path);


            Email em = new Email(subject, mailBody, i3Path);

            dataGridView2.Visible = false;

            ShowGridView();
            conn.Close();



        }




        public void YearDateStatement()
        {
            conn.Open();
            dataGridView2.Visible = true;
             
            string qry = "SELECT * From Payments";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Payments");
            dataGridView2.DataSource = ds.Tables["Payments"];


            string subject = "Year Payment Date Statement of  " + DateTime.Now;
            string mailBody = "This is " + DateTime.Now + " Year Statement";





            //Resize DataGridView to full height.
            int height = dataGridView2.Height;
            int width = dataGridView2.Width;

            dataGridView2.Width = width + 100;
            dataGridView2.Height = (dataGridView2.RowCount + 2) * dataGridView2.RowTemplate.Height;
            // dataGridView1.Width = (dataGridView1.ColumnCount+1) * dataGridView1.Columns.;

            //Create a Bitmap and draw the DataGridView on it.
            Bitmap bitmap = new Bitmap(this.dataGridView2.Width-350, this.dataGridView2.Height);
            dataGridView2.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView2.Width, this.dataGridView2.Height));

            //Resize DataGridView back to original height
            dataGridView2.Height = height;
            dataGridView2.Width = width;

            //Save the Bitmap to folder.
            const string i4Path = @"C:\ProgramData\GymManagementSoftware\YearDateStatement.png";
            bitmap.Save(i4Path);


            Email em = new Email(subject, mailBody, i4Path);

            dataGridView2.Visible = false;

            ShowGridView();
            conn.Close();



        }



        public void ShowGridView()
        {

            conn.Close();
            conn.Open();


            string qry = "SELECT * From Attendance";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Attendance");
            dataGridView1.DataSource = ds.Tables["Attendance"];

             

            conn.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void ScanID_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
