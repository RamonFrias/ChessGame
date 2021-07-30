using Xadrez_console.Board;
using Xadrez_console.Board.Enums;

namespace Xadrez_console.Chess
{
    class Horse : Piece
    {
        public Horse(Colors color, BoardClass board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "K";
        }

        private bool ThisMovimentIsPossible(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Line - 1, Position.Column - 2);
            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 2, Position.Column - 1);
            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 2, Position.Column + 1);
            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 1, Position.Column + 2);
            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 1, Position.Column + 2);
            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            
            pos.DefineValues(Position.Line + 1, Position.Column - 2);
            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 2, Position.Column + 1);
            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
