using SnakeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameInterfaces
{
    interface IGame
    {
        public void StartGame();
        public void PauseGame();
        public bool GameWon();
        public bool GameLost();
        public Player GetPlayer();
        public ISnake GetSnake();
        public ILevel GetLevel();
        public void UpdateGame();
    }
}
