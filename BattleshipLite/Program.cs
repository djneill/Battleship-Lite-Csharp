

using System.Data;
using System.Xml;
using BattleshipLiteLibrary.Logic;
using BattleshipLiteLibrary.Models;

WelcomeMessage();
PlayerInfoModel activePlayer = CreatePlayer("Player 1");
PlayerInfoModel opponent = CreatePlayer("Player 2");
PlayerInfoModel winner = null;

do
{
    // Display grid from activePlayer on where they fired
    DisplayShotGrid(activePlayer);

    // Ask activePlayer for a shot 
    // determine if it is a valid shot
    // determine shot results
    RecordPlayerShot(activePlayer, opponent);

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

IdentifyWinner(winner);

void IdentifyWinner(PlayerInfoModel winner)
{
    Console.WriteLine($"Congratulations to {winner.UsersName} for winning!");
    Console.WriteLine(($"{winner.UsersName} took {GameLogic.GetShotCount(winner)} shots."));
}

Console.ReadLine();

void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
{
    bool isValidShot = false;
    string row = "";
    int column = 0;

    do
    {
        string shot = AskForShot(activePlayer);
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

    DisplayShotResults(row, column, isAHit);
}

void DisplayShotResults(string row, int column, bool isAHit)
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

string AskForShot(PlayerInfoModel player)
{
    Console.Write($"{player.UsersName}, Please enter your shot selection: ");
    string output = Console.ReadLine();
    return output;
}

void DisplayShotGrid(PlayerInfoModel activePlayer)
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
            Console.Write(" X  ");
        }
        else if (girdSpot.Status == Enums.GridSpotStatus.Miss)
        {
            Console.Write(" O  ");
        }
        else
        {
            Console.Write(" ?  ");
        }
    }
    Console.WriteLine();
    Console.WriteLine();
}

Console.ReadLine();



static void WelcomeMessage()
{
    Console.Clear();
    Console.WriteLine("Welcome to Battleship Lite");
    Console.WriteLine("Created by DJ Neill");
    Console.WriteLine();
}

static PlayerInfoModel CreatePlayer(string playerTitle)
{
    PlayerInfoModel output = new PlayerInfoModel();

    Console.WriteLine($"Player information for {playerTitle}");
    // ask the user for their name
    output.UsersName = AskForUsersName();
    // load up the shot grid
    GameLogic.InitializeGrid(output);
    // ask the user for their 5 ship placements
    PlaceShips(output);
    // clear
    Console.Clear();

    return output;
}

static string AskForUsersName()
{
    Console.Write("What is your name: ");
    string output = Console.ReadLine();
    return output;
}

static void PlaceShips(PlayerInfoModel model)
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