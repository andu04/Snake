using SnakeGame.GameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    class Map:IMap
    {
        private int mapRows;
        private int mapColumns;
        private List<MapCell> mapCells;
        //public int MapRows
        //{
        //    get
        //    {
        //        return mapRows;
        //    }
        //    set
        //    {
        //        mapRows = value;
        //    }
        //}
        //public int MapColumns
        //{
        //    get
        //    {
        //        return mapColumns;
        //    }
        //    set
        //    {
        //        mapColumns = value;
        //    }
        //}
        //public List<MapCell> MapCells
        //{
        //    get
        //    {
        //        return mapCells;
        //    }
        //    set
        //    {
        //        mapCells = value;
        //    }
        //}


        //public Map(int mapRows, int mapColumns)
        //{
        //    this.mapRows = mapRows;
        //    this.mapColumns = mapColumns;
        //    mapCells = new List<MapCell>();
        //}

        //public Map(int mapRows, int mapColumns, List<MapCell> mapCells)
        //    :this(mapRows, mapColumns)
        //{
        //    this.mapCells = mapCells;
        //}
        //public void addMapCell(MapCell newMapCell)
        //{
        //    mapCells.Add(newMapCell);
        //}

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
            return null;
        }

        public void AddMapCell(MapCell mapCell)
        {
         //   throw new NotImplementedException();
        }
    }
}
