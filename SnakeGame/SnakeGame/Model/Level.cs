using SnakeGame.GameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    internal class Level:ILevel
    {
        private const long MIN_LEVEL_DURATION = 60;
        private const long MILLISECONDS_IN_SECOND = 1000;
        private Map levelMap;
        private List<NPC> npcs;
        private String name;
        private int id;
        private long timeToPlayInMilliS;
        internal Level(String name, int id, Map levelMap)
        {
            this.name = name;
            this.id = id;
            npcs = new List<NPC>();
            this.levelMap = levelMap;
            this.timeToPlayInMilliS = GenerateTimeById();

        }

        private long GenerateTimeById()
        {
            long time = MIN_LEVEL_DURATION * MILLISECONDS_IN_SECOND;
            time += MIN_LEVEL_DURATION * MILLISECONDS_IN_SECOND * id / 5;
            return time;  
        }
        
        public void AddNPC(int x, int y)
        {
            NPC npc = NPC.CreateNPC(x, y, id);
            npcs.Add(npc);
        }

        public void RemoveNPC(int x, int y)
        {
            foreach(NPC npc in npcs)
                if (npc.PositionOnX == x && npc.PositionOnY == y)
                {
                    npcs.Remove(npc);
                    break;
                }
        }

        public IMap LevelMap{ get { return levelMap;}}
        public int Id
        {
            get
            {
                return id;
            }
        }

        public List<NPC> GetNPCList()
        {
            return npcs;
        }
        internal NPC GetNPC(int x, int y)
        {
            foreach(NPC npc in npcs)
            {
                if (npc.PositionOnX == x && npc.PositionOnY == y)
                    return npc;
            }
            return null;
        }

        public long TimeToPlayInMilliS
        {
            get { return timeToPlayInMilliS; }
        }
    }
}
