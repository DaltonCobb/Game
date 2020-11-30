using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;

namespace Game.Objects
{
    class Sprite
    {
        public Image Image { get; set; } = new Image();

        public void Draw(Vector position)
        {
            Canvas.SetLeft(Image, position.X);
            Canvas.SetTop(Image, position.Y);
        }

        public static BitmapImage CreateBitmap(string name)
        {

            Uri uri = new Uri("pack://application:,,,/Resources/Images/" + name);
            BitmapImage bitmapImage = new BitmapImage(uri);

            return bitmapImage;
        }
    }
}
