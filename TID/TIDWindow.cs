using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TatehamaInterlocking.TID
{
    public partial class TIDWindow : Form
    {
        private TimeSpan ShiftTime = TimeSpan.FromHours(10);
        public TIDWindow()
        {
            InitializeComponent();
            TIDInit();
            BackgroundImage = Properties.Resources.Background1;
        }

        private Dictionary<string, TIDTrack> TrackList = new Dictionary<string, TIDTrack>();

        private void TIDWindow_Load(object sender, EventArgs e)
        {

        }

        public void TrackChenge(TrackCircuitInfo info)
        {
            if (TrackList.ContainsKey(info.signalName))
            {
                TrackList[info.signalName].SetTrain(info);
            }
        }

        private void Time_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShiftTime += TimeSpan.FromHours(1);
            }
            else
            {
                ShiftTime -= TimeSpan.FromHours(1);
            }
        }

        public void TimeChenge()
        {
            Time.Invoke((MethodInvoker)(() =>
            {
                Time.Text = $"更新時刻　{DateTime.Now - ShiftTime:HH:mm:ss}";
            }));
        }
    }
}
