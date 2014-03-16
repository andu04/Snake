using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    class SnakePart
    {
        private int X ; 
        private int Y; 
        public int getX()
        {
        return X;
        }
        public int getY()
        {
            return Y;
        }
        public void setX(int X1)
        {
            this.X = X1 ;
        }
        public void setY(int Y1)
        {
            this.Y = Y1;
        }
        // Constructor
        public SnakePart()
        {
            X = 0;
            Y = 0;
        }
    }
}
