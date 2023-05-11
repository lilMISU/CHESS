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
    class Cell : PictureBox
    {
        private int rowNumber;
        private int columnNumber;
        public Piece piece;

        public Cell(int x, int y, Color color)
        {
            rowNumber = x;
            columnNumber = y;
            BackColor = color;
            piece = new Piece();
        }

        public int returnRowNumber()
        {
            return rowNumber;
        }

        public int returnColumnNumber()
        {
            return columnNumber;
        }
        public void setPieces()
        {
            if (columnNumber == 1)
                this.BackgroundImage = Image.FromFile("../../../pion1.png");
            if (columnNumber == 6)
                this.BackgroundImage = Image.FromFile("../../../pion2.png");
            if (columnNumber == 0)
            {
                if (rowNumber == 0 || rowNumber == 7)
                    this.BackgroundImage = Image.FromFile("../../../tura1.png");

                else if (rowNumber == 1 || rowNumber == 6)
                    this.BackgroundImage = Image.FromFile("../../../cal1.png");

                else if (rowNumber == 2 || rowNumber == 5)
                    this.BackgroundImage = Image.FromFile("../../../nebun1.png");
                else if (rowNumber == 3)
                {
                    this.BackgroundImage = Image.FromFile("../../../regina1.png");
                    piece = new Queen();
                }
                else
                {
                    this.BackgroundImage = Image.FromFile("../../../rege1.png");
                    piece = new King();
                }
            }

            if (columnNumber == 7)
            {
                if (rowNumber == 0 || rowNumber == 7)
                    this.BackgroundImage = Image.FromFile("../../../tura2.png");

                else if (rowNumber == 1 || rowNumber == 6)
                    this.BackgroundImage = Image.FromFile("../../../cal2.png");

                else if (rowNumber == 2 || rowNumber == 5)
                    this.BackgroundImage = Image.FromFile("../../../nebun2.png");
                else if (rowNumber == 3)
                {
                    this.BackgroundImage = Image.FromFile("../../../regina2.png");
                    piece = new Queen();
                }
                else
                {
                    this.BackgroundImage = Image.FromFile("../../../rege2.png");
                    piece = new King();
                }
            }
            this.BackgroundImageLayout = ImageLayout.Center;
        }

    }
}
