using System;
using Engine;

namespace UI
{
    public class BoardView
    {
        private readonly Board r_Board;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private const char k_Player1RegularPiece = 'O';
        private const char k_Player1KingPiece = 'U';
        private const char k_Player2RegularPiece = 'X';
        private const char k_Player2KingPiece = 'K';
        private const char k_EmptyPiece = ' ';

        public BoardView(Board i_Board, Player i_Player1, Player i_Player2)
        {
            r_Board = i_Board;
            r_Player1 = i_Player1;
            r_Player2 = i_Player2;
        }

        private char getCharValueAtSpecificLocation(Board.Piece piece)
        {
            char res;
            if (piece.IsEmpty)
            {
                res = k_EmptyPiece;
            } 
            else
            {
                if (piece.Owner == r_Player1)
                {
                    res = piece.IsKing == false ? k_Player1RegularPiece : k_Player1KingPiece;
                }
                else
                {
                    res = piece.IsKing == false ? k_Player2RegularPiece : k_Player2KingPiece;
                }
            }

            return res;
        }

        private void printSeperatingLine()
        {
            for (int col = 0; col < r_Board.Size * 4 + 2; col++)
            {
                Console.Write("=");
            }
        }

        public void DisplayBoard()
        {
            char firstRowVal = 'A';
            char firstColVal = 'a';
            Console.Write(" ");

            for (int row = -1; row < r_Board.Size; row++)
            {
                if (row == -1)
                {
                    for (int col = 0; col < r_Board.Size; col++)
                    {
                        Console.Write(string.Format("  {0} ", firstRowVal));
                        firstRowVal++;
                    }
                    Console.WriteLine();
                } 
                else
                {
                    for (int col = -1; col < r_Board.Size; col++)
                    {
                        if (col == -1)
                        {
                            Console.Write(firstColVal);
                            firstColVal++;
                        } else
                        {
                            Console.Write(string.Format("| {0} ", getCharValueAtSpecificLocation(r_Board.Content[row, col])));
                        }
                    }
                    Console.WriteLine("|");
                }

                printSeperatingLine();
                Console.WriteLine();
            }
        }
    }
}
