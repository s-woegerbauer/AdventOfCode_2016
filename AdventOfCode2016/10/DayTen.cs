namespace AdventOfCode2016;

internal class DayTen
{
    public static void Solution()
    {
        var testInput = InputOutputHelper.GetInput(true, "10");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "10");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        var botInstructions = new Dictionary<int, (string lowTarget, int lowId, string highTarget, int highId)>();
        var botChips = new Dictionary<int, List<int>>();
        var outputs = new Dictionary<int, int>();
        var initialAssignments = new List<(int value, int bot)>();

        foreach (var line in input)
        {
            var parts = line.Split(' ');
            if (parts[0] == "value")
            {
                int value = int.Parse(parts[1]);
                int bot = int.Parse(parts[5]);
                initialAssignments.Add((value, bot));
            }
            else if (parts[0] == "bot")
            {
                int bot = int.Parse(parts[1]);
                string lowTarget = parts[5];
                int lowId = int.Parse(parts[6]);
                string highTarget = parts[10];
                int highId = int.Parse(parts[11]);
                botInstructions[bot] = (lowTarget, lowId, highTarget, highId);
            }
        }

        foreach (var (value, bot) in initialAssignments)
        {
            if (!botChips.ContainsKey(bot))
            {
                botChips[bot] = new List<int>();
            }

            botChips[bot].Add(value);
        }

        int responsibleBot = -1;

        bool changesMade;
        do
        {
            changesMade = false;
            foreach (var bot in botChips.Keys.ToList())
            {
                if (botChips[bot].Count == 2)
                {
                    var chips = botChips[bot].OrderBy(x => x).ToList();
                    int lowChip = chips[0];
                    int highChip = chips[1];

                    if (lowChip == 17 && highChip == 61)
                    {
                        responsibleBot = bot;
                    }

                    var (lowTarget, lowId, highTarget, highId) = botInstructions[bot];

                    if (lowTarget == "bot")
                    {
                        if (!botChips.ContainsKey(lowId))
                        {
                            botChips[lowId] = new List<int>();
                        }

                        botChips[lowId].Add(lowChip);
                    }
                    else if (lowTarget == "output")
                    {
                        outputs[lowId] = lowChip;
                    }

                    if (highTarget == "bot")
                    {
                        if (!botChips.ContainsKey(highId))
                        {
                            botChips[highId] = new List<int>();
                        }

                        botChips[highId].Add(highChip);
                    }
                    else if (highTarget == "output")
                    {
                        outputs[highId] = highChip;
                    }

                    botChips[bot].Clear();
                    changesMade = true;
                }
            }
        } while (changesMade);

        InputOutputHelper.WriteOutput(isTest, responsibleBot);
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        var botInstructions = new Dictionary<int, (string lowTarget, int lowId, string highTarget, int highId)>();
        var botChips = new Dictionary<int, List<int>>();
        var outputs = new Dictionary<int, int>();
        var initialAssignments = new List<(int value, int bot)>();

        foreach (var line in input)
        {
            var parts = line.Split(' ');
            if (parts[0] == "value")
            {
                int value = int.Parse(parts[1]);
                int bot = int.Parse(parts[5]);
                initialAssignments.Add((value, bot));
            }
            else if (parts[0] == "bot")
            {
                int bot = int.Parse(parts[1]);
                string lowTarget = parts[5];
                int lowId = int.Parse(parts[6]);
                string highTarget = parts[10];
                int highId = int.Parse(parts[11]);
                botInstructions[bot] = (lowTarget, lowId, highTarget, highId);
            }
        }

        foreach (var (value, bot) in initialAssignments)
        {
            if (!botChips.ContainsKey(bot))
            {
                botChips[bot] = new List<int>();
            }

            botChips[bot].Add(value);
        }

        bool changesMade;
        do
        {
            changesMade = false;
            foreach (var bot in botChips.Keys.ToList())
            {
                if (botChips[bot].Count == 2)
                {
                    var chips = botChips[bot].OrderBy(x => x).ToList();
                    int lowChip = chips[0];
                    int highChip = chips[1];

                    var (lowTarget, lowId, highTarget, highId) = botInstructions[bot];

                    if (lowTarget == "bot")
                    {
                        if (!botChips.ContainsKey(lowId))
                        {
                            botChips[lowId] = new List<int>();
                        }

                        botChips[lowId].Add(lowChip);
                    }
                    else if (lowTarget == "output")
                    {
                        outputs[lowId] = lowChip;
                    }

                    if (highTarget == "bot")
                    {
                        if (!botChips.ContainsKey(highId))
                        {
                            botChips[highId] = new List<int>();
                        }

                        botChips[highId].Add(highChip);
                    }
                    else if (highTarget == "output")
                    {
                        outputs[highId] = highChip;
                    }

                    botChips[bot].Clear();
                    changesMade = true;
                }
            }
        } while (changesMade);

        int result = outputs[0] * outputs[1] * outputs[2];
        InputOutputHelper.WriteOutput(isTest, result);
    }
}