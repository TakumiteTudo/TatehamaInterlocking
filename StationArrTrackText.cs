using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatehamaInterlocking
{
    internal class StationArrTrackText
    {
        internal List<string> TrainList;
        internal List<Label> LabelList;

        internal StationArrTrackText(List<Label> labelList)
        {
            LabelList = labelList;
            TrainList = new List<string>();
        }

        internal void TrackAddChenge(string Train)
        {
            if (!TrainList.Contains(Train) && !(Train == null || Train == ""))
            {
                TrainList.Add(Train);
                TrackSet();
            }
        }

        internal void TrackRemoveChenge(string Train)
        {
            var success = TrainList.Remove(Train);
            if (success)
            {
                TrackSet();
            }
        }

        private void TrackSet()
        {
            if (TrainList.Count > LabelList.Count)
            {
                for (int i = 0; i < LabelList.Count - 1; i++)
                {
                    if (LabelList[i].Text != TrainList[i])
                    {
                        LabelList[i].Text = TrainList[i];
                    }
                }
                LabelList[LabelList.Count - 1].Text = $"他{TrainList.Count - LabelList.Count + 1}列車";
            }
            else
            {
                for (int i = 0; i < LabelList.Count; i++)
                {
                    if (i < TrainList.Count)
                    {
                        if (LabelList[i].Text != TrainList[i])
                        {
                            LabelList[i].Text = TrainList[i];
                        }
                    }
                    else
                    {
                        if (LabelList[i].Text != "")
                        {
                            LabelList[i].Text = "";
                        }
                    }
                }
            }
        }
    }
}
