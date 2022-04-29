using UI;
using Engine;
using System;
using System.Threading;

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
                            if (currentPlayerTurn.Quit == true)
                            {
                                playerTurnValid = true;
                            }
                            else
                            {
                                playerTurnValid = currentPlayerTurn.IsValidForCurrentPlayer(game);
                                if (playerTurnValid == false)
                                {
                                    UIMessages.DisplayInvalidPlayerTurnEngineErrorMessage();
                                    playerTurnForm.ResetForm();
                                }
                            }
                        }
                        else
                        {
                            currentPlayerTurn = PlayerTurn.GenerateRandomValidTurn(game);
                            Thread.Sleep(3000);
                            playerTurnValid = true;
                        }
                    }

                    game.ExecuteTurn(currentPlayerTurn);
                    playerTurnValid = false;
                    playerTurnForm.ResetForm();
                }

                boardView.DisplayBoard();

                switch (game.Status)
                {
                    case Game.eGameStatus.WON:
                        UIMessages.DisplayWinnerMessage(game);
                        break;
                    case Game.eGameStatus.QUIT:
                        UIMessages.DisplayQuitMessage(game);
                        break;
                    case Game.eGameStatus.DRAW:
                        UIMessages.DisplayDrawMessage(game);
                        break;
                }

                newGameRequested = newGameRequestForm.DisplayAndGetResult();
                game.CheckNewGameRequest(newGameRequested);
            }
        }

    }
}
