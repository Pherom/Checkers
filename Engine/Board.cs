using System;
using System.Collections.Generic;

namespace Engine
{
    public class Board
    {
        public class Piece
        {
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

            public Piece(Player i_Owner, int i_StartingRow, int i_StartingCol)
            {
                m_Owner = i_Owner;
                m_Row = i_StartingRow;
                m_Col = i_StartingCol;
            }

            public void Crown()
            {
                m_IsKing = true;
            }
        }

        private static readonly List<int> sr_AvailableBoardSizes = new List<int>{6, 8, 10};
        private static readonly string sr_InvalidBoardSizeErrorMessage = string.Format("Board size must be one of the following options: {0}", sr_AvailableBoardSizes);
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

        public Board(int i_Size)
        {
            if (checkSizeValidity(i_Size))
            {
                throw new ArgumentException(sr_InvalidBoardSizeErrorMessage);
            }

            m_Size = i_Size;
            m_Content = new Piece[m_Size, m_Size];
        }

        public void PopulateBoard(Player player1, Player player2)
        {
            if (m_IsEmpty == true)
            {
                //POPULATE
                m_IsEmpty = false;
            }
        }

        public void ResetBoard(Player player1, Player player2)
        {
            if (m_IsEmpty == false)
            {
                //RESET
                m_IsEmpty = true;
            }
        }

        private bool checkSizeValidity(int i_Size)
        {
            return sr_AvailableBoardSizes.Contains(i_Size);
        }

    }
}
