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

namespace SnakeGame.View.UserControls
{
    /// <summary>
    /// Interaction logic for LevelUserControl.xaml
    /// </summary>
    public partial class LevelUserControl : UserControl
    {

        private IGame model;

        public LevelUserControl(IGame model)
        {
            this.model = model;
            InitializeComponent();
            canvas.Focus();
        }

        public void Update()
        {
            canvas.Children.Clear();
            
            int viewCellSize = 40;
            canvas.Width = viewCellSize * model.GetLevel().LevelMap.MapColumns;
            canvas.Height = viewCellSize * model.GetLevel().LevelMap.MapRows;

            for (int i = 0; i < model.GetLevel().LevelMap.MapRows; i++)
                for (int j = 0; j < model.GetLevel().LevelMap.MapColumns; j++)
                {
                    Button mapcell = new Button() { Width = 20, Height = 20 };
                    Canvas.SetTop(mapcell, i * viewCellSize + viewCellSize / 4);
                    Canvas.SetLeft(mapcell, j * viewCellSize + viewCellSize/4);
                    mapcell.Opacity = 0.3;
                    canvas.Children.Add(mapcell);
                }

            //Rectangle part = new Rectangle();
            ISnake snake = model.GetSnake();
            SnakePart prev=null, next=null;
            SnakePart sp = snake.GetSnakeHead();
            Button part = new Button();
            Canvas.SetLeft(part, sp.PositionOnX * viewCellSize);
            Canvas.SetTop(part, sp.PositionOnY * viewCellSize);
            part.Width = part.Height = viewCellSize;
            part.Content = "X";
            
            canvas.Children.Add(part);



            do
            {
                string type = "-";

                prev = sp;
                sp = snake.GetNextPart(sp);
                next = snake.GetNextPart(sp);

                if (sp != null)
                {
                    // e ultimul
                    if (next == null)
                        type = "#";
                    else 
                    {
                        type = GetSnakePartType(prev, sp, next).ToString();
                        
                    }
                    part = new Button();
                    Canvas.SetLeft(part, sp.PositionOnX * viewCellSize);
                    Canvas.SetTop(part, sp.PositionOnY * viewCellSize);
                    
                    part.Width = part.Height = viewCellSize;

                    if (type != "0")
                    {
                        part.Width = part.Height = viewCellSize / 2;
                        Canvas.SetLeft(part, sp.PositionOnX * viewCellSize + viewCellSize/4);
                        Canvas.SetTop(part, sp.PositionOnY * viewCellSize + viewCellSize/4);
                    }
                    canvas.Children.Add(part);
                    part.Content = type;
                }
            } while (sp != null);
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("key down");
        }

        private int GetSnakePartType(SnakePart prev, SnakePart sp, SnakePart next)
        {
            if (prev.PositionOnX == sp.PositionOnX + 1 && prev.PositionOnY == sp.PositionOnY
                && next.PositionOnX == sp.PositionOnX && next.PositionOnY == sp.PositionOnY + 1)
                return 1;
            if (prev.PositionOnX == sp.PositionOnX && prev.PositionOnY == sp.PositionOnY+1
                && next.PositionOnX == sp.PositionOnX-1 && next.PositionOnY == sp.PositionOnY )
                return 2;
            if (prev.PositionOnX == sp.PositionOnX-1 && prev.PositionOnY == sp.PositionOnY 
                && next.PositionOnX == sp.PositionOnX  && next.PositionOnY == sp.PositionOnY-1)
                return 3;
            if (prev.PositionOnX == sp.PositionOnX  && prev.PositionOnY == sp.PositionOnY -1
               && next.PositionOnX == sp.PositionOnX+1 && next.PositionOnY == sp.PositionOnY)
                return 4;

            if (next.PositionOnX == sp.PositionOnX + 1 && next.PositionOnY == sp.PositionOnY
                && prev.PositionOnX == sp.PositionOnX && prev.PositionOnY == sp.PositionOnY + 1)
                return 1;
            if (next.PositionOnX == sp.PositionOnX && next.PositionOnY == sp.PositionOnY + 1
                && prev.PositionOnX == sp.PositionOnX - 1 && prev.PositionOnY == sp.PositionOnY)
                return 2;
            if (next.PositionOnX == sp.PositionOnX - 1 && next.PositionOnY == sp.PositionOnY
                && prev.PositionOnX == sp.PositionOnX && prev.PositionOnY == sp.PositionOnY - 1)
                return 3;
            if (next.PositionOnX == sp.PositionOnX && next.PositionOnY == sp.PositionOnY - 1
               && prev.PositionOnX == sp.PositionOnX + 1 && prev.PositionOnY == sp.PositionOnY)
                return 4;

            return 0;
        }
    }
}
