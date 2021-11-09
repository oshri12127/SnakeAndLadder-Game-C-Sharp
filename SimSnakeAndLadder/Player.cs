using System;
using System.Collections.Generic;
using System.Text;

namespace SimSnakeAndLadder
{
    class Player
    {
        private string name;
        private int location;
        private int dices;
        public Player(string name)
        {
            this.name = name;
            Location = -1;
            dices = 0;
        }
        public string Name { get => name; }
        public int Location { get => location; set => location = value; }
        public int Dices { get => dices;}
        public void RollDice()//roll random dices
        {
            Random rnd = new Random();
            int dice1 = rnd.Next(1, 7);   // creates a number between 1 and 6
            int dice2 = rnd.Next(1, 7);   // creates a number between 1 and 6
            dices = dice1 + dice2;
        }
        public void UpdateLocation()//update location of player by result of dices
        {
           Location += dices;
        }
         public override string ToString()
         {
             return $"\"{Name}\" is on {Location+1}";
         }
    }
}
