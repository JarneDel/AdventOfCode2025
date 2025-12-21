using System.Text;

namespace AdventOfCode.AdventOfCode.Solutions.Year2025.Day10;

class Solution : SolutionBase
{
    public Solution() : base(10, 2025, "")
    {
        Debug = false;
    }

    protected override string? SolvePartOne()
    {
        int totalResult = 0;
        string[] lines = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            long target = ParseTarget(line);
            List<List<int>> buttons = ParseButtons(line);

            List<long> buttonMasks = buttons.Select(btnList => btnList.Aggregate<int, long>(0, (current, lightIdx) => current | (1L << lightIdx))).ToList();

            totalResult += SolveMachine(target, buttonMasks);
        }

        return totalResult.ToString();
    }



    private static int SolveMachine(long target, List<long> buttons)
    {
        if (target == 0) return 0;

        Queue<(long currentMask, int presses)> queue = new();
        HashSet<long> visited = new();

        queue.Enqueue((0, 0));
        visited.Add(0);

        while (queue.Count > 0)
        {
            (long current, int count) = queue.Dequeue();

            foreach (long buttonMask in buttons)
            {
                long next = current ^ buttonMask;

                if (next == target) return count + 1;

                if (visited.Add(next))
                {
                    queue.Enqueue((next, count + 1));
                }
            }
        }

        throw new Exception("No solution found");
    }

    private static long ParseTarget(string line)
    {
        long target = 0;
        int start = line.IndexOf('[');
        int end = line.IndexOf(']');
        string diagram = line.Substring(start + 1, end - start - 1);

        for (int i = 0; i < diagram.Length; i++)
        {
            if (diagram[i] == '#')
            {
                target |= (1L << i);
            }
        }

        return target;
    }

    private static List<List<int>> ParseButtons(string line)
    {
        const char startChar = '(';
        const char endChar = ')';
        const char delimiter = ',';
        bool isParsing = false;
        List<List<int>> buttonList = [];
        List<int> currentButton = [];
        StringBuilder currentButtonItem = new();
        foreach (char c in line)
        {
            if (char.IsDigit(c) && isParsing)
            {
                currentButtonItem.Append(c);
            }

            switch (c)
            {
                case startChar:
                    currentButton = [];
                    currentButtonItem = new StringBuilder();
                    isParsing = true;
                    break;
                case delimiter when isParsing:
                    currentButton.Add(int.Parse(currentButtonItem.ToString()));
                    currentButtonItem = new StringBuilder();
                    break;
                case endChar:
                    if (currentButtonItem.Length > 0)
                    {
                        currentButton.Add(int.Parse(currentButtonItem.ToString()));
                        currentButtonItem = new StringBuilder();
                    }

                    buttonList.Add(currentButton);
                    currentButton = [];
                    isParsing = false;
                    break;
            }
        }

        return buttonList;
    }
    
    

    protected override string? SolvePartTwo()
    {
        return null;
    }
}
