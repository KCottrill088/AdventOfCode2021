using Xunit;

namespace Depth;

public class Day2Tests
{
    [Fact]
    public void TestPosition()
    {
        var forward = 0;
        var depth = 0;
        foreach (var line in System.IO.File.ReadLines(@"C:\repos\AdventOfCode2021\Days\input.day2"))
        {
            var directions = line.Split(null);
            switch (directions[0])
            {
                case "forward":
                    forward += ToInt(directions[1]);
                    break;
                case "up":
                    depth -= ToInt(directions[1]);
                    break;
                case "down":
                    depth += ToInt(directions[1]);
                    break;
                default:
                    break;
            }
        }
        Assert.Equal(1957, forward);
        Assert.Equal(955, depth);
        Assert.Equal(1_868_935, forward * depth);
    }

    private static int ToInt(string s)
    {
        if (int.TryParse(s, out var n))
            return n;
        return 0;
    }
}

