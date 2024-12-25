namespace AoC2024.Day1;

internal static class Program
{
    private const string InputPath = "input.txt";

    public static void Main()
    {
        (List<int> lefts, List<int> rights) = ParseInput();

        //Part I - Distance
        //int totalDistance = FindDistances(lefts, rights);
        //Console.WriteLine(totalDistance);

        //Part 2 - Similarities


        /*int totalSimilarities =
            (from left in lefts
                let appearanceCount = rights.Count(o => o == left)
                select left * appearanceCount).Sum();*/
        
        var totalSimilarities = 0;

        foreach (int left in lefts)
        {
            int appearanceCount = rights.Count(o => o == left);
            int similarity = left * appearanceCount;
            totalSimilarities += similarity;
        }

        Console.WriteLine(totalSimilarities);
    }

    private static int FindDistances(List<int> lefts, List<int> rights)
    {
        int count = lefts.Count;

        var totalDistance = 0;
        for (var i = 0; i < count; i++)
        {
            int leftMin = lefts.GetMinAndRemove();
            int rightMin = rights.GetMinAndRemove();
            int distance = int.Abs(leftMin - rightMin);
            totalDistance += distance;
        }

        return totalDistance;
    }

    private static int GetMinAndRemove(this List<int> items)
    {
        var min = int.MaxValue;
        var index = 0;

        for (var i = 0; i < items.Count; i++)
        {
            int value = items[i];
            if (value < min)
            {
                min = value;
                index = i;
            }
        }

        items.RemoveAt(index);

        return min;
    }

    private static (List<int> lefts, List<int> rights) ParseInput()
    {
        var lefts = new List<int>();
        var rights = new List<int>();

        string[] lines = File.ReadAllLines(InputPath);

        foreach (string line in lines)
        {
            string[] columns = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            lefts.Add(int.Parse(columns[0]));
            rights.Add(int.Parse(columns[1]));
        }

        return (lefts, rights);
    }
}