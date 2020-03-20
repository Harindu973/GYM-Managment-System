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
using System.IO;


namespace Home
{
    public partial class Member_Recods : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");

        public Member_Recods()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();






            
                        string qry = "SELECT EMP_ID,MemberID,FullName,Package,NIC,Gender,Age,Weight,Height From MemDetails where CardID = '" + textBox8.Text + "' OR EMP_ID = '" + textBox8.Text + "'";
                        SqlDataAdapter da = new SqlDataAdapter(qry, conn);
                        DataSet ds = new DataSet();

                        da.Fill(ds, "MemDetails");
                        dataGridView1.DataSource = ds.Tables["MemDetails"];





                        //Image  retrive





                        SqlCommand cmd = new SqlCommand("SELECT * FROM MemDetails where CardID = '" + textBox8.Text + "' OR EMP_ID = '" + textBox8.Text + "'", conn);

                        SqlDataAdapter daa = new SqlDataAdapter(cmd);

                        DataSet dss = new DataSet();

                        daa.Fill(dss);

                        if (dss.Tables[0].Rows.Count > 0)

                        {

                            MemoryStream mss = new MemoryStream((byte[])dss.Tables[0].Rows[0]["Photo"]);

                            pictureBox1.Image = new Bitmap(mss);

                        }
                        
            conn.Close();
        }

        private void Member_Recods_Load(object sender, EventArgs e)
        {
            conn.Open();


            string qry = "SELECT EMP_ID,MemberID,FullName,Package,NIC,Gender,Age,Weight,Height From MemDetails";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "MemDetails");
            dataGridView1.DataSource = ds.Tables["MemDetails"];



            conn.Close();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 13)
            {

                button3_Click(sender, e);
                Member_Recods_Load(sender, e);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            conn.Open();
            





            try
            {
                string mainquery = "Delete from Attendance where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";
                string attquery = "Delete from MemDetails where CardID = '" + textBox8.Text + "' OR EMP_ID = '" + textBox8.Text + "'";
                string monthquery = "Delete from MonthlyAtt where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";
                string salquery = "Delete from Payments where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";

                SqlCommand maincmd = new SqlCommand(mainquery, conn);
                maincmd.ExecuteNonQuery();

                SqlCommand attcmd = new SqlCommand(attquery, conn);
                attcmd.ExecuteNonQuery();

                SqlCommand monthcmd = new SqlCommand(monthquery, conn);
                monthcmd.ExecuteNonQuery();

                SqlCommand salcmd = new SqlCommand(salquery, conn);
                salcmd.ExecuteNonQuery();



                MessageBox.Show(textBox8.Text + " is Deleted Successfully");


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something's Going wrong...!  Plz Contact a Developer..." + ex);
            }
            finally
            {
                conn.Close();
            }
            
            Member_Recods_Load(sender, e);








        }

    }
}
