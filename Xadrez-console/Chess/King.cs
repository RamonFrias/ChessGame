﻿using Xadrez_console.Board;
using Xadrez_console.Board.Enums;

namespace Xadrez_console.Chess
{
    class King : Piece
    {
        public King(Colors color, BoardClass board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "R";
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

            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Northeast
            pos.DefineValues(Position.Line - 1, Position.Column + 1);

            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // East
            pos.DefineValues(Position.Line, Position.Column + 1);

            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Southeast
            pos.DefineValues(Position.Line + 1, Position.Column + 1);

            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // South
            pos.DefineValues(Position.Line + 1, Position.Column);

            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Southwest
            pos.DefineValues(Position.Line + 1, Position.Column - 1);

            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // West
            pos.DefineValues(Position.Line, Position.Column - 1);

            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Northwest
            pos.DefineValues(Position.Line - 1, Position.Column - 1);

            if (Board.VerifyPosition(pos) && ThisMovimentIsPossible(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
