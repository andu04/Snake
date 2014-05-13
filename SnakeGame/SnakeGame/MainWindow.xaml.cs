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
using SnakeGame.Model;
using SnakeGame.View.UserControls;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Player player = new Player("mihai", 5, 5, null);
                PlayerUserControl playerC = new PlayerUserControl(player);

                playerUCGrid.Children.Add(playerC);
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }
    }
}
