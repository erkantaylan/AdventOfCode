using System.Text.RegularExpressions;

namespace Day3_Mul;

internal static partial class Day3Program
{
    private const string InputPath = "input.txt";

    private static void Main()
    {
        string input = File.ReadAllText(InputPath);

        MatchCollection matches = MatchMuls().Matches(input);

        var sum = 0;

        foreach (Match match in matches)
        {
            var value = match.ToString();
            string[] clear = value.Replace("mul(", "").Replace(")", "").Split(',');
            int left = int.Parse(clear[0]);
            int right = int.Parse(clear[1]);
            sum += left * right;
        }

        Console.WriteLine(sum);
        // 165225049
    }

    [GeneratedRegex(@"mul\((-?\d+),(-?\d+)\)")]
    private static partial Regex MatchMuls();
}