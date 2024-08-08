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
        private CommonTrack? ArrTrackText;
        private CommonTrack? DepTrackText;
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

        public StationNearTrack(CommonTrack? arrTrackText, CommonTrack? depTrackText, PictureBox TrackPic, TIDTrack? beforeTrack,
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

        public StationNearTrack(CommonTrack? arrTrackText, CommonTrack? depTrackText, PictureBox TrackPic, TIDTrack? beforeTrack,
            Dictionary<string, string> arrRouteToPlatform, Dictionary<string, string> depRouteToPlatform, Dictionary<string, TIDTrack> platformToTrack,
            Dictionary<string, Image> routeToTrackY, Dictionary<string, Image> routeToTrackR, StationNearTrackPic stationNearTrackPic)
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
            this.stationNearTrackPic = stationNearTrackPic;
        }
        public override void SetBeforeClass(TIDTrack track)
        {
            BeforeTrack = track;
        }

        public override void SetTrain(TrackCircuitInfo info)
        {
            //ToDo：ArrTrackText/DepTrackTextの情報変更をてこLのRで判断するように変更する。
            bool before = false;
            bool TrackOnly = false;
            string signalName = info.signalName;
            //到着番線一覧
            string arrPlatform = "";
            if (ArrRouteToPlatform.ContainsKey(signalName))
            {
                arrPlatform = ArrRouteToPlatform[signalName];
                if (arrPlatform.EndsWith("番"))
                {
                    TrackOnly = true;
                    arrPlatform = arrPlatform + "線";
                }
            }
            //出発番線一覧
            string depPlatform = "";
            if (DepRouteToPlatform.ContainsKey(signalName))
            {
                depPlatform = DepRouteToPlatform[signalName];
            }

            //進入状態
            if (info.stationStatus == StationStatus.ROUTE_CLOSED)
            {
                stationNearTrackPic.RemoveImage(RouteToTrackY[signalName]);
                stationNearTrackPic.RemoveImage(RouteToTrackR[signalName]);
                if (arrPlatform != "")
                {
                    PlatformToTrack[arrPlatform].ResetTrain(null);
                }
                else if (depPlatform != "")
                {
                    DepTrackText?.ResetTrain(null);
                }
            }
            else if (info.stationStatus == StationStatus.ROUTE_OPENED)
            {
                stationNearTrackPic.AddImage(RouteToTrackY[signalName]);
                stationNearTrackPic.RemoveImage(RouteToTrackR[signalName]);
                if (arrPlatform != "")
                {
                    PlatformToTrack[arrPlatform].SetRoute();
                }
            }
            else if (info.stationStatus == StationStatus.ROUTE_ENTERING)
            {
                BeforeTrack?.ResetTrain(info.diaName);
                stationNearTrackPic.RemoveImage(RouteToTrackY[signalName]);
                stationNearTrackPic.AddImage(RouteToTrackR[signalName]);
                if (arrPlatform != "")
                {
                    if (TrackOnly)
                    {
                        ArrTrackText?.ResetTrain(info.diaName);
                        PlatformToTrack[arrPlatform].SetTrain(info);
                    }
                    else
                    {
                        ArrTrackText?.SetTrain(info);
                    }
                }
                else if (depPlatform != "")
                {
                    DepTrackText?.SetTrain(info);
                }
                else
                {
                    ArrTrackText?.SetTrain(info);
                }
                if (depPlatform != "")
                {
                    PlatformToTrack[depPlatform].ResetTrain(info.diaName);
                }
            }
            else if (info.stationStatus == StationStatus.ROUTE_ENTERED)
            {
                stationNearTrackPic.RemoveImage(RouteToTrackY[signalName]);
                if (arrPlatform != "")
                {
                    ArrTrackText?.ResetTrain(info.diaName);
                    stationNearTrackPic.RemoveImage(RouteToTrackR[signalName]);
                    PlatformToTrack[arrPlatform].SetTrain(info);
                }
                else if (depPlatform != "")
                {
                    DepTrackText?.SetTrain(info);
                    stationNearTrackPic.AddImage(RouteToTrackR[signalName]);
                }
                else
                {
                    DepTrackText?.ResetTrain(info.diaName);
                    stationNearTrackPic.AddImage(RouteToTrackR[signalName]);
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
            ArrTrackText?.ResetTrain(retsuban);
            DepTrackText?.ResetTrain(retsuban);
        }
    }
}