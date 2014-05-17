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
        private int MIN_MAP_ROWS = 5;
        private int MIN_MAP_COLUMNS = 5;
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
            for (int i = 0; i < MapColumns; i++)
                for (int j = 0; j < MapRows; j++)
                {
                    // [mihai] - demo for cell types
                    if (i == 5 && j == 5)
                        mapCells.Add(new MapCell(MapCellType.Slowdown, i, j));
                    else
                        if (i == 1 && j == 1)
                            mapCells.Add(new MapCell(MapCellType.Block, i, j));
                        else
                            if (i == 3 && j == 8)
                                mapCells.Add(new MapCell(MapCellType.Accelerate, i, j));
                            else
                                mapCells.Add(new MapCell(i, j));
                }
            InitializeSnakeStartPosition();
        }

        private void InitializeSnakeStartPosition()
        {
            int middleX = MapColumns / 2;
            snakeStartPosition = new List<MapCell>();
            snakeStartPosition.Add(new MapCell(middleX, MapRows - 2));
            snakeStartPosition.Add(new MapCell(middleX - 1, MapRows - 1));
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
