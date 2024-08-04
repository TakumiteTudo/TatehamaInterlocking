using System.Diagnostics;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection;
using TatehamaInterlocking.Tatehama;
using TatehamaInterlocking.TID;
using TatehamaInterlocking.Tsuzaki;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MethodInvoker = System.Windows.Forms.MethodInvoker;

namespace TatehamaInterlocking
{
    public partial class MainWindow : Form
    {

        static internal Dictionary<string, PictureBox> RouteButtonList = new Dictionary<string, PictureBox>();
        static internal Dictionary<string, Image> RouteButtonImage0 = new Dictionary<string, Image>();
        static internal Dictionary<string, Image> RouteButtonImage1 = new Dictionary<string, Image>();

        private bool showtatehamaWindow;
        static private TatehamaKariWindow tatehamaWindow = new TatehamaKariWindow();
        private bool showtsuzakiWindow;
        static private TsuzakiWindow tsuzakiWindow = new TsuzakiWindow();
        private bool showshinNozakiWindow;
        static private ShinNozakiWindow shinNozakiWindow = new ShinNozakiWindow();
        private bool showdee;
        static private Dee Dee = new Dee();
        private bool showTIDWindow;
        static private TIDWindow TIDWindow = new TIDWindow();
        static private Socket socket = new Socket(Program.ServerAddress);

        public MainWindow()
        {
            InitializeComponent();
            tatehamaWindow.Show();
            tatehamaWindow.Hide();
            tsuzakiWindow.Show();
            tsuzakiWindow.Hide();
            shinNozakiWindow.Show();
            shinNozakiWindow.Hide();
            TIDWindow.Show();
            TIDWindow.Hide();
            showtatehamaWindow = false;
            showtsuzakiWindow = false;
            showshinNozakiWindow = false;
            showTIDWindow = false;
            showdee = false;
            LoadCustomFont();
        }

        private void LoadCustomFont()
        {
            //// 埋め込みリソースの名前を設定
            //string fontResourceName = "TatehamaInterlocking.KawashiroLED_K16TB.ttf";

            //// フォントを読み込むためのストリームを取得
            //Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fontResourceName);
            //if (fontStream == null)
            //{
            //    throw new Exception("フォントリソースが見つかりませんでした。");
            //}

            //// ストリームからバイト配列にフォントデータを読み込む
            //byte[] fontData = new byte[fontStream.Length];
            //fontStream.Read(fontData, 0, (int)fontStream.Length);
            //fontStream.Close();

            //// PrivateFontCollectionにフォントを追加
            //PrivateFontCollection pfc = new PrivateFontCollection();
            //IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            //System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            //pfc.AddMemoryFont(fontPtr, fontData.Length);
            //System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            //// フォントの適用
            //Font yourFont = new Font(pfc.Families[0], 12); // フォントサイズを指定
            //Font = yourFont;
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
                        if (error == "開通中" || error == "閉鎖中" || error == "進入中")
                        {
                            return;
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
                TIDWindow.TrackChenge(info);
                if (!info.isClosure)
                {
                    tsuzakiWindow.SignalChenge(info);
                    shinNozakiWindow.SignalChenge(info);
                    if (RouteButtonList.ContainsKey(info.signalName))
                    {
                        if (info.stationStatus == StationStatus.ROUTE_CLOSED || info.stationStatus == StationStatus.ROUTE_ENTERED)
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
            showtatehamaWindow = !showtatehamaWindow;
            if (showtatehamaWindow)
            {
                tatehamaWindow.Show();
            }
            else
            {
                tatehamaWindow.Hide();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showTIDWindow = !showTIDWindow;
            if (showTIDWindow)
            {
                TIDWindow.Show();
            }
            else
            {
                TIDWindow.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
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