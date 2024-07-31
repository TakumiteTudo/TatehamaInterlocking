using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TatehamaInterlocking.TID
{
    public partial class TIDWindow : Form
    {
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
