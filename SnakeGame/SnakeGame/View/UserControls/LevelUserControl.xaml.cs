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
        int viewCellSize = 40;
        private IGame model;

        public LevelUserControl(IGame model)
        {
            this.model = model;
            InitializeComponent();
            snakeCanvas.Width = mapCanvas.Width = viewCellSize * model.GetLevel().LevelMap.MapColumns;
            snakeCanvas.Height = mapCanvas.Height = viewCellSize * model.GetLevel().LevelMap.MapRows;
            DrawMap();
            Update();
        }

        public void Update()
        {
            
            DrawSnake();
        }

        private void DrawMap()
        {
            IMap map = model.GetLevel().LevelMap;
            for (int i = 0; i < model.GetLevel().LevelMap.MapRows; i++)
                for (int j = 0; j < model.GetLevel().LevelMap.MapColumns; j++)
                {
                    Image mapcell = new Image() { Width = viewCellSize, Height = viewCellSize };
                    Canvas.SetTop(mapcell, i * viewCellSize );
                    Canvas.SetLeft(mapcell, j * viewCellSize );

                    MapCell cell = map.GetMapCell(i, j);
                    
                    mapcell.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/normal.png", UriKind.RelativeOrAbsolute));
                    mapCanvas.Children.Add(mapcell);
                }
        }

        private void DrawSnake()
        {
            snakeCanvas.Children.Clear();
            ISnake snake = model.GetSnake();
            SnakePart prev = null, next = null;
            SnakePart sp = snake.GetSnakeHead();
            Button part = new Button();
            Canvas.SetLeft(part, sp.PositionOnX * viewCellSize);
            Canvas.SetTop(part, sp.PositionOnY * viewCellSize);
            part.Width = part.Height = viewCellSize;
            part.Content = "X";

            snakeCanvas.Children.Add(part);



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
                        Canvas.SetLeft(part, sp.PositionOnX * viewCellSize + viewCellSize / 4);
                        Canvas.SetTop(part, sp.PositionOnY * viewCellSize + viewCellSize / 4);
                    }
                    snakeCanvas.Children.Add(part);
                    part.Content = type;
                }
            } while (sp != null);
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
