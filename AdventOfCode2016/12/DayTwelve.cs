namespace AdventOfCode2016;

internal class DayTwelve
{
    public static void Solution()
    {
        var testInput = InputOutputHelper.GetInput(true, "12");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "12");
        PartOne(false, input);
        
        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        var registers = new Dictionary<string, int>
        {
            { "a", 0 },
            { "b", 0 },
            { "c", 0 },
            { "d", 0 }
        };
        
        var result = ExecuteInstructions(input, registers);

        InputOutputHelper.WriteOutput(isTest, result);
    }

    public static int ExecuteInstructions(string[] instructions, Dictionary<string, int> registers)
    {
        int pointer = 0;

        while (pointer < instructions.Length)
        {
            var parts = instructions[pointer].Split(' ');
            switch (parts[0])
            {
                case "cpy":
                    if (int.TryParse(parts[1], out int value))
                    {
                        registers[parts[2]] = value;
                    }
                    else
                    {
                        registers[parts[2]] = registers[parts[1]];
                    }

                    pointer++;
                    break;

                case "inc":
                    registers[parts[1]]++;
                    pointer++;
                    break;

                case "dec":
                    registers[parts[1]]--;
                    pointer++;
                    break;

                case "jnz":
                    if (int.TryParse(parts[1], out int xValue))
                    {
                        if (xValue != 0)
                        {
                            pointer += int.Parse(parts[2]);
                        }
                        else
                        {
                            pointer++;
                        }
                    }
                    else
                    {
                        if (registers[parts[1]] != 0)
                        {
                            pointer += int.Parse(parts[2]);
                        }
                        else
                        {
                            pointer++;
                        }
                    }

                    break;

                default:
                    throw new InvalidOperationException($"Unknown instruction: {parts[0]}");
            }
        }

        return registers["a"];
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        var registers = new Dictionary<string, int>
        {
            { "a", 0 },
            { "b", 0 },
            { "c", 1 },
            { "d", 0 }
        };
        
        var result = ExecuteInstructions(input, registers);

        InputOutputHelper.WriteOutput(isTest, result);
    }
}