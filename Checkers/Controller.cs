using UI;
using Engine;

namespace Checkers
{
    internal class Controller
    {
        public void Start()
        {
            Game game = new GameCreationForm().DisplayAndGetResult();
            BoardView boardView = new BoardView(game.Board, game.Player1, game.Player2);
            PlayerTurnForm playerTurnForm = new PlayerTurnForm();
            NewGameRequestForm newGameRequestForm = new NewGameRequestForm();
            PlayerTurn currentPlayerTurn = null;
            bool playerTurnValid = false;
            bool newGameRequested = true;

            while (newGameRequested == true)
            {
                while (game.Status == Game.eGameStatus.RUNNING)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    boardView.DisplayBoard();
                    while (playerTurnValid == false)
                    {
                        if (game.CurrentPlayer.IsHuman == true)
                        {
                            currentPlayerTurn = playerTurnForm.DisplayAndGetResult(game.CurrentPlayer.Name);
                            playerTurnValid = currentPlayerTurn.IsValid(game);
                            if (playerTurnValid == false)
                            {
                                //DISPLAY ERROR
                            }
                        }
                        else
                        {
                            //currentPlayerTurn = PlayerTurn.GenerateRandomValidTurn(game.Board);
                            playerTurnValid = true;
                        }
                    }

                    game.ExecuteTurn(currentPlayerTurn);
                    playerTurnValid = false;
                    playerTurnForm.ResetForm();
                }

                switch (game.Status)
                {
                    case Game.eGameStatus.WON:
                        //DISPLAY WON MESSAGE
                        break;
                    case Game.eGameStatus.QUIT:
                        //DISPLAY QUIT AND WON MESSAGE
                        break;
                    case Game.eGameStatus.DRAW:
                        //DISPLAY DRAW MESSAGE
                        break;
                }

                newGameRequested = newGameRequestForm.DisplayAndGetResult();
            }
        }

    }
}
