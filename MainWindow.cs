using System.Diagnostics;
using System.Net.Sockets;
using TatehamaInterlocking.Tsuzaki;

namespace TatehamaInterlocking
{
    public partial class MainWindow : Form
    {
        private bool showtsuzakiWindow;
        static private TsuzakiWindow tsuzakiWindow = new TsuzakiWindow();
        private bool showshinNozakiWindow;
        static private ShinNozakiWindow shinNozakiWindow = new ShinNozakiWindow();
        private bool showdee;
        static private Dee Dee = new Dee();
        static private Socket socket = new Socket(Program.ServerAddress);

        public MainWindow()
        {
            InitializeComponent();
            tsuzakiWindow.Hide();
            shinNozakiWindow.Hide();
            showtsuzakiWindow = false;
            showshinNozakiWindow = false;
            showdee = false;
        }

        static internal Dictionary<string, PictureBox> RouteButtonList = new Dictionary<string, PictureBox>();
        static internal Dictionary<string, Image> RouteButtonImage0 = new Dictionary<string, Image>();
        static internal Dictionary<string, Image> RouteButtonImage1 = new Dictionary<string, Image>();


        /// <summary>
        /// �i�H�{�^���������ꂽ������֐��B
        /// </summary>
        /// <param name="Name">�i�H����(�I��)</param>     
        /// <param name="Teihan">���(F)������(T)��</param>
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
                        // Todo: �G���[���b�Z�[�W���ł�̂ŁA�����\������
                        Debug.WriteLine(error);
                        if (RouteButtonList.ContainsKey(Name))
                        {
                            RouteButtonList[Name].Invoke((MethodInvoker)(() =>
                            {
                                if (error == "�J�ʒ�")
                                {
                                    RouteButtonList[Name].Visible = true;
                                }
                                else if (error == "����" || error == "�i����")
                                {
                                    RouteButtonList[Name].Visible = false;
                                }
                            }));
                        }
                        return;
                    }
                    // Todo: �Y���ӏ������点��     
                    if (RouteButtonList.ContainsKey(Name))
                    {
                        RouteButtonList[Name].Invoke((MethodInvoker)(() =>
                        {
                            RouteButtonList[Name].Visible = Teihan;
                        }));
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"{e}");
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
        /// ��Ԃ̍ݐ��󋵂��ω������Ƃ��ɌĂ΂��֐��B
        /// </summary>   
        /// <param name="info">��H���</param>     
        /// <param name="first">���񂩂ǂ���</param>
        static internal void TrackChenge(TrackCircuitInfo info, bool first = false)
        {
            Debug.WriteLine($"{info}");
            tsuzakiWindow.TrackChenge(info, first);
            shinNozakiWindow.TrackChenge(info, first);
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