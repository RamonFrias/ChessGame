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

        // Metod to return a piece in a especific point
        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            // Access this position and put the piece.
            Pieces[position.Line, position.Column] = piece;
            // Inform the piece position in Position.
            piece.Position = position;
        }
    }
}
