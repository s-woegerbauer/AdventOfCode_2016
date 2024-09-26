namespace AdventOfCode2016;

internal class DayTwo
{
    public static void Solution()
    {

        var testInput = InputOutputHelper.GetInput(true, "02");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "02");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        var result = "";
        
        int[,] keypad = new int[,] {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        
        int x = 1;
        int y = 1;
        
        foreach (var line in input)
        {
            foreach (var c in line)
            {
                switch (c)
                {
                    case 'U':
                        y = Math.Max(0, y - 1);
                        break;
                    case 'D':
                        y = Math.Min(2, y + 1);
                        break;
                    case 'L':
                        x = Math.Max(0, x - 1);
                        break;
                    case 'R':
                        x = Math.Min(2, x + 1);
                        break;
                }
            }
            result += $"{keypad[y, x]}";
        }

        InputOutputHelper.WriteOutput(isTest, result);
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        var result = "";
        
        char[,] keypad = new char[,] {
            {' ', ' ', '1', ' ', ' '},
            {' ', '2', '3', '4', ' '},
            {'5', '6', '7', '8', '9'},
            {' ', 'A', 'B', 'C', ' '},
            {' ', ' ', 'D', ' ', ' '}
        };
        
        int x = 0;
        int y = 2;
        
        foreach (var line in input)
        {
            foreach (var c in line)
            {
                int newX = x;
                int newY = y;

                switch (c)
                {
                    case 'U':
                        newY = y - 1;
                        break;
                    case 'D':
                        newY = y + 1;
                        break;
                    case 'L':
                        newX = x - 1;
                        break;
                    case 'R':
                        newX = x + 1;
                        break;
                }

                if (newX >= 0 && newX < 5 && newY >= 0 && newY < 5 && keypad[newY, newX] != ' ')
                {
                    x = newX;
                    y = newY;
                }
            }
            result += keypad[y, x];
        }

        InputOutputHelper.WriteOutput(isTest, result);
    }
}