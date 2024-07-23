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
            MainWindow.RouteButtonList.Add("津崎上り出発2R", BT_4R);
            MainWindow.RouteButtonImage0.Add("津崎上り出発2R", Properties.Resources.BT_4R_RC_Y_0);
            MainWindow.RouteButtonImage1.Add("津崎上り出発2R", Properties.Resources.BT_4R_RC_Y_1);
            MainWindow.RouteButtonList.Add("津崎上り出発3R", BT_5R);
            MainWindow.RouteButtonImage0.Add("津崎上り出発3R", Properties.Resources.BT_5R_RC_Y_0);
            MainWindow.RouteButtonImage1.Add("津崎上り出発3R", Properties.Resources.BT_5R_RC_Y_1);
            MainWindow.RouteButtonList.Add("津崎上り場内3LA", BT_6LC);
            MainWindow.RouteButtonImage0.Add("津崎上り場内3LA", Properties.Resources.BT_6LC_LC_Y_0);
            MainWindow.RouteButtonImage1.Add("津崎上り場内3LA", Properties.Resources.BT_6LC_LC_Y_1);
            MainWindow.RouteButtonList.Add("津崎上り場内3LB", BT_6LD);
            MainWindow.RouteButtonImage0.Add("津崎上り場内3LB", Properties.Resources.BT_6LCD_LL_Y_0);
            MainWindow.RouteButtonImage1.Add("津崎上り場内3LB", Properties.Resources.BT_6LCD_LL_Y_1);
            MainWindow.RouteButtonList.Add("津崎下り出発1L", BT_2L);
            MainWindow.RouteButtonImage0.Add("津崎下り出発1L", Properties.Resources.BT_2L_LC_Y_0);
            MainWindow.RouteButtonImage1.Add("津崎下り出発1L", Properties.Resources.BT_2L_LC_Y_1);
            MainWindow.RouteButtonList.Add("津崎下り出発2L", BT_3L);
            MainWindow.RouteButtonImage0.Add("津崎下り出発2L", Properties.Resources.BT_3L_LC_Y_0);
            MainWindow.RouteButtonImage1.Add("津崎下り出発2L", Properties.Resources.BT_3L_LC_Y_1);
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

        private void BT_4R_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("津崎上り出発2R", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_5R_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("津崎上り出発3R", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_6LC_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("津崎下り場内3LA", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_6LD_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("津崎下り場内3LB", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_2L_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("津崎下り出発1L", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;

        }

        private void BT_3L_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("津崎下り出発2L", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;

        }
    }
}
