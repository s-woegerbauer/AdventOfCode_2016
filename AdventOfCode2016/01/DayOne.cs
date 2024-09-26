namespace AdventOfCode2016;

internal class DayOne
{
    public static void Solution()
    {

        var testInput = InputOutputHelper.GetInput(true, "01");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "01");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        var result = 0;
        var x = 0;
        var y = 0;
        var dir = 0;
        
        foreach(string step in input[0].Split(", "))
        {
            if(step[0] == 'R')
            {
                dir = (dir + 1) % 4;
            }
            else if(step[0] == 'L')
            {
                dir = (dir +3) % 4;
            }
            
            var dist = int.Parse(step.Substring(1));
            switch(dir)
            {
                case 0:
                    y += dist;
                    break;
                case 1:
                    x += dist;
                    break;
                case 2:
                    y -= dist;
                    break;
                case 3:
                    x -= dist;
                    break;
            }
            
        }

        result = Math.Abs(x) + Math.Abs(y);
        
        InputOutputHelper.WriteOutput(isTest, result);
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        var result = 0;
        var x = 0;
        var y = 0;
        var dir = 0;
        
        List<(int, int)> visited = new();
        
        foreach(string step in input[0].Split(", "))
        {
            if(step[0] == 'R')
            {
                dir = (dir + 1) % 4;
            }
            else if(step[0] == 'L')
            {
                dir = (dir +3) % 4;
            }
            
            var dist = int.Parse(step.Substring(1));
            
            for(int i = 0; i < dist; i++)
            {
                switch(dir)
                {
                    case 0:
                        y++;
                        break;
                    case 1:
                        x++;
                        break;
                    case 2:
                        y--;
                        break;
                    case 3:
                        x--;
                        break;
                }
                
                if(visited.Contains((x, y)))
                {
                    result = Math.Abs(x) + Math.Abs(y);
                    InputOutputHelper.WriteOutput(isTest, result);
                    return;
                }
                visited.Add((x, y));
            }
        }

        result = Math.Abs(x) + Math.Abs(y);
        
        InputOutputHelper.WriteOutput(isTest, result);
    }
}