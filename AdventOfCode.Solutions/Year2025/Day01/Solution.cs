namespace AdventOfCode.AdventOfCode.Solutions.Year2025.Day01;

class Solution : SolutionBase
{
    public Solution() : base(01, 2025, "")
    {
        Debug = false;
    }

    private int _zeroCount = 0;
    private int _totalZeroHits = 0;

    private int CurrentLocation
    {
        get;
        set
        {
            int start = field;
            int end = value;

            int totalDistance = Math.Abs(end - start);
            _totalZeroHits += totalDistance / 100;

            int remainingSteps = totalDistance % 100;
            if (remainingSteps > 0)
            {
                int direction = end > start ? 1 : -1;
                for (int i = 1; i <= remainingSteps; i++)
                {
                    if ((start + (i * direction)) % 100 == 0)
                    {
                        _totalZeroHits++;
                    }
                }
            }

            field = (value % 100 + 100) % 100;
            if (field == 0) _zeroCount++;
        }
    } = 50;

    private enum Direction { Left, Right}
    
    protected override string? SolvePartOne()
    {
        var lines = Input.Split("\n");
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            Direction direction = line.FirstOrDefault() == 'L' ? Direction.Left : Direction.Right;
            int steps = int.Parse(line[1..]);
            CurrentLocation += direction == Direction.Left ? -steps : steps;
        }

        return _zeroCount.ToString();
    }

    protected override string? SolvePartTwo()
    {
        return _totalZeroHits.ToString();
    }
}
