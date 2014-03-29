using SnakeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameInterfaces
{
    interface IMap
    {
        public int MapRows { get; set; }
        public int MapColumns { get; set; }
        public MapCell GetMapCell(int x, int y);
        public void AddMapCell(MapCell mapCell);
    }
}
