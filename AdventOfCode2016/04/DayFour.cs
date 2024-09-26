using System.Text;

namespace AdventOfCode2016;

internal class DayFour
{
    public static void Solution()
    {

        var testInput = InputOutputHelper.GetInput(true, "04");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "04");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        var result = 0;
        
        foreach(string line in input)
        {
            var parts = line.Split("[");
            var name = string.Join("", parts.Take(parts.Length - 1));
            var checksum = parts.Last().Replace("]", "");
            var nameParts = name.Split("-");
            var sectorId = int.Parse(nameParts.Last());
            nameParts = nameParts.Take(nameParts.Length - 1).ToArray();
            var nameDict = new Dictionary<char, int>();
            foreach(var part in nameParts)
            {
                foreach(char c in part)
                {
                    if(nameDict.ContainsKey(c))
                    {
                        nameDict[c]++;
                    }
                    else
                    {
                        nameDict.Add(c, 1);
                    }
                }
            }

            var orderedDict = nameDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(5).ToList();
            var calculatedChecksum = string.Join("", orderedDict.Select(x => x.Key).Take(5));            
            if(calculatedChecksum == checksum)
            {
                result += sectorId;
            }
        }

        InputOutputHelper.WriteOutput(isTest, result);
    }

    
    public static void PartTwo(bool isTest, string[] input)
    {
        foreach (string line in input)
        {
            var parts = line.Split("[");
            var name = string.Join("", parts.Take(parts.Length - 1));
            var nameParts = name.Split("-");
            var sectorId = int.Parse(nameParts.Last());
            nameParts = nameParts.Take(nameParts.Length - 1).ToArray();
            var decryptedName = DecryptName(nameParts, sectorId);

            if (decryptedName.Contains("northpole object storage"))
            {
                InputOutputHelper.WriteOutput(isTest, sectorId);
                return;
            }
        }
    }

    private static string DecryptName(string[] nameParts, int sectorId)
    {
        var decryptedName = new StringBuilder();

        foreach (var part in nameParts)
        {
            foreach (char c in part)
            {
                var newChar = (char)((c - 'a' + sectorId) % 26 + 'a');
                decryptedName.Append(newChar);
            }
            decryptedName.Append(' ');
        }

        return decryptedName.ToString().Trim();
    }
}