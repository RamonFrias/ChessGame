using System;
using Xadrez_console.Board;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardClass board = new BoardClass(8, 8);
            Screen.PrintBoard(board); 
        }
    }
}
