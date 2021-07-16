namespace board
{
    class BoardClass
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        // It is privated because only the board have access.
        private Piece[,] Pieces { get; set; }

        public BoardClass(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }
    }
}
