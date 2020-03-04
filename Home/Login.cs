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
using Employee_Management_System;

namespace Home
{
    public partial class Login : Form
    {

        SqlConnection constring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bhashitha\OneDrive\Desktop\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");
        

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string uname = txtUname.Text;
            string pw = txtPw.Text;
            bool Match;

            if (uname == string.Empty || pw == string.Empty)
            {
                MessageBox.Show("Please check...  Something's Missing...!!!");
                //txtUname.Text = "";
                //txtPw.Text = "";
            }
            else
            {
                
                Encap en = new Encap();
              
                en.setValues(uname, pw);
                Match = en.getValues();

                if (Match == false)
                {
                    MessageBox.Show("Wrong Username Or Password...!!!");
                    txtUname.Text = "";
                    txtPw.Text = "";
                }
                else
                {
                    Homepage em = new Homepage();
                    em.Show();
                    this.Hide();

                }
            }



            






        }
    }
}
