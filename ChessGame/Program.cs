using ChessGame.board;
using ChessGame.board.Chess;

namespace ChessGame
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            var b1 = new Board(8, 8);
            b1.MakeAPiece(new Tower(Colors.Black, b1), new Position(0, 0));
            b1.MakeAPiece(new Tower(Colors.Black, b1), new Position(1, 3));
            b1.MakeAPiece(new King(Colors.Black, b1), new Position(2, 4));

            Screen.PrintBoardLines(b1);
            Console.ReadLine();
        }
    }
}