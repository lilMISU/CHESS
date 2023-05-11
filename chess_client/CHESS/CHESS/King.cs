using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    class King : Piece
    {
        public override void  ColorChange(Cell[,] cell)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        cell[i, j].BackColor = Color.BlanchedAlmond;
                    else
                        cell[i, j].BackColor = Color.White;

                }
            }

        }
    }
}
