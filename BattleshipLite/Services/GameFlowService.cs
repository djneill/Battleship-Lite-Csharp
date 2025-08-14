using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleshipLiteLibrary.Logic;
using BattleshipLiteLibrary.Models;
using BattleshipLite.Services;

namespace BattleshipLite.Services
{
    public static class GameFlowService
    {
        public static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            bool isValidShot = false;
            string row = "";
            int column = 0;

            do
            {
                string shot = UserInputService.AskForShot(activePlayer);
                try
                {
                    (row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);
                    isValidShot = GameLogic.ValidateShot(activePlayer, row, column);
                }
                catch (Exception ex)
                {
                    isValidShot = false;
                }

                if (isValidShot == false)
                {
                    Console.WriteLine("Invalid shot location. Please try again.");
                }

            } while (isValidShot == false);
            // ask for a shot ( we ask for b2 2)
            // determine what row and column that is - split it apart
            // determine if that is a valid shot
            // go back to the beginning if not a valid shot

            // determine shot results

            bool isAHit = GameLogic.IdentifyShotResult(opponent, row, column);
            // record results
            GameLogic.MarkShotResult(activePlayer, row, column, isAHit);

            GameDisplayService.DisplayShotResults(row, column, isAHit);
        }


    }
}