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

namespace TatehamaInterlocking.Tatehama
{
    public partial class TatehamaKariWindow : Form
    {
        bool Cancel;

        public TatehamaKariWindow()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cancel = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("館浜上り出発1R", !Cancel);
            Cancel = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("館浜上り出発2R", !Cancel);
            Cancel = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("館浜上り出発3R", !Cancel);
            Cancel = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("館浜上り出発4R", !Cancel);
            Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("館浜下り場内1LA", !Cancel);
            Cancel = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("館浜下り場内1LB", !Cancel);
            Cancel = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("館浜下り場内1LC", !Cancel);
            Cancel = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("館浜下り場内1LD", !Cancel);
            Cancel = false;
        }
    }
}
