using System;
using Engine;

namespace UI
{
    internal class GamemodeCreationForm
    {
        private const string k_InvalidOptionEnteredErrorMessage = "You entered an invalid option";
        private const string k_InputIsNotANumberErrorMessage = "You must enter a number";
        private const string k_NoGamemodeCreatedErrorMessage = "Gamemode was not created yet";
        private int m_Input;
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
            while (m_Result == null)
            {
                try
                {
                    bool validIntEntered;
                    Console.WriteLine(string.Format("Enter the number of gamemode you want to play: (1/2){0}1. Singleplayer{0}2. Multiplayer", Environment.NewLine));
                    validIntEntered = int.TryParse(Console.ReadLine(), out m_Input);
                    if (validIntEntered == false)
                    {
                        throw new Exception(k_InputIsNotANumberErrorMessage);
                    }

                    if (checkInputValidity(m_Input) == false)
                    {
                        throw new Exception(k_InvalidOptionEnteredErrorMessage);
                    }

                    m_Result = (Game.eGamemode)m_Input;
                } 
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
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
