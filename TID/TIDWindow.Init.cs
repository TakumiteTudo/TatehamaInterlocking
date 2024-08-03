using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatehamaInterlocking.TID
{
    partial class TIDWindow
    {
        private void TIDInit()
        {
            var TrackNo6 = new CommonTrack(Text_6, Line_6, Track_6, null);
            TrackList["上り閉塞6"] = TrackNo6;
            var TrackNo8 = new CommonTrack(Text_8, Line_8, Track_8, TrackNo6);
            TrackList["上り閉塞8"] = TrackNo8;

            //駒野
            var TrackNo26 = new CommonTrack(Text_26, Line_26, Track_26, null);
            TrackList["上り閉塞26"] = TrackNo26;
            var TrackNo30 = new CommonTrack(Text_30, Line_30, Track_30, TrackNo26);
            TrackList["上り閉塞30"] = TrackNo30;
            var TrackNo36 = new CommonTrack(Text_36, Line_36, Track_36, TrackNo30);
            TrackList["上り閉塞36"] = TrackNo36;
            var TrackNo42 = new CommonTrack(Text_42, Line_42, Track_42, TrackNo36);
            TrackList["上り閉塞42"] = TrackNo42;
            var TrackNo48 = new CommonTrack(Text_48, Line_48, Track_48, TrackNo42);
            TrackList["上り閉塞48"] = TrackNo48;
            var TrackNo56 = new CommonTrack(Text_56, Line_56, Track_56, TrackNo48);
            TrackList["上り閉塞56"] = TrackNo56;
            var TrackNo62 = new CommonTrack(Text_62, Line_62, Track_62, TrackNo56);
            TrackList["上り閉塞62"] = TrackNo62;
            var TrackNo68 = new CommonTrack(Text_68, Line_68, Track_68, TrackNo62);
            TrackList["上り閉塞68"] = TrackNo68;
            var TrackNo74 = new CommonTrack(Text_74, Line_74, Track_74, TrackNo68);
            TrackList["上り閉塞74"] = TrackNo74;

            //津崎
            var TrackNo86 = new CommonTrack(Text_86, Line_86, Track_86, null);
            TrackList["上り閉塞86"] = TrackNo86;
            var TrackNo92 = new CommonTrack(Text_92, Line_92, Track_92, TrackNo86);
            TrackList["上り閉塞92"] = TrackNo92;
            //浜園
            var TrackNo102 = new CommonTrack(Text_102, Line_102, Track_102, null);
            TrackList["上り閉塞102"] = TrackNo102;
            var TrackNo108 = new CommonTrack(Text_108, Line_108, Track_108, TrackNo102);
            TrackList["上り閉塞108"] = TrackNo108;
            var TrackNo114 = new CommonTrack(Text_114, Line_114, Track_114, TrackNo108);
            TrackList["上り閉塞114"] = TrackNo114;
            var TrackNo120 = new CommonTrack(Text_120, Line_120, Track_120, TrackNo114);
            TrackList["上り閉塞120"] = TrackNo120;
            var TrackNo124 = new CommonTrack(Text_124, Line_124, Track_124, TrackNo120);
            TrackList["上り閉塞124"] = TrackNo124;
            //新野崎
            var TrackNo136 = new CommonTrack(Text_136, Line_136, Track_136, null);
            TrackList["上り閉塞136"] = TrackNo136;
            var TrackNo142 = new CommonTrack(Text_142, Line_142, Track_142, TrackNo136);
            TrackList["上り閉塞142"] = TrackNo142;
            var TrackNo146 = new CommonTrack(Text_146, Line_146, Track_146, TrackNo142);
            TrackList["上り閉塞146"] = TrackNo146;
            //江ノ原
            var TrackNo156 = new CommonTrack(Text_156, Line_156, Track_156, null);
            TrackList["上り閉塞156"] = TrackNo156;


            //江ノ原
            var TrackNo151 = new CommonTrack(Text_151, Line_151, Track_151, null);
            TrackList["下り閉塞151"] = TrackNo151;
            var TrackNo145 = new CommonTrack(Text_145, Line_145, Track_145, TrackNo151);
            TrackList["下り閉塞145"] = TrackNo145;
            var TrackNo143 = new CommonTrack(Text_143, Line_143, Track_143, TrackNo145);
            TrackList["下り閉塞143"] = TrackNo143;
            var TrackNo137 = new CommonTrack(Text_137, Line_137, Track_137, TrackNo143);
            TrackList["下り閉塞137"] = TrackNo137;
            // 新野崎
            var TrackNo123 = new CommonTrack(Text_123, Line_123, Track_123, null);
            TrackList["下り閉塞123"] = TrackNo123;
            var TrackNo117 = new CommonTrack(Text_117, Line_117, Track_117, TrackNo123);
            TrackList["下り閉塞117"] = TrackNo117;
            var TrackNo111 = new CommonTrack(Text_111, Line_111, Track_111, TrackNo117);
            TrackList["下り閉塞111"] = TrackNo111;
            var TrackNo105 = new CommonTrack(Text_105, Line_105, Track_105, TrackNo111);
            TrackList["下り閉塞105"] = TrackNo105;
            var TrackNo103 = new CommonTrack(Text_103, Line_103, Track_103, TrackNo105);
            TrackList["下り閉塞103"] = TrackNo103;

            var TrackNo89 = new CommonTrack(Text_89, Line_89, Track_89, null);
            TrackList["下り閉塞89"] = TrackNo89;

            //津崎    
            var TrackNo75 = new CommonTrack(Text_75, Line_75, Track_75, null);
            TrackList["下り閉塞75"] = TrackNo75;
            var TrackNo71 = new CommonTrack(Text_71, Line_71, Track_71, TrackNo75);
            TrackList["下り閉塞71"] = TrackNo71;
            var TrackNo67 = new CommonTrack(Text_67, Line_67, Track_67, TrackNo71);
            TrackList["下り閉塞67"] = TrackNo67;
            var TrackNo59 = new CommonTrack(Text_59, Line_59, Track_59, TrackNo67);
            TrackList["下り閉塞59"] = TrackNo59;
            var TrackNo55 = new CommonTrack(Text_55, Line_55, Track_55, TrackNo59);
            TrackList["下り閉塞55"] = TrackNo55;
            var TrackNo49 = new CommonTrack(Text_49, Line_49, Track_49, TrackNo55);
            TrackList["下り閉塞49"] = TrackNo49;
            var TrackNo45 = new CommonTrack(Text_45, Line_45, Track_45, TrackNo49);
            TrackList["下り閉塞45"] = TrackNo45;
            var TrackNo41 = new CommonTrack(Text_41, Line_41, Track_41, TrackNo45);
            TrackList["下り閉塞41"] = TrackNo41;
            var TrackNo35 = new CommonTrack(Text_35, Line_35, Track_35, TrackNo41);
            TrackList["下り閉塞35"] = TrackNo35;
            var TrackNo27 = new CommonTrack(Text_27, Line_27, Track_27, TrackNo35);
            TrackList["下り閉塞27"] = TrackNo27;

            //駒野
            var TrackNo9 = new CommonTrack(Text_9, Line_9, Track_9, null);
            TrackList["下り閉塞9"] = TrackNo9;
            var TrackNo7 = new CommonTrack(Text_7, Line_7, Track_7, TrackNo9);
            TrackList["下り閉塞7"] = TrackNo7;


            var TatehamaE = new StationNearTrack
            (
                new CommonTrack(Text_W01_5L, Line_W01_5L, null, null),
                new CommonTrack(Text_W01_SST, Line_W01_SST, null, null),
                Track_W01_E, TrackNo7,
                new Dictionary<string, string>
                {
                    {"館浜下り場内1LA", "1番線" }  ,
                    {"館浜下り場内1LB", "2番線" }  ,
                    {"館浜下り場内1LC", "3番線" }  ,
                    {"館浜下り場内1LD", "4番線" }
                },
                new Dictionary<string, string>
                {
                    {"館浜上り出発1R", "1番線" }  ,
                    {"館浜上り出発2R", "2番線" }  ,
                    {"館浜上り出発3R", "3番線" }  ,
                    {"館浜上り出発4R", "4番線" }
                },
                new Dictionary<string, TIDTrack>
                {
                    {"1番線", new CommonTrack(Text_W01_Track1, Line_W01_Track1, Track_W01_Track1, null) },
                    {"2番線", new CommonTrack(Text_W01_Track2, Line_W01_Track2, Track_W01_Track2, null) },
                    {"3番線", new CommonTrack(Text_W01_Track3, Line_W01_Track3, Track_W01_Track3, null) },
                    {"4番線", new CommonTrack(Text_W01_Track4, Line_W01_Track4, Track_W01_Track4, null) }
                },
                new Dictionary<string, Image>{
                    {"館浜上り出発1R", Properties.Resources.TID_Track_W01_1R_Y } ,
                    {"館浜上り出発2R", Properties.Resources.TID_Track_W01_2R_Y } ,
                    {"館浜上り出発3R", Properties.Resources.TID_Track_W01_3R_Y } ,
                    {"館浜上り出発4R", Properties.Resources.TID_Track_W01_4R_Y } ,
                    {"館浜下り場内1LA", Properties.Resources.TID_Track_W01_5LA_Y } ,
                    {"館浜下り場内1LB", Properties.Resources.TID_Track_W01_5LB_Y } ,
                    {"館浜下り場内1LC", Properties.Resources.TID_Track_W01_5LC_Y } ,
                    {"館浜下り場内1LD", Properties.Resources.TID_Track_W01_5LD_Y }
                },
                new Dictionary<string, Image>{
                    {"館浜上り出発1R", Properties.Resources.TID_Track_W01_1R_R } ,
                    {"館浜上り出発2R", Properties.Resources.TID_Track_W01_2R_R } ,
                    {"館浜上り出発3R", Properties.Resources.TID_Track_W01_3R_R } ,
                    {"館浜上り出発4R", Properties.Resources.TID_Track_W01_4R_R } ,
                    {"館浜下り場内1LA", Properties.Resources.TID_Track_W01_5LA_R } ,
                    {"館浜下り場内1LB", Properties.Resources.TID_Track_W01_5LB_R } ,
                    {"館浜下り場内1LC", Properties.Resources.TID_Track_W01_5LC_R } ,
                    {"館浜下り場内1LD", Properties.Resources.TID_Track_W01_5LD_R }
                }
            );

            TrackList["館浜上り出発1R"] = TatehamaE;
            TrackList["館浜上り出発2R"] = TatehamaE;
            TrackList["館浜上り出発3R"] = TatehamaE;
            TrackList["館浜上り出発4R"] = TatehamaE;
            TrackList["館浜下り場内1LA"] = TatehamaE;
            TrackList["館浜下り場内1LB"] = TatehamaE;
            TrackList["館浜下り場内1LC"] = TatehamaE;
            TrackList["館浜下り場内1LD"] = TatehamaE;

            TrackNo6.SetBeforeClass(TatehamaE);



            //津崎   
            var W06_Track1 = new CommonTrack(Text_W06_Track1, Line_W06_Track1, Track_W06_Track1, null);
            var W06_Track2 = new CommonTrack(Text_W06_Track2, Line_W06_Track2, Track_W06_Track2, null);
            var W06_Track3 = new CommonTrack(Text_W06_Track3, Line_W06_Track3, Track_W06_Track3, null);
            var W06_Track4 = new CommonTrack(Text_W06_Track4, Line_W06_Track4, Track_W06_Track4, null);

            var TsuzakiW = new StationNearTrack
            (
                new CommonTrack(Text_W06_1R, Line_W06_1R, null, null),
                new CommonTrack(Text_W06_TST, Line_W06_TST, null, null),
                Track_W06_W, TrackNo74,
                new Dictionary<string, string>
                {
                    {"津崎上り場内1RB", "1番線" }  ,
                    {"津崎上り場内1RA", "2番線" }
                },
                new Dictionary<string, string>
                {
                    {"津崎下り出発1L", "3番線" }  ,
                    {"津崎下り出発2L", "4番線" }
                },
                new Dictionary<string, TIDTrack>
                {
                                {"1番線", W06_Track1 },
                                {"2番線", W06_Track2 },
                                {"3番線", W06_Track3 },
                                {"4番線", W06_Track4 }
                },
                new Dictionary<string, Image>{
                    {"津崎上り場内1RB", Properties.Resources.TID_Track_W06_1RA_Y } ,
                    {"津崎上り場内1RA", Properties.Resources.TID_Track_W06_1RB_Y } ,
                    {"津崎下り出発1L", Properties.Resources.TID_Track_W06_2L_Y } ,
                    {"津崎下り出発2L", Properties.Resources.TID_Track_W06_3L_Y }
                },
                new Dictionary<string, Image>{
                    {"津崎上り場内1RB", Properties.Resources.TID_Track_W06_1RA_R } ,
                    {"津崎上り場内1RA", Properties.Resources.TID_Track_W06_1RB_R } ,
                    {"津崎下り出発1L", Properties.Resources.TID_Track_W06_2L_R } ,
                    {"津崎下り出発2L", Properties.Resources.TID_Track_W06_3L_R }
                }
            );

            var TsuzakiE = new StationNearTrack
            (
                new CommonTrack(Text_W06_6L, Line_W06_6L, null, null),
                new CommonTrack(Text_W06_SST, Line_W06_SST, null, null),
                Track_W06_E, TrackNo89,
                new Dictionary<string, string>
                {
                                {"津崎下り場内3LA", "3番線" }  ,
                                {"津崎下り場内3LB", "4番線" }
                },
                new Dictionary<string, string>
                {
                                {"津崎上り出発2R", "1番線" }  ,
                                {"津崎上り出発3R", "2番線" }
                },
                new Dictionary<string, TIDTrack>
                {
                                            {"1番線", W06_Track1 },
                                            {"2番線", W06_Track2 },
                                            {"3番線", W06_Track3 },
                                            {"4番線", W06_Track4 }
                },
                new Dictionary<string, Image>{
                                {"津崎上り出発2R", Properties.Resources.TID_Track_W06_4R_Y } ,
                                {"津崎上り出発3R", Properties.Resources.TID_Track_W06_5R_Y } ,
                                {"津崎下り場内3LA", Properties.Resources.TID_Track_W06_6LC_Y } ,
                                {"津崎下り場内3LB", Properties.Resources.TID_Track_W06_6LD_Y }
                },
                new Dictionary<string, Image>{
                                {"津崎上り出発2R", Properties.Resources.TID_Track_W06_4R_R } ,
                                {"津崎上り出発3R", Properties.Resources.TID_Track_W06_5R_R } ,
                                {"津崎下り場内3LA", Properties.Resources.TID_Track_W06_6LC_R } ,
                                {"津崎下り場内3LB", Properties.Resources.TID_Track_W06_6LD_R }
                }
            );

            TrackList["津崎上り場内1RB"] = TsuzakiW;
            TrackList["津崎上り場内1RA"] = TsuzakiW;
            TrackList["津崎下り出発1L"] = TsuzakiW;
            TrackList["津崎下り出発2L"] = TsuzakiW;
            TrackList["津崎上り出発2R"] = TsuzakiE;
            TrackList["津崎上り出発3R"] = TsuzakiE;
            TrackList["津崎下り場内3LA"] = TsuzakiE;
            TrackList["津崎下り場内3LB"] = TsuzakiE;

            TrackNo75.SetBeforeClass(TsuzakiW);
            TrackNo86.SetBeforeClass(TsuzakiE);



            //浜園                        
            var W07_Track1 = new CommonTrack(Text_W06_Track1, Line_W06_Track1, Track_W06_Track1, null);
            var W07_Track2 = new CommonTrack(Text_W06_Track2, Line_W06_Track2, Track_W06_Track2, null);


            //新野崎   
            var W10_Track1 = new CommonTrack(Text_W10_Track1, Line_W10_Track1, Track_W10_Track1, null);
            var W10_Track2 = new CommonTrack(Text_W10_Track2, Line_W10_Track2, Track_W10_Track2, null);
            var W10_Track3 = new CommonTrack(Text_W10_Track3, Line_W10_Track3, Track_W10_Track3, null);
            var W10_Track4 = new CommonTrack(Text_W10_Track4, Line_W10_Track4, Track_W10_Track4, null);

            var ShinNozakiW = new StationNearTrack
            (
                new CommonTrack(Text_W10_1R, Line_W10_1R, null, null),
                new CommonTrack(Text_W10_TST, Line_W10_TST, null, null),
                Track_W10_W, TrackNo74,
                new Dictionary<string, string>
                {
                                {"新野崎上り場内1RB", "1番線" }  ,
                                {"新野崎上り場内1RA", "2番線" }
                },
                new Dictionary<string, string>
                {
                                {"新野崎下り出発1L", "3番線" }  ,
                                {"新野崎下り出発2L", "4番線" }
                },
                new Dictionary<string, TIDTrack>
                {
                                            {"1番線", W10_Track1 },
                                            {"2番線", W10_Track2 },
                                            {"3番線", W10_Track3 },
                                            {"4番線", W10_Track4 }
                },
                new Dictionary<string, Image>{
                                {"新野崎上り場内1RB", Properties.Resources.TID_Track_W10_1RA_Y } ,
                                {"新野崎上り場内1RA", Properties.Resources.TID_Track_W10_1RB_Y } ,
                                {"新野崎下り出発1L", Properties.Resources.TID_Track_W10_2L_Y } ,
                                {"新野崎下り出発2L", Properties.Resources.TID_Track_W10_3L_Y }
                },
                new Dictionary<string, Image>{
                                {"新野崎上り場内1RB", Properties.Resources.TID_Track_W10_1RA_R } ,
                                {"新野崎上り場内1RA", Properties.Resources.TID_Track_W10_1RB_R } ,
                                {"新野崎下り出発1L", Properties.Resources.TID_Track_W10_2L_R } ,
                                {"新野崎下り出発2L", Properties.Resources.TID_Track_W10_3L_R }
                }
            );
            var ShinNozakiE = new StationNearTrack
            (
            new CommonTrack(Text_W10_10L, Line_W10_10L, null, null),
            new CommonTrack(Text_W10_SST, Line_W10_SST, null, null),
            Track_W10_E, TrackNo137,
            new Dictionary<string, string>
            {
                                            {"新野崎下り場内3L", "3番線" } ,
                                            {"新野崎下り場内4L", "4番線" } ,
                                            {"新野崎入換104L", "4番線" },
                                            {"新野崎入換111R", "5番線" }
            },
            new Dictionary<string, string>
            {
                                            {"新野崎上り出発11R", "1番線" } ,
                                            {"新野崎上り出発12R", "2番線" } ,
                                            {"新野崎入換111R", "1番線" }
            },
            new Dictionary<string, TIDTrack>
            {
                                                        {"1番線", W10_Track1 },
                                                        {"2番線", W10_Track2 },
                                                        {"3番線", W10_Track3 },
                                                        {"4番線", W10_Track4 },
                                            {"5番線", new CommonTrack(Text_W10_Track5, Line_W10_Track5, Track_W10_Track5, null) }
            },
            new Dictionary<string, Image>{
                                            {"新野崎下り場内3L", TIDTrack.TransPng } ,
                                            {"新野崎下り場内4L", TIDTrack.TransPng } ,
                                            {"新野崎上り出発11R", Properties.Resources.TID_Track_W10_8R_Y } ,
                                            {"新野崎上り出発12R", Properties.Resources.TID_Track_W10_9R_Y } ,
                                            {"新野崎下り場内5LA", Properties.Resources.TID_Track_W10_10LC_Y } ,
                                            {"新野崎下り場内5LB", Properties.Resources.TID_Track_W10_10LD_Y } ,
                                            {"新野崎入換104L", TIDTrack.TransPng } ,
                                            {"新野崎入換111R", Properties.Resources.TID_Track_W10_33R_Y } ,
                                            {"新野崎入換101L", Properties.Resources.TID_Track_W10_35LD_Y } ,
            },
            new Dictionary<string, Image>{
                                            {"新野崎下り場内3L", TIDTrack.TransPng } ,
                                            {"新野崎下り場内4L", TIDTrack.TransPng } ,
                                            {"新野崎上り出発11R", Properties.Resources.TID_Track_W10_8R_R } ,
                                            {"新野崎上り出発12R", Properties.Resources.TID_Track_W10_9R_R } ,
                                            {"新野崎下り場内5LA", Properties.Resources.TID_Track_W10_10LC_R } ,
                                            {"新野崎下り場内5LB", Properties.Resources.TID_Track_W10_10LD_R } ,
                                            {"新野崎入換104L", TIDTrack.TransPng } ,
                                            {"新野崎入換111R", Properties.Resources.TID_Track_W10_33R_R } ,
                                            {"新野崎入換101L", Properties.Resources.TID_Track_W10_35LD_R } ,
            }
            );

            TrackList["新野崎上り場内1RB"] = ShinNozakiW;
            TrackList["新野崎上り場内1RA"] = ShinNozakiW;
            TrackList["新野崎下り出発1L"] = ShinNozakiW;
            TrackList["新野崎下り出発2L"] = ShinNozakiW;
            TrackList["新野崎下り場内3L"] = ShinNozakiE;
            TrackList["新野崎下り場内4L"] = ShinNozakiE;
            TrackList["新野崎上り出発11R"] = ShinNozakiE;
            TrackList["新野崎上り出発12R"] = ShinNozakiE;
            TrackList["新野崎下り場内5LA"] = ShinNozakiE;
            TrackList["新野崎下り場内5LB"] = ShinNozakiE;
            TrackList["新野崎入換104L"] = ShinNozakiE;
            TrackList["新野崎入換111R"] = ShinNozakiE;
            TrackList["新野崎入換101L"] = ShinNozakiE;


            TrackNo136.SetBeforeClass(ShinNozakiW);
            TrackNo123.SetBeforeClass(ShinNozakiE);


            var W12_Track1 = new CommonTrack(Text_W12_Track1, Line_W12_Track1, Track_W12_Track1, null);
            var W12_Track2 = new CommonTrack(Text_W12_Track2, Line_W12_Track2, Track_W12_Track2, null);
            var W12_Track3 = new CommonTrack(Text_W12_Track3, Line_W12_Track3, Track_W12_Track3, null);
            var W12_Track4 = new CommonTrack(Text_W12_Track4, Line_W12_Track4, Track_W12_Track4, null);


            var DaidojiW = new StationNearTrack
            (
                new CommonTrack(Text_W12_1R, Line_W12_1R, null, null),
                new CommonTrack(Text_W12_TST, Line_W12_TST, null, null),
                Track_W12_W, TrackNo156,
                new Dictionary<string, string>
                {
                                {"大道寺上り場内2R", "1番線" }  ,
                                {"大道寺上り場内3R", "2番線" }  ,
                                {"大道寺上り場内8R", "3番線" }
                },
                new Dictionary<string, string>
                {
                                {"大道寺下り出発1L", "3番線" }  ,
                                {"大道寺下り出発2L", "4番線" }
                },
                new Dictionary<string, TIDTrack>
                {
                                {"1番線", W12_Track1 },
                                {"2番線", W12_Track2 },
                                {"3番線", W12_Track3 },
                                {"4番線", W12_Track4 }
                },
                new Dictionary<string, Image>{
                                {"大道寺上り場内1RA", Properties.Resources.TID_Track_W12_1RA_Y } ,
                                {"大道寺上り場内1RB", Properties.Resources.TID_Track_W12_1RB_Y } ,
                                {"大道寺上り場内1RC", Properties.Resources.TID_Track_W12_1RC_Y } ,
                                {"大道寺上り場内2R", TIDTrack.TransPng } ,
                                {"大道寺上り場内3R", TIDTrack.TransPng } ,
                                {"大道寺上り場内8R", TIDTrack.TransPng } ,
                                {"大道寺下り出発1L", Properties.Resources.TID_Track_W12_5L_Y } ,
                                {"大道寺下り出発2L", Properties.Resources.TID_Track_W12_6L_Y }
                },
                new Dictionary<string, Image>{
                                {"大道寺上り場内1RA", Properties.Resources.TID_Track_W12_1RA_R } ,
                                {"大道寺上り場内1RB", Properties.Resources.TID_Track_W12_1RB_R } ,
                                {"大道寺上り場内1RC", Properties.Resources.TID_Track_W12_1RC_R } ,
                                {"大道寺上り場内2R", TIDTrack.TransPng } ,
                                {"大道寺上り場内3R", TIDTrack.TransPng } ,
                                {"大道寺上り場内8R", TIDTrack.TransPng } ,
                                {"大道寺下り出発1L", Properties.Resources.TID_Track_W12_5L_R } ,
                                {"大道寺下り出発2L", Properties.Resources.TID_Track_W12_6L_R }
                }
            );

            var DaidojiE = new StationNearTrack
            (
                new CommonTrack(Text_W12_13L, Line_W12_13L, null, null),
                new CommonTrack(Text_W12_7R, Line_W12_7R, null, null),
                Track_W12_E, null,
                new Dictionary<string, string>
                {
                                {"大道寺入換105R", "E番線" }  ,
                                {"大道寺入換112L", "E番線" }  ,
                                {"大道寺入換103L", "3番線" }  ,
                                {"大道寺入換104L", "4番線" }  ,
                                {"大道寺入換110LC", "3番線" }  ,
                                {"大道寺入換110LD", "4番線" }  ,
                                {"大道寺入換110R", "7番線" }
                },
                new Dictionary<string, string>
                {
                    {"大道寺入換105R", "2番線" }  ,
                    {"大道寺入換112L", "7番線" }  ,
                    {"大道寺入換110L", "E番線" }  ,
                    {"大道寺入換110R", "E番線" }
                },
                new Dictionary<string, TIDTrack>
                {
                                            {"1番線", W12_Track1 },
                                            {"2番線", W12_Track2 },
                                            {"3番線", W12_Track3 },
                                            {"4番線", W12_Track4 },
                                {"5番線", new CommonTrack(Text_W12_Track5, Line_W12_Track5, Track_W12_Track5, null) },
                                {"6番線", new CommonTrack(Text_W12_Track6, Line_W12_Track6, Track_W12_Track6, null) },
                                {"7番線", new CommonTrack(Text_W12_Track7, Line_W12_Track7, Track_W12_Track7, null) }  ,
                                {"E番線", new CommonImageTrack(Text_W12_28BT, Line_W12_28BT, Track_W12_28BT, null, Properties.Resources.Trans , Properties.Resources.TID_Track_W12_28BT_Y, Properties.Resources.TID_Track_W12_28BT_R) }
                },
                new Dictionary<string, Image>{
                    {"大道寺入換105R", Properties.Resources.TID_Track_W12_42RE_Y } ,
                    {"大道寺入換112L", Properties.Resources.TID_Track_W12_47LE_Y } ,
                    {"大道寺入換103L", TIDTrack.TransPng } ,
                    {"大道寺入換104L", TIDTrack.TransPng } ,
                    {"大道寺入換110LC", Properties.Resources.TID_Track_W12_43RE_Y } ,
                    {"大道寺入換110LD", Properties.Resources.TID_Track_W12_44RE_Y } ,
                    {"大道寺入換110R", Properties.Resources.TID_Track_W12_47LE_Y }
                },
                new Dictionary<string, Image>{
                    {"大道寺入換105R", Properties.Resources.TID_Track_W12_42RE_R } ,
                    {"大道寺入換112L", Properties.Resources.TID_Track_W12_47LE_R } ,
                    {"大道寺入換103L", TIDTrack.TransPng } ,
                    {"大道寺入換104L", TIDTrack.TransPng } ,
                    {"大道寺入換110LC", Properties.Resources.TID_Track_W12_43RE_R } ,
                    {"大道寺入換110LD", Properties.Resources.TID_Track_W12_44RE_R } ,
                    {"大道寺入換110R", Properties.Resources.TID_Track_W12_47LE_R }
                }
            );

            TrackList["大道寺上り場内1RA"] = DaidojiW;
            TrackList["大道寺上り場内1RB"] = DaidojiW;
            TrackList["大道寺上り場内1RC"] = DaidojiW;
            TrackList["大道寺上り場内2R"] = DaidojiW;
            TrackList["大道寺上り場内3R"] = DaidojiW;
            TrackList["大道寺上り場内8R"] = DaidojiW;
            TrackList["大道寺下り出発1L"] = DaidojiW;
            TrackList["大道寺下り出発2L"] = DaidojiW;
            TrackList["大道寺入換105R"] = DaidojiE;
            TrackList["大道寺入換112L"] = DaidojiE;
            TrackList["大道寺入換103L"] = DaidojiE;
            TrackList["大道寺入換104L"] = DaidojiE;
            TrackList["大道寺入換110LC"] = DaidojiE;
            TrackList["大道寺入換110LD"] = DaidojiE;
            TrackList["大道寺入換110R"] = DaidojiE;

        }
    }
}
