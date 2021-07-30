﻿using Xadrez_console.Board;
using Xadrez_console.Board.Enums;

namespace Xadrez_console.Chess
{
    class Queen : Piece
    {
        public Queen(Colors color, BoardClass board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "Q";
        }

        private bool ThisMovimentIsPossible(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            // North
            pos.DefineValues(Position.Line - 1, Position.Column);
            while (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column);
            }

            // South
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column);
            }

            // East
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line, pos.Column + 1);
            }

            // West
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line, pos.Column - 1);
            }

            // Northeast
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            while (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column + 1);
            }

            // Southeast
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            while (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column + 1);
            }

            // Southwest
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            while (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column - 1);
            }

            // Northwest
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            while (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column - 1);
            }

            return mat;
        }
    }
}
