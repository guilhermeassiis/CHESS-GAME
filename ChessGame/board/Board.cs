namespace ChessGame.board
{
    public class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines,columns];
        }
        public Piece ReturnPiece(int line, int column)
        {
            return pieces[line, column];
        }
    }
}