namespace AdventOfCode2016;

internal class DayEight
{
    public static void Solution()
    {
        var testInput = InputOutputHelper.GetInput(true, "08");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "08");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        const int width = 50;
        const int height = 6;
        bool[,] screen = new bool[width, height];

        foreach (string line in input)
        {
            if (line.StartsWith("rect"))
            {
                var parts = line.Split(' ')[1].Split('x');
                int a = int.Parse(parts[0]);
                int b = int.Parse(parts[1]);
                Rect(screen, a, b);
            }
            else if (line.StartsWith("rotate row"))
            {
                var parts = line.Split(' ');
                int y = int.Parse(parts[2].Split('=')[1]);
                int b = int.Parse(parts[4]);
                RotateRow(screen, y, b);
            }
            else if (line.StartsWith("rotate column"))
            {
                var parts = line.Split(' ');
                int x = int.Parse(parts[2].Split('=')[1]);
                int b = int.Parse(parts[4]);
                RotateColumn(screen, x, b);
            }
        }

        int result = CountLitPixels(screen);
        InputOutputHelper.WriteOutput(isTest, result);
    }

    private static void Rect(bool[,] screen, int a, int b)
    {
        for (int x = 0; x < a; x++)
        {
            for (int y = 0; y < b; y++)
            {
                screen[x, y] = true;
            }
        }
    }

    private static void RotateRow(bool[,] screen, int y, int b)
    {
        int width = screen.GetLength(0);
        bool[] newRow = new bool[width];
        for (int x = 0; x < width; x++)
        {
            newRow[(x + b) % width] = screen[x, y];
        }

        for (int x = 0; x < width; x++)
        {
            screen[x, y] = newRow[x];
        }
    }

    private static void RotateColumn(bool[,] screen, int x, int b)
    {
        int height = screen.GetLength(1);
        bool[] newColumn = new bool[height];
        for (int y = 0; y < height; y++)
        {
            newColumn[(y + b) % height] = screen[x, y];
        }

        for (int y = 0; y < height; y++)
        {
            screen[x, y] = newColumn[y];
        }
    }

    private static int CountLitPixels(bool[,] screen)
    {
        int count = 0;
        foreach (bool pixel in screen)
        {
            if (pixel)
            {
                count++;
            }
        }

        return count;
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        const int width = 50;
        const int height = 6;
        bool[,] screen = new bool[width, height];

        foreach (string line in input)
        {
            if (line.StartsWith("rect"))
            {
                var parts = line.Split(' ')[1].Split('x');
                int a = int.Parse(parts[0]);
                int b = int.Parse(parts[1]);
                Rect(screen, a, b);
            }
            else if (line.StartsWith("rotate row"))
            {
                var parts = line.Split(' ');
                int y = int.Parse(parts[2].Split('=')[1]);
                int b = int.Parse(parts[4]);
                RotateRow(screen, y, b);
            }
            else if (line.StartsWith("rotate column"))
            {
                var parts = line.Split(' ');
                int x = int.Parse(parts[2].Split('=')[1]);
                int b = int.Parse(parts[4]);
                RotateColumn(screen, x, b);
            }
        }

        PrintScreen(screen);
        InputOutputHelper.WriteOutput(isTest, 0);
    }

    private static void PrintScreen(bool[,] screen)
    {
        int width = screen.GetLength(0);
        int height = screen.GetLength(1);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(screen[x, y] ? '#' : '.');
            }
            Console.WriteLine();
        }
    }
}