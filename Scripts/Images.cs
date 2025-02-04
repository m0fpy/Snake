using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Snake.Scripts
{
    public static class Images
    {
        public readonly static ImageSource Empty = LoadImage("EmptyCell.png");
        public readonly static ImageSource Food = LoadImage("FoodCell.png");
        public readonly static ImageSource Head = LoadImage("HeadCell.png");
        public readonly static ImageSource Body = LoadImage("BodyCell.png");
        public readonly static ImageSource DeadHead = LoadImage("DeadHeadCell.png");
        public readonly static ImageSource DeadBody = LoadImage("DeadBodyCell.png");

        private static ImageSource LoadImage(string fileName)
        {
            return new  BitmapImage(new Uri($"Assets/{fileName}", UriKind.Relative));
        }
    }
}
