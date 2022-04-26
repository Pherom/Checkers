using System;
using Engine;

namespace UI
{
    public class GameCreationForm
    {
        private const string k_NoGameCreatedErrorMessage = "Game was not created yet";
        private Game m_Result = null;

        public Game Result
        {
            get
            {
                if (m_Result == null)
                {
                    throw new Exception(k_NoGameCreatedErrorMessage);
                }

                return m_Result;
            }
        }

        public void Display()
        {
            Player player1 = new PlayerCreationForm().DisplayAndGetResult();
            Player player2;
            Board board = new BoardCreationForm().DisplayAndGetResult();
            Game.eGamemode gamemode = new GamemodeCreationForm().DisplayAndGetResult();

            if (gamemode == Game.eGamemode.SINGLEPLAYER)
            {
                m_Result = new Game(board, player1);
            }
            else if (gamemode == Game.eGamemode.MULTIPLAYER)
            {
                player2 = new PlayerCreationForm().DisplayAndGetResult();
                m_Result = new Game(board, player1, player2);
            }
        }

        public Game DisplayAndGetResult()
        {
            Display();
            return m_Result;
        }
    }
}
