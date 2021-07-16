using Xadrez_console.Board;
using Xadrez_console.Board.Enums;

namespace Xadrez_console.Chess
{
    class King : Piece
    {
        public King(Colors color, BoardClass board) : base(color, board) {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
