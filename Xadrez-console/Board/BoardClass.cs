using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_console.Board
{
    class BoardClass
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        protected Piece[,] Pieces;

        public BoardClass(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }
    }
}
