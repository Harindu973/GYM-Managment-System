using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Employee_Management_System
{
    class Encap
    {

        SqlConnection constring = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bhashitha\OneDrive\Desktop\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");



        private string Pname;
        private string Ppw;
        private bool verify = false;

        public void setValues(string uname, string pw)
        {
            Pname = uname;
            Ppw = pw;
            string qFname = "SELECT * FROM Admin where Username = '" + Pname + "' AND Password = '" + Ppw + "' ";
            SqlCommand cmd = new SqlCommand(qFname, constring);



            constring.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            //reader.Read();

            if (reader.Read())
            {
                verify = true;
            }



            // reader.Close();


        }

        public bool getValues()
        {
            return verify;
        }



    }
}
