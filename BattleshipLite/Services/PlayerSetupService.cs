using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleshipLiteLibrary.Logic;
using BattleshipLiteLibrary.Models;

namespace BattleshipLite.Services
{
    public class PlayerSetupService
    {
        public static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();

            Console.WriteLine($"Player information for {playerTitle}");
            // ask the user for their name
            output.UsersName = UserInputService.AskForUsersName();
            // load up the shot grid
            GameLogic.InitializeGrid(output);
            // ask the user for their 5 ship placements
            PlaceShips(output);
            // clear
            Console.Clear();

            return output;
        }



        public static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.Write($"Where do you want to place ship {model.ShipLocation.Count + 1}: ");
                string location = Console.ReadLine();

                bool isValidLocation = false;

                try
                {
                    isValidLocation = GameLogic.PlaceShip(model, location);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location. Please try again.");
                }
            } while (model.ShipLocation.Count < 5);
        }
    }
}