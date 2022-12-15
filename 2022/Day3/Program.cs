// Each input line is a rucksack.
// Each letter represents an item.
// Rucksack has 2 compartments, items are spread evenly to each compartment.
// Lowercase and uppercase characters are different items.
// Find the item which appears in both compartments, and add priority number.
// Lowercase item types a through z have priorities 1 through 26.
// Uppercase item types A through Z have priorities 27 through 52.

string rucksackFilePath = "..\\..\\..\\input.txt";
DataAccess rucksackFile = new DataAccess(rucksackFilePath);
var rucksacks = rucksackFile.GetAllLinesFromFile();
var totalPriorityValue = 0;
var totalPriorityValueForBadges = 0;

// Part 1
foreach (var rucksack in rucksacks)
{
    int numberOfItems = rucksack.Length;
    var compartment1 = rucksack.Substring(0, (numberOfItems / 2 ));
    var compartment2 = rucksack.Substring((numberOfItems / 2));

    var intersect = compartment1.Intersect(compartment2);

    foreach (var value in intersect)
    {
        int alphabeticalNumber;
        if (char.IsUpper(value))
        {
            // Uppercase item types A through Z have priorities 27 through 52.
            alphabeticalNumber = ((int)value % 32) + 26;
        }
        else
        {
            // Lowercase item types a through z have priorities 1 through 26.
            alphabeticalNumber = ((int)value % 32);
        }
        
        totalPriorityValue += alphabeticalNumber;
    }
}

Console.WriteLine(rucksacks[0]);

// Part 2
for (int i = 0; i < rucksacks.Count(); i+=3)
{
    // Group of 3 elves.
    var rucksack1 = rucksacks[i];
    var rucksack2 = rucksacks[i + 1];
    var rucksack3 = rucksacks[i + 2];

    var intersect1 = rucksack1.Intersect(rucksack2);
    var intersect2 = rucksack2.Intersect(rucksack3);
    var finalIntersect = intersect1.Intersect(intersect2);

    foreach (var value in finalIntersect)
    {
        int alphabeticalNumber;
        if (char.IsUpper(value))
        {
            // Uppercase item types A through Z have priorities 27 through 52.
            alphabeticalNumber = ((int)value % 32) + 26;
        }
        else
        {
            // Lowercase item types a through z have priorities 1 through 26.
            alphabeticalNumber = ((int)value % 32);
        }

        totalPriorityValueForBadges += alphabeticalNumber;
    }
}

// Part 1 - answer is 7878
Console.WriteLine($"The sum of the priorities is: { totalPriorityValue }");

// Part 2 - answer is 2760
Console.WriteLine($"The sum of the priorities for badges is: {totalPriorityValueForBadges}");

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