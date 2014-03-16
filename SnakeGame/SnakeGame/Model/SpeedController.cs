using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Model
{
    /* Singleton */
    class SpeedController
    {
        private SpeedController instance;

        private long delay;
        private bool isPaused;

        private SpeedController()
        {
            this.delay = 1000 / 60;
            this.isPaused = true;
        }

        public SpeedController GetInstance()
        {
            if (instance == null)
            {
                instance = new SpeedController();
            }

            return instance;
        }

        public void Pause() 
        {
            isPaused = true;
        }

        public void Resume()
        {
            isPaused = false;
        }

        public void SetDelay(long delay)
        {
            this.delay = delay;
        }
    }
}
