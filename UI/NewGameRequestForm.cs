using System;

namespace UI
{
    public class NewGameRequestForm
    {
        private const string k_NoDescisionMadeErrorMessage = "There was no decision";
        private string m_Input = null;
        private bool? m_Result = null;
        public bool Result
        {
            get
            {
                if (m_Result == null)
                {
                    throw new Exception(k_NoDescisionMadeErrorMessage);
                }

                return m_Result.Value;
            }
        }

        public void Display()
        {

        }

        public bool DisplayAndGetResult()
        {
            Display();
            return m_Result.Value;
        }
    }
}
