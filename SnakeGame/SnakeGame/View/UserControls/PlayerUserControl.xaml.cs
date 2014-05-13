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
using SnakeGame.Model;

namespace SnakeGame.View.UserControls
{
    /// <summary>
    /// Interaction logic for PlayerUserControl.xaml
    /// </summary>
    public partial class PlayerUserControl : UserControl
    {
        private Player player;

        public string UserName
        {
            get { return (string) GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(PlayerUserControl), new PropertyMetadata("not_defined"));

        public long TimePlayed
        {
            get { return (long)GetValue(TimePlayedProperty); }
            set { SetValue(TimePlayedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimePlayed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimePlayedProperty =
            DependencyProperty.Register("TimePlayed", typeof(long), typeof(PlayerUserControl), new PropertyMetadata(0L));


        public PlayerUserControl(Player player)
        {
            this.player = player;
            UserName = player.Name;
            TimePlayed = player.TimePlayed;

            this.DataContext = this;
            InitializeComponent();
        }
    }
}
