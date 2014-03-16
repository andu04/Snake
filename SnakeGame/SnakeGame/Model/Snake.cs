using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;



namespace Player
{
    class Snake
    {

      private  Queue<SnakePart> snake = new Queue<SnakePart>();
      private int direction ; // Down = 0, Left = 1, Right = 2, Up = 3

      public int Direction
      {
          get { return direction; }
          set { direction = value; }
      }
      private int step;

      public int Step
      {
          get { return step; }
          set { step = value; }
      }
      public Snake(int direction, SnakePart first,int step)
      {
          direction = 0;
          snake.Enqueue(first);
          step = 0;
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
          snake.Enqueue(part);

      }
      public void removePart()
      {
          snake.Dequeue();

      }
   
    }
}
