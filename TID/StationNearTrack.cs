using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatehamaInterlocking.TID
{
    internal class StationNearTrack : TIDTrack
    {
        private CommonTrack ArrTrackText;
        private CommonTrack DepTrackText;
        private PictureBox TrackPic;
        private TIDTrack? BeforeTrack;

        private Dictionary<string, string> ArrRouteToPlatform;
        private Dictionary<string, string> DepRouteToPlatform;
        private Dictionary<string, TIDTrack> PlatformToTrack;
        private Dictionary<string, Image> RouteToTrackY;
        private Dictionary<string, Image> RouteToTrackR;

        private string? ArrString;
        private string? ArrPlatform;
        private string? DepString;

        private StationNearTrackPic stationNearTrackPic;

        public StationNearTrack(CommonTrack arrTrackText, CommonTrack depTrackText, PictureBox TrackPic, TIDTrack? beforeTrack,
            Dictionary<string, string> arrRouteToPlatform, Dictionary<string, string> depRouteToPlatform, Dictionary<string, TIDTrack> platformToTrack,
            Dictionary<string, Image> routeToTrackY, Dictionary<string, Image> routeToTrackR)
        {
            ArrTrackText = arrTrackText;
            DepTrackText = depTrackText;
            this.TrackPic = TrackPic;
            BeforeTrack = beforeTrack;
            ArrRouteToPlatform = arrRouteToPlatform;
            DepRouteToPlatform = depRouteToPlatform;
            PlatformToTrack = platformToTrack;
            RouteToTrackY = routeToTrackY;
            RouteToTrackR = routeToTrackR;
            stationNearTrackPic = new StationNearTrackPic();
        }
        public override void SetBeforeClass(TIDTrack track)
        {
            BeforeTrack = track;
        }

        public override void SetTrain(TrackCircuitInfo info)
        {
            bool before = false;
            //到着番線一覧
            string arrPlatform = "";
            if (ArrRouteToPlatform.ContainsKey(info.signalName))
            {
                arrPlatform = ArrRouteToPlatform[info.signalName];
            }
            //出発番線一覧
            string depPlatform = "";
            if (DepRouteToPlatform.ContainsKey(info.signalName))
            {
                depPlatform = DepRouteToPlatform[info.signalName];
            }

            //進入状態
            if (info.stationStatus == StationStatus.ROUTE_CLOSED)
            {
                stationNearTrackPic.RemoveImage(RouteToTrackY[info.signalName]);
                stationNearTrackPic.RemoveImage(RouteToTrackR[info.signalName]);
                if (arrPlatform != "")
                {
                    PlatformToTrack[arrPlatform].ResetRoute();
                }
            }
            else if (info.stationStatus == StationStatus.ROUTE_OPENED)
            {
                stationNearTrackPic.AddImage(RouteToTrackY[info.signalName]);
                stationNearTrackPic.RemoveImage(RouteToTrackR[info.signalName]);
                if (arrPlatform != "")
                {
                    PlatformToTrack[arrPlatform].SetRoute();
                }
            }
            else if (info.stationStatus == StationStatus.ROUTE_ENTERING)
            {
                stationNearTrackPic.RemoveImage(RouteToTrackY[info.signalName]);
                stationNearTrackPic.AddImage(RouteToTrackR[info.signalName]);
                if (arrPlatform != "")
                {
                    ArrTrackText.SetTrain(info);
                }
                else if (depPlatform != "")
                {
                    DepTrackText.SetTrain(info);
                }
                if (depPlatform != "")
                {
                    PlatformToTrack[depPlatform].ResetTrain(info.diaName);
                }
            }
            else if (info.stationStatus == StationStatus.ROUTE_ENTERED)
            {
                stationNearTrackPic.RemoveImage(RouteToTrackY[info.signalName]);
                if (arrPlatform != "")
                {
                    ArrTrackText.ResetTrain(info.diaName);
                    stationNearTrackPic.RemoveImage(RouteToTrackR[info.signalName]);
                    PlatformToTrack[arrPlatform].SetTrain(info);
                }
                else
                {
                    DepTrackText.ResetTrain(info.diaName);
                    stationNearTrackPic.AddImage(RouteToTrackR[info.signalName]);
                }
            }
            if (before)
            {
                BeforeTrack?.ResetTrain(info.diaName);
            }
            TrackPic.Image = stationNearTrackPic.CombineImages();
        }

        public override void ResetTrain(string? retsuban)
        {
            if (retsuban == ArrString)
            {
                ArrTrackText.ResetTrain(retsuban);
                if (ArrPlatform != null)
                {
                    PlatformToTrack[ArrPlatform].ResetTrain(retsuban);
                }
            }
            else if (retsuban == DepString)
            {
                DepTrackText.ResetTrain(retsuban);
            }
        }
    }
}