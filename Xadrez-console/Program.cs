using System;
using Xadrez_console.Board;
using Xadrez_console.Board.Enums;
using Xadrez_console.Chess;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardClass board = new BoardClass(8, 8);
            board.PutPiece(new King(Colors.Yellow, board), new Position(0, 0));
            board.PutPiece(new Queen(Colors.Yellow, board), new Position(1, 3));
            board.PutPiece(new Rook(Colors.Yellow, board), new Position(2, 4));
            Screen.PrintBoard(board); 
        }
    }
}
