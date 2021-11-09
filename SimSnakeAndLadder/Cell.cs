using System;
using System.Collections.Generic;
using System.Text;

namespace SimSnakeAndLadder
{
    public enum TypeCell//Types of cells.
    {
        Regular,
        Ladder,
        Snake,
        Golden
    };
    class Cell
    {
        private static int countCell = 0; //count instances of class
        private int numCell;
        private KeyValuePair<TypeCell, int> type;
        public Cell()
        {
            numCell = countCell;
            Type = new KeyValuePair<TypeCell, int>(TypeCell.Regular, -1);
            countCell++;
        }

        public int NumCell { get => numCell;}
        public KeyValuePair<TypeCell, int> Type { get => type; set => type = value; }
    }
}
