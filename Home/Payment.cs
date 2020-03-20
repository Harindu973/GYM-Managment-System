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
    public partial class payment : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");
        string ValueOfCombo;

        public payment()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void payment_Load(object sender, EventArgs e)
        {

            conn.Open();


            string qry = "SELECT * From Payments";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Payments");
            dgvFees.DataSource = ds.Tables["Payments"];



            conn.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            conn.Open();


            string qry = "SELECT * From Payments where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Payments");
            dgvFees.DataSource = ds.Tables["Payments"];



            conn.Close();



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueOfCombo = comboBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
        

            string payqry = "UPDATE Payments SET  "+ ValueOfCombo +" = '" + DateTime.Today + "' where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";
            SqlCommand cmdsl = new SqlCommand(payqry, conn);
            cmdsl.ExecuteNonQuery();

            MessageBox.Show("Your Payment of "+ValueOfCombo+" Recorded Succesfully...!!! ");





            //Showing Updated Result after refresh
            string qry = "SELECT * From Payments where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Payments");
            dgvFees.DataSource = ds.Tables["Payments"];

            conn.Close();

            insertAmount();


            if (checkBox1.Checked == true)
            {
                admitionFee();
            }


        }


        public void admitionFee()
        {

            string payqry = "UPDATE PaymentFee SET  Reg-Fee = 'Paid' where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";
            SqlCommand cmdsl = new SqlCommand(payqry, conn);
            cmdsl.ExecuteNonQuery();


        }



        public void insertAmount()
        {

            conn.Open();

            decimal fee = decimal.Parse(textBox1.Text);

            string payqry = "UPDATE PaymentFee SET  " + ValueOfCombo + " = " + fee + " where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";
            SqlCommand cmdsl = new SqlCommand(payqry, conn);
            cmdsl.ExecuteNonQuery();

           





            //Showing Updated Result after refresh
            string qry = "SELECT * From PaymentFee where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "PaymentFee");
            dataGridView1.DataSource = ds.Tables["PaymentFee"];

            conn.Close();



        }




        private void button2_Click(object sender, EventArgs e)
        {

            conn.Open();


            string qry = "SELECT * From Payments";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Payments");
            dgvFees.DataSource = ds.Tables["Payments"];

            textBox8.Text = null;


            conn.Close();




            conn.Open();


            string qry2 = "SELECT * From PaymentFee";
            SqlDataAdapter da2 = new SqlDataAdapter(qry2, conn);
            DataSet ds2 = new DataSet();

            da2.Fill(ds2, "PaymentFee");
            dataGridView1.DataSource = ds2.Tables["PaymentFee"];

            textBox8.Text = null;
            textBox1.Text = null;
            checkBox1.Checked = false;


            conn.Close();

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 13)
            {

                button3_Click(sender, e);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            payment_Load(sender, e);
        }
    }
}
