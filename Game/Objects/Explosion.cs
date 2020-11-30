using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Objects
{
    class Explosion : GameObject
    {
        private double timer = 0.25;
        public override void Update(double dt)
        {
            timer -= dt;
            if (timer <= 0)
            {
                IsDestroyed = true;
            }
            base.Update(dt);
        }
        public static Explosion Create(Vector postion, Vector velocity, Vector size)
        {
            Explosion explosion = new Explosion();

            explosion.Sprite.Image.Source = Sprite.CreateBitmap("explosion.png");
            explosion.Sprite.Image.Width = size.X;
            explosion.Sprite.Image.Height = size.Y;

            explosion.Postion = postion;
            explosion.Velocity = velocity;

            return explosion;
        }
    
}
}
