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
                            if (error == "�J�ʒ�" || error == "����" || error == "�i����")
                            {
                                return;
                            }
                        }
                        MessageBox.Show($"�i�H�m�ۂ����݂܂������A�M���T�[�o�[����ȉ��̃G���[���Ԃ�܂����B\n{error}", "�G���[ | �w�ߑ� | �ٕl�d�S�@�_�C���^�]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"�i�H�m�ۂ����݂܂������A�\�t�g�ňُ킪�������܂����B\n{e}", "�G���[ | �w�ߑ� | �ٕl�d�S�@�_�C���^�]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                Debug.WriteLine($"{info}");
                //�ݐ���ԕ\���X�V
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
                MessageBox.Show($"�ݐ��󋵂̕ύX�����݂܂������A�\�t�g�ňُ킪�������܂����B\n�ΏہF{info}\n{e}", "�G���[ | �w�ߑ� | �ٕl�d�S�@�_�C���^�]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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