

using System.Data;
using System.Xml;
using BattleshipLite.Services;
using BattleshipLiteLibrary.Logic;
using BattleshipLiteLibrary.Models;

GameDisplayService.WelcomeMessage();
PlayerInfoModel activePlayer = PlayerSetupService.CreatePlayer("Player 1");
PlayerInfoModel opponent = PlayerSetupService.CreatePlayer("Player 2");
PlayerInfoModel winner = null;

do
{
    // Display grid from activePlayer on where they fired
    GameDisplayService.DisplayShotGrid(activePlayer);

    // Ask activePlayer for a shot 
    // determine if it is a valid shot
    // determine shot results
    GameFlowService.RecordPlayerShot(activePlayer, opponent);

    // determine if the game is over
    bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

    // if over, set activePlayer as the winner 
    // else, swap positions ( activePlayer to opponent)
    if (doesGameContinue == true)
    {
        // swap using a temp variable
        // PlayerInfoModel tempHolder = opponent;
        // opponent = activePlayer;
        // activePlayer = tempHolder;

        // Use Tuple
        (activePlayer, opponent) = (opponent, activePlayer);
    }
    else
    {
        winner = activePlayer;
    }

} while (winner == null);

GameDisplayService.IdentifyWinner(winner);

Console.ReadLine();