using Xadrez_console.Board;
using System;
using Xadrez_console.Board.Enums;
using Xadrez_console.Chess;
using Xadrez_console.Exceptions;
using System.Collections.Generic;

namespace Xadrez_console
{
    class Screen
    {

        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);

            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();

            Console.WriteLine($"Turn: {match.Turn}");

            if (!match.Finish)
            {
                Console.WriteLine($"Waiting move: {match.CurrentPlayer}");

                if (match.Check)
                {
                    Console.WriteLine("Check!");
                }
            }
            else
            {
                Console.WriteLine("Checkmate!");
                Console.WriteLine($"Winner: {match.CurrentPlayer}");
            }
            
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces:");

            Console.Write($"White: ");
            PrintSet(match.CapturedPiece(Colors.White));

            Console.WriteLine();

            ConsoleColor auxiliar = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write($"Black: ");
            PrintSet(match.CapturedPiece(Colors.Black));
            Console.ForegroundColor = auxiliar;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> pieces)
        {
            Console.Write("[");
            foreach (Piece piece in pieces)
            {
                Console.Write($"{piece} ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(BoardClass board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiace(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        } 
        
        public static void PrintBoard(BoardClass board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkBlue;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiace(board.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

            Console.BackgroundColor = originalBackground;
        }

        public static void PrintPiace(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string auxiliar = Console.ReadLine();
            char column = auxiliar[0];
            int line = int.Parse(auxiliar[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintException(BoardException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Press ENTER to continue!");
            Console.ReadLine();
        }
    }
}
