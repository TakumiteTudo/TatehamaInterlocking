using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TatehamaInterlocking.Hamazono
{
    public partial class HamazonoKariWindow : Form
    {
        bool Cancel;
        public HamazonoKariWindow()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Cancel = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("浜園上り場内1R", !Cancel);
            Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("浜園下り出発1L", !Cancel);
            Cancel = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("浜園上り出発2R", !Cancel);
            Cancel = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("浜園下り場内2L", !Cancel);
            Cancel = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("浜園入換102R", !Cancel);
            Cancel = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("浜園入換101L", !Cancel);
            Cancel = false;
        }
    }
}
