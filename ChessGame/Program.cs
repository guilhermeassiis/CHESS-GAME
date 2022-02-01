using ChessGame.board;

namespace ChessGame
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            var b1 = new Board(8, 8);

            Screen.PrintBoardLines(b1);
            Console.ReadLine();
        }
    }
}