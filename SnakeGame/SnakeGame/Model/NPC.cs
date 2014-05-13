using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Model
{
    public abstract class NPC
    {
        private int positionOnX;
        private int positionOnY;
        private int points;

        public NPC()
        {
        }

        public NPC(int x, int y, int points)
        {
            this.positionOnX = x;
            this.positionOnY = y;
            this.points = points;
        }
        public int PositionOnX
        {
            get { return positionOnX; }
            private set { positionOnX = value; }
        }

        public int PositionOnY
        {
            get { return positionOnY; }
            private set { positionOnY = value; }
        }
        public int Value
        {
            get { return points; }
            private set { this.points = value; }
        }

        protected abstract void Appear();
        protected abstract void Dissapear();
        protected abstract void GeneratePosition();


        internal static NPC CreateNPC(int x, int y, int id)
        {
            throw new NotImplementedException();
        }
    }
}
