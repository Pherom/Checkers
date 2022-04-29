using System;
using System.Text;
using Engine;

namespace UI
{
    internal class BoardCreationForm
    {
        private const string k_InputIsNotANumberErrorMessage = "You must enter a number";
        private const string k_NoBoardCreatedErrorMessage = "Board was not created yet";
        private int m_Size;
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
            while (m_Result == null)
            {
                try
                {
                    bool validIntEntered;

                    Console.Write(String.Format("Enter board size (available options: {0}): ", string.Join(", ", Board.AvailableBoardSizes.ToArray())));
                    validIntEntered = int.TryParse(Console.ReadLine(), out m_Size);
                    if (validIntEntered == false)
                    {
                        throw new Exception(k_InputIsNotANumberErrorMessage);
                    }

                    m_Result = new Board(m_Size);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Board DisplayAndGetResult()
        {
            Display();
            return m_Result;
        }
    }
}
