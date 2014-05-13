using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SnakeGame.GameInterfaces;



namespace SnakeGame.Model
{
    class Snake:ISnake
    {

        private static readonly int HEAD_INDEX = 0;
        private  List<SnakePart> bodyParts;
        private SnakeDirection direction; 
        public Snake()
        {
              bodyParts = new List<SnakePart>();
        }
        public void RemoveSnakePart()
        {
            if (bodyParts.Count == 0)
                throw new Exception("Snake length = 0(can not remove snake part)");
              bodyParts.RemoveAt(bodyParts.Count - 1);
        }
        public void AddSnakePart(int x, int y)
          {
              SnakePart newSnakePart = new SnakePart(x, y);
              bodyParts.Add(newSnakePart);
          }

        public SnakeDirection Direction
          {
              get
              {
                  return direction;
              }
              set
              {
                  direction = value;
              }
          }

        public SnakePart GetSnakeHead()
        {
            if (bodyParts.Count == 0)
                throw new Exception("Snake is empty (length = 0)");
            return bodyParts.ElementAt(HEAD_INDEX);
        }

        public SnakePart GetNextPart(SnakePart snakePart)
        {
            int nextIndex = bodyParts.IndexOf(snakePart) + 1;
            if (nextIndex >= bodyParts.Count)
                throw new Exception("Next part is null");
            return bodyParts.ElementAt(bodyParts.IndexOf(snakePart) + 1);
        }
    }
}
