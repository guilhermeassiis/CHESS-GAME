using ChessGame.board;
namespace ChessGame
{
    public class Screen
    {
        public static void PrintBoardLines(Board board)
        {
            for (int i=0; i<board.lines; i++)
            {
                for (int j=0; j<board.columns; j++) 
                {
                    if (board.ReturnPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.ReturnPiece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}