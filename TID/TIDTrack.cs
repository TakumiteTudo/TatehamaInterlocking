using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatehamaInterlocking.TID
{
    internal class TIDTrack
    {
        private TIDTrack beforeTrack;
        internal static Color White = Color.White;
        internal static Color Trans = Color.Transparent;
        internal static Image TransPng = Properties.Resources.Trans;

        internal static Color Local = Color.FromArgb(0, 255, 255, 255);
        internal static Color SemiExp = Color.FromArgb(0, 0, 255, 255);
        internal static Color Exp = Color.FromArgb(0, 255, 128, 0);
        internal static Color RapExp = Color.FromArgb(0, 192, 128, 255);
        internal static Color LtdExp = Color.FromArgb(0, 255, 0, 64);
        internal static Color NiS = Color.FromArgb(0, 192, 192, 192);
        internal static Color NiSA = Color.FromArgb(0, 255, 128, 128);
        internal static Color NiSB = Color.FromArgb(0, 128, 128, 128);
        internal static Color Mizotsuki = Color.FromArgb(0, 64, 64, 255);

        public TIDTrack() { }

        public virtual void SetBeforeClass(TIDTrack track)
        {
            beforeTrack = track;
        }

        public virtual void SetTrain(TrackCircuitInfo info)
        {
            beforeTrack.ResetTrain(info.diaName);
        }

        public virtual void ResetTrain(string? retsuban)
        {

        }

        public virtual void SetRoute()
        {
        }

        public virtual void ResetRoute()
        {
        }

        /// <summary>
        /// 特定の形式に従って文字列を変換するメソッド
        /// </summary>
        /// <param name="Retsuban">変換前の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string RetsubanText(string Retsuban)
        {
            if (string.IsNullOrWhiteSpace(Retsuban))
            {
                return Retsuban;
            }

            string result = Retsuban;

            // 先頭が数字であれば "　" を追加
            if (char.IsDigit(result[0]) && result.EndsWith("X"))
            {
                result = " " + result;
            }
            else if (char.IsDigit(result[0]))
            {
                result = "　" + result;
            }
            // 条件に従ってスペースを挿入
            if ((result.Length == 4) || (result.Length == 5 && IsAsciiLetter(result[result.Length - 1])))
            {
                result = result.Insert(1, " ");
            }

            return result;
        }

        /// <summary>
        /// 文字がASCIIのアルファベットかどうかを判定するメソッド
        /// </summary>
        /// <param name="c">判定する文字</param>
        /// <returns>アルファベットであればtrue、そうでなければfalse</returns>
        static private bool IsAsciiLetter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }

        public Color TypeColor(string Retsuban)
        {
            if (Retsuban.Contains("溝月"))
            {
                return Mizotsuki;
            }
            if (Retsuban.StartsWith("回"))
            {
                if (Retsuban.Contains("A"))
                {
                    return NiSA;
                }
                return NiS;
            }

            if (Retsuban.Contains("A"))
            {
                return LtdExp;
            }
            if (Retsuban.Contains("K"))
            {
                return RapExp;
            }
            if (Retsuban.Contains("B"))
            {
                return Exp;
            }
            if (Retsuban.Contains("C"))
            {
                return SemiExp;
            }
            if (int.TryParse(Retsuban, null, out _))
            {
                return Local;
            }
            return NiSB;
        }
    }
}
