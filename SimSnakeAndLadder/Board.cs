using System;
using System.Collections.Generic;
using System.Text;

namespace SimSnakeAndLadder
{
    class Board
    {
        private Cell[] cellsArray;
        private int size;
        public Board(int size,int snakes,int ladders)
        {
            this.size = size;
            cellsArray = new Cell[size];
            for (int i = 0; i < size; i++)
            {
                cellsArray[i] = new Cell();
            }
            //CreateSnakes(snakes);
            //CreateLadders(ladders);
            CreateSnakesOrLadders(snakes, TypeCell.Snake);
            CreateSnakesOrLadders(ladders, TypeCell.Ladder);
            CreateGolden();
        }
        public Cell[] CellsArray { get => cellsArray; }
        private int CreateRandomNumber(int start,int end)//creates a random number between start and end
        {
            Random rnd = new Random();
            int rand = rnd.Next(start, end);   // creates a number between start and end
            return rand;
        }
       
        private void CreateGolden()//create golden tile
        {
            Console.WriteLine("Golden");
            int cellNumber;
            for (int i = 0; i < 2; i++)
            {
                cellNumber = CreateRandomNumber(0,size);
                while(cellsArray[cellNumber].Type.Key!=TypeCell.Regular)//check if is dont regular cell
                {
                    cellNumber= CreateRandomNumber(0, size);
                }
                cellsArray[cellNumber].Type= new KeyValuePair<TypeCell, int>(TypeCell.Golden, -1);
                Console.WriteLine($"{cellNumber+1}");
            }
            Console.WriteLine();
        }

        public KeyValuePair<TypeCell, int> ReturnTypeOfCellByIndex(int indexCell)
        {
            return cellsArray[indexCell].Type;
        }

       /* private void CreateLadders(int ladders)
        {
            Console.WriteLine("ladders");
            int cellFrom,cellTo;
            for (int i = 0; i < ladders; i++)
            {
                cellFrom = CreateRandomNumber(0, size);
                while (cellsArray[cellFrom].Type.Key != TypeCell.Regular||cellFrom/10==(size-1)/10)
                {
                    cellFrom = CreateRandomNumber(0, size);
                }
                cellTo = CreateRandomNumber(cellFrom, size);
                while (cellsArray[cellTo].Type.Key != TypeCell.Regular||cellFrom==cellTo|| cellFrom / 10 == cellTo / 10)
                {
                    cellTo = CreateRandomNumber(cellFrom, size);
                }
                cellsArray[cellFrom].Type = new KeyValuePair<TypeCell, int>(TypeCell.Ladder, cellTo);
                cellsArray[cellTo].Type = new KeyValuePair<TypeCell, int>(TypeCell.Ladder, -1);
                Console.WriteLine($"{cellFrom + 1} => {cellTo + 1}");
            }
            Console.WriteLine();
        }*/
        private void CreateSnakesOrLadders(int amount,TypeCell type)//create tiles of snakes or ladders by type and amount.
        {
            if(type == TypeCell.Ladder)
                Console.WriteLine("ladders");
            else
                Console.WriteLine("snakes");
            int cellFrom, cellTo;
            for (int i = 0; i < amount; i++)
            {
                cellFrom = CreateRandomNumber(0, size);
                if (type==TypeCell.Ladder)
                {
                    while (cellsArray[cellFrom].Type.Key != TypeCell.Regular || cellFrom / 10 == (size - 1) / 10)
                    {
                        cellFrom = CreateRandomNumber(0, size);
                    }
                    cellTo = CreateRandomNumber(cellFrom, size);
                    while (cellsArray[cellTo].Type.Key != TypeCell.Regular || cellFrom == cellTo || cellFrom / 10 == cellTo / 10)
                    {
                        cellTo = CreateRandomNumber(cellFrom, size);
                    }
                }
                else//type=Snakes
                {
                    while (cellsArray[cellFrom].Type.Key != TypeCell.Regular || cellFrom / 10 == 0)
                    {
                        cellFrom = CreateRandomNumber(0, size);
                    }
                    cellTo = CreateRandomNumber(0, cellFrom);
                    while (cellsArray[cellTo].Type.Key != TypeCell.Regular || cellFrom == cellTo || cellFrom / 10 == cellTo / 10)
                    {
                        cellTo = CreateRandomNumber(0, cellFrom);
                    }
                }
                cellsArray[cellFrom].Type = new KeyValuePair<TypeCell, int>(type, cellTo);
                cellsArray[cellTo].Type = new KeyValuePair<TypeCell, int>(type, -1);
                Console.WriteLine($"{cellFrom + 1} => {cellTo + 1}");
            }
            Console.WriteLine();
        }
       /* private void CreateSnakes(int snakes)
        {
            Console.WriteLine("snakes");
            int cellFrom, cellTo;
            for (int i = 0; i < snakes; i++)
            {
                cellFrom = CreateRandomNumber(0, size);
                while (cellsArray[cellFrom].Type.Key != TypeCell.Regular || cellFrom / 10 == 0)
                {
                    cellFrom = CreateRandomNumber(0, size);
                }
                cellTo = CreateRandomNumber(0, cellFrom);
                while (cellsArray[cellTo].Type.Key != TypeCell.Regular || cellFrom == cellTo || cellFrom / 10 == cellTo / 10)
                {
                    cellTo = CreateRandomNumber(0, cellFrom);
                }
                cellsArray[cellFrom].Type = new KeyValuePair<TypeCell, int>(TypeCell.Snake, cellTo);
                cellsArray[cellTo].Type = new KeyValuePair<TypeCell, int>(TypeCell.Snake, -1);
                Console.WriteLine($"{cellFrom+1} => {cellTo+1}");
            }
            Console.WriteLine();
        }*/

        
    }
}
