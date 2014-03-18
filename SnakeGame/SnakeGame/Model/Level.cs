using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    class Level
    {
        private Map levelMap;
        private List<NPC> npcs;
        private String name;
        private int id;

        public Map LevelMap
        {
            get { return levelMap; }
            set { levelMap = value; }
        }

        public List<NPC> Npcs
        {
            get { return npcs; }
            set { npcs = value; }
        }
   
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Level(String name, int id)
        {
            this.name = name;
            this.id = id;
        }
        public Level(String name, int id, Map levelMap)
            :this(name, id)
        {
            this.levelMap = levelMap;
        }

        public void AddNPC(NPC npc)
        {
            npcs.Add(npc);
        }

        public void RemoveNPC(NPC npc)
        {
            npcs.Remove(npc);
        }

    }
}
