using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    class MapCell
    {
        enum MapCellType
        {
            Grass, Sand
        }

        private double cellSize;
        private MapCellType cellType;

        public double CellSize
        {
            get { return cellSize; }
            set { cellSize = value; }
        }
        
        public MapCellType CellType
        {
            get { return cellType; }
            set { cellType = value; }
        }

        public MapCell(double cellSize, MapCellType cellType)
        {
            this.cellSize = cellSize;
            this.cellType = cellType;
        }
    }
}
