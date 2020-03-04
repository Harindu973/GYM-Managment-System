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
    public partial class SMS : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");

        public SMS()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();


            string qry = "SELECT * From Members where CardID = '" + textBox8.Text + "' OR EMP_ID = '" + textBox8.Text + "'";
            SqlCommand selcmd = new SqlCommand(qry, conn);
            SqlDataReader reader = selcmd.ExecuteReader();
            reader.Read();

            textBox2.Text = reader["PhoneNO"].ToString();


            reader.Close();

            conn.Close();
        }
    }
}
