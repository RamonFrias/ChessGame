using Xadrez_console.Board;
using Xadrez_console.Board.Enums;

namespace Xadrez_console.Chess
{
    class Pawn : Piece
    {
        public Pawn(Colors color, BoardClass board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistEnenmy(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Color != Color;
        }

        private bool Free(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Colors.White)
            {
                pos.DefineValues(Position.Line - 1, Position.Column);
                if (Board.VerifyPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 2, Position.Column);
                if (Board.VerifyPosition(pos) && Free(pos) && QuantityOfMoviments == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column - 1);
                if (Board.VerifyPosition(pos) && ExistEnenmy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column + 1);
                if (Board.VerifyPosition(pos) && ExistEnenmy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (Board.VerifyPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 2, Position.Column);
                if (Board.VerifyPosition(pos) && Free(pos) && QuantityOfMoviments == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column - 1);
                if (Board.VerifyPosition(pos) && ExistEnenmy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column + 1);
                if (Board.VerifyPosition(pos) && ExistEnenmy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            return mat;
        }
    }
}
