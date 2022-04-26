using System;
using Engine;

namespace UI
{
    public class BoardView
    {
        private Board m_Board;
        private const char k_Player1RegularPiece = 'O';
        private const char k_Player1KingPiece = 'U';
        private const char k_Player2RegularPiece = 'X';
        private const char k_Player2KingPiece = 'K';
        public BoardView(Board i_Board)
        {
            m_Board = i_Board;
        }

        public void DisplayBoard()
        {

        }
    }
}
