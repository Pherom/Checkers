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
            // show who won i_Game.getWinner().name 
            // show points difference: i_Game.getWinner().Score - i_Game.getOpponent(i_Game.getWinner()).Score
            Console.WriteLine("Won");
        }

        public static void DisplayQuitMessage(Game i_Game)
        {
            //Show that i_Game.CurrentPlayer quit
            Console.WriteLine("Quit");
            DisplayWinnerMessage(i_Game);
        }

        public static void DisplayDrawMessage(Game i_Game)
        {
            Console.WriteLine("Draw");
            // Show points of each player i_Game.Player1.Score, I_Game.Player2.Score
        }


    }
}
