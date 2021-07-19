using Xadrez_console.Exceptions;

namespace Xadrez_console.Board
{
    class BoardClass
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        protected Piece[,] Pieces;

        public BoardClass(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        // Metod to return a piece in a especific line and column
        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        // Metod to return a piece in a especific position
        public Piece Piece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (ExistPieceInPosition(position))
            {
                throw new BoardException("Exist a piece in this position!!");
            }
            // Access this position and put the piece.
            Pieces[position.Line, position.Column] = piece;
            // Inform the piece position in Position.
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }

            Piece auxiliar = Piece(position);
            auxiliar.Position = null;

            Pieces[position.Line, position.Column] = null;
            return auxiliar;
        }

        public bool ExistPieceInPosition(Position position)
        {
            ValidPosition(position);
            return Piece(position) != null;
        }

        public bool VerifyPosition(Position position)
        {
            if (position.Line >=Lines || position.Line < 0 || position.Column > Columns || position.Column < 0)
            {
                return false;
            }
            return true;
        }

        public void ValidPosition(Position position)
        {
            if (!VerifyPosition(position))
            {
                throw new BoardException("Invalid position!!");
            }
        }
    }
}
