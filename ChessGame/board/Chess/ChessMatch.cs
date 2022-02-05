using ChessGame.board;

namespace ChessGame.board.Chess
{
    public class ChessMatch
    {
        public Board board { get; private set; } 
        private int turn;
        private Colors currentPayerColor;
        public bool closed { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 0;
            currentPayerColor = Colors.White;
            closed = false; 
            PutPieces();
        }

        public void PerformMoviment(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            if (p != null)
            {
                p.IncrementNumberOfMoves();
                Piece capturedPiece = board.RemovePiece(destination);
                board.MakeAPiece(p, destination);

            }
            
        }
        private void PutPieces()
        {
            board.MakeAPiece(new Tower(Colors.White, board), new ChessPosition('c', 1).ToPosition());
            board.MakeAPiece(new Tower(Colors.White, board), new ChessPosition('c', 2).ToPosition());
            board.MakeAPiece(new Tower(Colors.White, board), new ChessPosition('d', 2).ToPosition());
            board.MakeAPiece(new Tower(Colors.White, board), new ChessPosition('e', 2).ToPosition());
            board.MakeAPiece(new Tower(Colors.White, board), new ChessPosition('e', 1).ToPosition());
            board.MakeAPiece(new King(Colors.White, board), new ChessPosition('d', 1).ToPosition());

            board.MakeAPiece(new Tower(Colors.Black, board), new ChessPosition('c', 7).ToPosition());
            board.MakeAPiece(new Tower(Colors.Black, board), new ChessPosition('c', 8).ToPosition());
            board.MakeAPiece(new Tower(Colors.Black, board), new ChessPosition('d', 7).ToPosition());
            board.MakeAPiece(new Tower(Colors.Black, board), new ChessPosition('e', 7).ToPosition());
            board.MakeAPiece(new Tower(Colors.Black, board), new ChessPosition('e', 8).ToPosition());
            board.MakeAPiece(new King(Colors.Black, board), new ChessPosition('d', 8).ToPosition());
        }
    }
}