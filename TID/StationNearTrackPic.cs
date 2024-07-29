using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace TatehamaInterlocking.TID
{
    /// <summary>
    /// 複数の画像を重ね合わせたり除去するクラス
    /// </summary>
    public class StationNearTrackPic
    {
        private HashSet<Image> images;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StationNearTrackPic()
        {
            images = new HashSet<Image>();
        }

        /// <summary>
        /// 画像を追加するメソッド
        /// </summary>
        /// <param name="image">追加する画像</param>
        public void AddImage(Image image)
        {
            images.Add(image);
        }

        /// <summary>
        /// 画像を削除するメソッド
        /// </summary>
        /// <param name="image">削除する画像</param>
        public void RemoveImage(Image image)
        {
            images.Remove(image);
        }

        /// <summary>
        /// 画像を重ね合わせるメソッド
        /// </summary>
        /// <returns>重ね合わせた画像</returns>
        public Image CombineImages()
        {
            if (images.Count == 0) return TIDTrack.TransPng;

            // 最初の画像を基準にサイズを決定
            int width = images.First().Width;
            int height = images.First().Height;
            Bitmap combinedImage = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(combinedImage))
            {
                foreach (var image in images)
                {
                    g.DrawImage(image, new Point(0, 0));
                }
            }

            return combinedImage;
        }
    }
}
