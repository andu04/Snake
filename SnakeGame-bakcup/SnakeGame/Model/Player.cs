using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Model
{
    class Player
    {
        private string name;
        private int score;
        private int livesLeft;
        private int highScore;
        private int lastLevelId;
        private long timePlayed;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int LivesLeft
        {
            get { return livesLeft; }
            set { livesLeft = value; }
        }

        public int HighScore
        {
            get { return highScore; }
            set { highScore = value; }
        }

        public int LastLevelId
        {
            get { return lastLevelId; }
            set { lastLevelId = value; }
        }

        public long TimePlayed
        {
            get { return timePlayed; }
            set { timePlayed = value; }
        }


        public Player(string name, int startingLives, int lastLevelId, long timePlayed)
        {
            this.name = name;
            this.livesLeft = startingLives;
            this.lastLevelId = lastLevelId;
            this.timePlayed = timePlayed;
            this.score = 0;
            this.highScore = 0;
        }
        public Player(string name, int startingLives, int lastLevelId, long timePlayed, int score, int highScore)
            :this(name, startingLives, lastLevelId, timePlayed)
        {
            this.score = score;
            this.highScore = highScore;
        }

        public void AddPoints(int totalPoints)
        {
            score += totalPoints;
        }

        public void Kill()
        {
            if (livesLeft > 0)
            {
                livesLeft--;
            }
        }
    }
}
