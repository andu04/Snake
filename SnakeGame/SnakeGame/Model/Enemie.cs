using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeApplication
{
    class Enemie:NPC
    {

        public void appear()
        {
            //appear on map enemie de tipl type
            //sa nu apara pe pozitii suprapuse cu sarpele sau cu un fruct
        }

        public void dissapear()
        {
            //dispare la sf nivelului
        }

        public void generatePosition()
        {
           //se genereaza o pozitie in functie de nivel
           //ma gandeam sa punem poisonFruits pe care daca le mananca sa se interschimbe directiile(st-dr si sus-jos) 
            //si obstacole dar nu stiu daca sa mai fac clase separate si pt ele sau doar schimbam type-ul
           
        }
    }
}
