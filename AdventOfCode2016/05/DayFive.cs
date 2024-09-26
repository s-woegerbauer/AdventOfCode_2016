namespace AdventOfCode2016;

internal class DayFive
{
    public static void Solution()
    {

        var testInput = InputOutputHelper.GetInput(true, "01");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "01");
        //PartOne(false, input);

        //PartTwo(true, testInput);
        //PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        var result = 0;

        InputOutputHelper.WriteOutput(isTest, result);
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        var result = 0;

        InputOutputHelper.WriteOutput(isTest, result);
    }
}