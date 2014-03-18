using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;



namespace SnakeGame.Model
{
    class Snake
    {

      private  Queue<SnakePart> bodyParts = new Queue<SnakePart>();
      public enum SnakeDirection
      {
          Up,
          Down,
          Left,
          Right
      }
      private SnakeDirection direction;
      private int step;

      public SnakeDirection Direction
      {
          get { return direction; }
          set { direction = value; }
      }

      public int Step
      {
          get { return step; }
          set { step = value; }
      }
      public Snake(SnakeDirection direction, SnakePart first,int step)
      {
          this.direction = direction;
          bodyParts.Enqueue(first);
          this.step = step;
      }
      //private void StartGame()
      //{
      //    direction = 0;
      //    snake.Clear();
      //    SnakePart head = new SnakePart();
      //    head.X = 20;
      //    head.Y = 5;
      //    snake.Enqueue(head);
         
      //}
      public void addPart(SnakePart part)
      {
          bodyParts.Enqueue(part);

      }
      public void removePart()
      {
          bodyParts.Dequeue();
      }
   
    }
}
