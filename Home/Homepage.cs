using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            payment1.BringToFront();
            label1.BringToFront();
            pictureBox4.BringToFront();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            memberdash1.BringToFront();
            label3.BringToFront();
            pictureBox2.BringToFront();
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
            staff11.BringToFront();
            label4.BringToFront();
            pictureBox3.BringToFront();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sms1.BringToFront();
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
    }
}
