using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SnakeGame.Model
{
    /* Singleton */
    class SpeedController
    {
        private static SpeedController instance;

        private long delay;
        private bool isPaused;
        private DispatcherTimer timer;

        public long Delay { get { return delay; } set { delay = value; } }
        public bool IsPaused { get { return isPaused; } set { isPaused = value; } }

        private SpeedController()
        {
            this.delay = 200;
            this.isPaused = true;
        }

        public static SpeedController GetInstance()
        {
            if (instance == null)
            {
                instance = new SpeedController();
            }

            return instance;
        }


        public delegate void Tick();
        public event Tick OnTick;

        public void Start()
        {
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(delay);
                timer.Tick += timer_Tick;
            }
            timer.IsEnabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (OnTick != null)
                {
                    OnTick();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Pause() 
        {
            isPaused = true;
            timer.IsEnabled = false;
        }

        public void Resume()
        {
            isPaused = false;
            Start();
        }

        public void SetDelay(long delay)
        {
            this.delay = delay;
        }

        public void Stop()
        {
            isPaused = false;
            timer.IsEnabled = false;
        }

    }
}
