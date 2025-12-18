namespace AdventOfCode.AdventOfCode.Solutions.Year2025.Day02;

class Solution : SolutionBase
{
    public Solution() : base(02, 2025, "")
    {
        Debug = false;
    }

    protected override string? SolvePartOne()
    {
        string[] ranges = Input.Split(",");
        long result = (from line in ranges
            select line.Split("-")
            into split
            let min = long.Parse(split[0])
            let max = long.Parse(split[1])
            select CheckSequences(min, max)).Sum();

        return result.ToString();
    }

    protected override string? SolvePartTwo()
    {
        string[] ranges = Input.Split(",");
        long result = (from line in ranges
            select line.Split("-")
            into split
            let min = long.Parse(split[0])
            let max = long.Parse(split[1])
            select CheckSequencesAll(min, max)).Sum();

        return result.ToString();
    }

    private static long CheckSequences(long min, long max)
    {
        long sequences = 0;
        for (long i = min; i <= max; i++)
        {
            string number = i.ToString();
            int split = number.Length / 2;
            if (number.Substring(0, split) == number.Substring(split, number.Length - split))
            {
                sequences += i;
            }
        }

        return sequences;
    }

    private static long CheckSequencesAll(long min, long max)
    {
        HashSet<long> sequences = [];
        for (long i = min; i <= max; i++)
        {
            string number = i.ToString();
            int split = number.Length / 2;
            for (int j = 1; j <= split; j++)
            {
                string pattern = number[..j];
                bool patternRepeatsEveryTime = pattern.Length > 0 && number.Length % pattern.Length == 0 &&
                                               Enumerable.Range(0, number.Length / pattern.Length).All(k =>
                                                   number.Substring(k * pattern.Length, pattern.Length) == pattern);
                if (patternRepeatsEveryTime)
                {
                    sequences.Add(i);
                }
            }
        }

        return sequences.Sum();
    }
}