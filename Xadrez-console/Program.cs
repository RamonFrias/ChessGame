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
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finish)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();

                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.ValidOriginPosition(origin);

                        bool[,] possiblePositions = match.Board.Piece(origin).PossibleMoviments();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.WriteLine("\n");

                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition().ToPosition();
                        match.ValidDestinyPosition(origin, destiny);

                        match.RealizeMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Screen.PrintException(e);
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch (BoardException e)
            {

                Screen.PrintException(e);
            }
        }
    }
}
