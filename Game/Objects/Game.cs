using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Game.Engine;

namespace Game.Objects
{
    class Game 
    {
        public int Score { get; set; }
        public Canvas Canvas { get; set; }
        public TextBlock GameOver { get; set; }

        private List<GameObject> gameObjects = new List<GameObject>();

        public void Update(double dt)
        {
            //foreach(GameObject gameObject in gameObjects)
            for(int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(dt);
            }
            //check collisions
            for (int i = 0; i < gameObjects.Count; i++)
                {
                for(int j = i + 1; j < gameObjects.Count; j++)
                {
                    if(gameObjects[i].Intersects(gameObjects[j]))
                    {
                        gameObjects[i].OnCollision(gameObjects[j]);
                    }
                }
            }

            //destroy objects
            var destroyed = gameObjects.Where(gameObjects => gameObjects.IsDestroyed).ToList();
            foreach(var gameObject in destroyed)
            {
                Canvas.Children.Remove(gameObject.Sprite.Image);
            }
            gameObjects = gameObjects.Except(destroyed).ToList();
        }

        public void Draw()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw();
            }
        }
        public void AddGameObject(GameObject gameObject)
        {
            gameObject.Game = this;
            gameObjects.Add(gameObject);
            Canvas.Children.Add(gameObject.Sprite.Image);
        }

        public void OnEvent(string eventName)
        {
            if(eventName == "player_dead")
            {
                GameOver.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
