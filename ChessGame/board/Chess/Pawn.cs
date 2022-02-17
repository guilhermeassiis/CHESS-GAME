namespace ChessGame.board.Chess
{
    public class Pawn : Piece
    {
        public Pawn(Colors color, Board board) : base(color, board)
        {
        }

        private bool ExistsEnemy(Position position)
        {
            Piece p = board.ReturnPiece(position);
            return p != null && p.color != color;
        }
        private bool Free(Position position)
        {
            return board.ReturnPiece(position) == null;
        }
        public override bool[,] PossibleMovies()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            Position pos = new Position(0, 0);

            if (color == Colors.White)
            {
                pos.DefineValues(position.line - 1, position.column);
                if(board.ValidPosition(pos) && Free(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.DefineValues(position.line - 2, position.column);
                if(board.ValidPosition(pos) && Free(pos) && numberOfMoves == 0)
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.DefineValues(position.line - 1, position.column -1);
                if(board.ValidPosition(pos) && ExistsEnemy(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.DefineValues(position.line - 1, position.column + 1);
                if(board.ValidPosition(pos) && ExistsEnemy(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
            }
            else
            {
                pos.DefineValues(position.line + 1, position.column);
                if(board.ValidPosition(pos) && Free(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.DefineValues(position.line + 2, position.column);
                if(board.ValidPosition(pos) && Free(pos) && numberOfMoves == 0)
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.DefineValues(position.line + 1, position.column + 1);
                if(board.ValidPosition(pos) && ExistsEnemy(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
                pos.DefineValues(position.line + 1, position.column - 1);
                if(board.ValidPosition(pos) && ExistsEnemy(pos))
                {
                    matrix[pos.line, pos.column] = true;
                }
            }
            return matrix;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}