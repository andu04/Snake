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
        int MapRows { get; set; }
        int MapColumns { get; set; }
        MapCell GetMapCell(int x, int y);
        void AddMapCell(MapCell mapCell);
    }
}
