using System;
using Engine;

namespace UI
{
    public class PlayerTurnForm
    {
        private const char k_QuitChar = 'Q';
        private const string k_NoTurnCreatedErrorMessage = "Turn was not created yet";
        private string m_Input = null;
        private PlayerTurn m_Result = null;
        public PlayerTurn Result
        {
            get
            {
                if (m_Result == null)
                {
                    throw new Exception(k_NoTurnCreatedErrorMessage);
                }

                return m_Result;
            }
        }

        public void Display(string i_PlayerName)
        {

        }
        public PlayerTurn DisplayAndGetResult(string i_PlayerName)
        {
            Display(i_PlayerName);
            return m_Result;
        }

        private bool checkInputValidity(string i_Input)
        {

        }
    }
}
