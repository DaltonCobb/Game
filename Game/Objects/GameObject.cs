using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Objects
{
    class GameObject
    {
        public Game Game { get; set; }
        public Vector Postion { get; set; }
        public Vector Velocity { get; set; }
        public Sprite Sprite { get; set; } = new Sprite();
        public Vector Size { get { return new Vector(Sprite.Image.ActualWidth, Sprite.Image.ActualHeight); } }
        public Rect Rect { get { return new Rect((Point)Postion - (Size * 0.5), Size); } }
        public GameObject Owner { get; set; }
        public bool IsDestroyed { get; set; } = false;

        public virtual void Update(double dt)
        {
            Postion = Postion + (Velocity * dt);
        }

        public virtual void Draw()
        {
            Sprite.Draw(Postion - Size * 0.5);
        }

        public virtual void OnCollision(GameObject gameObject)
        {
            //
        }

        public bool Intersects(GameObject gameObject)
        {
            return this.Rect.IntersectsWith(gameObject.Rect);
        }
    
    }
}
