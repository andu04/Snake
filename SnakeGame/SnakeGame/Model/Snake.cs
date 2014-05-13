using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SnakeGame.GameInterfaces;



namespace SnakeGame.Model
{
    internal class Snake:ISnake
    {

        private static readonly int HEAD_INDEX = 0;
        private  List<SnakePart> bodyParts;
        private Queue<SnakePart> waitingParts;
        private SnakeDirection direction;
        internal Snake()
        {
            bodyParts = new List<SnakePart>();
            waitingParts = new Queue<SnakePart>();
            Direction = SnakeDirection.Up;
        }

        internal Snake(List<MapCell> startPosition)
            :this()
        {
            int initialSnakeLength = 2;
            if (startPosition.Count == initialSnakeLength)
            {
                bodyParts.Add(new SnakePart((int)startPosition.ElementAt(0).PositionOnX, (int)startPosition.ElementAt(0).PositionOnY));
                bodyParts.Add(new SnakePart((int)startPosition.ElementAt(1).PositionOnX, (int)startPosition.ElementAt(1).PositionOnY));
            }
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
              waitingParts.Enqueue(newSnakePart);
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
                return null;
            return bodyParts.ElementAt(HEAD_INDEX);
        }

        public SnakePart GetNextPart(SnakePart snakePart)
        {
            int nextIndex = bodyParts.IndexOf(snakePart) + 1;
            if (nextIndex >= bodyParts.Count)
                return null;
            return bodyParts.ElementAt(bodyParts.IndexOf(snakePart) + 1);
        }

        public void MoveSnake()
        {
            SnakePart currentHeadPosition = bodyParts.ElementAt(HEAD_INDEX);
            SnakePart newHeadPosition;
            switch (direction)
            {
                case SnakeDirection.Up:
                    newHeadPosition = new SnakePart(currentHeadPosition.PositionOnX - 1, currentHeadPosition.PositionOnY);
                    break;
                case SnakeDirection.Down:
                    newHeadPosition = new SnakePart(currentHeadPosition.PositionOnX + 1, currentHeadPosition.PositionOnY);
                    break;
                case SnakeDirection.Left:
                    newHeadPosition = new SnakePart(currentHeadPosition.PositionOnX, currentHeadPosition.PositionOnY - 1);
                    break;
                case SnakeDirection.Right:
                    newHeadPosition = new SnakePart(currentHeadPosition.PositionOnX, currentHeadPosition.PositionOnY + 1);
                    break;
                default:
                    newHeadPosition = currentHeadPosition;
                    break;
            }
            bodyParts.Insert(HEAD_INDEX, newHeadPosition);
            bodyParts.RemoveAt(bodyParts.Count - 1);
            if (bodyParts.Contains(waitingParts.Peek()) == false)
            {
                bodyParts.Add(waitingParts.Dequeue());
            }
        }
    }
}
