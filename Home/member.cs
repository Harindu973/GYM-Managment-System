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
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using Emgu.CV.Cuda;

namespace Home
{
    public partial class member : UserControl
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");
        string ValueOfCombo;


        public member()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            string Fname = txtName.Text;
            string Pack = ValueOfCombo;
            string Nic = txtNic.Text;
            string Phone = txtTp.Text;
            string Age = txtAge.Text;
            string Add = txtAddress.Text;
            string Height = txtHeight.Text;
            string Weight = txtWeight.Text;
            string Cid = txtCid.Text;
            string Email = txtMail.Text;
            string Gender;


            if (Fname == string.Empty || Nic == string.Empty || Phone == string.Empty || Add == string.Empty || Age == string.Empty || Weight == string.Empty || Height == string.Empty || Email == string.Empty || Cid == string.Empty)
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





                Image pic = ImageToByte(picOutput.Image);


                conn.Open();
       
                string query = "INSERT INTO Members values('" + Fname + "','" + Pack + "','" + Nic + "','" + Phone + "',' ','" + Add + "','" + Gender + "','@images','" + Weight + "','"+Height+ "', '" + Age + "' ,'" + Cid + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@images", picOutput.Image);


    


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



                //Attendance Sheet reg







                try
                {
                    conn.Open();
                    string selqry = "SELECT * FROM Members where CardID = '" + Cid + "' ";
                    SqlCommand selcmd = new SqlCommand(selqry, conn);
                    SqlDataReader reader = selcmd.ExecuteReader();
                    reader.Read();

                    string EMPID = reader["EMP_ID"].ToString();
                    reader.Close();

                    string attquery = "INSERT INTO Attendance values('" + EMPID + "','" + Fname + "','Absent','','','0','0','"+ Cid +"')";
                    SqlCommand attcmd = new SqlCommand(attquery, conn);

                    attcmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Something's Going wrong in Attendance sheet reg...!  Plz Contact a Developer..." + ex);
                }
                catch (Exception x)
                {
                    MessageBox.Show("" + x);
                }
                finally
                {
                    conn.Close();
                }




                //Fees Table reg



                try
                {
                    conn.Open();
                    string selqry = "SELECT * FROM Members where CardID = '" + Cid + "' ";
                    SqlCommand selcmd = new SqlCommand(selqry, conn);
                    SqlDataReader reader = selcmd.ExecuteReader();
                    reader.Read();

                    string EMPID = reader["EMP_ID"].ToString();
                    reader.Close();

                    string attquery = "INSERT INTO Payments (EMPID,CardID,Name) values('" + EMPID + "','"+Cid+"','" + Fname + "')";

                    SqlCommand attcmd = new SqlCommand(attquery, conn);

                    attcmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Something's Going wrong in Fees reg...!  Plz Contact a Developer..." + ex);
                }
                catch (Exception x)
                {
                    MessageBox.Show("" + x);
                }
                finally
                {
                    conn.Close();
                }



















                //Attendance Monthy table reg

                try
                {
                    conn.Open();
                    string selqry = "SELECT * FROM Members where NIC = '" + Nic + "' ";
                    SqlCommand selcmd = new SqlCommand(selqry, conn);
                    SqlDataReader reader = selcmd.ExecuteReader();
                    reader.Read();

                    string EMPID = reader["EMP_ID"].ToString();
                    reader.Close();

                    //string attquery = "INSERT INTO Attendance values('" + EMPID + "','" + Fname + "','Absent','','','0','0','0')";
                    string attmonthquery = "INSERT INTO MonthlyAtt values('" + EMPID + "','" + Fname + "','" + Cid + "','0','0')";

                    //SqlCommand attcmd = new SqlCommand(attquery, conn);
                    SqlCommand attmonthcmd = new SqlCommand(attmonthquery, conn);

                    //attcmd.ExecuteNonQuery();
                    attmonthcmd.ExecuteNonQuery();



                    conn.Close();


                    MessageBox.Show("You are now Registerd...!!!");


                    txtName.Text = "";
                    txtNic.Text = "";

                    txtAge.Text = "";
                    txtTp.Text = "";

                    txtAddress.Text = "";
                    txtWeight.Text = "";
                    txtHeight.Text = "";
                    txtMail.Text = "";
                    txtCid.Text = "";

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Something's Going wrong in Monthly Attendance sheet...!  Plz Contact a Developer..." + ex);
                }
                catch (Exception x)
                {
                    MessageBox.Show("Something's Going wrong in Monthly Attendance ..!  Plz Contact a Developer..." + x);
                }
                finally
                {
                    conn.Close();


                }

               

            }








        }

        private Image ImageToByte(Image image)
        {
            throw new NotImplementedException();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Capture capture = new Capture();
            var img = capture.QueryFrame().ToImage<Bgr, byte>();
            var bmp = img.Bitmap;
            picOutput.Image = bmp;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueOfCombo = comboBox1.Text;
        }




        public static byte[] ImageToByte2(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }



    }
    
}
