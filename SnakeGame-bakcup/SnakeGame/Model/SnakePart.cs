    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Model
{
    public class SnakePart
    {
        private int positionOnX ; 
        private int positionOnY; 
        
        public SnakePart(int x, int y)
        {
            this.positionOnX = x;
            this.positionOnY = y;
        }

        public int PositionOnX
        {
            get { return positionOnX; }
            set { positionOnX = value; }
        }

        public int PositionOnY
        {
            get { return positionOnY; }
            set { positionOnY = value; }
        }
    }
}
