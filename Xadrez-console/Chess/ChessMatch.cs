using System;
using System.Collections.Generic;
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
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch()
        {
            Board = new BoardClass(8, 8);
            Turn = 1;
            CurrentPlayer = Colors.White;
            Finish = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            PutingInitialPieces();
        }

        public void ExecutMoviment(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementMovimentsQuantity();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PutPiece(piece, destiny);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturedPiece(Colors color)
        {
            HashSet<Piece> auxiliar = new HashSet<Piece>();
            foreach (Piece piece in capturedPieces)
            {
                if (piece.Color == color)
                {
                    auxiliar.Add(piece);
                }
            }
            return auxiliar;
        }

        public HashSet<Piece> PiecesInGame(Colors color)
        {
            HashSet<Piece> auxiliar = new HashSet<Piece>();
            foreach (Piece piece in pieces)
            {
                if (piece.Color == color)
                {
                    auxiliar.Add(piece);
                }
            }
            auxiliar.ExceptWith(CapturedPiece(color));
            return auxiliar;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void PutingInitialPieces()
        {
            PutNewPiece('c', 1, new Rook(Colors.White, Board));
            PutNewPiece('c', 2, new Rook(Colors.White, Board));
            PutNewPiece('d', 2, new Rook(Colors.White, Board));
            PutNewPiece('e', 2, new Rook(Colors.White, Board));
            PutNewPiece('e', 1, new Rook(Colors.White, Board));
            PutNewPiece('d', 1, new King(Colors.White, Board));
            
            PutNewPiece('c', 7, new Rook(Colors.Black, Board));
            PutNewPiece('c', 8, new Rook(Colors.Black, Board));
            PutNewPiece('d', 7, new Rook(Colors.Black, Board));
            PutNewPiece('e', 7, new Rook(Colors.Black, Board));
            PutNewPiece('e', 8, new Rook(Colors.Black, Board));
            PutNewPiece('d', 8, new King(Colors.Black, Board));
        }

    }
}
