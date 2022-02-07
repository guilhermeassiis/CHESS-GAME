using ChessGame.board;
using ChessGame.board.Chess;

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
                   PrintPiece(board.ReturnPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintBoardLines(Board board, bool[,] matrix)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;
            
            for (int i=0; i<board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j=0; j<board.columns; j++) 
                {
                    if (matrix[i, j])
                    {
                        Console.BackgroundColor = newBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                   PrintPiece(board.ReturnPiece(i, j));
                   Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static ChessPosition GetChessPosition()
        {
            string position = Console.ReadLine();
            char column = position[0];
            int line = int.Parse(position[1] + "");
            return new ChessPosition(column, line);
            
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
   
}