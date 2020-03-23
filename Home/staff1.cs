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
    public partial class staff1 : UserControl
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");
    

        public staff1()
        {
            InitializeComponent();
        }





  


        private void showStaf()
        {

            conn.Open();


            string qry = "SELECT * From Staff";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Staff");
            dataGridView1.DataSource = ds.Tables["Staff"];



            conn.Close();

        }



        private void button1_Click_1(object sender, EventArgs e)
        {








            string Fname = txtName.Text;
            string Nic = txtNic.Text;
            string Phone = txtTp.Text;
            string Age = txtAge.Text;
            string Add = txtAddress.Text;
            string Cid = txtCid.Text;
            string Email = txtMail.Text;
            string Gender;





            if (Fname == string.Empty && Nic == string.Empty && Phone == string.Empty && Add == string.Empty && Age == string.Empty && Cid == string.Empty)
            {
                MessageBox.Show("Some fileds are empty !!");
            }
            else
            {
                if (Rmale.Checked)
                {
                    Gender = "Male";
                }
                else
                {
                    Gender = "Female";
                }








                conn.Open();

                string query = "INSERT INTO Staff values('" + Fname + "','" + Nic + "','" + Phone + "','" + Add + "','" + Gender + "', '" + Age + "' ,'" + Cid + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
          





                try
                {

                    cmd.ExecuteNonQuery();
                    //attcmd.ExecuteNonQuery();


                    // MessageBox.Show("You are now Registerd...!!!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Something's Going wrong in EMP Reg...!  Plz Contact a Developer..." + ex);
                }
                finally
                {
                    conn.Close();
                }





                showStaf();






            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();






            try
            {
                string mainquery = "Delete from Staff where CardID = '" + textBox8.Text + "' OR Staff_ID = '" + textBox8.Text + "'";


                SqlCommand maincmd = new SqlCommand(mainquery, conn);
                maincmd.ExecuteNonQuery();

                MessageBox.Show(textBox8.Text + " is Deleted Successfully");


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Something's Going wrong...!  Plz Contact a Developer..."+ex);
            }
            finally
            {
                conn.Close();
            }

            showStaf();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {

            conn.Open();


            string qry = "SELECT * From Staff where CardID = '" + textBox8.Text + "' OR Staff_ID = '" + textBox8.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Staff");
            dataGridView1.DataSource = ds.Tables["Staff"];



            conn.Close();

        }

        private void staff1_Load_1(object sender, EventArgs e)
        {
            showStaf();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showStaf();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 13)
            {

                button4_Click_2(sender, e);

            }
        }
    }
}
