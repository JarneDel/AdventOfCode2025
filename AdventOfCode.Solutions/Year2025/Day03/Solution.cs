namespace AdventOfCode.AdventOfCode.Solutions.Year2025.Day03;

class Solution : SolutionBase
{
    public Solution() : base(03, 2025, "")
    {
        Debug = false;
    }


    protected override string? SolvePartOne()
    {
        long result = 0;
        string[] lines = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            if (line.Length < 2) continue;

            int maxJoltage = 0;
            int bestOnesDigit = -1;

            for (int i = line.Length - 1; i >= 0; i--)
            {
                int currentDigit = line[i] - '0';

                if (bestOnesDigit != -1)
                {
                    int currentJoltage = (currentDigit * 10) + bestOnesDigit;
                    if (currentJoltage > maxJoltage) maxJoltage = currentJoltage;
                }

                if (currentDigit > bestOnesDigit)
                {
                    bestOnesDigit = currentDigit;
                }
            }

            result += maxJoltage;
        }

        return result.ToString();
    }

    protected override string? SolvePartTwo()
    {
        long result = 0;
        string[] lines = Input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            if (line.Length < 12) continue;

            char[] bestSequence = new char[12];
            int currentSearchStart = 0;

            for (int digitPos = 0; digitPos < 12; digitPos++)
            {
                // We need to leave (11 - digitPos) characters for the rest of the number
                int remainingNeeded = 11 - digitPos;
                int searchEnd = line.Length - remainingNeeded;

                char bestChar = '0';
                int bestIdx = currentSearchStart;

                // Find the largest digit in the allowed range
                for (int i = currentSearchStart; i < searchEnd; i++)
                {
                    if (line[i] > bestChar)
                    {
                        bestChar = line[i];
                        bestIdx = i;
                        if (bestChar == '9') break; // Optimization: can't do better than 9
                    }
                }

                bestSequence[digitPos] = bestChar;
                currentSearchStart = bestIdx + 1;
            }

            result += long.Parse(new string(bestSequence));
        }

        return result.ToString();
    }
// ... existing code ...
}
