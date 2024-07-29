using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace TatehamaInterlocking.TID
{
    internal class CommonTrack : TIDTrack
    {
        private Label TrackText;
        private Panel TrackUnderline;
        private PictureBox? TrackPic;
        private TIDTrack? BeforeTrack;

        public CommonTrack(Label trackText, Panel trackUnderline, PictureBox? trackPic, TIDTrack? beforeTrack)
        {
            TrackText = trackText;
            TrackUnderline = trackUnderline;
            TrackPic = trackPic;
            BeforeTrack = beforeTrack;
            TrackUnderline.BackColor = TIDTrack.Trans;
        }

        public override void SetBeforeClass(TIDTrack track)
        {
            BeforeTrack = track;
        }

        public override void SetTrain(TrackCircuitInfo info)
        {
            if (info.diaName == null)
            {
                ResetTrain(null);
            }
            else
            {
                TrackText.Invoke((MethodInvoker)(() =>
                {

                    TrackText.Text = RetsubanText(info.diaName);
                    TrackText.ForeColor = TypeColor(info.diaName);
                    TrackUnderline.BackColor = White;
                    if (TrackPic != null)
                    {
                        TrackPic.Image = Properties.Resources.TID_Track_F_R;
                    }
                }));
                BeforeTrack?.ResetTrain(info.diaName);
            }
        }

        public override void SetRoute()
        {
            Debug.WriteLine($"目標番線あり{this}");
            TrackPic.Image = Properties.Resources.TID_Track_F_Y;
        }

        public override void ResetRoute()
        {
            if (TrackText.Text != "")
            {
                TrackPic.Image = Properties.Resources.TID_Track_F_W;
            }
        }

        public override void ResetTrain(string? retsuban)
        {
            if (retsuban != null)
            {
                if (!(TrackText.Text == RetsubanText(retsuban)))
                {
                    return;
                }
            }
            TrackText.Invoke((MethodInvoker)(() =>
            {
                TrackText.Text = "";
                TrackUnderline.BackColor = TIDTrack.Trans;
                if ((TrackPic != null && retsuban == null))
                {
                    TrackPic.Image = Properties.Resources.TID_Track_F_W;
                }
            }));
        }
    }
}
