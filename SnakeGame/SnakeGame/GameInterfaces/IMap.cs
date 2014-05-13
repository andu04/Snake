using SnakeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameInterfaces
{
    public interface IMap
    {
        int MapRows { get; }
        int MapColumns { get; }
        MapCell GetMapCell(int x, int y);
        void AddMapCell(MapCell mapCell);

        List<MapCell> SnakeStartPosition { get; }
    }
}
