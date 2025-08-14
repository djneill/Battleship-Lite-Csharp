using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleshipLiteLibrary.Models;
using BattleshipLiteLibrary.Logic;


namespace BattleshipLite.Services
{
    public class GameDisplayService
    {
        public static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            string currentRow = activePlayer.ShotGrid[0].SpotLetter;
            foreach (var girdSpot in activePlayer.ShotGrid)
            {
                if (girdSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = girdSpot.SpotLetter;
                }
                if (girdSpot.Status == Enums.GridSpotStatus.Empty)
                {
                    Console.Write($" {girdSpot.SpotLetter}{girdSpot.SpotNumber} ");
                }
                else if (girdSpot.Status == Enums.GridSpotStatus.Hit)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" X  ");
                    Console.ResetColor();
                }
                else if (girdSpot.Status == Enums.GridSpotStatus.Miss)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" O  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" ?  ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void DisplayShotResults(string row, int column, bool isAHit)
        {
            if (isAHit)
            {
                Console.WriteLine($"{row}{column} is a hit!");
            }
            else
            {
                Console.WriteLine($"{row}{column} is a miss.");
            }
            Console.WriteLine();
        }

        public static void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Battleship Lite");
            Console.WriteLine("Created by DJ Neill");
            Console.WriteLine();
        }

        public static void IdentifyWinner(PlayerInfoModel winner)
        {
            Console.WriteLine($"Congratulations to {winner.UsersName} for winning!");
            Console.WriteLine(($"{winner.UsersName} took {GameLogic.GetShotCount(winner)} shots."));
        }


    }
}