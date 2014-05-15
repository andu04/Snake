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
    public partial class MainWindow : Window
    {
        public IGame game;
        LevelUserControl levelUC;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Player player = new Player("mihai", 5, 5, null);
                PlayerUserControl playerC = new PlayerUserControl(player);
                playerUCGrid.Children.Add(playerC);

                Map map1 = new Map(6, 10);
                Level level = new Level("Level 1 Impossible", 1, map1);

                game = new Game(level, player, this);

                levelUC = new LevelUserControl(game);
                levelUCGrid.Children.Add(levelUC);


                game.StartGame();
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare in mainwindow : "+ex.Message);
            }
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
                game.GetSnake().Direction = SnakeDirection.Left;
            }
            if (e.Key == Key.Down)
            {
                game.GetSnake().Direction = SnakeDirection.Right;
            }
            if (e.Key == Key.Left)
            {
                game.GetSnake().Direction = SnakeDirection.Up;
            }
            if (e.Key == Key.Right)
            {
                game.GetSnake().Direction = SnakeDirection.Down;
            }
            if (e.Key == Key.Space)
            {
                game.GetSnake().AddSnakePart(5, 5);

            }
        }

    }
}
