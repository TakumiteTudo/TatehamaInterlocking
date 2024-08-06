using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TatehamaInterlocking.Daidoji
{
    public partial class DaidojiKariWindow : Form
    {
        bool Cancel;
        public DaidojiKariWindow()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺上り場内1RA", !Cancel);
            Cancel = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺上り場内1RB", !Cancel);
            Cancel = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺上り場内1RC", !Cancel);
            Cancel = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺上り場内2R", !Cancel);
            Cancel = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺上り場内3R", !Cancel);
            Cancel = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺上り場内8R", !Cancel);
            Cancel = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺下り出発1L", !Cancel);
            Cancel = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺下り出発2L", !Cancel);
            Cancel = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺入換105R", !Cancel);
            Cancel = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺入換103L", !Cancel);
            Cancel = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺入換104L", !Cancel);
            Cancel = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺入換110LC", !Cancel);
            Cancel = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺入換110LD", !Cancel);
            Cancel = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺入換110R", !Cancel);
            Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("大道寺入換112L", !Cancel);
            Cancel = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cancel = true;
        }
    }
}
