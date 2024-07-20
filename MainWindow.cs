using TatehamaInterlocking.Tsuzaki;

namespace TatehamaInterlocking
{
    public partial class MainWindow : Form
    {
        private TsuzakiWindow tsuzakiWindow;
        public MainWindow()
        {
            InitializeComponent();
            tsuzakiWindow = new TsuzakiWindow();
            tsuzakiWindow.Show();
        }

        static internal Dictionary<string, PictureBox> RouteButtonList = new Dictionary<string, PictureBox>();
        static internal Dictionary<string, Image> RouteButtonImage0 = new Dictionary<string, Image>();
        static internal Dictionary<string, Image> RouteButtonImage1 = new Dictionary<string, Image>();


        /// <summary>
        /// 進路ボタンが押された時走る関数。
        /// </summary>
        /// <param name="Name">進路名称(鯖側)</param>     
        /// <param name="Teihan">定位(F)か反位(T)か</param>
        internal void ButtonPush(string Name, bool Teihan)
        {
        }

        /// <summary>
        /// 進路が反位になったときに走らせる関数。
        /// </summary>
        internal void RouteSet(string Name)
        {
            RouteButtonList[Name].Image = RouteButtonImage1[Name];
        }

        /// <summary>
        /// 進路が定位になったときに走らせる関数。
        /// </summary>
        internal void RouteReset(string Name)
        {
            RouteButtonList[Name].Image = RouteButtonImage0[Name];
        }

        /// <summary>
        /// 列車の在線状況が変化したときに呼ばれる関数。
        /// </summary>   
        /// <param name="Name">回路名称(鯖側)</param>     
        /// <param name="Train">列車番号</param>
        internal void TrackChenge(string Name, string Train)
        {
            tsuzakiWindow.TrackChenge(Name, Train);
        }
    }
}