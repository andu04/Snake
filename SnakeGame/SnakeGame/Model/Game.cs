using SnakeGame.GameInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SnakeGame.Model
{
    class Game: Observable<Game>, IGame
    {
        private Level level;
        private Snake snake;
        private Player player;
        private SpeedController gameSpeed;
        private bool gameWon;
        private bool gameLost;
        private DispatcherTimer gameDuration;
        private long timeElapsedInSeconds;
        private int currentGameScore;
        
        public Game(int levelId, Player player)
        {    
            this.player = player;
            InitializeLevel();
            InitializeGameDuration();
            InitializeGameSpeed();
            InitializeSnake();
            gameWon = false;
            gameLost = false;
            this.currentGameScore = 0;
        }

        private void InitializeGameDuration()
        {
            timeElapsedInSeconds = 0;
            if (gameDuration == null)
            {
                gameDuration = new DispatcherTimer();
            }
            gameDuration.Interval = TimeSpan.FromMilliseconds(1000);
            gameDuration.Tick +=gameDuration_Tick;
        }

        void gameDuration_Tick(object sender, EventArgs e)
        {
            try
            {
                timeElapsedInSeconds++;
                if (timeElapsedInSeconds == this.level.TimeToPlayInMilliS)
                {
                    Lost();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);    
            }
        }

        
         private void InitializeLevel()
        {
            Map map1 = new Map(20, 30);
            this.level = new Level("Level 1 Impossible", 1, map1);
        }

        private void InitializeSnake()
        {
            List<MapCell> startPosition = level.LevelMap.SnakeStartPosition;
            snake = new Snake(startPosition);
        }

        private void InitializeGameSpeed()
        {
            this.gameSpeed = SpeedController.GetInstance();
            gameSpeed.OnTick += gameTimer_OnTick;
        }
    
        public void StartGame()
        {
            gameSpeed.Start();
            gameDuration.Start();
            
        }

        void gameTimer_OnTick()
        {
            if (IsValidNextMove() == true && gameLost == false && gameWon == false)
            {
                snake.MoveSnake();
                SnakePart sp = snake.GetSnakeHead();
                NPC currentNPC = level.GetNPC(sp.PositionOnX, sp.PositionOnY);
                Notify(this);
            }
            else
            {
                Lost();
            }
        }

        private bool IsValidNextMove()
        {
            SnakeDirection currentDirection = snake.Direction;
            SnakePart currentSnakeHead = snake.GetSnakeHead();
            MapCell currentMapCell = level.LevelMap.GetMapCell(currentSnakeHead.PositionOnX, currentSnakeHead.PositionOnY);
            MapCell nextMapCell = null;
            switch (currentDirection)
            {
                case SnakeDirection.Up:
                    nextMapCell = new MapCell(currentMapCell.PositionOnX, currentMapCell.PositionOnY - 1);
                    break;
                case SnakeDirection.Down:
                    nextMapCell = new MapCell(currentMapCell.PositionOnX, currentMapCell.PositionOnY + 1);
                    break;
                case SnakeDirection.Left:
                    nextMapCell = new MapCell(currentMapCell.PositionOnX - 1, currentMapCell.PositionOnY);
                    break;
                case SnakeDirection.Right:
                    nextMapCell = new MapCell(currentMapCell.PositionOnX + 1, currentMapCell.PositionOnY);
                    break;
                default:
                    return false;
            }
            if (nextMapCell.PositionOnX < 0 || nextMapCell.PositionOnY >= level.LevelMap.MapRows
                || nextMapCell.PositionOnY < 0 || nextMapCell.PositionOnX >= level.LevelMap.MapColumns)
                    return false;
            if (snake.Contain(new SnakePart(nextMapCell.PositionOnX, nextMapCell.PositionOnY)) == true)
                return false;
            nextMapCell = level.LevelMap.GetMapCell(nextMapCell.PositionOnX, nextMapCell.PositionOnY);
            if (nextMapCell.CellType == MapCellType.Block)
                return false;
            return true;
        }
        public void PauseGame()
        {
            if (gameSpeed.IsPaused == false)
                gameSpeed.Pause();
        }

        public void ResumeGame()
        {
            if (gameSpeed.IsPaused == true)
                gameSpeed.Resume();
        }

        public Player GetPlayer()
        {
            return this.player;
        }

        public ISnake GetSnake()
        {
            return this.snake;
        }

        public ILevel GetLevel()
        {
            return this.level;
        }

        private void Win()
        {
            gameLost = false;
            gameWon = true;
            gameDuration.IsEnabled = false;
            gameSpeed.Stop();
            player.AddHighscore(level.Id, currentGameScore);
            player.LastLevelId++;
        }

        private void Lost()
        {
            gameLost = true;
            gameWon = false;
            gameDuration.IsEnabled = false;
            gameSpeed.Stop();
        }

        public bool GameWon
        {
            get { return gameWon; }
        }

        public bool GameLost
        {
            get { return gameLost; }
        }

        public long TimeElapsed
        {
            get { return timeElapsedInSeconds; }
        }

        public void ChangeSnakeDirection(SnakeDirection dir)
        {
            if ((int)dir >= 0 && (int)dir <= 3)
            {
                if (this.snake.Direction == SnakeDirection.Up && dir == SnakeDirection.Down)
                    return;
                if (this.snake.Direction == SnakeDirection.Down && dir == SnakeDirection.Up)
                    return;
                if (this.snake.Direction == SnakeDirection.Left && dir == SnakeDirection.Right)
                    return;
                if (this.snake.Direction == SnakeDirection.Right && dir == SnakeDirection.Left)
                    return;
            }
                this.snake.Direction = dir;
        }
    }
}
