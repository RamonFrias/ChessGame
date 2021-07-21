using Xadrez_console.Board;
using Xadrez_console.Board.Enums;

namespace Xadrez_console.Chess
{
    class King : Piece
    {
        public King(Colors color, BoardClass board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool ThisMovimentIsPossible(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            // North
            position.DefineValues(Position.Line - 1, Position.Column);

            if (Board.VerifyPosition(position) && ThisMovimentIsPossible(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // Northeast
            position.DefineValues(Position.Line - 1, Position.Column + 1);

            if (Board.VerifyPosition(position) && ThisMovimentIsPossible(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // East
            position.DefineValues(Position.Line, Position.Column + 1);

            if (Board.VerifyPosition(position) && ThisMovimentIsPossible(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // Southeast
            position.DefineValues(Position.Line + 1, Position.Column + 1);

            if (Board.VerifyPosition(position) && ThisMovimentIsPossible(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // South
            position.DefineValues(Position.Line + 1, Position.Column);

            if (Board.VerifyPosition(position) && ThisMovimentIsPossible(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // Southwest
            position.DefineValues(Position.Line + 1, Position.Column - 1);

            if (Board.VerifyPosition(position) && ThisMovimentIsPossible(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // West
            position.DefineValues(Position.Line, Position.Column - 1);

            if (Board.VerifyPosition(position) && ThisMovimentIsPossible(position))
            {
                mat[position.Line, position.Column] = true;
            }

            // Northwest
            position.DefineValues(Position.Line - 1, Position.Column - 1);

            if (Board.VerifyPosition(position) && ThisMovimentIsPossible(position))
            {
                mat[position.Line, position.Column] = true;
            }

            return mat;
        }
    }
}
