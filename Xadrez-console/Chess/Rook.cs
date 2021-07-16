using Xadrez_console.Board;
using Xadrez_console.Board.Enums;

namespace Xadrez_console.Chess
{
    class Rook : Piece
    {
        public Rook(Colors color, BoardClass board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
