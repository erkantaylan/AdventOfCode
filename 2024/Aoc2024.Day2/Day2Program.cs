using Core;

namespace Aoc2024.Day2;

internal static class Day2Program
{
    private const string InputPath = "input.txt";

    private static void Main()
    {
        string[] lines = File.ReadAllLines(InputPath);

        var safeCount = 0;

        foreach (string line in lines)
        {
            List<int> numbers = line
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

            if (IsSafe(numbers))
            {
                safeCount++;
            }
        }

        Console.WriteLine($"Safe Count: {safeCount}");
    }

    private static bool IsSafe(List<int> line)
    {
        return line.IsValidSequence();
    }
}