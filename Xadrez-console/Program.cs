﻿using System;
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
                    Console.Clear();
                    Screen.PrintBoard(match.board);

                    Console.WriteLine();

                    Console.WriteLine($"Turn: {match.Turn}");
                    Console.WriteLine($"Waiting move: {match.CurrentPlayer}");

                    Console.WriteLine();

                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = match.board.Piece(origin).PossibleMoviments();

                    Console.Clear();
                    Screen.PrintBoard(match.board, possiblePositions);

                    Console.WriteLine("\n");

                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.RealizeMove(origin, destiny);
                }              
            }
            catch (BoardException e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
