namespace AdventOfCode.AdventOfCode.Solutions.Year2025.Day04;

class Solution : SolutionBase
{
    public Solution() : base(04, 2025, "")
    {
        Debug = false;
    }

    protected override string? SolvePartOne()
    {
        string[] lines = Input.Split(Environment.NewLine);
        char[][] map = lines.Select(line => line.ToCharArray()).ToArray();
        int count = 0;

        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                char item = map[i][j];
                if (item != '@')
                {
                    continue;
                }

                List<char> around =
                [
                    GetCell(i - 1, j - 1),
                    GetCell(i - 1, j),
                    GetCell(i - 1, j + 1),
                    GetCell(i, j - 1),
                    GetCell(i, j + 1),
                    GetCell(i + 1, j - 1),
                    GetCell(i + 1, j),
                    GetCell(i + 1, j + 1)
                ];
                if (around.Count(c => c == '@') < 4)
                {
                    count += 1;
                }
            }
        }
        return count.ToString();

        char GetCell(int row, int column) =>
            row >= 0 && row < map.Length && column >= 0 && column < map[row].Length
                ? map[row][column]
                : '.';
    }


    protected override string? SolvePartTwo()
    {
        string[] lines = Input.Split(Environment.NewLine);
        char[][] map = lines.Select(line => line.ToCharArray()).ToArray();
        int count = 0;
        bool isFinished = false;

        while (!isFinished)
        {
            (int, bool) result = EvaluateSurroundingCells(map, count);
            count = result.Item1;  
            isFinished = !result.Item2;
        }
        
        return count.ToString();
    }

    private static (int, bool) EvaluateSurroundingCells(char[][] map, int count)
    {
        bool changed = false;
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                char item = map[i][j];
                if (item != '@')
                {
                    continue;
                }

                List<char> around =
                [
                    GetCell(i - 1, j - 1),
                    GetCell(i - 1, j),
                    GetCell(i - 1, j + 1),
                    GetCell(i, j - 1),
                    GetCell(i, j + 1),
                    GetCell(i + 1, j - 1),
                    GetCell(i + 1, j),
                    GetCell(i + 1, j + 1)
                ];
                if (around.Count(c => c == '@') >= 4) continue;
                count += 1;
                changed = true;
                map[i][j] = '.';
            }
        }

        return (count, changed);

        char GetCell(int row, int column) =>
            row >= 0 && row < map.Length && column >= 0 && column < map[row].Length
                ? map[row][column]
                : '.';
    }
}
