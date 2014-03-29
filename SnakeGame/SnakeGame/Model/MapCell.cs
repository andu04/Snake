using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    class MapCell
    {
        public enum MapCellType
        {
            Normal,
            Block,
            Slowdown,
            Accelerate,
        }

        private MapCellType cellType;
        
        public MapCellType CellType
        {
            get { return cellType; }
            set { cellType = value; }
        }

        public MapCell(MapCellType cellType)
        {
            this.cellType = cellType;
        }

    }
}
