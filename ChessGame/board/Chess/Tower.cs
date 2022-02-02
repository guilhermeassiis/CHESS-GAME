using ChessGame.board;
namespace ChessGame.board.Chess
{
    public class Tower : Piece
    {
         public Tower(Colors color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}