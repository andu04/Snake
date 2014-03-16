using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeApplication
{
    interface NPC
    {
        private int x, y;
        private String type;
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

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public NPC(int x, int y, String type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        protected void appear();
        protected void dissapear();
        protected void generatePosition();

    }
}
