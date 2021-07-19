using System;
using Xadrez_console.Board;
using Xadrez_console.Board.Enums;

namespace Xadrez_console.Chess
{
    class ChessMatch
    {
        public BoardClass board { get; private set; }
        private int turn;
        private Colors currentPlayer;

        public ChessMatch()
        {
            board = new BoardClass(8, 8);
            turn = 1;
            currentPlayer = Colors.White;
            PutingInitialPieces();
        }

        public void ExecutMoviment(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.IncrementMovimentsQuantity();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PutPiece(piece, destiny);
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
