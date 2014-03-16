using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Player
{
    class Player
    {
        private string name;
        private int score;
        private int livesLeft;
        private int highScore;
        private int lastLevelId;
        long timePlayed;
         public Player(string name)
        {
            this.name = name;
        }

        public Player(string name, int startingLives,int lastLevelId,Timer timePlayed)
        {
            this.name = name;
            livesLeft = startingLives;
            lastLevelId = 0;
            timePlayed.Interval = (1000) * (10);              // Timer will tick every 10 second
            timePlayed.Enabled = true;                       // Enable the timer
            timePlayed.Start();       
        }

        public string GetName()
        {
            return name;
        }

        public int GetScore()
        {
            return score;
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

        public int GetLivesLeft()
        {
            return livesLeft;
        }
        public int GetlastLevelId()
        {
            return lastLevelId;
        }
        public void SetlastLevelId(int newLevel)
        {
            this.lastLevelId=newLevel;
        }
        public int GethighScore()
        {
            return highScore;
        }
        public void SethighScore(int newHigh)
        {
            this.highScore = newHigh;
        }
        public long GettimePlayed()
        {
            return timePlayed;
        }

    }
}
