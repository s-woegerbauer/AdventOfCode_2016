namespace AdventOfCode2016;

internal class DayThree
{
    public static void Solution()
    {

        var testInput = InputOutputHelper.GetInput(true, "03");
        PartOne(true, testInput);

        var input = InputOutputHelper.GetInput(false, "03");
        PartOne(false, input);

        PartTwo(true, testInput);
        PartTwo(false, input);
    }

    public static void PartOne(bool isTest, string[] input)
    {
        var result = 0;

        foreach (string line in input)
        {
            int a = int.Parse(line.Substring(0, 5).Trim());
            int b = int.Parse(line.Substring(5, 5).Trim());
            int c = int.Parse(line.Substring(10, 5).Trim());

            if (a + b > c && a + c > b && b + c > a)
            {
                result++;
            }
        }

        InputOutputHelper.WriteOutput(isTest, result);
    }

    public static void PartTwo(bool isTest, string[] input)
    {
        var result = 0;

        List<List<int>> triangles = new();

        int i = 0;
        int triangleA = -3;
        int triangleB = -2;
        int triangleC = -1;

        foreach (string line in input)
        {
            int a = int.Parse(line.Substring(0, 5).Trim());
            int b = int.Parse(line.Substring(5, 5).Trim());
            int c = int.Parse(line.Substring(10, 5).Trim());

            if(i % 3 == 0)
            {
                triangles.Add(new());
                triangles.Add(new());
                triangles.Add(new());

                triangleA += 3;
                triangleB += 3;
                triangleC += 3;
            }
            
            triangles[triangleA].Add(a);
            triangles[triangleB].Add(b);
            triangles[triangleC].Add(c);

            i++;
        }
        
        foreach (List<int> triangle in triangles)
        {
            if (triangle[0] + triangle[1] > triangle[2] && triangle[0] + triangle[2] > triangle[1] && triangle[1] + triangle[2] > triangle[0])
            {
                result++;
            }
        }

        InputOutputHelper.WriteOutput(isTest, result);
    }
}