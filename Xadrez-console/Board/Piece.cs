using Xadrez_console.Board;

namespace board
{
    class Piece
    {
        public Position Position { get; set; }
        // The color have access only to get the color, but only have access to set the color in SuperClass and SubClass because it's protected.
        public Colors Color { get; protected set; }
        public int MovimentsQuantity { get; set; }
        // The same description as Color
        public BoardClass Board { get; set; }

        public Piece(Position position, Colors color, BoardClass board)
        {
            Position = position;
            Color = color;
            // Quantity is 0 because the piece starts with 0 moviments
            MovimentsQuantity = 0;
            Board = board;
        }
    }
}
