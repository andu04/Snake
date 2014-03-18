using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    class Game
    {
        private Level level;
        private Snake snake;
        private Player player;
        private SpeedController speedController;

        public Game(Level level, Snake snake, Player player, SpeedController speedController)
        {
            this.level = level;
            this.snake = snake;
            this.player = player;
            this.speedController = speedController;
        }

    }
}
