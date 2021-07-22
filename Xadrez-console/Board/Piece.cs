using Xadrez_console.Board.Enums;

namespace Xadrez_console.Board
{
    abstract class Piece
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

        public void IncrementMovimentsQuantity()
        {
            QuantityOfMoviments++;
        }

        public bool ExistPossibleMoviments()
        {
            bool[,] mat = PossibleMoviments();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoviments()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMoviments();
    }
}
