using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleshipLiteLibrary.Models;

namespace BattleshipLite.Services
{
    public class UserInputService
    {
        public static string AskForUsersName()
        {
            Console.Write("What is your name: ");
            string output = Console.ReadLine();
            return output;
        }

        public static string AskForShot(PlayerInfoModel player)
        {
            Console.Write($"{player.UsersName}, Please enter your shot selection: ");
            string output = Console.ReadLine();
            return output;
        }
    }
}