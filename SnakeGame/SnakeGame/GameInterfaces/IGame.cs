using SnakeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.GameInterfaces
{
    public interface IGame
    {
        void StartGame();
        void PauseGame();
        void ChangeSnakeDirection(SnakeDirection dir);
        bool GameWon { get; }
        bool GameLost { get; }
        long TimeElapsed { get; }
        Player GetPlayer();
        ISnake GetSnake();
        ILevel GetLevel();
    }
}
