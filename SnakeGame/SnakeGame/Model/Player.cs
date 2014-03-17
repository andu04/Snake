using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Model
{
    class Player
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        private int livesLeft;

        public int LivesLeft
        {
            get { return livesLeft; }
            set { livesLeft = value; }
        }
        private int highScore;

        public int HighScore
        {
            get { return highScore; }
            set { highScore = value; }
        }
        private int lastLevelId;

        public int LastLevelId
        {
            get { return lastLevelId; }
            set { lastLevelId = value; }
        }
        long timePlayed;

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
