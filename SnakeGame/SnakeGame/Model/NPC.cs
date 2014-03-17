using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Model
{
    abstract class NPC
    {
        private int x, y, value;
        private String type;
        public NPC(int x, int y, int value, String type)
        {
            this.x = x;
            this.y = y;
            this.value = value;
            this.type = type;
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
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        protected abstract void appear();
        protected abstract void dissapear();
        protected abstract void generatePosition();
        
    }
}
