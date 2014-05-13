using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    public enum MapCellType
    {
        Normal,
        Block,
        Slowdown,
        Accelerate,
    }
    public class MapCell:IEquatable<MapCell>
    {
        private int positionOnX;
        private int positionOnY;
        private MapCellType cellType;

        public int PositionOnX { get { return positionOnX; }}
        public int PositionOnY { get { return positionOnY; }}
        public MapCellType CellType{ get { return cellType; }}

        internal MapCell(MapCellType cellType, int x, int y)
        {
            this.cellType = cellType;
            positionOnY = y;
            positionOnX = x;
        }
        internal MapCell(int x, int y)
        {
            positionOnX = x;
            positionOnY = y;
            this.cellType = MapCellType.Normal;
        }


        public bool Equals(MapCell other)
        {
            return this.PositionOnX == other.PositionOnX && this.PositionOnY == other.PositionOnY;
        }
    }
}
