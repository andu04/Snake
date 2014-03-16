using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeApplication
{
    class Fruits:NPC
    {

        public void appear(int x, int y, String type)
        {   
           //appear on map pe poz x,y, fructtul de tipul type
            //conditii: sa nu fie pe aceleasi coordonate ca si sarpele sau cu vreun enemie(sa nu se suprapuna)
        }

        public void dissapear()
        {
            //remove npc then appear npc daca nu s-a terminat nivelul
        }

        public void generatePosition()
        {
           //genereaza random o pozitie a unui npc care sa nu se suprapuna cu  pozitia sarpelui sau a vreunui enemie
        }
    }
}
