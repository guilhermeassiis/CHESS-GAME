using ChessGame.board;
namespace ChessGame.board.Chess
{
    public class King : Piece
    {
        public King(Colors color, Board board) : base(color, board)
        {
        }

        public override bool[,] PossibleMovies()
        {
            bool[,] matrix = new bool[board.lines, board.columns];
            // Only instance one position
            Position pos = new Position(0, 0);
            // Above
            pos.DefineValues(position.line - 1, position.column);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            // North east
            pos.DefineValues(position.line - 1, position.column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            // Rigth
            pos.DefineValues(position.line, position.column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            // South east
            pos.DefineValues(position.line + 1, position.column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            // Down 
            pos.DefineValues(position.line + 1, position.column);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            // South west
            pos.DefineValues(position.line + 1, position.column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            // Left
            pos.DefineValues(position.line, position.column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            // North West
            pos.DefineValues(position.line - 1, position.column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.line, pos.column] = true;
            }
            return matrix;


        }

        public override string ToString()
        {
            return "R";
        }
    }
}