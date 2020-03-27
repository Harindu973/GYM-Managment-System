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

namespace Home
{
    public partial class Homepage : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\OneDrive\Forcus\FO-GYM-Managment-System\Database\Gym.mdf;Integrated Security=True;Connect Timeout=30");

        private bool isCollapsed;
        public Homepage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //payment1.BringToFront();
            label1.BringToFront();
            pictureBox4.BringToFront();

        }

       
        private void homeImg1_Load(object sender, EventArgs e)
        {

        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // staff11.BringToFront();
            label4.BringToFront();
            pictureBox3.BringToFront();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //sms1.BringToFront();
            label2.BringToFront();
            pictureBox5.BringToFront();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox6.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                //button5.Image = Resources.Collapse_Arrow_20px;
                panelDropDown.Height += 10;
                if (panelDropDown.Size == panelDropDown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                //button5.Image = Resources.Expand_Arrow_20px;
                panelDropDown.Height -= 10;
                if (panelDropDown.Size == panelDropDown.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                // button5.Image = Resources.Collapse_Arrow_20px;
                panel6.Height += 10;
                if (panel6.Size == panel6.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                // button5.Image = Resources.Expand_Arrow_20px;
                panel6.Height -= 10;
                if (panel6.Size == panel6.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed = true;
                }
            }
        }

      
        private void button5_Click_2(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void member1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            sms1.BringToFront();
            label2.BringToFront();
            pictureBox5.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            member1.BringToFront();
            pictureBox2.BringToFront();
            label3.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            staff11.BringToFront();
            label4.BringToFront();
            pictureBox6.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            payment1.BringToFront();
            label1.BringToFront();
            pictureBox4.BringToFront();
        }

       

        private void button3_Click_1(object sender, EventArgs e)
        {
            attendance_Recods1.BringToFront();
            label5.BringToFront();
            pictureBox3.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            member_Recods1.BringToFront();
            label6.BringToFront();
            pictureBox2.BringToFront();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            feesRecodscs1.BringToFront();
            label7.BringToFront();
            pictureBox4.BringToFront();


        }

        private void button10_Click(object sender, EventArgs e)
        {
            selling_Recods1.BringToFront();
            label8.BringToFront();
            pictureBox4.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dasboard1.BringToFront();
            pictureBox7.BringToFront();
            label9.BringToFront();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ScanID a1 = new ScanID();
            a1.Show();
            
        }

        private void dasboard1_Load(object sender, EventArgs e)
        {

           


        }
    }
}
