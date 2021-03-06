﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Model
{
    public class SnakePart:IEquatable<SnakePart>
    {
        private int positionOnX ; 
        private int positionOnY; 
        
        internal SnakePart(int x, int y)
        {
            this.positionOnX = x;
            this.positionOnY = y;
        }

        public int PositionOnX
        {
            get { return positionOnX; }
        }

        public int PositionOnY
        {
            get { return positionOnY; }
        }

        public bool Equals(SnakePart other)
        {
            return this.PositionOnX == other.PositionOnX && this.PositionOnY == other.PositionOnY;
        }
    }
}
