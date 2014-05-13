using SnakeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.GameInterfaces
{
    public enum SnakeDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    public interface ISnake
    {
        void RemoveSnakePart();
        void AddSnakePart(int x, int y);
        void MoveSnake();
        SnakeDirection Direction { get; set; }

        SnakePart GetSnakeHead();
        SnakePart GetNextPart(SnakePart snakePart);
    }
}
