using board;
using System;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardClass board = new BoardClass(8, 8);

            Console.WriteLine(board);
        }
    }
}
