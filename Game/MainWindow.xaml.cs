using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Game.Objects;
using Game.Engine;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game.Objects.Game game = new Objects.Game();
        private Player player;

        private Random random = new Random();
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private DateTime prevTime = new DateTime();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            game.Canvas = cnvCanvas;
            game.GameOver = txtGameOver;

            //audio player
            AudioPlayer.Instance.AddSound("fire", "shoot.wav");
            AudioPlayer.Instance.AddSound("explosion", "invader_destroy.wav");

            player = Player.Create(new Vector(200, 350), new Vector(0, 0), new Vector(30, 30));
            game.AddGameObject(player);

            for (int i = 0; i < 20; i++)
            {
                Alien alien = Alien.Create(new Vector(random.Next(400), random.Next(200)), new Vector(.180, 0), new Vector(30, 30));
                game.AddGameObject(alien);
            }

            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Start();

            prevTime = DateTime.Now;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = DateTime.Now - prevTime;

            //update game
            game.Update(timeSpan.TotalSeconds);
            game.Draw();
            // update score
            txtScore.Text = game.Score.ToString("D6");

        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            InputSystem.Instance.OnKeyUp(e.Key);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.IsRepeat) return;
            if (e.Key == Key.Escape) Application.Current.Shutdown();

            InputSystem.Instance.OnKeyDown(e.Key);

          
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
