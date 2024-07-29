using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace TatehamaInterlocking.TID
{
    internal class CommonImageTrack : TIDTrack
    {
        private Label TrackText;
        private Panel TrackUnderline;
        private PictureBox? TrackPic;
        private TIDTrack? BeforeTrack;
        private Image W;
        private Image Y;
        private Image R;

        public CommonImageTrack(Label trackText, Panel trackUnderline, PictureBox? trackPic, TIDTrack? beforeTrack, Image w, Image y, Image r)
        {
            TrackText = trackText;
            TrackUnderline = trackUnderline;
            TrackPic = trackPic;
            BeforeTrack = beforeTrack;
            W = w; Y = y; R = r;
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
                        TrackPic.Image = R;
                    }
                }));
                BeforeTrack?.ResetTrain(info.diaName);
            }
        }

        public override void SetRoute()
        {
            TrackPic.Image = Y;
        }

        public override void ResetRoute()
        {
            if (TrackText.Text != "")
            {
                TrackPic.Image = W;
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
                    TrackPic.Image = W;
                }
            }));
        }
    }
}
