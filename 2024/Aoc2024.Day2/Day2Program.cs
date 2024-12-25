using Core;

namespace Aoc2024.Day2;

internal static class Day2Program
{
    private const string InputPath = "input.txt";

    private static void Main()
    {
        string[] lines = File.ReadAllLines(InputPath);

        //Part I
        int safeCount = CalculateSafeReports(lines);
        Console.WriteLine($"Safe Count: {safeCount}");

        //Part II
        int safeEnoughCount = CalculateSafeEnoughReports(lines);
        Console.WriteLine($"Safe Enough Count: {safeEnoughCount}");
    }

    private static int CalculateSafeEnoughReports(string[] lines)
    {
        var safeCount = 0;

        foreach (string line in lines)
        {
            List<int> numbers = line
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

            if (IsSafeEnough(numbers))
            {
                safeCount++;
            }
        }

        return safeCount;
    }

    private static int CalculateSafeReports(string[] lines)
    {
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

        return safeCount;
    }

    private static bool IsSafe(List<int> line)
    {
        return line.IsValidSequence();
    }

    private static bool IsSafeEnough(List<int> line)
    {
        return line
               .Select((t, i) => line.Where((_, index) => index != i).ToList())
               .Any(IsSafe);
    }
}