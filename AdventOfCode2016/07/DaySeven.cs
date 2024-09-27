namespace AdventOfCode2016;

internal class DaySeven
{
    public static void Solution()
    {
        var testInput = InputOutputHelper.GetInput(true, "07");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "07");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        var result = 0;

        foreach (string line in input)
        {
            var hypernet = "";
            var supernet = "";
            var isHypernet = false;
            foreach (char c in line)
            {
                if (c == '[')
                {
                    isHypernet = true;
                }

                if (c == ']')
                {
                    isHypernet = false;
                }

                if (isHypernet)
                {
                    hypernet += c;
                }
                else
                {
                    supernet += c;
                }
            }

            var isAbba = false;
            for (int i = 0; i < supernet.Length - 3; i++)
            {
                if (supernet[i] == supernet[i + 3] && supernet[i + 1] == supernet[i + 2] && supernet[i] != supernet[i + 1])
                {
                    isAbba = true;
                    break;
                }
            }

            if (isAbba)
            {
                var isAbbaHypernet = false;
                    for (int i = 0; i < hypernet.Length - 3; i++)
                    {
                        if (hypernet[i] == hypernet[i + 3] && hypernet[i + 1] == hypernet[i + 2] && hypernet[i] != hypernet[i + 1])
                        {
                            isAbbaHypernet = true;
                            break;
                        }
                    }

                if (!isAbbaHypernet)
                {
                    result++;
                }
            }
        }

        InputOutputHelper.WriteOutput(isTest, result);
    }

    public static void PartTwo(bool isTest, string[] input)
        {
            var result = 0;

            foreach (string line in input)
            {
                var hypernetSequences = new List<string>();
                var supernetSequences = new List<string>();
                var isHypernet = false;
                var currentSequence = "";

                foreach (char c in line)
                {
                    if (c == '[')
                    {
                        if (!isHypernet)
                        {
                            supernetSequences.Add(currentSequence);
                        }
                        else
                        {
                            hypernetSequences.Add(currentSequence);
                        }
                        currentSequence = "";
                        isHypernet = true;
                    }
                    else if (c == ']')
                    {
                        hypernetSequences.Add(currentSequence);
                        currentSequence = "";
                        isHypernet = false;
                    }
                    else
                    {
                        currentSequence += c;
                    }
                }

                if (!isHypernet)
                {
                    supernetSequences.Add(currentSequence);
                }
                else
                {
                    hypernetSequences.Add(currentSequence);
                }

                var abaPatterns = new List<string>();
                foreach (var supernet in supernetSequences)
                {
                    for (int i = 0; i < supernet.Length - 2; i++)
                    {
                        if (supernet[i] == supernet[i + 2] && supernet[i] != supernet[i + 1])
                        {
                            abaPatterns.Add(supernet.Substring(i, 3));
                        }
                    }
                }

                var isSSL = false;
                foreach (var aba in abaPatterns)
                {
                    var bab = $"{aba[1]}{aba[0]}{aba[1]}";
                    foreach (var hypernet in hypernetSequences)
                    {
                        if (hypernet.Contains(bab))
                        {
                            isSSL = true;
                            break;
                        }
                    }
                    if (isSSL)
                    {
                        break;
                    }
                }

                if (isSSL)
                {
                    result++;
                }
            }

            InputOutputHelper.WriteOutput(isTest, result);
        }
}