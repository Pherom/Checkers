using System;
using System.Collections.Generic;

namespace Engine
{
    public class Board
    {
        public class Piece
        {
            private bool m_IsEmpty = true;
            private Player m_Owner;
            private bool m_IsKing = false;
            private int m_Row;
            private int m_Col;

            public Player Owner
            {
                get
                {
                    return m_Owner;
                }
            }

            public bool IsKing
            {
                get
                {
                    return m_IsKing;
                }
            }

            public bool IsEmpty
            {
                get
                {
                    return m_IsEmpty;
                }
            }

            public void CopyPiece(Piece piece)
            {
                // No need to copy row and col, because it's changed to the current m_Row, m_Col, so only updating the rest
                m_Owner = piece.Owner;
                m_IsKing = piece.IsKing;
                m_IsEmpty = piece.IsEmpty;
            }

            public void UpdatePiece(Player i_Owner, int i_StartingRow, int i_StartingCol)
            {
                m_Owner = i_Owner;
                m_Row = i_StartingRow;
                m_Col = i_StartingCol;
                m_IsEmpty = false;
            }

            public void Empty()
            {
                m_Owner = null;
                m_IsKing = false;
                m_IsEmpty = true;
            }
            public void Crown()
            {
                m_IsKing = true;
            }
        }

        private static readonly List<int> sr_AvailableBoardSizes = new List<int>{6, 8, 10};
        private static readonly string sr_InvalidBoardSizeErrorMessage = string.Format("Board size must be one of the following options: {0}", string.Join(", ", sr_AvailableBoardSizes));
        private int m_Size;
        private Piece[,] m_Content;
        private bool m_IsEmpty = true;

        public int Size
        {
            get
            {
                return m_Size;
            }
        }

        public Piece[,] Content
        {
            get
            {
                return m_Content;
            }
        }

        public Board(int i_Size)
        {
            if (checkSizeValidity(i_Size) == false)
            {
                throw new ArgumentException(sr_InvalidBoardSizeErrorMessage);
            }

            m_Size = i_Size;
            m_Content = new Piece[m_Size, m_Size];
            initBoard();
        }

        public void initBoard()
        {
            for (int row = 0; row < m_Size; row++)
            {
                for (int col = 0; col < m_Size; col++)
                {
                    m_Content[row, col] = new Piece();
                }
            }
        }

        public void PopulateBoard(Player player1, Player player2)
        {
            if (m_IsEmpty == true)
            {
                int rowsToFill = m_Size / 2 - 1;
                // Player1
                for (int currRow = 0; currRow < rowsToFill; currRow++)
                {
                    for (int currCol = (currRow + 1) % 2; currCol < m_Size; currCol += 2)
                    {
                        m_Content[currRow, currCol].UpdatePiece(player1, currRow, currCol);
                        player1.Pieces.Add(m_Content[currRow, currCol]);
                    }
                }

                // Player2
                for (int currRow = m_Size - 1; currRow >= m_Size - rowsToFill; currRow--)
                {
                    for (int currCol = (currRow + 1) % 2; currCol < m_Size; currCol += 2)
                    {
                        m_Content[currRow, currCol].UpdatePiece(player2, currRow, currCol);
                        player2.Pieces.Add(m_Content[currRow, currCol]);
                    }
                }

                m_IsEmpty = false;
            }
        }

        public void ResetBoard(Player player1, Player player2)
        {
            if (m_IsEmpty == false)
            {
                for (int row = 0; row < m_Size; row++)
                {
                    for (int col = 0; col < m_Size; col++)
                    {
                        m_Content[row, col].Empty();
                    }
                }
                m_IsEmpty = true;
            }
        }

        private bool checkSizeValidity(int i_Size)
        {
            return sr_AvailableBoardSizes.Contains(i_Size);
        }
    }
}
