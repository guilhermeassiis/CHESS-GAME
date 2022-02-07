namespace ChessGame.board
{
    public abstract class Piece
    {
        public Position position { get; set; }  
        public Colors color { get; protected set; }
        public Board board { get; protected set; }
        public int numberOfMoves { get; protected set; }
        
        public Piece(Colors color, Board board)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            this.numberOfMoves = 0;
        }
        protected bool CanMove(Position position)
        {
            Piece p = board.ReturnPiece(position);
            return p == null || p.color != this.color;
        }
        public void IncrementNumberOfMoves()    
        {
            numberOfMoves++;
        }
        public abstract bool[,] PossibleMovies();
    }
}