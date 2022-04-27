using System;
using Engine;

namespace UI
{
    public class PlayerTurnForm
    {
        private const char k_QuitChar = 'Q';
        private const string k_InvalidTurnEntered = "Invalid move";
        private const string k_NoTurnCreatedErrorMessage = "Turn was not created yet";
        private string m_Input;
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
            while (m_Result == null)
            {
                try
                {
                    Console.Write(string.Format("{0}'s turn: ", i_PlayerName));
                    m_Input = Console.ReadLine();
                    if (checkInputValidity(m_Input) == false)
                    {
                        throw new Exception(k_InvalidTurnEntered);
                    }

                    if (m_Input.ToUpper().Equals(k_QuitChar))
                    {
                        m_Result = new PlayerTurn(true);
                    } 
                    else
                    {
                        string trimmedInput = m_Input.Trim();
                        int startCol = trimmedInput[0] - 'A';
                        int startRow = trimmedInput[1] - 'a';
                        int endCol = trimmedInput[trimmedInput.Length - 2] - 'A';
                        int endRow = trimmedInput[trimmedInput.Length - 1] - 'a';
                        m_Result = new PlayerTurn(startRow, startCol, endRow, endCol);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ResetForm()
        {
            m_Result = null;
        }

        public PlayerTurn DisplayAndGetResult(string i_PlayerName)
        {
            Display(i_PlayerName);
            return m_Result;
        }

        private bool checkColValidity(char i_Row)
        {
            return (i_Row >= 'A' && i_Row <= 'Z');
        }

        private bool checkRowValidity(char i_Col)
        {
            return (i_Col >= 'a' && i_Col <= 'z');
        }

        private bool checkInputValidity(string i_Input)
        {
            string trimmedInput = m_Input.Trim();
            return i_Input.ToUpper().Equals(k_QuitChar) || 
                 trimmedInput.Length >= 5 && 
                 checkColValidity(trimmedInput[0]) && checkRowValidity(trimmedInput[1]) &&
                 checkColValidity(trimmedInput[trimmedInput.Length - 2]) && checkRowValidity(trimmedInput[trimmedInput.Length - 1]) &&
                 trimmedInput.Substring(2, trimmedInput.Length - 4).Trim().Equals(">");
        }
    }
}
