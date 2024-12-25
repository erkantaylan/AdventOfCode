using System.Text.RegularExpressions;

namespace Day3_Mul;

internal static partial class Day3Program
{
    private const string InputPath = "input.txt";

    private static void Main()
    {
        string input = File.ReadAllText(InputPath);

        MatchCollection matches = MatchMulsDosDonts().Matches(input);

        var sum = 0;
        var isDo = true;
        foreach (Match match in matches)
        {
            var value = match.ToString();

            if (value == "do()")
            {
                isDo = true;
            }
            else if (value == "don't()")
            {
                isDo = false;
            }
            else
            {
                if (isDo)
                {
                    (int left, int right) = ParseLeftRight(value);
                    sum += left * right;
                }
            }
        }

        Console.WriteLine(sum);
        //108830766


        //CalculatePart1(matches);
    }


    private static void CalculatePart1(string input)
    {
        MatchCollection matches = MatchMuls().Matches(input);

        var sum = 0;

        foreach (Match match in matches)
        {
            var value = match.ToString();
            (int left, int right) = ParseLeftRight(value);
            sum += left * right;
        }

        Console.WriteLine(sum);
        // 165225049
    }

    private static (int left, int right) ParseLeftRight(string mul)
    {
        string[] clear = mul.Replace("mul(", "").Replace(")", "").Split(',');
        int left = int.Parse(clear[0]);
        int right = int.Parse(clear[1]);
        return (left, right);
    }

    [GeneratedRegex(@"mul\((-?\d+),(-?\d+)\)")]
    private static partial Regex MatchMuls();


    [GeneratedRegex(@"(mul\((-?\d+),(-?\d+)\))|(don't\(\))|(do\(\))")]
    private static partial Regex MatchMulsDosDonts();
}