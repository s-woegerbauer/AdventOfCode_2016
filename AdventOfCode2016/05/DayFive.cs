using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2016;

internal class DayFive
{
    public static void Solution()
    {

        var testInput = InputOutputHelper.GetInput(true, "05");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "05");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        string doorId = input[0];
        string password = FindPassword(doorId);
        InputOutputHelper.WriteOutput(isTest, password);
    }

    private static string FindPassword(string doorId)
    {
        StringBuilder password = new StringBuilder();
        int index = 0;
        using (MD5 md5 = MD5.Create())
        {
            while (password.Length < 8)
            {
                string toHash = doorId + index;
                byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(toHash));
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                if (hash.StartsWith("00000"))
                {
                    password.Append(hash[5]);
                }

                index++;
            }
        }

        return password.ToString();
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        string doorId = input[0];
        string password = FindPasswordTwo(doorId);
        InputOutputHelper.WriteOutput(isTest, password);
    }
    
    private static string FindPasswordTwo(string doorId)
    {
        char[] password = new char[8];
        Array.Fill(password, '_');
        int filledPositions = 0;
        int index = 0;
        using (MD5 md5 = MD5.Create())
        {
            while (filledPositions < 8)
            {
                string toHash = doorId + index;
                byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(toHash));
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                if (hash.StartsWith("00000"))
                {
                    int position;
                    if (int.TryParse(hash[5].ToString(), out position) && position >= 0 && position < 8 && password[position] == '_')
                    {
                        password[position] = hash[6];
                        filledPositions++;
                    }
                }

                index++;
            }
        }

        return new string(password);
    }
}