using System;
using Engine;

namespace UI
{
    internal class BoardCreationForm
    {
        private const string k_NoBoardCreatedErrorMessage = "Board was not created yet";
        private int? m_Size = null;
        private Board m_Result = null;
        public Board Result
        {
            get
            {
                if (m_Result == null)
                {
                    throw new Exception(k_NoBoardCreatedErrorMessage);
                }

                return m_Result;
            }
        }

        public void Display()
        {

        }

        public Board DisplayAndGetResult()
        {
            Display();
            return m_Result;
        }
    }
}
