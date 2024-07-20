using System.Diagnostics;
using System.Net.Sockets;
using TatehamaInterlocking.Tsuzaki;

namespace TatehamaInterlocking
{
    public partial class MainWindow : Form
    {
        static private TsuzakiWindow tsuzakiWindow = new TsuzakiWindow();
        static private Socket socket = new Socket(Program.ServerAddress);
        public MainWindow()
        {
            InitializeComponent();
            tsuzakiWindow.Show();
        }

        static internal Dictionary<string, PictureBox> RouteButtonList = new Dictionary<string, PictureBox>();
        static internal Dictionary<string, Image> RouteButtonImage0 = new Dictionary<string, Image>();
        static internal Dictionary<string, Image> RouteButtonImage1 = new Dictionary<string, Image>();


        /// <summary>
        /// i˜Hƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‘–‚éŠÖ”B
        /// </summary>
        /// <param name="Name">i˜H–¼Ì(I‘¤)</param>     
        /// <param name="Teihan">’èˆÊ(F)‚©”½ˆÊ(T)‚©</param>
        static internal void ButtonPush(string Name, bool Teihan)
        {
            Debug.WriteLine($"Push:{Name}/{Teihan}");
            if (Teihan)
            {
                socket.routeOpen(Name);
            }
            else
            {
                //Todo: routeClose
            }
        }

        /// <summary>
        /// i˜H‚ª”½ˆÊ‚É‚È‚Á‚½‚Æ‚«‚É‘–‚ç‚¹‚éŠÖ”B
        /// </summary>
        static internal void RouteSet(string Name)
        {
            Debug.WriteLine($"Set:{Name}");
            RouteButtonList[Name].Image = RouteButtonImage1[Name];
        }

        /// <summary>
        /// i˜H‚ª’èˆÊ‚É‚È‚Á‚½‚Æ‚«‚É‘–‚ç‚¹‚éŠÖ”B
        /// </summary>
        static internal void RouteReset(string Name)
        {
            Debug.WriteLine($"Reset:{Name}");
            RouteButtonList[Name].Image = RouteButtonImage0[Name];
        }

        /// <summary>
        /// —ñÔ‚Ìİüó‹µ‚ª•Ï‰»‚µ‚½‚Æ‚«‚ÉŒÄ‚Î‚ê‚éŠÖ”B
        /// </summary>   
        /// <param name="Name">‰ñ˜H–¼Ì(I‘¤)</param>     
        /// <param name="Train">—ñÔ”Ô†</param>
        static internal void TrackChenge(string Name, string Train)
        {
            Debug.WriteLine($"Chenge:{Name}/{Train}");
            tsuzakiWindow.TrackChenge(Name, Train);
        }
    }
}