namespace TatehamaInterlocking.Tsuzaki
{
    public partial class TsuzakiWindow : Form
    {
        private bool Cancel;

        private StationArrTrackText OutboundTexts;
        private StationArrTrackText InboundTexts;

        public TsuzakiWindow()
        {
            InitializeComponent();
            MainWindow.RouteButtonList.Add("津崎上り場内1RB", BT_1RA);
            MainWindow.RouteButtonImage0.Add("津崎上り場内1RB", Properties.Resources.BT_1RA_RL_R_0);
            MainWindow.RouteButtonImage1.Add("津崎上り場内1RB", Properties.Resources.BT_1RA_RL_R_1);
            MainWindow.RouteButtonList.Add("津崎上り場内1RA", BT_1RB);
            MainWindow.RouteButtonImage0.Add("津崎上り場内1RA", Properties.Resources.BT_1RB_RC_R_0);
            MainWindow.RouteButtonImage1.Add("津崎上り場内1RA", Properties.Resources.BT_1RB_RC_R_1);
            MainWindow.RouteButtonList.Add("津崎下り出発1L", BT_2L);
            MainWindow.RouteButtonImage0.Add("津崎下り出発1L", Properties.Resources.BT_2L_LC_R_0);
            MainWindow.RouteButtonImage1.Add("津崎下り出発1L", Properties.Resources.BT_2L_LC_R_1);
            MainWindow.RouteButtonList.Add("津崎下り出発2L", BT_3L);
            MainWindow.RouteButtonImage0.Add("津崎下り出発2L", Properties.Resources.BT_3L_LC_R_0);
            MainWindow.RouteButtonImage1.Add("津崎下り出発2L", Properties.Resources.BT_3L_LC_R_1);
            MainWindow.RouteButtonList.Add("津崎上り出発2R", BT_4R);
            MainWindow.RouteButtonImage0.Add("津崎上り出発2R", Properties.Resources.BT_4R_RC_R_0);
            MainWindow.RouteButtonImage1.Add("津崎上り出発2R", Properties.Resources.BT_4R_RC_R_1);
            MainWindow.RouteButtonList.Add("津崎上り出発3R", BT_5R);
            MainWindow.RouteButtonImage0.Add("津崎上り出発3R", Properties.Resources.BT_5R_RC_R_0);
            MainWindow.RouteButtonImage1.Add("津崎上り出発3R", Properties.Resources.BT_5R_RC_R_1);
            MainWindow.RouteButtonList.Add("津崎下り場内3LA", BT_6LC);
            MainWindow.RouteButtonImage0.Add("津崎下り場内3LA", Properties.Resources.BT_6LC_LC_R_0);
            MainWindow.RouteButtonImage1.Add("津崎下り場内3LA", Properties.Resources.BT_6LC_LC_R_1);
            MainWindow.RouteButtonList.Add("津崎下り場内3LB", BT_6LD);
            MainWindow.RouteButtonImage0.Add("津崎下り場内3LB", Properties.Resources.BT_6LD_LL_R_0);
            MainWindow.RouteButtonImage1.Add("津崎下り場内3LB", Properties.Resources.BT_6LD_LL_R_1);
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
                case "上り閉塞56":
                    Text_In4.Text = Train;
                    break;
                case "上り閉塞62":
                    Text_In3.Text = Train;
                    break;
                case "上り閉塞68":
                    Text_In2.Text = Train;
                    break;
                case "上り閉塞74":
                    Text_In1.Text = Train;
                    break;
                case "津崎上り場内1RB":
                    SetTrainHome(Text_1RAT, Text_1RT, Text_In1, Train, info.stationStatus, first);
                    break;
                case "津崎上り場内1RA":
                    SetTrainHome(Text_1RBT, Text_1RT, Text_In1, Train, info.stationStatus, first);
                    break;
                case "津崎上り出発2R":
                case "津崎上り出発3R":
                    SetTrainDep(Text_SST, new List<Label> { Text_1RAT, Text_1RBT }, Train, first);
                    break;
                case "下り閉塞103":
                    Text_Out4.Text = Train;
                    break;
                case "浜園下り場内2L":
                    Text_Out3.Text = Train;
                    break;
                case "浜園入換101L":
                    Text_Out3.Text = Train;
                    break;
                case "浜園下り出発1L":
                    Text_Out2.Text = Train;
                    break;
                case "下り閉塞89":
                    Text_Out1.Text = Train;
                    break;
                case "津崎下り場内3LA":
                    SetTrainHome(Text_6LCT, Text_6LT, Text_Out1, Train, info.stationStatus, first);
                    break;
                case "津崎下り場内3LB":
                    SetTrainHome(Text_6LDT, Text_6LT, Text_Out1, Train, info.stationStatus, first);
                    break;
                case "津崎下り出発1L":
                case "津崎下り出発2L":
                    SetTrainDep(Text_TST, new List<Label> { Text_6LCT, Text_6LDT }, Train, first);
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
                case "津崎上り場内1RB":
                    L_1RA.Visible = on;
                    break;
                case "津崎上り場内1RA":
                    L_1RB.Visible = on;
                    break;
                case "津崎上り出発2R":
                    L_4R.Visible = on;
                    break;
                case "津崎上り出発3R":
                    L_5R.Visible = on;
                    break;
                case "津崎下り場内3LA":
                    L_6LC.Visible = on;
                    break;
                case "津崎下り場内3LB":
                    L_6LD.Visible = on;
                    break;
                case "津崎下り出発1L":
                    L_2L.Visible = on;
                    break;
                case "津崎下り出発2L":
                    L_3L.Visible = on;
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
            if (first && !(targetLabel.Text != "回1234" || targetLabel.Text != "-"))
            {
                targetLabel.Text += Train;
            }
            else
            {
                targetLabel.Text = Train;
            }

            if (!first)
            {
                foreach (var label in beforeLabels)
                {
                    if (label.Text == Train)
                    {
                        label.Text = "";
                    }
                }
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
                    targetFormLabel.Text = "";
                }
                else
                {
                    targetLabel.Text = Train;
                    targetFormLabel.Text = "";
                }
                if (first && (targetLabel.Text == "回1234" || targetLabel.Text == "-"))
                {
                    targetLabel.Text = "";
                    targetFormLabel.Text = "";
                }
                if (Train == null)
                {
                    targetFormLabel.Text = "";
                }
            }

            if (!first)
            {
                foreach (var label in beforeLabels)
                {
                    if (label.Text == Train)
                    {
                        label.Text = Train;
                    }
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
            MainWindow.ButtonPush("津崎上り場内1RB", !Cancel);
            CancelBtn.Image = Properties.Resources.BT_Cancel_0;
            Cancel = false;
        }

        private void BT_1RB_Click(object sender, EventArgs e)
        {
            MainWindow.ButtonPush("津崎上り場内1RA", !Cancel);
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
