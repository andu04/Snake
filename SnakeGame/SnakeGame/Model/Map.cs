using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    class Map
    {
        private int cellSize;
        private int mapRows;
        private int mapColumns;
        private List<MapCell> mapCells;
        public int CellSize
        {
            get
            {
                return cellSize;
            }
            set
            {
                cellSize = value;
            }
        }
        public int MapRows
        {
            get
            {
                return mapRows;
            }
            set
            {
                mapRows = value;
            }
        }
        public int MapColumns
        {
            get
            {
                return mapColumns;
            }
            set
            {
                mapColumns = value;
            }
        }
        public List<MapCell> MapCells
        {
            get
            {
                return mapCells;
            }
            set
            {
                mapCells = value;
            }
        }


        public Map(int cellSize, int mapRows, int mapColumns)
        {
            this.cellSize = cellSize;
            this.mapRows = mapRows;
            this.mapColumns = mapColumns;
            mapCells = new List<MapCell>();
        }

        public Map(int cellSize, int mapRows, int mapColumns, List<MapCell> mapCells)
            :this(cellSize, mapRows, mapColumns)
        {
            this.mapCells = mapCells;
        }
        public void addMapCell(MapCell newMapCell)
        {
            mapCells.Add(newMapCell);
        }
    }
}
