using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Objects
{
    class Missile : GameObject
    {
        private double timer = 1.5;
        public override void Update(double dt)
        {
            timer -= dt;
            if(timer <= 0)
            {
                IsDestroyed = true;
            }
            base.Update(dt);
        }
        public static Missile Create(Vector postion, Vector velocity, Vector size)
        {
            Missile missile = new Missile();

            missile.Sprite.Image.Source = Sprite.CreateBitmap("missile.png");
            missile.Sprite.Image.Width = size.X;
            missile.Sprite.Image.Height = size.Y;

            missile.Postion = postion;
            missile.Velocity = velocity;

            return missile;
        }
    }
}
