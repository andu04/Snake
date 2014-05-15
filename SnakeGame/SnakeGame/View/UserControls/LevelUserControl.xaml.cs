﻿using System;
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


        }

        public void Update()
        {
            canvas.Children.Clear();
            int viewCellSize = 30;

            //Rectangle part = new Rectangle();
            ISnake snake = model.GetSnake();

            SnakePart sp = snake.GetSnakeHead();
            Button part = new Button();
            Canvas.SetLeft(part, sp.PositionOnX * viewCellSize);
            Canvas.SetTop(part, sp.PositionOnY * viewCellSize);
            part.Width = part.Height = viewCellSize;
            part.Content = "X";
            canvas.Children.Add(part);

            do
            {
                sp = snake.GetNextPart(sp);
                if (sp != null)
                {
                    part = new Button();
                    Canvas.SetLeft(part, sp.PositionOnX * viewCellSize);
                    Canvas.SetTop(part, sp.PositionOnY * viewCellSize);
                    part.Width = part.Height = viewCellSize;
                    canvas.Children.Add(part);
                }
            } while (sp != null);
        }
    }
}
