using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class PlayerTurn
    {
        private bool m_Quit = false;
        private int m_StartCol;
        private int m_StartRow;
        private int m_EndCol;
        private int m_EndRow;

        public int StartCol
        {
            get
            {
                return m_StartCol;
            }
        }

        public int StartRow
        {
            get
            {
                return m_StartRow;
            }
        }

        public int EndCol
        {
            get
            {
                return m_EndCol;
            }
        }

        public int EndRow
        {
            get
            {
                return m_EndRow;
            }
        }

        public PlayerTurn(bool i_Quit)
        {
            m_Quit = i_Quit;
        }

        public PlayerTurn(int i_StartRow, int i_StartCol, int i_EndRow, int i_EndCol)
        {
            m_StartRow = i_StartRow;
            m_StartCol = i_StartCol;
            m_EndRow = i_EndRow;
            m_EndCol = i_EndCol;
        }

        public bool IsValid(Game game)
        {
            //Check that CurrentPlayer piece is in starting position
            //Check that if m_RequiredTurns is not empty, the turn is contained within it
            //Check that is within the bounds of the board
            //Check that the end position is empty
            //Check that either moving directly or eating an opponent
            //Check that if not king, is not moving backwards
        }
    }
}
