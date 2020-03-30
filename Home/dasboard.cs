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
    public partial class dasboard : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");

        public dasboard()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void dasboard_Load(object sender, EventArgs e)
        {
            RefreshDash();

        }

        public void RefreshDash()
        {
            conn.Open();

            int month = DateTime.Now.Month;

            CheckPayment ch = new CheckPayment();

            string monthName1 = ch.Switch(month);
            string monthName2 = ch.Switch(month - 1);
            string monthName3 = ch.Switch(month - 2);

            string qry2 = "SELECT EMPID,Name," + monthName3 + "," + monthName2 + "," + monthName1 + " From PaymentFee where " + monthName1 + " = 0.00  OR " + monthName1 + " = NULL ";
            SqlDataAdapter da2 = new SqlDataAdapter(qry2, conn);
            DataSet ds2 = new DataSet();

            da2.Fill(ds2, "PaymentFee");
            dataGridView1.DataSource = ds2.Tables["PaymentFee"];




            conn.Close();





            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM MemDetails");
            sqlCommand.Connection = conn;

            int RecordCount = Convert.ToInt32(sqlCommand.ExecuteScalar());

            conn.Close();

            label8.Text = RecordCount.ToString();







            conn.Open();
            SqlCommand sqlCommand2 = new SqlCommand("SELECT COUNT(*) FROM Attendance where Mark = 1 ");
            sqlCommand2.Connection = conn;

            int RecordCount2 = Convert.ToInt32(sqlCommand2.ExecuteScalar());

            conn.Close();

            label5.Text = RecordCount2.ToString();




        }

        private void label5_Click(object sender, EventArgs e)
        {




        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            RefreshDash();
        }
    }
}
