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
        return null;
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
}