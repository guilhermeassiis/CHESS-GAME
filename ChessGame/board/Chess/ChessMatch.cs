using System.Collections.Generic;
using ChessGame.board.Exceptions;

namespace ChessGame.board.Chess
{
    public class ChessMatch
    {
        public Board board { get; private set; } 
        public int turn { get; private set; }
        public Colors currentPayerColor { get; private set; }
        public bool closed { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool xeque { get; private set; }


        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPayerColor = Colors.White;
            closed = false; 
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece PerformMoviment(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.IncrementNumberOfMoves();
            Piece capturedPiece = board.RemovePiece(destination);
            board.MakeAPiece(p, destination);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }
        public void MakeMove (Position origin, Position destination)
        {
            Piece capturedPiece = PerformMoviment(origin, destination);
            
            if (ItsInCheck(currentPayerColor))
            {
                UndoMoviment(origin, destination, capturedPiece);
                throw new BoardException("You cant put yourself in check");
            }
            if (ItsInCheck(AdversaryColor(currentPayerColor)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            turn++;
            ChangePlayer();

        }
        public void UndoMoviment(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = board.RemovePiece(destination);
            p.DecrementNumberOfMoves();
            if (capturedPiece != null)
            {
                board.MakeAPiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            board.MakeAPiece(p, origin);
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
        public HashSet<Piece> CapturedPiecesColor(Colors color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        private Colors AdversaryColor(Colors color)
        {
            if(color == Colors.White)
            {
                return Colors.Black;
            }
            return Colors.White;
        }
        private Piece King(Colors color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }
        public bool ItsInCheck(Colors color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException("The king dont exists.");
            }
            foreach (Piece x in PiecesInGame(AdversaryColor(color)))
            {
                bool[,] matrix = x.PossibleMovies();
                if (matrix[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }
        public HashSet<Piece> PiecesInGame(Colors color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPiecesColor(color));
            return aux;
        }
        public void PutANewPiece(char column, int line, Piece piece)
        {
            board.MakeAPiece(piece, new ChessPosition(column, line).ToPosition());
            pieces.Add(piece);
        }
        private void PutPieces()
        {
            PutANewPiece('c', 1, new Tower(Colors.White, board));
            PutANewPiece('c', 2, new Tower(Colors.White, board));
            PutANewPiece('d', 2, new Tower(Colors.White, board));
            PutANewPiece('e', 1, new Tower(Colors.White, board));
            PutANewPiece('e', 2, new Tower(Colors.White, board));
            PutANewPiece('d', 1, new King(Colors.White, board));

            PutANewPiece('c', 7, new Tower(Colors.Black, board));
            PutANewPiece('c', 8, new Tower(Colors.Black, board));
            PutANewPiece('d', 7, new Tower(Colors.Black, board));
            PutANewPiece('e', 7, new Tower(Colors.Black, board));
            PutANewPiece('e', 8, new Tower(Colors.Black, board));
            PutANewPiece('d', 8, new King(Colors.Black, board));
        }
    }
}