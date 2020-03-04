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

        }
    }
}
