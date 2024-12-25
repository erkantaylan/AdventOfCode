namespace Core;

public static class SequenceChecker
{
    
    /// <summary>
    /// Checks if a sequence of numbers is strictly increasing or decreasing with differences between specified bounds.
    /// </summary>
    /// <typeparam name="T">The numeric type of the sequence elements.</typeparam>
    /// <param name="numbers">The sequence to check.</param>
    /// <param name="minDifference">The minimum allowed absolute difference between consecutive elements (default: 1).</param>
    /// <param name="maxDifference">The maximum allowed absolute difference between consecutive elements (default: 3).</param>
    /// <returns>
    /// true if:
    /// - The sequence is empty or has a single element
    /// - The sequence is strictly increasing or decreasing
    /// - All consecutive elements have absolute differences between minDifference and maxDifference (inclusive)
    /// false otherwise
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when:
    /// - minDifference is greater than maxDifference
    /// - minDifference is negative
    /// </exception>
    /// <remarks>
    /// The sequence must maintain its direction (either increasing or decreasing) throughout all elements.
    /// The direction is determined by the first two elements.
    /// </remarks>
    /// <example>
    /// <code>
    /// var sequence1 = new[] { 1, 3, 5, 7 };
    /// bool result1 = sequence1.IsValidSequence();     // returns true
    /// 
    /// var sequence2 = new[] { 10, 8, 6, 4 };
    /// bool result2 = sequence2.IsValidSequence();     // returns true
    /// 
    /// var sequence3 = new[] { 1, 5, 6, 8 };
    /// bool result3 = sequence3.IsValidSequence();     // returns false (first difference > 3)
    /// </code>
    /// </example>
    public static bool IsValidSequence<T>(
        this IEnumerable<T> numbers,
        double minDifference = 1,
        double maxDifference = 3) where T : IConvertible
    {
        if (minDifference > maxDifference)
        {
            throw new ArgumentException("Minimum difference cannot be greater than maximum difference");
        }

        if (minDifference < 0)
        {
            throw new ArgumentException("Minimum difference cannot be negative");
        }

        using IEnumerator<T> enumerator = numbers.GetEnumerator();

        if (!enumerator.MoveNext())
        {
            return true;
        }

        var first = Convert.ToDouble(enumerator.Current);
        if (!enumerator.MoveNext())
        {
            return true;
        }

        var second = Convert.ToDouble(enumerator.Current);
        double diff = Math.Abs(second - first);

        if (diff < minDifference || diff > maxDifference)
        {
            return false;
        }

        bool isIncreasing = second > first;
        first = second;

        while (enumerator.MoveNext())
        {
            second = Convert.ToDouble(enumerator.Current);
            diff = Math.Abs(second - first);

            if (diff < minDifference || diff > maxDifference)
            {
                return false;
            }

            if (isIncreasing && second <= first)
            {
                return false;
            }

            if (!isIncreasing && second >= first)
            {
                return false;
            }

            first = second;
        }

        return true;
    }
}