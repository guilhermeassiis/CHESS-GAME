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
               ChessMatch chessMatch = new ChessMatch();
               
               while (!chessMatch.closed)
               {
                    Console.Clear();
                    Screen.PrintBoardLines(chessMatch.board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.GetChessPosition().ToPosition();
                    Console.Write("Destination: ");
                    Position destination = Screen.GetChessPosition().ToPosition();

                    chessMatch.PerformMoviment(origin, destination);
               }
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