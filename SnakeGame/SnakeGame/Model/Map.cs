using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    class Map
    {
        int cellSize;
        int mapRows;
        int mapColumns;
        List<MapCell> mapCells;

        public Map(int cellSize, int mapRows, int mapColumns)
        {
            this.cellSize = cellSize;
            this.mapRows = mapRows;
            this.mapColumns = mapColumns;
            mapCells = new List<MapCell>();
        }
        public void addMapCell(MapCell newMapCell)
        {
            mapCells.Add(newMapCell);
        }
    }
}
