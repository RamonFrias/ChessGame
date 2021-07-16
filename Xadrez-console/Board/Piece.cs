using Xadrez_console.Board.Enums;

namespace Xadrez_console.Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Colors Color { get; protected set; }
        public int QuantityOfMoviments { get; protected set; }
        public BoardClass Board { get; set; }

        public Piece(Colors color, BoardClass board)
        {
            Position = null;
            Color = color;
            Board = board;
            QuantityOfMoviments = 0;
        }
    }
}
