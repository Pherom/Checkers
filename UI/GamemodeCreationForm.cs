using System;
using Engine;

namespace UI
{
    internal class GamemodeCreationForm
    {
        private const string k_NoGamemodeCreatedErrorMessage = "Gamemode was not created yet";
        private int? m_Input = null;
        private Game.eGamemode? m_Result = null;

        public Game.eGamemode Gamemode
        {
            get
            {
                if (m_Result == null)
                {
                    throw new Exception(k_NoGamemodeCreatedErrorMessage);
                }

                return m_Result.Value;
            }
        }

        public void Display()
        {

        }

        public Game.eGamemode DisplayAndGetResult()
        {
            Display();
            return m_Result.Value;
        }

        private bool checkInputValidity(int i_Input)
        {
            return i_Input == (int)Game.eGamemode.SINGLEPLAYER || i_Input == (int)Game.eGamemode.MULTIPLAYER;
        }
    }
}
