using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TatehamaInterlocking.Komano
{
    public partial class KomanoKariWindow : Form
    {
        bool Cancel;
        public KomanoKariWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野上り場内1RA", !Cancel);
            Cancel = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野上り場内1RB", !Cancel);
            Cancel = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野下り出発1L", !Cancel);
            Cancel = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野下り出発4L", !Cancel);
            Cancel = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野上り場内2RB", !Cancel);
            Cancel = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野上り場内2RA", !Cancel);
            Cancel = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野下り出発2L", !Cancel);
            Cancel = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野上り出発3R", !Cancel);
            Cancel = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野上り出発4R", !Cancel);
            Cancel = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野下り場内11LA", !Cancel);
            Cancel = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("駒野入換110R", !Cancel);
            Cancel = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Cancel = true;
        }
    }
}
