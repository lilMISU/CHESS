using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHESS
{
    class Chessboard
    {
        private int Size;
        public Cell[,] theGrid;

        public Chessboard(int Size)
        {
            this.Size = Size;
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if ((i + j) % 2 == 0)
                        theGrid[i, j] = new Cell(i, j, Color.BurlyWood);
                    else
                        theGrid[i, j] = new Cell(i, j, Color.Aquamarine);
                    theGrid[i, j].setPieces();
                    if (j == 0 || j == 1)
                        theGrid[i, j].piece.team = "black";
                    if (j == 6 || j == 7)
                        theGrid[i, j].piece.team = "white";
                }
            }
            theGrid[0, 0].piece.name = "t1";
            theGrid[1, 0].piece.name = "c1";
            theGrid[2, 0].piece.name = "n1";
            theGrid[3, 0].piece.name = "qu";
            theGrid[4, 0].piece.name = "kg";
            theGrid[5, 0].piece.name = "n2";
            theGrid[6, 0].piece.name = "c2";
            theGrid[7, 0].piece.name = "t2";
            for (int i = 0; i < 8; i++)
                theGrid[i, 1].piece.name = "p" + Convert.ToString(i + 1);
            theGrid[0, 7].piece.name = "t1";
            theGrid[1, 7].piece.name = "c1";
            theGrid[2, 7].piece.name = "n1";
            theGrid[3, 7].piece.name = "qu";
            theGrid[4, 7].piece.name = "kg";
            theGrid[5, 7].piece.name = "n2";
            theGrid[6, 7].piece.name = "c2";
            theGrid[7, 7].piece.name = "t2";
            for (int i = 0; i < 8; i++)
                theGrid[i, 6].piece.name = "p" + Convert.ToString(i + 1);
        }

        public int returnSize()
        {
            return Size;
        }
    }
}
