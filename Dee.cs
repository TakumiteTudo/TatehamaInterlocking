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

namespace TatehamaInterlocking
{
    public partial class Dee : Form
    {
        public Dee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush(textBox1.Text, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush(textBox1.Text, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainWindow.enterSignal(textBox2.Text, textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {

            }
            MainWindow.leaveSignal(textBox2.Text, textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainWindow.enteringComplete(textBox2.Text, textBox3.Text);
        }
    }
}
