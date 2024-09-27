namespace AdventOfCode2016;

internal class DaySix
{
    public static void Solution()
    {

        var testInput = InputOutputHelper.GetInput(true, "06");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "06");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        var result = "";
        var columnCount = input[0].Length;
        var charCounts = new List<Dictionary<char, int>>();

        for (var i = 0; i < columnCount; i++)
        {
            charCounts.Add(new Dictionary<char, int>());
        }

        foreach (var line in input)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (charCounts[i].ContainsKey(line[i]))
                {
                    charCounts[i][line[i]]++;
                }
                else
                {
                    charCounts[i].Add(line[i], 1);
                }
            }
        }

        foreach (var charCount in charCounts)
        {
            var max = charCount.Values.Max();
            var maxChar = charCount.FirstOrDefault(x => x.Value == max).Key;
            result += maxChar;
        }

        InputOutputHelper.WriteOutput(isTest, result);
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        var result = "";
        var columnCount = input[0].Length;
        var charCounts = new List<Dictionary<char, int>>();

        for (var i = 0; i < columnCount; i++)
        {
            charCounts.Add(new Dictionary<char, int>());
        }

        foreach (var line in input)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (charCounts[i].ContainsKey(line[i]))
                {
                    charCounts[i][line[i]]++;
                }
                else
                {
                    charCounts[i].Add(line[i], 1);
                }
            }
        }

        foreach (var charCount in charCounts)
        {
            var max = charCount.Values.Min();
            var maxChar = charCount.FirstOrDefault(x => x.Value == max).Key;
            result += maxChar;
        }

        InputOutputHelper.WriteOutput(isTest, result);
    }
}