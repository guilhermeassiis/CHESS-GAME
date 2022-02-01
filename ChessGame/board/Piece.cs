namespace ChessGame.board
{
    public class Piece
    {
        public Position position { get; set; }  
        public Colors color { get; protected set; }
        public Board board { get; protected set; }
        public int numberOfMoves { get; protected set; }
        
        public Piece(Position position, Colors color, Board board)
        {
            this.position = position;
            this.color = color;
            this.board = board;
            this.numberOfMoves = 0;
        }
    }
}