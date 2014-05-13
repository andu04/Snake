using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace SnakeGame.Model
{
    public class Player:INotifyPropertyChanged
    {
        private string name;
        private List<int> highScore;
        private int lastLevelId;
        private long timePlayed;

        public string Name
        {
            get { return name; }
            set { name = value;
            NotifyPropoertyChanged("Name");
            }
        }

        public int LastLevelId
        {
            get { return lastLevelId; }
            set { lastLevelId = value;
            NotifyPropoertyChanged("LastLevelId");
            }
        }

        public long TimePlayed
        {
            get { return timePlayed; }
            set { timePlayed = value;
            NotifyPropoertyChanged("TimePlayed");
            }
        }
        public Player(string name, int lastLevelId, long timePlayed)
        {
            this.Name = name;
            this.LastLevelId = lastLevelId;
            this.TimePlayed = timePlayed;
            this.highScore = new List<int>();
        }
        public Player(string name, int lastLevelId, long timePlayed, List<int> highScore)
            :this(name, lastLevelId, timePlayed)
        {
            this.highScore = highScore;
        }

        public void AddHighscore(int levelId, int highscore)
        {
            highScore[levelId] = highscore;
        }
        public int GetHighscore(int levelId)
        {
            return highScore.ElementAt(levelId);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropoertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
