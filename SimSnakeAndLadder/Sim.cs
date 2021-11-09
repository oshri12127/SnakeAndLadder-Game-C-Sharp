using System;
using System.Collections.Generic;
using System.Text;

namespace SimSnakeAndLadder
{
    class Sim
    {
        private int snakesSize, laddersSize;
        private int numberOfPlayers, sizeBoard;
        private bool flagWinner;//true win
        private Board boardGame;
        private Player[] playersArray;

        public Sim() 
        {
            numberOfPlayers = 2;
            sizeBoard = 99;
            flagWinner = false;
        }
        public void Run()//run the simulation
        {
            int round = 1;
            Input();
            CreateBoardAndPlayers();
            Console.WriteLine("Simulation Started");
            while (flagWinner == false)
            {
                Console.WriteLine("round" + round);
                StartRound();
                round++;
            }
        }

        private void StartRound()
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                playersArray[i].RollDice();
                Console.WriteLine('"' + playersArray[i].Name + '"' + " rolled " + playersArray[i].Dices);
                playersArray[i].UpdateLocation();
                if (CheckIfWinner(i) == true)
                    return;
                PlayerOnSpecialCell(i);
                Console.WriteLine(playersArray[i].ToString());
            }
        }
        private void Input()//Checks and enters input of amount of snakes and ladder.
        {
            string tempSnakesSize, tempLaddersSize;
            int numericValue;
            Console.WriteLine("Enter amount of snakes");
            tempSnakesSize = Console.ReadLine();
            Console.WriteLine("Enter amount of ladder");
            tempLaddersSize = Console.ReadLine();
            while (int.TryParse(tempSnakesSize, out numericValue) == false || int.TryParse(tempLaddersSize, out numericValue) == false || Convert.ToInt32(tempLaddersSize) < 0 || Convert.ToInt32(tempSnakesSize) < 0 || Convert.ToInt32(tempSnakesSize) + Convert.ToInt32(tempLaddersSize) > sizeBoard / 2)
            {
                Console.WriteLine("Error,Invalid input or is negative number or the total sum of Snakes and Ladders exceed 50% of the board. Please enter a valid input");
                Console.WriteLine();
                Console.WriteLine("Enter amount of snakes");
                tempSnakesSize = Console.ReadLine();
                Console.WriteLine("Enter amount of ladder");
                tempLaddersSize = Console.ReadLine();
            }
            snakesSize = Convert.ToInt32(tempSnakesSize);
            laddersSize = Convert.ToInt32(tempLaddersSize);
        }
        private void CreateBoardAndPlayers()
        {
            
            playersArray = new Player[numberOfPlayers];
            string name;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine($"Enter the name for the player {i+1}: ");
                name =Console.ReadLine();
                while(CheckIfNameExists(name)==true||name=="")
                {
                    if(name=="")
                    {Console.WriteLine("Please enter a valid name."); }
                    else 
                    {Console.WriteLine("The name is exists. Enter a different name."); }
                    name = Console.ReadLine();
                }
                playersArray[i] = new Player(name);
            }
            Console.WriteLine();
            boardGame = new Board(sizeBoard, snakesSize, laddersSize);
        }
        private bool CheckIfWinner(int playerIndex)
        {
            if(playersArray[playerIndex].Location>=sizeBoard)
            {
                Console.WriteLine($"\"{playersArray[playerIndex].Name}\" has won!");
                flagWinner = true;
                return true;
            }
            return false;

        }
        private void PlayerOnSpecialCell(int playerIndex)//check if player landed on snake,ladder or golden tile
        {
            KeyValuePair<TypeCell, int> type;
            type=boardGame.ReturnTypeOfCellByIndex(playersArray[playerIndex].Location);
            if(type.Key==TypeCell.Snake&&type.Value!=-1)
            {
                playersArray[playerIndex].Location = type.Value;
                Console.WriteLine($"\"{playersArray[playerIndex].Name}\" has landed on a snake");
            }
            if (type.Key == TypeCell.Ladder && type.Value != -1)
            {
                playersArray[playerIndex].Location = type.Value;
                Console.WriteLine($"\"{playersArray[playerIndex].Name}\" has landed on a ladder");
            }
            if (type.Key == TypeCell.Golden)
            {
                int topPlayerIndex = FindTopPlayer();
                if(playerIndex!=topPlayerIndex)
                {
                    Console.WriteLine($"\"{playersArray[playerIndex].Name} \" landed on golden tile and switched with {playersArray[topPlayerIndex].Name}");
                    int numTopCell = playersArray[topPlayerIndex].Location;
                    playersArray[topPlayerIndex].Location = playersArray[playerIndex].Location;
                    playersArray[playerIndex].Location = numTopCell;
                    Console.WriteLine($"\"{playersArray[topPlayerIndex].Name}\" is on {playersArray[topPlayerIndex].Location+1}");
                }
                else
                {
                    Console.WriteLine($"\"{playersArray[playerIndex].Name}\" landed on golden tile and {playersArray[playerIndex].Name} is already the top player");
                }
            }
        }
        private int FindTopPlayer()
        {
            int topPlayer = 0;
            for (int i = 1; i < numberOfPlayers; i++)
            {
                if (playersArray[i].Location > playersArray[topPlayer].Location)
                    topPlayer = i;
            }
            return topPlayer;
        }
        private bool CheckIfNameExists(string name)
        {
            for (int i = 0; i < playersArray.Length; i++)
            {
                if (playersArray[i]!=null&&playersArray[i].Name == name)
                    return true;
            }
            return false;
        }
    }
}
