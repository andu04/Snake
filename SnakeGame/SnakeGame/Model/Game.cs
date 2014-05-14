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
    class Game: IGame
    {
        private Level level;
        private ISnake snake;
        private Player player;
        private SpeedController gameSpeed;
        private bool gameWon;
        private bool gameLost;
        private DispatcherTimer gameDuration;
        private long timeElapsedInSeconds;
        private int currentGameScore;
        public Game(Level level, Player player)
        {
            this.level = level;
            this.player = player;
            //InitializeLevel();
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

        
        //TODO: modificat parametru constructo din level in levelID si de facut metoda IniTializeLevel()
        private void InitializeLevel()
        {
            throw new NotImplementedException();
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
            if (IsValidNextMove() == true)
            {
                snake.MoveSnake();
                SnakePart sp = snake.GetSnakeHead();
                NPC currentNPC = level.GetNPC(sp.PositionOnX, sp.PositionOnY);
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
                    if (currentMapCell.PositionOnX == 0)
                        return false;
                    nextMapCell = level.LevelMap.GetMapCell(currentMapCell.PositionOnX, currentMapCell.PositionOnY - 1);
                    break;
                case SnakeDirection.Down:
                    if (currentMapCell.PositionOnX == level.LevelMap.MapRows - 1)
                        return false;
                    nextMapCell = level.LevelMap.GetMapCell(currentMapCell.PositionOnX, currentMapCell.PositionOnY + 1);
                    break;
                case SnakeDirection.Left:
                    if (currentMapCell.PositionOnY == 0)
                        return false;
                    nextMapCell = level.LevelMap.GetMapCell(currentMapCell.PositionOnX - 1, currentMapCell.PositionOnY);
                    break;
                case SnakeDirection.Right:
                    if (currentMapCell.PositionOnY == level.LevelMap.MapColumns - 1)
                        return false;
                    nextMapCell = level.LevelMap.GetMapCell(currentMapCell.PositionOnX + 1, currentMapCell.PositionOnY);
                    break;
                default:
                    return false;
            }
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
            throw new NotImplementedException();
        }

        public ISnake GetSnake()
        {
            throw new NotImplementedException();
        }

        public ILevel GetLevel()
        {
            throw new NotImplementedException();
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
                this.snake.Direction = dir;
        }
    }
}
