using System.Numerics;

namespace AdventOfCode2016;

internal class DayNine
{
    public static void Solution()
    {

        var testInput = InputOutputHelper.GetInput(true, "09");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "09");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }
 
    public static void PartOne(bool isTest, string[] input)
    {
        var result = 0;

        foreach (string line in input)
        {
            bool isMarker = false;
            string current = "";
            int length = 0;
            int i = 0;

            while (i < line.Length)
            {
                char c = line[i];

                if (c == '(')
                {
                    current = "";
                    isMarker = true;
                }
                else if (c == ')')
                {
                    isMarker = false;
                    var parts = current.Split('x');
                    int f1 = int.Parse(parts[0]);
                    int f2 = int.Parse(parts[1]);
                    length = f1;
                    result += f1 * f2;
                    i += f1;
                }
                else if (isMarker)
                {
                    current += c;
                }
                else
                {
                    result++;
                }

                i++;
            }
        }

        InputOutputHelper.WriteOutput(isTest, result);
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        BigInteger GetDecompressedLength(string str)
        {
            BigInteger length = 0;
            int i = 0;

            while (i < str.Length)
            {
                if (str[i] == '(')
                {
                    int markerEnd = str.IndexOf(')', i);
                    var marker = str.Substring(i + 1, markerEnd - i - 1).Split('x');
                    int charsToRepeat = int.Parse(marker[0]);
                    int repeatCount = int.Parse(marker[1]);
                    string segment = str.Substring(markerEnd + 1, charsToRepeat);
                    length += repeatCount * GetDecompressedLength(segment);
                    i = markerEnd + charsToRepeat + 1;
                }
                else
                {
                    length++;
                    i++;
                }
            }

            return length;
        }

        BigInteger result = 0;

        foreach (string line in input)
        {
            result += GetDecompressedLength(line);
        }

        InputOutputHelper.WriteOutput(isTest, (long)result);
    }
}