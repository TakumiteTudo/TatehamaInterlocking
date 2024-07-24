using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Sockets;
using TatehamaInterlocking.Tsuzaki;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TatehamaInterlocking
{
    public partial class MainWindow : Form
    {
        private bool showtsuzakiWindow;

        static internal Dictionary<string, PictureBox> RouteButtonList = new Dictionary<string, PictureBox>();
        static internal Dictionary<string, Image> RouteButtonImage0 = new Dictionary<string, Image>();
        static internal Dictionary<string, Image> RouteButtonImage1 = new Dictionary<string, Image>();

        static private TsuzakiWindow tsuzakiWindow = new TsuzakiWindow();
        private bool showshinNozakiWindow;
        static private ShinNozakiWindow shinNozakiWindow = new ShinNozakiWindow();
        private bool showdee;
        static private Dee Dee = new Dee();
        static private Socket socket = new Socket(Program.ServerAddress);

        public MainWindow()
        {
            InitializeComponent();
            tsuzakiWindow.Show();
            shinNozakiWindow.Show();
            tsuzakiWindow.Hide();
            shinNozakiWindow.Hide();
            showtsuzakiWindow = false;
            showshinNozakiWindow = false;
            showdee = false;
        }


        /// <summary>
        /// 進路ボタンが押された時走る関数。
        /// </summary>
        /// <param name="Name">進路名称(鯖側)</param>     
        /// <param name="Teihan">定位(F)か反位(T)か</param>
        static internal void ButtonPush(string Name, bool Teihan)
        {
            Debug.WriteLine($"Push:{Name}/{Teihan}");
            Task.Run(async () =>
            {
                try
                {
                    string? error;
                    if (Teihan)
                    {
                        error = await socket.routeOpen(Name);
                    }
                    else
                    {
                        error = await socket.routeCancel(Name);
                    }
                    if (error.Length > 0)
                    {
                        // Todo: エラーメッセージがでるので、それを表示する
                        Debug.WriteLine(error);
                        if (RouteButtonList.ContainsKey(Name))
                        {
                            if (error == "開通中" || error == "閉鎖中" || error == "進入中")
                            {
                                return;
                            }
                        }
                        MessageBox.Show($"進路確保を試みましたが、信号サーバーから以下のエラーが返りました。\n{error}", "エラー | 指令卓 | 館浜電鉄　ダイヤ運転", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"進路確保を試みましたが、ソフトで異常が発生しました。\n{e}", "エラー | 指令卓 | 館浜電鉄　ダイヤ運転", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        static internal void enterSignal(string signalName, string trainName)
        {
            socket.enterSignal(signalName, trainName);
        }

        static internal void leaveSignal(string signalName, string trainName)
        {
            socket.leaveSignal(signalName, trainName);
        }

        static internal void enteringComplete(string signalName, string trainName)
        {
            socket.enteringComplete(signalName, trainName);
        }

        /// <summary>
        /// 列車の在線状況が変化したときに呼ばれる関数。
        /// </summary>   
        /// <param name="info">回路情報</param>     
        /// <param name="first">初回かどうか</param>
        static internal void TrackChenge(TrackCircuitInfo info, bool first = false)
        {
            try
            {
                Debug.WriteLine($"{info}");
                //在線列番表示更新
                tsuzakiWindow.TrackChenge(info, first);
                shinNozakiWindow.TrackChenge(info, first);
                if (!info.isClosure)
                {
                    tsuzakiWindow.SignalChenge(info);
                    if (RouteButtonList.ContainsKey(info.signalName))
                    {
                        if (info.stationStatus == StationStatus.ROUTE_CLOSED)
                        {
                            RouteButtonList[info.signalName].Invoke((MethodInvoker)(() =>
                            {
                                RouteButtonList[info.signalName].Image = RouteButtonImage0[info.signalName];
                            }));
                        }
                        else
                        {
                            RouteButtonList[info.signalName].Invoke((MethodInvoker)(() =>
                            {
                                RouteButtonList[info.signalName].Image = RouteButtonImage1[info.signalName];
                            }));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"在線状況の変更を試みましたが、ソフトで異常が発生しました。\n対象：{info}\n{e}", "エラー | 指令卓 | 館浜電鉄　ダイヤ運転", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showtsuzakiWindow = !showtsuzakiWindow;
            if (showtsuzakiWindow)
            {
                tsuzakiWindow.Show();
            }
            else
            {
                tsuzakiWindow.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showshinNozakiWindow = !showshinNozakiWindow;
            if (showshinNozakiWindow)
            {
                shinNozakiWindow.Show();
            }
            else
            {
                shinNozakiWindow.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showdee = !showdee;
            if (showdee)
            {
                Dee.Show();
            }
            else
            {
                Dee.Hide();
            }
        }
    }
}