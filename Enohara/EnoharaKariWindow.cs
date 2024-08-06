using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TatehamaInterlocking.Enohara
{
    public partial class EnoharaKariWindow : Form
    {
        bool Cancel;
        public EnoharaKariWindow()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("江ノ原検車区上り場内1RA", !Cancel);
            Cancel = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("江ノ原検車区上り場内1RB", !Cancel);
            Cancel = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("江ノ原検車区上り場内1RC", !Cancel);
            Cancel = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("江ノ原検車区上り出発2R", !Cancel);
            Cancel = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("江ノ原検車区下り出発2L", !Cancel);
            Cancel = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("江ノ原検車区下り出発3L", !Cancel);
            Cancel = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("江ノ原検車区下り場内1LA", !Cancel);
            Cancel = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("江ノ原検車区下り場内1LB", !Cancel);
            Cancel = false;
        }
    }
}
