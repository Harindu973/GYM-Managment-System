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
    public partial class Warning : Form
    {
        public Warning()
        {
            InitializeComponent();
        }


        Timer timer = new Timer();
        private void Warning_Load(object sender, EventArgs e)
        {


                timer.Interval = 3000;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();


        }


        void timer_Tick(object sender, EventArgs e)
        {
            
            ScanID sid = new ScanID();
            sid.ShowGridView();
            sid.textBox1.Focus();
            this.Close();
        }
    }
}
