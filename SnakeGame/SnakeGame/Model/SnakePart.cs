﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    class SnakePart
    {
        private int x ; 
        private int y; 
        
        public SnakePart(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
