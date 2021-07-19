using Xadrez_console.Board;
using System;
using Xadrez_console.Board.Enums;

namespace Xadrez_console
{
    class Screen
    {
        public static void PrintBoard(BoardClass board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiace(board.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintPiace(Piece piece)
        {
            if (piece.Color == Colors.White)
            {
                Console.Write(piece);
            }
            // If the piece is Black or other color, print in yellow
            else
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = color;
            }
        }
    }
}
