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
    public partial class FeesRecodscs : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");

        public FeesRecodscs()
        {
            InitializeComponent();
        }

        private void FeesRecodscs_Load(object sender, EventArgs e)
        {

            conn.Open();


            string qry = "SELECT * From Payments";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Payments");
            dgvFees.DataSource = ds.Tables["Payments"];



            conn.Close();




        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();


            string qry = "SELECT * From Payments  where CardID = '" + textBox8.Text + "' OR EMPID = '" + textBox8.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Payments");
            dgvFees.DataSource = ds.Tables["Payments"];



            conn.Close();

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == 13)
            {

                button3_Click(sender, e);

            }
        }
    }
}
