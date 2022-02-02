using ChessGame.board;
namespace ChessGame.board.Chess
{
    public class King : Piece
    {
        public King(Colors color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}