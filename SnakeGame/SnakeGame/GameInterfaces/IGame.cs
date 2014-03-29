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
        void StartGame();
        void PauseGame();
        bool GameWon();
        bool GameLost();
        Player GetPlayer();
        ISnake GetSnake();
        ILevel GetLevel();
        void UpdateGame();
    }
}
