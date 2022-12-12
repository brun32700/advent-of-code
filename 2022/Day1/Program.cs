
string caloriesFilePath = "..\\..\\..\\input.txt";
DataAccess caloriesFile = new DataAccess(caloriesFilePath);
var calories = caloriesFile.GetAllLinesFromFile();

// Key: Elf number, Value: Total Calories Carrying
var elfNumberByCaloriesCarrying = new Dictionary<int, int>();

int currentElf = 1;
int totalCalories = 0;

foreach (string? calorie in calories)
{
    // If int add to current total
    if (string.IsNullOrEmpty(calorie))
    {
        elfNumberByCaloriesCarrying.Add(currentElf, totalCalories);

        currentElf += 1;
        totalCalories = 0;
    }
    else
    {
        bool CalorieIsInt = int.TryParse(calorie, out int calorieAsInt);
        if (CalorieIsInt)
        {
            totalCalories += calorieAsInt;
        }
    }
}

// Part 1 - answer is 69310 calories
var maxCalorie = elfNumberByCaloriesCarrying.Values.Max();
Console.WriteLine($"Most carried calories by one elf is: {maxCalorie} ");

// Part 2 - answer is 206104 calories
var topThreeTotalCalories = elfNumberByCaloriesCarrying.OrderByDescending(elfByCalorie => elfByCalorie.Value).Take(3);
var topThreeElftotalCalories = topThreeTotalCalories.Sum(elfByCalorie => elfByCalorie.Value);
Console.WriteLine($"Total carried calories by the top three elves is: {topThreeElftotalCalories} ");

Console.ReadLine();

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