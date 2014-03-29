using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.GameInterfaces
{
    public interface ISnake
    {
        public void RemoveSnakePart();
        public void AddSnakePart();
        public enum SnakeDirection
        {
            Up,
            Down,
            Left,
            Right
        }
        public SnakeDirection Direction { get; set; }
    }
}
