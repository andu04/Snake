using SnakeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Model
{
    class Fruits:NPC
    {
        public Fruits(int x, int y, int value, String type)
            //:base(x, y, value, type)
        {

        }

        protected override void Appear()
        {
            //appear on map pe poz x,y, fructtul de tipul type
            //conditii: sa nu fie pe aceleasi coordonate ca si sarpele sau cu vreun enemie(sa nu se suprapuna)
            throw new NotImplementedException();
        }

        protected override void Dissapear()
        {
            //remove npc then appear npc daca nu s-a terminat nivelul
            throw new NotImplementedException();
        }

        protected override void GeneratePosition()
        {
            //genereaza random o pozitie a unui npc care sa nu se suprapuna cu  pozitia sarpelui sau a vreunui enemie
            throw new NotImplementedException();
        }
    }
}
