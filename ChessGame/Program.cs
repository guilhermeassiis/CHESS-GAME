using ChessGame.board;
using ChessGame.board.Chess;
using ChessGame.board.Exceptions;

namespace ChessGame
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
               var chessBoard = new Board(8, 8);
                chessBoard.MakeAPiece(new Tower(Colors.Black, chessBoard), new Position(0, 0));
                chessBoard.MakeAPiece(new Tower(Colors.White, chessBoard), new Position(1, 3));
                chessBoard.MakeAPiece(new King(Colors.Black, chessBoard), new Position(2, 4));
                Screen.PrintBoardLines(chessBoard);
            }
             catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
            // ChessPosition chessPosition = new ChessPosition('a', 1);
            // System.Console.WriteLine(chessPosition);
            // System.Console.WriteLine(chessPosition.ToPosition());

            // Console.ReadKey();

        }
    }
}