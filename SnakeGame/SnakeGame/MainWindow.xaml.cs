using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using SnakeGame.GameInterfaces;
using SnakeGame.Model;
using SnakeGame.View.UserControls;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserver<IGame>
    {
        public IGame game;
        LevelUserControl levelUC;
        PlayerUserControl playerUC;
        public MainWindow()
        {
            InitializeComponent();
            var game = new Game(1, new Player("mihai", 5, 5, null));
            var unsubscriber = game.Subscribe(this);
            game.StartGame();
        }

        public void Update()
        {
            levelUC.Update();
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.Key.ToString());
            if (e.Key == Key.Up)
            {
                game.ChangeSnakeDirection(SnakeDirection.Up);
            }
            if (e.Key == Key.Down)
            {
                game.ChangeSnakeDirection(SnakeDirection.Down);
            }
            if (e.Key == Key.Left)
            {
                game.ChangeSnakeDirection(SnakeDirection.Left);
            }
            if (e.Key == Key.Right)
            {
                game.ChangeSnakeDirection(SnakeDirection.Right);
            }
            if (e.Key == Key.Space)
            {
                game.GetSnake().AddSnakePart(5, 5);
            }
        }

        public void OnCompleted()
        {
            MessageBox.Show("Start");
        }

        public void OnError(Exception error)
        {
            MessageBox.Show("Error!");
        }

        public void OnNext(IGame value)
        {
            this.game = value;

            try
            {
                if (levelUC == null)
                {
                    Player player = game.GetPlayer();
                    playerUC = new PlayerUserControl(player);
                    playerUCGrid.Children.Add(playerUC);

                    levelUC = new LevelUserControl(game);
                    levelUCGrid.Children.Add(levelUC);
                    levelUC.Focus();
                }

                Update();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare in mainwindow : " + ex.Message);
            }

        }

    }
}
