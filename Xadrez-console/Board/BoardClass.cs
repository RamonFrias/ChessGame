using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_console.Board
{
    class BoardClass
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        protected Piece[,] Piece;

        public BoardClass(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Piece = new Piece[lines, columns];
        }
    }
}
