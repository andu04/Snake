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
        int viewCellSize = 26;
        private IGame model;
        private bool coada = true;

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

                    MapCell cell = map.GetMapCell(j, i);
                    try
                    {
                        switch (cell.CellType)
                        {
                            case MapCellType.Normal:
                                mapcell.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/normal.png", UriKind.RelativeOrAbsolute));
                                break;
                            case MapCellType.Accelerate:
                                mapcell.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/accelerate.png", UriKind.RelativeOrAbsolute));
                                break;
                            case MapCellType.Slowdown:
                                mapcell.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/slow.png", UriKind.RelativeOrAbsolute));
                                break;
                            case MapCellType.Block:
                                mapcell.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/block.png", UriKind.RelativeOrAbsolute));
                                break;
                            default:
                                break;
                        }
                    }
                    catch
                    {
                        Debug.WriteLine("eroare view cell type files");
                    }

                    mapCanvas.Children.Add(mapcell);
                }
            DrawMapBorder(map);
        }

        private void DrawMapBorder(IMap map)
        {
            int rows = map.MapRows;
            int columns = map.MapColumns;

            // UP
            for (int j = 1; j < columns - 1; j++)
            {
                Image mapcell = new Image() { Width = viewCellSize, Height = viewCellSize };
                Canvas.SetTop(mapcell, 0 * viewCellSize);
                Canvas.SetLeft(mapcell, j * viewCellSize);

                mapcell.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/border2.png", UriKind.RelativeOrAbsolute));
                mapCanvas.Children.Add(mapcell);
            }

            // RIGHT
            for (int i = 1; i < rows - 1; i++)
            {
                Image mapcell = new Image() { Width = viewCellSize, Height = viewCellSize };
                Canvas.SetTop(mapcell, i * viewCellSize);
                Canvas.SetLeft(mapcell, (columns - 1) * viewCellSize);

                mapcell.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/border4.png", UriKind.RelativeOrAbsolute));
                mapCanvas.Children.Add(mapcell);
            }

            // DOWN
            for (int j = 1; j < columns - 1; j++)
            {
                Image mapcell = new Image() { Width = viewCellSize, Height = viewCellSize };
                Canvas.SetTop(mapcell, (rows - 1) * viewCellSize);
                Canvas.SetLeft(mapcell, j * viewCellSize);

                mapcell.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/border6.png", UriKind.RelativeOrAbsolute));
                mapCanvas.Children.Add(mapcell);
            }

            // LEFT
            for (int i = 1; i < rows - 1; i++)
            {
                Image mapcell = new Image() { Width = viewCellSize, Height = viewCellSize };
                Canvas.SetTop(mapcell, i * viewCellSize);
                Canvas.SetLeft(mapcell, 0 * viewCellSize);

                mapcell.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/border8.png", UriKind.RelativeOrAbsolute));
                mapCanvas.Children.Add(mapcell);
            }

            //
            // CORNERS
            //
            Image mapcel = new Image() { Width = viewCellSize, Height = viewCellSize };
            Canvas.SetTop(mapcel, 0 * viewCellSize);
            Canvas.SetLeft(mapcel, (columns - 1) * viewCellSize);
            mapcel.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/border3.png", UriKind.RelativeOrAbsolute));
            mapCanvas.Children.Add(mapcel);


            mapcel = new Image() { Width = viewCellSize, Height = viewCellSize };
            Canvas.SetTop(mapcel, 0 * viewCellSize);
            Canvas.SetLeft(mapcel, 0 * viewCellSize);
            mapcel.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/border1.png", UriKind.RelativeOrAbsolute));
            mapCanvas.Children.Add(mapcel);



            mapcel = new Image() { Width = viewCellSize, Height = viewCellSize };
            Canvas.SetTop(mapcel, (rows-1) * viewCellSize);
            Canvas.SetLeft(mapcel, (columns - 1) * viewCellSize);
            mapcel.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/border5.png", UriKind.RelativeOrAbsolute));
            mapCanvas.Children.Add(mapcel);



            mapcel = new Image() { Width = viewCellSize, Height = viewCellSize };
            Canvas.SetTop(mapcel, (rows-1) * viewCellSize);
            Canvas.SetLeft(mapcel, 0 * viewCellSize);
            mapcel.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/border7.png", UriKind.RelativeOrAbsolute));
            mapCanvas.Children.Add(mapcel);
        }

        private void DrawSnake()
        {
            snakeCanvas.Children.Clear();
            ISnake snake = model.GetSnake();
            SnakePart prev = null, next = null;
            SnakePart sp = snake.GetSnakeHead();
            Image part1 = new Image();
            Canvas.SetLeft(part1, sp.PositionOnX * viewCellSize);
            Canvas.SetTop(part1, sp.PositionOnY * viewCellSize);
            part1.Width = part1.Height = viewCellSize;
            part1.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/snake/cap2.png", UriKind.RelativeOrAbsolute));

            switch (snake.Direction)
            {
                case SnakeDirection.Up:
                    part1.RenderTransform = new RotateTransform(180, viewCellSize/2, viewCellSize/2);
                    break;
                case SnakeDirection.Left:
                    part1.RenderTransform = new RotateTransform(90, viewCellSize / 2, viewCellSize / 2);
                    break;
                case SnakeDirection.Right:
                    var transformGroup = new TransformGroup();
                    transformGroup.Children.Add(new RotateTransform(270, viewCellSize / 2, viewCellSize / 2)); 
                    transformGroup.Children.Add(new ScaleTransform(1, -1, viewCellSize / 2, viewCellSize / 2)); 
                    part1.RenderTransform = transformGroup;
               
                    break;
                case SnakeDirection.Down:
                    break;
                default:
                    break;
            }

           
            snakeCanvas.Children.Add(part1);

            do
            {
                string type = "-";

                prev = sp;
                sp = snake.GetNextPart(sp);
                next = snake.GetNextPart(sp);

                int partType = -1;

                Image part = new Image();
                if (sp != null)
                {
                    // e ultimul
                    if (next == null)
                    {
                        if(coada)
                            part.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/snake/coada1.png", UriKind.RelativeOrAbsolute));
                        else
                            part.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/snake/coada2.png", UriKind.RelativeOrAbsolute));
                        coada = !coada;

                        switch (GetCoadaDirection(prev, sp))
                        {
                            case SnakeDirection.Up:
                               
                                break;
                            case SnakeDirection.Left:
                                var transformGroup = new TransformGroup();
                                transformGroup.Children.Add(new RotateTransform(90, viewCellSize / 2, viewCellSize / 2));
                                transformGroup.Children.Add(new ScaleTransform(-1, 1, viewCellSize / 2, viewCellSize / 2));
                                part.RenderTransform = transformGroup;
                                break;
                            case SnakeDirection.Right:
                                transformGroup = new TransformGroup();
                                transformGroup.Children.Add(new RotateTransform(270, viewCellSize / 2, viewCellSize / 2));
                                transformGroup.Children.Add(new ScaleTransform(-1, 1, viewCellSize / 2, viewCellSize / 2));
                                part.RenderTransform = transformGroup;
                                break;
                            case SnakeDirection.Down:
                                part.RenderTransform = new RotateTransform(180, viewCellSize / 2, viewCellSize / 2);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        partType = GetSnakePartType(prev, sp, next);
                    }

                    Canvas.SetLeft(part, sp.PositionOnX * viewCellSize);
                    Canvas.SetTop(part, sp.PositionOnY * viewCellSize);
                    part.Width = part.Height = viewCellSize;

                    switch (partType)
                    {
                        case 1:
                            part.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/snake/part1.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 2:
                            part.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/snake/part2.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 3:
                            part.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/snake/part3.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 4:
                            part.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/snake/part4.png", UriKind.RelativeOrAbsolute));
                            break;

                        case 5:
                            part.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/snake/vertical2.png", UriKind.RelativeOrAbsolute));
                            break;
                        case 6:
                            part.Source = new BitmapImage(new Uri("/SnakeGame;component/View/Resources/snake/horizontal2.png", UriKind.RelativeOrAbsolute));
                            break;
                        default:
                            break;
                    }


                    snakeCanvas.Children.Add(part);
                }
            } while (sp != null);
        }

        private SnakeDirection GetCoadaDirection(SnakePart prev, SnakePart sp)
        {
            if (prev.PositionOnY == sp.PositionOnY + 1)
                return SnakeDirection.Down;
            if (prev.PositionOnY == sp.PositionOnY - 1)
                return SnakeDirection.Up;
            if (prev.PositionOnX == sp.PositionOnX + 1)
                return SnakeDirection.Right;
            if (prev.PositionOnX == sp.PositionOnX - 1)
                return SnakeDirection.Left;
            return SnakeDirection.Up;
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


            // vertical
            if (next.PositionOnX == sp.PositionOnX && prev.PositionOnX == sp.PositionOnX)
                return 5;

            // horizontal
            if (next.PositionOnY == sp.PositionOnY && prev.PositionOnY == sp.PositionOnY)
                return 6;

            return 0;
        }


    }
}
