using System.Diagnostics;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection;
using TatehamaInterlocking.Tatehama;
using TatehamaInterlocking.Komano;
using TatehamaInterlocking.TID;
using TatehamaInterlocking.Tsuzaki;
using TatehamaInterlocking.Daidoji;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MethodInvoker = System.Windows.Forms.MethodInvoker;
using TatehamaInterlocking.Enohara;
using TatehamaInterlocking.Hamazono;

namespace TatehamaInterlocking
{
    public partial class MainWindow : Form
    {

        static internal Dictionary<string, PictureBox> RouteButtonList = new Dictionary<string, PictureBox>();
        static internal Dictionary<string, Image> RouteButtonImage0 = new Dictionary<string, Image>();
        static internal Dictionary<string, Image> RouteButtonImage1 = new Dictionary<string, Image>();

        private bool showtatehamaWindow;
        static private TatehamaKariWindow tatehamaWindow = new TatehamaKariWindow();
        private bool showkomanoWindow;
        static private KomanoKariWindow komanoWindow = new KomanoKariWindow();
        private bool showtsuzakiWindow;
        static private TsuzakiWindow tsuzakiWindow = new TsuzakiWindow();
        private bool showhamazonoWindow;
        static private HamazonoKariWindow hamazonoWindow = new HamazonoKariWindow();
        private bool showshinNozakiWindow;
        static private ShinNozakiWindow shinNozakiWindow = new ShinNozakiWindow();
        private bool showenoharaWindow;
        static private EnoharaKariWindow enoharaWindow = new EnoharaKariWindow();
        private bool showdaidojiWindow;
        static private DaidojiKariWindow daidojiWindow = new DaidojiKariWindow();
        private bool showdee;
        static private Dee Dee = new Dee();
        private bool showTIDWindow;
        static internal TIDWindow TIDWindow = new TIDWindow();
        static private Socket socket;

        public MainWindow()
        {
            InitializeComponent();
            TIDWindow.Show();
            TIDWindow.Hide();
            tatehamaWindow.Show();
            tatehamaWindow.Hide();
            komanoWindow.Show();
            komanoWindow.Hide();
            tsuzakiWindow.Show();
            tsuzakiWindow.Hide();
            shinNozakiWindow.Show();
            shinNozakiWindow.Hide();
            daidojiWindow.Show();
            daidojiWindow.Hide();
            socket = new Socket(Program.ServerAddress);
            showtatehamaWindow = false;
            showkomanoWindow = false;
            showtsuzakiWindow = false;
            showhamazonoWindow = false;
            showshinNozakiWindow = false;
            showenoharaWindow = false;
            showdaidojiWindow = false;
            showTIDWindow = false;
            showdee = false;
            LoadCustomFont();
        }

        private void LoadCustomFont()
        {
            //// ���ߍ��݃��\�[�X�̖��O��ݒ�
            //string fontResourceName = "TatehamaInterlocking.KawashiroLED_K16TB.ttf";

            //// �t�H���g��ǂݍ��ނ��߂̃X�g���[�����擾
            //Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fontResourceName);
            //if (fontStream == null)
            //{
            //    throw new Exception("�t�H���g���\�[�X��������܂���ł����B");
            //}

            //// �X�g���[������o�C�g�z��Ƀt�H���g�f�[�^��ǂݍ���
            //byte[] fontData = new byte[fontStream.Length];
            //fontStream.Read(fontData, 0, (int)fontStream.Length);
            //fontStream.Close();

            //// PrivateFontCollection�Ƀt�H���g��ǉ�
            //PrivateFontCollection pfc = new PrivateFontCollection();
            //IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            //System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            //pfc.AddMemoryFont(fontPtr, fontData.Length);
            //System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            //// �t�H���g�̓K�p
            //Font yourFont = new Font(pfc.Families[0], 12); // �t�H���g�T�C�Y���w��
            //Font = yourFont;
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
                        if (error == "�J�ʒ�" || error == "����" || error == "�i����")
                        {
                            return;
                        }
                        if (error.Contains("���J��"))
                        {
                            return;
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
                MessageBox.Show($"�ݐ��󋵂̕ύX�����݂܂������A�\�t�g�ňُ킪�������܂����B\n�ΏہF{info}\n{e}", "�G���[ | �w�ߑ� | �ٕl�d�S�@�_�C���^�]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void button2_Click(object sender, EventArgs e)
        {
            showkomanoWindow = !showkomanoWindow;
            if (showkomanoWindow)
            {
                komanoWindow.Show();
            }
            else
            {
                komanoWindow.Hide();
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
        private void button4_Click(object sender, EventArgs e)
        {
            showhamazonoWindow = !showhamazonoWindow;
            if (showhamazonoWindow)
            {
                hamazonoWindow.Show();
            }
            else
            {
                hamazonoWindow.Hide();
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
        private void button6_Click(object sender, EventArgs e)
        {
            showenoharaWindow = !showenoharaWindow;
            if (showenoharaWindow)
            {
                enoharaWindow.Show();
            }
            else
            {
                enoharaWindow.Hide();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            showdaidojiWindow = !showdaidojiWindow;
            if (showdaidojiWindow)
            {
                daidojiWindow.Show();
            }
            else
            {
                daidojiWindow.Hide();
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

        private void ButtonPushError_Click(object sender, EventArgs e)
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