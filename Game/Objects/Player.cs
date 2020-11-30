using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Game.Engine;

namespace Game.Objects
{
    class Player : GameObject
    {
        public double Speed { get; set; } = 200;
        public double FireRate { get; set; } = 1;

        private double fireTimer = 0;
        public override void Update(double dt)
        {
            Velocity = new Vector(0, 0);
            if (InputSystem.Instance.GetKeyState(InputSystem.eKey.Left))
            {
                Velocity = new Vector(-1, 0) * Speed;
            }
            if (InputSystem.Instance.GetKeyState(InputSystem.eKey.Right))
            {
                Velocity = new Vector(1, 0) * Speed;
            }

            fireTimer -= dt;
            if (fireTimer <= 0 && InputSystem.Instance.GetKeyState(InputSystem.eKey.Space))
            {
                fireTimer = FireRate;
                Missile missile = Missile.Create(Postion, new Vector(0, -250), new Vector(20, 20));
                missile.Owner = this;
                Game.AddGameObject(missile);

                AudioPlayer.Instance.PlaySound("fire");
            }


            base.Update(dt);
        }

        public override void OnCollision(GameObject gameObject)
        {

            if (gameObject is Missile && gameObject.Owner is Alien)
            {
                IsDestroyed = true;
                gameObject.IsDestroyed = true;

                Game.OnEvent("player_dead");
                AudioPlayer.Instance.PlaySound("explosion");

                Game.AddGameObject(Explosion.Create(Postion, new Vector(0, 0), new Vector(30, 30)));
            }
            base.OnCollision(gameObject);

        }
        public static Player Create(Vector postion, Vector velocity, Vector size)
        {
            Player player = new Player();

            player.Sprite.Image.Source = Sprite.CreateBitmap("player.png");
            player.Sprite.Image.Width = size.X;
            player.Sprite.Image.Height = size.Y;

            player.Postion = postion;
            player.Velocity = velocity;

            return player;
        }
    }
}
