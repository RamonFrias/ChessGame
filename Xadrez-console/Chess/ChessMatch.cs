using System;
using Xadrez_console.Board;
using Xadrez_console.Board.Enums;
using Xadrez_console.Exceptions;

namespace Xadrez_console.Chess
{
    class ChessMatch
    {
        public BoardClass Board { get; private set; }
        public int Turn { get; private set; }
        public Colors CurrentPlayer { get; private set; }
        public bool Finish { get; private set; }

        public ChessMatch()
        {
            Board = new BoardClass(8, 8);
            Turn = 1;
            CurrentPlayer = Colors.White;
            Finish = false;
            PutingInitialPieces();
        }

        public void ExecutMoviment(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementMovimentsQuantity();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PutPiece(piece, destiny);
        }

        public void RealizeMove(Position origin, Position destiny)
        {
            ExecutMoviment(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidOriginPosition(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("Not exist piece in the origin position!");
            }
            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("The origin piece chosen for you it's not yours!");
            }
            if (!Board.Piece(position).ExistPossibleMoviments())
            {
                throw new BoardException("Don't have possible moviments for the origin piece chosed!");
            }
        }

        public void ValidDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
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
            Board.PutPiece(new Rook(Colors.White, Board), new ChessPosition('c', 1).ToPosition());
            Board.PutPiece(new Rook(Colors.White, Board), new ChessPosition('c', 2).ToPosition());
            Board.PutPiece(new Rook(Colors.White, Board), new ChessPosition('d', 2).ToPosition());
            Board.PutPiece(new Rook(Colors.White, Board), new ChessPosition('e', 2).ToPosition());
            Board.PutPiece(new Rook(Colors.White, Board), new ChessPosition('e', 1).ToPosition());
            Board.PutPiece(new King(Colors.White, Board), new ChessPosition('d', 1).ToPosition());

            Board.PutPiece(new Rook(Colors.Black, Board), new ChessPosition('c', 8).ToPosition());
            Board.PutPiece(new Rook(Colors.Black, Board), new ChessPosition('c', 7).ToPosition());
            Board.PutPiece(new Rook(Colors.Black, Board), new ChessPosition('d', 7).ToPosition());
            Board.PutPiece(new Rook(Colors.Black, Board), new ChessPosition('e', 7).ToPosition());
            Board.PutPiece(new Rook(Colors.Black, Board), new ChessPosition('e', 8).ToPosition());
            Board.PutPiece(new King(Colors.Black, Board), new ChessPosition('d', 8).ToPosition());
        }

    }
}
