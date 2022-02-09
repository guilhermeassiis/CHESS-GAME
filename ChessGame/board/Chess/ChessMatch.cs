using ChessGame.board;
using ChessGame.board.Exceptions;

namespace ChessGame.board.Chess
{
    public class ChessMatch
    {
        public Board board { get; private set; } 
        public int turn { get; private set; }
        public Colors currentPayerColor { get; private set; }
        public bool closed { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
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
        public void MakeMove (Position origin, Position destination)
        {
            PerformMoviment(origin, destination);
            turn++;
            ChangePlayer();
        }
        public void ValidateOriginPosition(Position position)
        {
            if(board.ReturnPiece(position) == null)
            {
                throw new BoardException("Don't exists a piece in this location.");
            }
            if(currentPayerColor != board.ReturnPiece(position).color)
            {
                throw new BoardException("The origin piece is not your's. ");
            }
            if(board.ReturnPiece(position).ThereArePossibleMoviments())
            {
                throw new BoardException("There is not possibles moviments in this location.");
            }   
        }
        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            if (!board.ReturnPiece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Destination position is invalid."); 
            }
        }
        private void ChangePlayer()
        {
            
            if (currentPayerColor == Colors.White)
            {
                currentPayerColor = Colors.Black;
            }
            else
            {
                currentPayerColor = Colors.White;
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