using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Game.Objects
{
    class SpriteAnimation
    {

        public List<BitmapImage> Images { get; set; } = new List<BitmapImage>();
        public double Time { get; set; }

        private double timer;
        private int frame;

        public void Update(double dt)
        {
            timer += dt;
            if(timer >= Time)
            {
                timer = 0;
                frame++;
                if (frame >= Images.Count) frame = 0;
            }
        }

        public BitmapImage GetImage()
        {
            return Images[frame];
        }
    }
}
