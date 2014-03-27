using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareProblemVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[,] { {0, 0, 0, 0, 0, 0 },
                                        {0, 1, 1, 1, 2, 1 },
                                        {0, 0, 1, 2, 1, 0 },
                                        {0, 2, 2, 1, 1, 2 },
                                        {0, 2, 0, 0, 1, 0 },
                                        {2, 0, 0, 0, 1, 1 },
                                     };

            int n = 6;
           
            // Piece result = GetBoardState(board, n, 3, 2);
            // Piece result = GetBoardState(board, n, 1, 1);
            // Piece result = GetBoardState(board, n, 5, 4);
            // Piece result = GetBoardState(board, n, 1, 3);
            // Piece result = GetBoardState(board, n, 3, 4);
            Piece result = GetBoardState(board, n, 3, 2);

            Console.WriteLine("Result is {0}", result.ToString());
        }

        enum Piece
        {
            Empty,
            Player1,
            Player2
        };


        static Piece GetBoardState(int[,] board, int n, int row, int column)
        {
           // Row check
           int countRow = 0;
           int countValuesOnRightSideOfRow = 0;

           Piece currentPiece = (Piece)board[row, column];

           for (int i = column; i < n - 1; i++)
           {
               if ((board[row, i] != (int)Piece.Empty) &&
                   (board[row, i] == board[row, i + 1]))
               {
                   countValuesOnRightSideOfRow++;
               }
               else
               {
                   break;
               }
           }

           if (countValuesOnRightSideOfRow + 1 == n - 1)
           {
               return (Piece)board[row, column];
           }

           int countValuesOnLeftSideOfRow = 0;

           for (int i = column; i >= 1; i--)
           {
               if ((board[row, i] != (int)Piece.Empty) && 
                   (board[row, i] == board[row, i - 1]))
               {
                   countValuesOnLeftSideOfRow++;
               }
               else
               {
                   break;
               }
           }

           if (countValuesOnRightSideOfRow + countValuesOnLeftSideOfRow + 1 == n - 1)
           {
               return (Piece)board[row, column];
           }

           // Column check

           int countValuesBottomPartColumn = 0;

           for (int i = row; i < n - 1; i++)
           {
               if ((board[i, column] != (int)Piece.Empty) && (board[i, column] == board[i + 1, column]))
               {
                   countValuesBottomPartColumn++;
               }
               else
               {
                   break;
               }
           }

           if (countValuesBottomPartColumn + 1 == n - 1)
           {
               return currentPiece;
           }

           int countValuesTopPartColumn = 0;
          
           for (int i = row; i >= 1; i--)
           {
               if ((board[i, column] != (int)Piece.Empty) && (board[i, column] == board[i - 1, column]))
               {
                   countValuesTopPartColumn++;
               }
               else
               {
                   break;
               }
           }

           if (countValuesBottomPartColumn + countValuesTopPartColumn + 1 == n - 1)
           {
               return (Piece)board[row, column];
           }


           if (row == column)
           {
               // Check diagonal1
               int countFirstHalfOfDiagonal1 = 0;

               for (int p = row, q = column; p < n - 1 && q < n - 1; p++, q++)
               {
                   if (board[p, q] != (int)Piece.Empty && board[p, q] == board[p + 1, q + 1])
                   {
                       countFirstHalfOfDiagonal1++;
                   }
                   else
                   {
                       break;
                   }
               }

               if (countFirstHalfOfDiagonal1 + 1 == n - 1)
               {
                   return currentPiece;
               }

               int countSecondHalfOfDiagonal1 = 0;
               for (int p = row, q = column; p >= 1 && q >= 1; p--, q--)
               {
                   if (board[p, q] != (int)Piece.Empty && board[p, q] ==  board[p - 1, q - 1])
                   {
                       countSecondHalfOfDiagonal1++;
                   }
                   else
                   {
                       break;
                   }
               }

               if (countFirstHalfOfDiagonal1 + countSecondHalfOfDiagonal1 + 1 == n - 1)
               {
                   return (Piece)board[row, column];
               }

           }


            if (row + column == n - 1)
            {
               // Check diagonal2

                int countFirstHalfDiagonal2 = 0;

                for (int p = row, q = column; p < n - 1 && q >= 1; p++, q--)
                {
                    if (board[p, q] != (int)Piece.Empty && board[p, q] == board[p + 1, q - 1])
                    {
                        countFirstHalfDiagonal2++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (countFirstHalfDiagonal2 + 1 == n - 1)
                {
                    return (Piece)board[row, column];
                }

                int countSecondHalfDiagonal2 = 0;

                for (int p = row, q = column; p >= 1 && q < n - 1; p--, q++)
                {
                    if (board[p, q] != (int)Piece.Empty && board[p, q] == board[p - 1, q + 1])
                    {
                        countSecondHalfDiagonal2++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (countFirstHalfDiagonal2 + countSecondHalfDiagonal2 + 1 == n - 1)
                {
                    return currentPiece;
                }

            }    

            return Piece.Empty; 
        }

    }
}
