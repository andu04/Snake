using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Model
{
    abstract class NPC
    {
        private int positionOnX;
        private int positionOnY;
        private int points;
        private String type;
        public NPC(int x, int y, int points, String type)
        {
            this.positionOnX = x;
            this.positionOnY = y;
            this.points = points;
            this.type = type;
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
        public int Value
        {
            get { return points; }
            set { this.points = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        protected abstract void Appear();
        protected abstract void Dissapear();
        protected abstract void GeneratePosition();
        
    }
}
