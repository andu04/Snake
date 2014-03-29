using SnakeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameInterfaces
{
    interface ILevel
    {
        void AddNPC(int x, int y);
        void RemoveNPC(int x, int y);

        IMap LevelMap { get; set; }

        int Id { get; set; }

        List<NPC> getNPCList();

    }
}
