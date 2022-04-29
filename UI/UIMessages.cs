using System;
using Engine;

namespace UI
{
    public class UIMessages
    {

        private const string k_InvalidTurnEntered = "Invalid move";

        public static void DisplayInvalidPlayerTurnEngineErrorMessage()
        {
            Console.WriteLine(k_InvalidTurnEntered);
        }

        public static void DisplayWinnerMessage(Game i_Game)
        {
            Console.WriteLine(string.Format("{0} won!", i_Game.GetWinner().Name));
            displayGameScore(i_Game);
        }

        public static void DisplayQuitMessage(Game i_Game)
        {
            Console.WriteLine(String.Format("{0} quit!", i_Game.CurrentPlayer.Name));
            DisplayWinnerMessage(i_Game);
        }

        public static void DisplayDrawMessage(Game i_Game)
        {
            Console.WriteLine("It's a draw!");
            displayGameScore(i_Game);
        }

        private static void displayGameScore(Game i_Game)
        {
            Console.WriteLine(String.Format("{0}'s score: {1} | {2}'s score: {3}", i_Game.Player1.Name, i_Game.Player1.Score, i_Game.Player2.Name, i_Game.Player2.Score));
        }

    }
}
