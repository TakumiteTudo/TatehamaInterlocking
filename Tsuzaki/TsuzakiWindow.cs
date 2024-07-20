using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TatehamaInterlocking.Tsuzaki
{
    public partial class TsuzakiWindow : Form
    {
        private bool Cancel;

        public TsuzakiWindow()
        {
            InitializeComponent();
            this.Shown += TsuzakiWindow_Shown;
            Cancel = false;
        }

        private void TsuzakiWindow_Shown(object? sender, EventArgs e)
        {
            MainWindow.RouteButtonList.Add("津崎上り場内1RA", BT_1RA);
            MainWindow.RouteButtonImage0.Add("津崎上り場内1RA", Properties.Resources.BT_1RA_RL_Y_0);
            MainWindow.RouteButtonImage1.Add("津崎上り場内1RA", Properties.Resources.BT_1RA_RL_Y_1);
            MainWindow.RouteButtonList.Add("津崎上り場内1RB", BT_1RB);
            MainWindow.RouteButtonImage0.Add("津崎上り場内1RB", Properties.Resources.BT_1RB_RC_Y_0);
            MainWindow.RouteButtonImage1.Add("津崎上り場内1RB", Properties.Resources.BT_1RB_RC_Y_1);
        }


        /// <summary>
        /// 列車の在線状況が変化したときに呼ばれる関数。
        /// </summary>   
        /// <param name="Name">回路名称(鯖側)</param>     
        /// <param name="Train">列車番号</param>
        internal void TrackChenge(string Name, string Train)
        {
            switch (Name)
            {
                case "上り閉塞74":
                    L_No74.Text = Train;
                    break;
                default:
                    break;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Cancel = true;
            CancelBtn.Image = Properties.Resources.BT_Cancel_1;
        }

        private void BT_1RA_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("津崎上り場内1RA", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_1RB_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("津崎上り場内1RB", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

    }
}
