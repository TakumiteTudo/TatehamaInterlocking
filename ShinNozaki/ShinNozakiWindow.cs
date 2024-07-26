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
    public partial class ShinNozakiWindow : Form
    {
        private bool Cancel;
        private StationArrTrackText OutboundTexts;
        private StationArrTrackText InboundTexts;

        public ShinNozakiWindow()
        {
            InitializeComponent();
            InboundTexts = new StationArrTrackText(new List<Label> { Text_In1, Text_In2, Text_In3, Text_In4 });
            OutboundTexts = new StationArrTrackText(new List<Label> { Text_Out1, Text_Out2, Text_Out3, Text_Out4 });
            MainWindow.RouteButtonList.Add("新野崎上り場内1RB", BT_1RA);
            MainWindow.RouteButtonImage0.Add("新野崎上り場内1RB", Properties.Resources.BT_1RA_RL_R_0);
            MainWindow.RouteButtonImage1.Add("新野崎上り場内1RB", Properties.Resources.BT_1RA_RL_R_1);
            MainWindow.RouteButtonList.Add("新野崎上り場内1RA", BT_1RB);
            MainWindow.RouteButtonImage0.Add("新野崎上り場内1RA", Properties.Resources.BT_1RB_RC_R_0);
            MainWindow.RouteButtonImage1.Add("新野崎上り場内1RA", Properties.Resources.BT_1RB_RC_R_1);
            MainWindow.RouteButtonList.Add("新野崎下り出発1L", BT_2L);
            MainWindow.RouteButtonImage0.Add("新野崎下り出発1L", Properties.Resources.BT_2L_LC_R_0);
            MainWindow.RouteButtonImage1.Add("新野崎下り出発1L", Properties.Resources.BT_2L_LC_R_1);
            MainWindow.RouteButtonList.Add("新野崎下り出発2L", BT_3L);
            MainWindow.RouteButtonImage0.Add("新野崎下り出発2L", Properties.Resources.BT_3L_LC_R_0);
            MainWindow.RouteButtonImage1.Add("新野崎下り出発2L", Properties.Resources.BT_3L_LC_R_1);
            MainWindow.RouteButtonList.Add("新野崎下り場内3L", BT_4L);
            MainWindow.RouteButtonImage0.Add("新野崎下り場内3L", Properties.Resources.BT_4L_LC_R_0);
            MainWindow.RouteButtonImage1.Add("新野崎下り場内3L", Properties.Resources.BT_4L_LC_R_1);
            MainWindow.RouteButtonList.Add("新野崎下り場内4L", BT_5L);
            MainWindow.RouteButtonImage0.Add("新野崎下り場内4L", Properties.Resources.BT_5L_LC_R_0);
            MainWindow.RouteButtonImage1.Add("新野崎下り場内4L", Properties.Resources.BT_5L_LC_R_1);
            MainWindow.RouteButtonList.Add("新野崎上り出発11R", BT_8R);
            MainWindow.RouteButtonImage0.Add("新野崎上り出発11R", Properties.Resources.BT_8R_RC_R_0);
            MainWindow.RouteButtonImage1.Add("新野崎上り出発11R", Properties.Resources.BT_8R_RC_R_1);
            MainWindow.RouteButtonList.Add("新野崎上り出発12R", BT_9R);
            MainWindow.RouteButtonImage0.Add("新野崎上り出発12R", Properties.Resources.BT_9R_RC_R_0);
            MainWindow.RouteButtonImage1.Add("新野崎上り出発12R", Properties.Resources.BT_9R_RC_R_1);
            MainWindow.RouteButtonList.Add("新野崎下り場内5LA", BT_10LC);
            MainWindow.RouteButtonImage0.Add("新野崎下り場内5LA", Properties.Resources.BT_10LC_LC_R_0);
            MainWindow.RouteButtonImage1.Add("新野崎下り場内5LA", Properties.Resources.BT_10LC_LC_R_1);
            MainWindow.RouteButtonList.Add("新野崎下り場内5LB", BT_10LD);
            MainWindow.RouteButtonImage0.Add("新野崎下り場内5LB", Properties.Resources.BT_10LD_LL_R_0);
            MainWindow.RouteButtonImage1.Add("新野崎下り場内5LB", Properties.Resources.BT_10LD_LL_R_1);
            MainWindow.RouteButtonList.Add("新野崎入換104L", BT_32L);
            MainWindow.RouteButtonImage0.Add("新野崎入換104L", Properties.Resources.BT_32L_LC_G_0);
            MainWindow.RouteButtonImage1.Add("新野崎入換104L", Properties.Resources.BT_32L_LC_G_1);
            MainWindow.RouteButtonList.Add("新野崎入換111R", BT_33R);
            MainWindow.RouteButtonImage0.Add("新野崎入換111R", Properties.Resources.BT_33R_RC_G_0);
            MainWindow.RouteButtonImage1.Add("新野崎入換111R", Properties.Resources.BT_33R_RC_G_1);
            MainWindow.RouteButtonList.Add("新野崎入換101L", BT_35LD);
            MainWindow.RouteButtonImage0.Add("新野崎入換101L", Properties.Resources.BT_35LD_LL_G_0);
            MainWindow.RouteButtonImage1.Add("新野崎入換101L", Properties.Resources.BT_35LD_LL_G_1);
            Cancel = false;
        }


        /// <summary>
        /// 列車の在線状況が変化したときに呼ばれる関数。
        /// </summary>   
        internal void TrackChenge(TrackCircuitInfo info, bool first)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => TrackChenge(info, first)));
                return;
            }
            var Train = info.diaName;
            var name = info.signalName;
            switch (name)
            {
                case "上り閉塞108":
                    InboundTexts.TrackAddChenge(Train);
                    break;
                case "上り閉塞114":
                    InboundTexts.TrackAddChenge(Train);
                    break;
                case "上り閉塞120":
                    InboundTexts.TrackAddChenge(Train);
                    break;
                case "上り閉塞124":
                    InboundTexts.TrackAddChenge(Train);
                    break;
                case "新野崎上り場内1RB":
                    SetTrainHome(Text_1RAT, Text_1RT, InboundTexts, Train, info.stationStatus, first);
                    break;
                case "新野崎上り場内1RA":
                    SetTrainHome(Text_1RBT, Text_1RT, InboundTexts, Train, info.stationStatus, first);
                    break;
                case "新野崎上り出発11R":
                case "新野崎上り出発12R":
                    SetTrainDep(Text_SST, new List<Label> { Text_1RAT, Text_1RBT }, Train, first);
                    break;
                case "新野崎入換111R":
                    SetTrainHome(Text_33RT, Text_26T, new List<Label> { Text_1RAT }, Train, info.stationStatus, first);
                    break;
                case "新野崎入換101L":
                    SetTrainHome(Text_10LT, Text_10LT, new List<Label> { Text_33RT }, Train, info.stationStatus, first);
                    break;
                case "新野崎入換104L":
                    SetTrainHome(Text_5LT, Text_5LT, new List<Label> { Text_10LT }, Train, info.stationStatus, first);
                    break;
                case "下り閉塞151":
                    OutboundTexts.TrackAddChenge(Train);
                    break;
                case "下り閉塞145":
                    OutboundTexts.TrackAddChenge(Train);
                    break;
                case "下り閉塞143":
                    OutboundTexts.TrackAddChenge(Train);
                    break;
                case "下り閉塞137":
                    OutboundTexts.TrackAddChenge(Train);
                    break;
                case "新野崎下り場内5LA":
                case "新野崎下り場内5LB":
                    SetTrainHome(Text_10LT, Text_10LT, OutboundTexts, Train, info.stationStatus, first);
                    break;
                case "新野崎下り場内3L":
                    SetTrainHome(Text_4LT, Text_4LT, Text_10LT, Train, info.stationStatus, first);
                    break;
                case "新野崎下り場内4L":
                    SetTrainHome(Text_5LT, Text_5LT, Text_10LT, Train, info.stationStatus, first);
                    break;
                case "新野崎下り出発1L":
                case "新野崎下り出発2L":
                    SetTrainDep(Text_TST, new List<Label> { Text_4LT, Text_5LT }, Train, first);
                    break;
                default:
                    break;
            }
        }

        internal void SignalChenge(TrackCircuitInfo info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SignalChenge(info)));
                return;
            }
            var name = info.signalName;

            var on = info.signalPhase != "R";
            switch (name)
            {
                case "新野崎上り場内1RB":
                    L_1RA.Visible = on;
                    break;
                case "新野崎上り場内1RA":
                    L_1RB.Visible = on;
                    break;
                case "新野崎上り出発11R":
                    L_8R.Visible = on;
                    break;
                case "新野崎上り出発12R":
                    L_9R.Visible = on;
                    break;
                case "新野崎下り場内5LA":
                    L_10LC.Visible = on;
                    break;
                case "新野崎下り場内5LB":
                    L_10LD.Visible = on;
                    break;
                case "新野崎下り場内3L":
                    L_4L.Visible = on;
                    break;
                case "新野崎下り場内4L":
                    L_5L.Visible = on;
                    break;
                case "新野崎下り出発1L":
                    L_2L.Visible = on;
                    break;
                case "新野崎下り出発2L":
                    L_3L.Visible = on;
                    break;
                case "新野崎入換111R":
                    L_33R.Visible = on;
                    break;
                case "新野崎入換101L":
                    L_35L.Visible = on;
                    break;
                case "新野崎入換104L":
                    L_32L.Visible = on;
                    break;
            }
        }

        /// <summary>
        /// 出発進路の車両表示を制御する関数
        /// </summary>
        /// <param name="targetLabel">操作される回路表示</param>             
        /// <param name="beforeLabel">列車が来た可能性のある回路全て</param>
        /// <param name="Train">列車名</param>
        /// <param name="first">初回かどうか</param>
        private void SetTrainDep(Label targetLabel, List<Label> beforeLabels, string Train, bool first)
        {
            if (!first)
            {
                foreach (var label in beforeLabels)
                {
                    if (label.Text != "" && Train != null)
                    {
                        label.Text = "";
                    }
                }
            }

            if (first && !(targetLabel.Text != "回1234" || targetLabel.Text != "-"))
            {
                targetLabel.Text += Train;
            }
            else
            {
                targetLabel.Text = Train;
            }

        }

        /// <summary>
        /// 出発進路の車両表示を制御する関数
        /// </summary>
        /// <param name="targetLabel">操作される回路表示</param>
        /// <param name="beforeLabel">列車が来た可能性のある回路全て</param>
        /// <param name="Train">列車名</param>
        /// <param name="first">初回かどうか</param>
        private void SetTrainDep(Label targetLabel, Label beforeLabel, string Train, bool first)
        {
            SetTrainDep(targetLabel, new List<Label> { beforeLabel }, Train, first);
        }


        /// <summary>
        /// 場内・入換進路の車両表示を制御する関数
        /// </summary>                                          
        /// <param name="targetFormLabel">操作されるホーム回路表示</param>    
        /// <param name="targetLabel">操作される場内-ホーム間回路表示</param>       
        /// <param name="beforeLabel">列車が来た可能性のある回路全て</param>
        /// <param name="Train">列車名</param>
        /// <param name="first">初回かどうか</param>
        private void SetTrainHome(Label targetFormLabel, Label targetLabel, List<Label> beforeLabels, string Train, StationStatus stationStatus, bool first)
        {
            if (!first)
            {
                foreach (var label in beforeLabels)
                {
                    if (label.Text != "" && Train != null)
                    {
                        label.Text = "";
                    }
                }
            }

            if (stationStatus == StationStatus.ROUTE_ENTERED)
            {
                if (first && !(targetFormLabel.Text != "回1234" || targetFormLabel.Text != "-"))
                {
                    targetFormLabel.Text += Train;
                }
                else
                {
                    targetFormLabel.Text = Train;
                }
                if (first && (targetLabel.Text == "回1234" || targetLabel.Text == "-"))
                {
                    targetLabel.Text = "";
                }
                if (!first)
                {
                    targetLabel.Text = "";
                }
            }
            else
            {
                if (first && !(targetLabel.Text != "回1234" || targetLabel.Text != "-"))
                {
                    targetLabel.Text += Train;
                }
                else
                {
                    targetLabel.Text = Train;
                }
                if (first && (targetLabel.Text == "回1234" || targetLabel.Text == "-"))
                {
                    targetLabel.Text = "";
                }
                if (Train == null)
                {
                    targetFormLabel.Text = "";
                }
            }
        }

        /// <summary>
        /// 場内・入換進路の車両表示を制御する関数
        /// </summary>                                          
        /// <param name="targetFormLabel">操作されるホーム回路表示</param>    
        /// <param name="targetLabel">操作される場内-ホーム間回路表示</param>       
        /// <param name="beforeLabel">列車が来た可能性のある回路全て</param>
        /// <param name="Train">列車名</param>
        /// <param name="first">初回かどうか</param>
        private void SetTrainHome(Label targetFormLabel, Label targetLabel, Label beforeLabels, string Train, StationStatus stationStatus, bool first)
        {
            SetTrainHome(targetFormLabel, targetLabel, new List<Label> { beforeLabels }, Train, stationStatus, first);
        }

        /// <summary>
        /// 場内・入換進路の車両表示を制御する関数
        /// </summary>                                          
        /// <param name="targetFormLabel">操作されるホーム回路表示</param>    
        /// <param name="targetLabel">操作される場内-ホーム間回路表示</param>       
        /// <param name="beforeLabel">列車が来た可能性のある回路全て</param>
        /// <param name="Train">列車名</param>
        /// <param name="first">初回かどうか</param>
        private void SetTrainHome(Label targetFormLabel, Label targetLabel, StationArrTrackText beforeLabel, string Train, StationStatus stationStatus, bool first)
        {
            SetTrainHome(targetFormLabel, targetLabel, new List<Label> { }, Train, stationStatus, first);
            beforeLabel.TrackRemoveChenge(Train);
        }


        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Cancel = true;
            CancelBtn.Image = Properties.Resources.BT_Cancel_1;
        }

        private void BT_1RA_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎上り場内1RB", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_1RB_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎上り場内1RA", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_2L_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎下り出発1L", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_3L_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎下り出発2L", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_4L_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎下り場内3L", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_5L_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎下り場内4L", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_6R_Click(object sender, EventArgs e)
        {
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_7R_Click(object sender, EventArgs e)
        {
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_8R_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎上り出発11R", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_9R_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎上り出発12R", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_10LC_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎下り場内5LA", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_10LD_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎下り場内5LB", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_31L_Click(object sender, EventArgs e)
        {
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_32L_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎入換104L", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_33R_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎入換111R", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_34R_Click(object sender, EventArgs e)
        {
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_35LC_Click(object sender, EventArgs e)
        {
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_35LD_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("新野崎入換101L", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_31LZ_Click(object sender, EventArgs e)
        {

        }

        private void BT_32LZ_Click(object sender, EventArgs e)
        {

        }
    }
}
