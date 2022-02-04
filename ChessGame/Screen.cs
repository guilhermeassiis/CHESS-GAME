using ChessGame.board;
namespace ChessGame
{
    public class Screen
    {
        public static void PrintBoardLines(Board board)
        {
            for (int i=0; i<board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j=0; j<board.columns; j++) 
                {
                    if (board.ReturnPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.ReturnPiece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintPiece(Piece piece)
        {
            if(piece.color == Colors.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = color;
            }
        }
    }
   
}