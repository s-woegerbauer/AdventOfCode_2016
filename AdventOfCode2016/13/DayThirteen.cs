namespace AdventOfCode2016;

internal class DayThirteen
{
    public static void Solution()
    {

        var testInput = InputOutputHelper.GetInput(true, "13");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "13");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        int inputNumber = int.Parse(input[0]);
        var result = FindFewestSteps(inputNumber, (1, 1), (31, 39));

        InputOutputHelper.WriteOutput(isTest, result);
    }
    
    private static int FindFewestSteps(int favoriteNumber, (int x, int y) start, (int x, int y) target)
    {
        var directions = new (int dx, int dy)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
        var queue = new Queue<((int x, int y) position, int steps)>();
        var visited = new HashSet<(int x, int y)>();

        queue.Enqueue((start, 0));
        visited.Add(start);

        while (queue.Count > 0)
        {
            var (current, steps) = queue.Dequeue();

            if (current == target)
            {
                return steps;
            }

            foreach (var (dx, dy) in directions)
            { 
                (int x, int y) next = (current.x + dx, current.y + dy);

                if (next.x >= 0 && next.y >= 0 && !visited.Contains(next) && IsOpenSpace(next.x, next.y, favoriteNumber))
                {
                    queue.Enqueue((next, steps + 1));
                    visited.Add(next);
                }
            }
        }

        return -1;
    }

    private static bool IsOpenSpace(int x, int y, int favoriteNumber)
    {
        int value = x * x + 3 * x + 2 * x * y + y + y * y + favoriteNumber;
        int bitCount = CountBits(value);
        return bitCount % 2 == 0;
    }

    private static int CountBits(int value)
    {
        int count = 0;
        while (value > 0)
        {
            count += value & 1;
            value >>= 1;
        }
        return count;
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        int inputNumber = int.Parse(input[0]);
        var result = CountReachableLocations(inputNumber, (1, 1), 50);

        InputOutputHelper.WriteOutput(isTest, result);
    }

    private static int CountReachableLocations(int favoriteNumber, (int x, int y) start, int maxSteps)
    {
        var directions = new (int dx, int dy)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
        var queue = new Queue<((int x, int y) position, int steps)>();
        var visited = new HashSet<(int x, int y)>();

        queue.Enqueue((start, 0));
        visited.Add(start);

        while (queue.Count > 0)
        {
            var (current, steps) = queue.Dequeue();

            if (steps >= maxSteps)
            {
                continue;
            }

            foreach (var (dx, dy) in directions)
            {
                (int x, int y) next = (current.x + dx, current.y + dy);

                if (next.x >= 0 && next.y >= 0 && !visited.Contains(next) && IsOpenSpace(next.x, next.y, favoriteNumber))
                {
                    queue.Enqueue((next, steps + 1));
                    visited.Add(next);
                }
            }
        }

        return visited.Count;
    }
}