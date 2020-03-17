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


            string qry = "SELECT * From MemDetails where CardID = '" + textBox8.Text + "' OR EMP_ID = '" + textBox8.Text + "'";
            SqlCommand selcmd = new SqlCommand(qry, conn);
            SqlDataReader reader = selcmd.ExecuteReader();
            reader.Read();

            textBox2.Text = reader["PhoneNO"].ToString();


            reader.Close();

            conn.Close();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 13)
            {

                button6_Click(sender, e);

            }
        }

        private void SMS_Load(object sender, EventArgs e)
        {

        }
    }
}
