using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Game.Engine;

namespace Game.Objects
{
    class Alien : GameObject
    {
        private SpriteAnimation spriteAnimation = new SpriteAnimation();

        private double fireTimer = 0;
        private static Random random = new Random();
        public override void Update(double dt)
        {
            fireTimer -= dt;
            if(fireTimer <= 0)
            {
                fireTimer = 2;

                Missile missile = Missile.Create(Postion, new Vector(0, -200), new Vector(20, 20));
                missile.Owner = this;
                Game.AddGameObject(missile);
            }

            if(Postion.X >= 400)
            {
                Velocity = new  Vector(-Velocity.X, Velocity.Y);
                Postion = new Vector(400 - (Postion.X - 400), Postion.Y);
            }
            if (Postion.X <= 0)
            {
                Velocity = new Vector(-Velocity.X, Velocity.Y);
                Postion = new Vector(Math.Abs(Postion.X), Postion.Y);
            }
            spriteAnimation.Update(dt);

            base.Update(dt);
        }
        public override void Draw()
        {
            Sprite.Image.Source = spriteAnimation.GetImage();
            base.Draw();
        }

        public override void OnCollision(GameObject gameObject)
        {
            
            if( gameObject is Missile && gameObject.Owner is Player)
            {
                IsDestroyed = true;
                gameObject.IsDestroyed = true;

                Game.Score += 100;
                AudioPlayer.Instance.PlaySound("explosion");
                
                Game.AddGameObject(Explosion.Create(Postion, new Vector(0, 0), new Vector(30, 30)));
            }
            base.OnCollision(gameObject);

        }
        public static Alien Create(Vector postion, Vector velocity, Vector size)
        {
            Alien alien = new Alien();

            alien.fireTimer = 3+  Alien.random.NextDouble() * 4;

            alien.spriteAnimation.Images.Add(Sprite.CreateBitmap("alienA01.png"));
            alien.spriteAnimation.Images.Add(Sprite.CreateBitmap("alienA02.png"));
            alien.spriteAnimation.Time = 0.2;


            //alien.Sprite.Image.Source = Sprite.CreateBitmap("alienA01.png");
            alien.Sprite.Image.Width = size.X;
            alien.Sprite.Image.Height = size.Y;

            alien.Postion = postion;
            alien.Velocity = velocity;

            return alien;
        }
    }
}
