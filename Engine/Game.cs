using System;
using System.Collections.Generic;

namespace Engine
{
    public class Game
    {
        public enum eGamemode
        {
            SINGLEPLAYER = 1,
            MULTIPLAYER
        }

        public enum eGameStatus
        {
            RUNNING,
            QUIT,
            WON,
            DRAW
        }

        private const string k_NoDeterminedWinnerErrorMessage = "There is no determined winner yet";
        private readonly eGamemode m_Gamemode;
        private eGameStatus m_Status = eGameStatus.RUNNING;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrPlayer;
        private Player m_Winner = null;
        private Board m_Board;
        private List<PlayerTurn> requiredTurns = new List<PlayerTurn>();

        public eGamemode Gamemode
        {
            get
            {
                return m_Gamemode;
            }
        }

        public Player Player1
        {
            get
            {
                return m_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrPlayer;
            }
        }

        public eGameStatus Status
        {
            get
            {
                return m_Status;
            }
        }

        public Player Winner
        {
            get
            {
                if (m_Winner == null)
                {
                    throw new Exception(k_NoDeterminedWinnerErrorMessage);
                }
                return m_Winner;
            }
        }

        public Game(Board i_Board, Player i_Player1)
        {
            m_Board = i_Board;
            m_Player1 = i_Player1;
            m_Player2 = new Player("Computer", false);
            m_Gamemode = eGamemode.SINGLEPLAYER;
            m_CurrPlayer = m_Player1;
            m_Board.PopulateBoard(m_Player1, m_Player2);
        }

        public Game(Board i_Board, Player i_Player1, Player i_Player2)
        {
            m_Board = i_Board;
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            m_Gamemode = eGamemode.MULTIPLAYER;
            m_CurrPlayer = m_Player1;
            m_Board.PopulateBoard(m_Player1, m_Player2);
        }

        public void ExecuteTurn(PlayerTurn i_Turn)
        {
            if (i_Turn.Quit == true)
            {
                m_Status = eGameStatus.QUIT;
            } 
            else
            {
                // execute turn
                Board.Content[i_Turn.EndRow, i_Turn.EndCol].CopyPiece(Board.Content[i_Turn.StartRow, i_Turn.StartCol]);
                CurrentPlayer.Pieces.Remove(Board.Content[i_Turn.StartRow, i_Turn.StartCol]);
                CurrentPlayer.Pieces.Add(Board.Content[i_Turn.EndRow, i_Turn.EndCol]);
                Board.Content[i_Turn.StartRow, i_Turn.StartCol].Empty(); // Setting whitespace in startPos


                // if didnt eat
                if (m_Status == eGameStatus.RUNNING)
                {
                    switchTurn();
                }
            }
        }

        private void switchTurn()
        {
            m_CurrPlayer = m_CurrPlayer == m_Player1 ? m_Player2 : m_Player1;
        }

        private void checkAndUpdateGameStatus()
        {

        }

    }
}
