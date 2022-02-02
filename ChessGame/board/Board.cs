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
        public void MakeAPiece(Piece p, Position position)
        {
            pieces[position.line, position.column] = p;
            p.position = position;
            
        }
    }
}