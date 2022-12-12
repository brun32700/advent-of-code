
// Get input strategies from file
using System.ComponentModel;

string strategyFilePath = "..\\..\\..\\input.txt";
DataAccess strategyFile = new DataAccess(strategyFilePath);
var strategies = strategyFile.GetAllLinesFromFile();
int totalScore = 0;

var letterByPlays = new Dictionary<string, string>()
{
    { "a", "rock" },
    { "b", "paper" },
    { "c", "scissors" },
    { "x", "rock" },
    { "y", "paper" },
    { "z", "scissors" }
};

foreach (var round in strategies)
{
    string[] opponentAndPlayerPicks = round.Split(" ");
    string opponenPick = opponentAndPlayerPicks[0].ToLower();
    string playerPick = opponentAndPlayerPicks[1].ToLower();

    Outcome playerResult = RockPaperScissors.RoundOutcomeForPlayer(playerPick: letterByPlays[playerPick],
                                                                   opponentPick: letterByPlays[opponenPick]);

    if (playerResult != null)
    {
        if (Enum.TryParse<Score>(letterByPlays[playerPick], true, out Score itemPlayed))
        {
            totalScore += RockPaperScissors.CalculateScoreForPlayer(playerResult, itemPlayed);
        }
        else
        {
            break;
        }
    }
    else
    {
        break;
    }
}

// Part 1 - answer is 9241 total score
Console.WriteLine($"Total score is {totalScore} if everything goes according to the strategy guide.");

// Part 2 - 

Console.ReadLine();

public enum Score
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public enum Outcome
{
    Lost = 0,
    Draw = 3,
    Won = 6
}

public static class RockPaperScissors
{
    public static Outcome RoundOutcomeForPlayer(string playerPick, string opponentPick)
    {
        playerPick= playerPick.ToLower();
        opponentPick= opponentPick.ToLower();

        if (playerPick == "rock" && opponentPick == "rock" ||
            playerPick == "paper" && opponentPick == "paper" ||
            playerPick == "scissors" && opponentPick == "scissors")
        {
            return Outcome.Draw;
        }
        else if (playerPick == "rock" && opponentPick == "scissors" ||
                 playerPick == "paper" && opponentPick == "rock" ||
                 playerPick == "scissors" && opponentPick == "paper")
        {
            return Outcome.Won;
        }
        else if (playerPick == "rock" && opponentPick == "paper" ||
                 playerPick == "paper" && opponentPick == "scissors" ||
                 playerPick == "scissors" && opponentPick == "rock")
        {
            return Outcome.Lost;
        }
        else
        {
            throw new InvalidDataException($"Picks included an unknown value ( {playerPick}, { opponentPick } ).\nMust be either rock, paper or scissors.");
        }

    }

    public static int CalculateScoreForPlayer(Outcome result, Score itemPlayed)
    {
        return (int)result + (int)itemPlayed;
    }
}

public class DataAccess
{
    private readonly string _filePath;

    public DataAccess(string filePath)
    {
        _filePath = filePath;
    }

    public List<string?> GetAllLinesFromFile()
    {
        List<string?> lines = new List<string?>();

        using (StreamReader streamReader = new StreamReader(_filePath))
        {
            while (streamReader.Peek() >= 0)
            {
                lines.Add(streamReader.ReadLine());
            }
        }

        return lines;
    }
}