using System;
using Xadrez_console.Board;
using Xadrez_console.Board.Enums;
using Xadrez_console.Chess;
using Xadrez_console.Exceptions;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardClass board = new BoardClass(8, 8);
            try
            {
                board.PutPiece(new King(Colors.Black, board), new Position(0, 0));
                board.PutPiece(new Queen(Colors.Black, board), new Position(1, 3));
                board.PutPiece(new Rook(Colors.White, board), new Position(2, 4));
                board.PutPiece(new Bishop(Colors.White, board), new Position(0, 4));

                ChessPosition position = new ChessPosition('c', 7);
                Screen.PrintBoard(board);

                Console.WriteLine(position.ToPosition());
            }
            catch (BoardException e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
