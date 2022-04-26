using System;
using Engine;

namespace UI
{
    internal class PlayerCreationForm
    {
        private const string k_NoPlayerCreatedErrorMessage = "Player was not created yet";
        private string m_PlayerName = null;
        private Player m_Result = null;

        public Player Result
        {
            get
            {
                if (m_Result == null)
                {
                    throw new Exception(k_NoPlayerCreatedErrorMessage);
                }

                return m_Result;
            }
        }

        public void Display()
        {

        }

        public Player DisplayAndGetResult()
        {
            Display();
            return m_Result;
        }
    }
}
