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
    public partial class Member_Recods : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");

        public Member_Recods()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();


            string qry = "SELECT EMP_ID,MemberID,FullName,Package,NIC,Gender,Age,Weight,Height From Members where CardID = '" + textBox8.Text + "' OR EMP_ID = '" + textBox8.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Members");
            dataGridView1.DataSource = ds.Tables["Members"];



            conn.Close();
        }

        private void Member_Recods_Load(object sender, EventArgs e)
        {
            conn.Open();


            string qry = "SELECT EMP_ID,MemberID,FullName,Package,NIC,Gender,Age,Weight,Height From Members";
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Members");
            dataGridView1.DataSource = ds.Tables["Members"];



            conn.Close();
        }
    }
}
