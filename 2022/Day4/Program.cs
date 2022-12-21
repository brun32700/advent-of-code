string sectionAssignmentFilePath = "..\\..\\..\\input.txt";
DataAccess sectionAsignmentFile = new DataAccess(sectionAssignmentFilePath);
var sectionAssignments = sectionAsignmentFile.GetAllLinesFromFile();
var totalSectionAssignmentsFullyContained = 0;
var totalSectionAssignmentsOverlapping = 0;


// Part 1
// First elf: start section - end section, Second elf: start section - end section
foreach (var sectionAssignment in sectionAssignments)
{
    var elfPairAssignments = sectionAssignment.Split(",");
    var elf1Assignments = elfPairAssignments[0].Split("-");
    var elf2Assignments = elfPairAssignments[1].Split("-");

    //Console.WriteLine(elfPairAssignments[0]);
    //Console.WriteLine($"Elf 1 | start section: { elf1Assignments[0] } end section: { elf1Assignments[1] }\n");
    //Console.WriteLine(elfPairAssignments[1]);
    //Console.WriteLine($"Elf 2 | start section: { elf2Assignments[0] } end section: { elf2Assignments[1] }");

    if (int.Parse(elf1Assignments[0]) <= int.Parse(elf2Assignments[0]) && int.Parse(elf1Assignments[1]) >= int.Parse(elf2Assignments[1]))
    {
        // Elf 1 section assignment range contain elf 2 section assignment range?
        totalSectionAssignmentsFullyContained ++;
    }
    else if (int.Parse(elf2Assignments[0]) <= int.Parse(elf1Assignments[0]) && int.Parse(elf2Assignments[1]) >= int.Parse(elf1Assignments[1]))
    {
        // Elf 2 section assignment range contains elf 1 section assignment range
        totalSectionAssignmentsFullyContained++;
    }
}

// Part 2
foreach (var sectionAssignment in sectionAssignments)
{
    var elfPairAssignments = sectionAssignment.Split(",");
    var elf1Assignments = elfPairAssignments[0].Split("-");
    var elf2Assignments = elfPairAssignments[1].Split("-");

    //Console.WriteLine(elfPairAssignments[0]);
    //Console.WriteLine($"Elf 1 | start section: { elf1Assignments[0] } end section: { elf1Assignments[1] }\n");
    //Console.WriteLine(elfPairAssignments[1]);
    //Console.WriteLine($"Elf 2 | start section: { elf2Assignments[0] } end section: { elf2Assignments[1] }");

    // 5-7,7-9
    // ____---__
    // ______---

    // 6-7,5-8
    // _____67__
    // ____5678_

    if (int.Parse(elf1Assignments[0]) <= int.Parse(elf2Assignments[0]) && int.Parse(elf2Assignments[0]) <= int.Parse(elf1Assignments[1]) ||
        int.Parse(elf1Assignments[0]) <= int.Parse(elf2Assignments[1]) && int.Parse(elf2Assignments[1]) <= int.Parse(elf1Assignments[1]))
    {
        // Elf 2 first and last section assignments are between elf 1 first and last section assignments
        totalSectionAssignmentsOverlapping++;
    }
    else if (int.Parse(elf2Assignments[0]) <= int.Parse(elf1Assignments[0]) && int.Parse(elf1Assignments[0]) <= int.Parse(elf2Assignments[1]) ||
             int.Parse(elf2Assignments[0]) <= int.Parse(elf1Assignments[1]) && int.Parse(elf1Assignments[1]) <= int.Parse(elf2Assignments[1]))
    {
        // Elf 1 first and last section assignments are between elf 2 first and last section assignments
        totalSectionAssignmentsOverlapping++;
    }
}

// Part 1 - answer is 511
Console.WriteLine($"Part 1 - total number of section assignments fully contained: {totalSectionAssignmentsFullyContained}");

// Part 2 - answer is 821
Console.WriteLine($"Part 2 - total number of section assignments overlapping: {totalSectionAssignmentsOverlapping}");

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