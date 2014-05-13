using SnakeGame.GameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    internal class Map:IMap
    {
        private int MIN_MAP_ROWS = 10;
        private int MIN_MAP_COLUMNS = 10;
        private int mapRows;
        private int mapColumns;
        private List<MapCell> mapCells;
        private List<MapCell> snakeStartPosition;
        public Map(int mapRows, int mapColumns)
        {
            if (mapRows < MIN_MAP_ROWS || mapColumns < MIN_MAP_COLUMNS)
            {
                throw new ArgumentOutOfRangeException("map rows or map columns is smaller than minim value");
            }
            this.MapRows = mapRows;
            this.MapColumns = mapColumns;
            mapCells = new List<MapCell>();
            InitializeSnakeStartPosition();
        }

        private void InitializeSnakeStartPosition()
        {
            int middleY = MapColumns / 2;
            snakeStartPosition = new List<MapCell>();
            snakeStartPosition.Add(new MapCell(MapRows - 2, middleY));
            snakeStartPosition.Add(new MapCell(MapRows - 1, middleY));
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

        public MapCell GetMapCell(int x, int y)
        {
            foreach (MapCell mapCell in mapCells)
                if (mapCell.PositionOnX == x && mapCell.PositionOnY == y)
                    return mapCell;
            return null;
        }

        public void AddMapCell(MapCell mapCell)
        {
            if (mapCells.Contains(mapCell) == false)
                mapCells.Add(mapCell);
        }


        public List<MapCell> SnakeStartPosition
        {
            get { return snakeStartPosition; }
        }
    }
}
