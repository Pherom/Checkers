using System;

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

        public bool Quit
        {
            get
            {
                return m_Quit;
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
        
        private bool isInRange(int i_Size)
        {
            return m_StartRow < i_Size && m_StartCol < i_Size && m_EndRow < i_Size && m_EndCol < i_Size;
        }

        private bool checkCurrentPlayerPieceIsInStartingPosition(Game i_Game)
        {
            return i_Game.Board.Content[m_StartRow, m_StartCol].Owner == i_Game.CurrentPlayer;
        }

        private bool checkWhitespaceAtEndPosition(Game i_Game)
        {
            return i_Game.Board.Content[m_EndRow, m_EndCol].IsEmpty;
        }



        public bool IsValid(Game i_Game)
        {
            return isInRange(i_Game.Board.Size) && checkCurrentPlayerPieceIsInStartingPosition(i_Game) &&
                checkWhitespaceAtEndPosition(i_Game);
            //Check that is within the bounds of the board V
            //Check that CurrentPlayer piece is in starting position  V
            //Check that the end position is empty V
            //Check that if m_RequiredTurns is not empty, the turn is contained within it
            //Check that either moving directly or eating an opponent
            //Check that if not king, is not moving backwards
        }

    }
}
