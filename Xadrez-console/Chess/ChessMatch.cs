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
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new BoardClass(8, 8);
            Turn = 1;
            CurrentPlayer = Colors.White;
            Finish = false;
            Check = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            PutingInitialPieces();
        }

        public Piece ExecutMoviment(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementMovimentsQuantity();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PutPiece(piece, destiny);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }

            // Especial move small roque
            if (piece is King && destiny.Column == origin.Column + 2)
            {
                Position RookOrigin = new Position(origin.Line, origin.Column + 3);
                Position RookDestiny = new Position(origin.Line, origin.Column + 1);
                Piece rook = Board.RemovePiece(RookOrigin);
                rook.IncrementMovimentsQuantity();
                Board.PutPiece(rook, RookDestiny);
            }
            
            // Especial move big roque
            if (piece is King && destiny.Column == origin.Column - 2)
            {
                Position RookOrigin = new Position(origin.Line, origin.Column - 4);
                Position RookDestiny = new Position(origin.Line, origin.Column - 1);
                Piece rook = Board.RemovePiece(RookOrigin);
                rook.IncrementMovimentsQuantity();
                Board.PutPiece(rook, RookDestiny);
            }

            return capturedPiece;
        }

        public void RealizeMove(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecutMoviment(origin, destiny);
            if (IsInCheck(CurrentPlayer))
            {
                UndoMoviment(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check");
            }
            if (IsInCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (TestCheckmate(Opponent(CurrentPlayer)))
            {
                Finish = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
        }

        public void UndoMoviment(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destiny);
            piece.DecrementMovimentsQuantity();
            if (capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, destiny);
                capturedPieces.Remove(capturedPiece);
            }
            Board.PutPiece(piece, origin);

            // Especial move small roque
            if (piece is King && destiny.Column == origin.Column + 2)
            {
                Position RookOrigin = new Position(origin.Line, origin.Column + 3);
                Position RookDestiny = new Position(origin.Line, origin.Column + 1);
                Piece rook = Board.RemovePiece(RookDestiny);
                rook.DecrementMovimentsQuantity();
                Board.PutPiece(rook, RookOrigin);
            }

            // Especial move big roque
            if (piece is King && destiny.Column == origin.Column - 2)
            {
                Position RookOrigin = new Position(origin.Line, origin.Column - 4);
                Position RookDestiny = new Position(origin.Line, origin.Column - 1);
                Piece rook = Board.RemovePiece(RookDestiny);
                rook.DecrementMovimentsQuantity();
                Board.PutPiece(rook, RookOrigin);
            }
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

        private Piece King(Colors color)
        {
            foreach (Piece piece in PiecesInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Colors color)
        {
            Piece king = King(color);
            if (king == null)
            {
                throw new BoardException($"Don't have {color} king in the board!");
            }
            foreach (Piece piece in PiecesInGame(Opponent(color)))
            {
                bool[,] mat = piece.PossibleMoviments();
                if (mat[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestCheckmate(Colors color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (Piece piece in PiecesInGame(color))
            {
                bool[,] mat = piece.PossibleMoviments();

                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = piece.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecutMoviment(origin, destiny);
                            bool testCheck = IsInCheck(color);
                            UndoMoviment(origin, destiny, capturedPiece);

                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private Colors Opponent(Colors color)
        {
            if (color == Colors.White)
            {
                return Colors.Black;
            }
            else
            {
                return Colors.White;
            }
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void PutingInitialPieces()
        {
            PutNewPiece('a', 1, new Rook(Colors.White, Board));
            PutNewPiece('b', 1, new Horse(Colors.White, Board));
            PutNewPiece('c', 1, new Bishop(Colors.White, Board));
            PutNewPiece('d', 1, new Queen(Colors.White, Board));
            PutNewPiece('e', 1, new King(Colors.White, Board, this));
            PutNewPiece('f', 1, new Bishop(Colors.White, Board));
            PutNewPiece('g', 1, new Horse(Colors.White, Board));
            PutNewPiece('h', 1, new Rook(Colors.White, Board));
            PutNewPiece('a', 2, new Pawn(Colors.White, Board));
            PutNewPiece('b', 2, new Pawn(Colors.White, Board));
            PutNewPiece('c', 2, new Pawn(Colors.White, Board));
            PutNewPiece('d', 2, new Pawn(Colors.White, Board));
            PutNewPiece('e', 2, new Pawn(Colors.White, Board));
            PutNewPiece('f', 2, new Pawn(Colors.White, Board));
            PutNewPiece('g', 2, new Pawn(Colors.White, Board));
            PutNewPiece('h', 2, new Pawn(Colors.White, Board));
            
            PutNewPiece('a', 8, new Rook(Colors.Black, Board));
            PutNewPiece('b', 8, new Horse(Colors.Black, Board));
            PutNewPiece('c', 8, new Bishop(Colors.Black, Board));
            PutNewPiece('d', 8, new Queen(Colors.Black, Board));
            PutNewPiece('e', 8, new King(Colors.Black, Board, this));
            PutNewPiece('f', 8, new Bishop(Colors.Black, Board));
            PutNewPiece('g', 8, new Horse(Colors.Black, Board));
            PutNewPiece('h', 8, new Rook(Colors.Black, Board));
            PutNewPiece('a', 7, new Pawn(Colors.Black, Board));
            PutNewPiece('b', 7, new Pawn(Colors.Black, Board));
            PutNewPiece('c', 7, new Pawn(Colors.Black, Board));
            PutNewPiece('d', 7, new Pawn(Colors.Black, Board));
            PutNewPiece('e', 7, new Pawn(Colors.Black, Board));
            PutNewPiece('f', 7, new Pawn(Colors.Black, Board));
            PutNewPiece('g', 7, new Pawn(Colors.Black, Board));
            PutNewPiece('h', 7, new Pawn(Colors.Black, Board));
        }

    }
}
