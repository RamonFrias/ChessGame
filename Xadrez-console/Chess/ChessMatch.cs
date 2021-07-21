using System;
using Xadrez_console.Board;
using Xadrez_console.Board.Enums;

namespace Xadrez_console.Chess
{
    class ChessMatch
    {
        public BoardClass board { get; private set; }
        public int Turn { get; private set; }
        public Colors CurrentPlayer { get; private set; }
        public bool Finish { get; private set; }

        public ChessMatch()
        {
            board = new BoardClass(8, 8);
            Turn = 1;
            CurrentPlayer = Colors.White;
            Finish = false;
            PutingInitialPieces();
        }

        public void ExecutMoviment(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.IncrementMovimentsQuantity();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PutPiece(piece, destiny);
        }

        public void RealizeMove(Position origin, Position destiny)
        {
            ExecutMoviment(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Colors.White)
            {
                CurrentPlayer = Colors.Black;
            }
            else
            {
                CurrentPlayer = Colors.White;
            }
        }

        private void PutingInitialPieces()
        {
            board.PutPiece(new Rook(Colors.White, board), new ChessPosition('c', 1).ToPosition());
            board.PutPiece(new Rook(Colors.White, board), new ChessPosition('c', 2).ToPosition());
            board.PutPiece(new Rook(Colors.White, board), new ChessPosition('d', 2).ToPosition());
            board.PutPiece(new Rook(Colors.White, board), new ChessPosition('e', 2).ToPosition());
            board.PutPiece(new Rook(Colors.White, board), new ChessPosition('e', 1).ToPosition());
            board.PutPiece(new King(Colors.White, board), new ChessPosition('d', 1).ToPosition());
            
            board.PutPiece(new Rook(Colors.Black, board), new ChessPosition('c', 8).ToPosition());
            board.PutPiece(new Rook(Colors.Black, board), new ChessPosition('c', 7).ToPosition());
            board.PutPiece(new Rook(Colors.Black, board), new ChessPosition('d', 7).ToPosition());
            board.PutPiece(new Rook(Colors.Black, board), new ChessPosition('e', 7).ToPosition());
            board.PutPiece(new Rook(Colors.Black, board), new ChessPosition('e', 8).ToPosition());
            board.PutPiece(new King(Colors.Black, board), new ChessPosition('d', 8).ToPosition());
        }

    }
}
