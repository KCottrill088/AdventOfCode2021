using Xunit;

namespace Depth;

public class Day2Tests
{
    static string[] lines =
    {
        "forward 5",
        "down 5",
        "forward 8",
        "up 3",
        "down 8",
        "forward 2"
    };

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

    [Fact]
    public void TestImprovedPosition()
    {
        var horizontal = 0;
        var aim = 0;
        var depth = 0;

        foreach (var line in System.IO.File.ReadLines(@"C:\repos\AdventOfCode2021\Days\input.day2"))
        //foreach (var line in lines)
        {
            var directions = line.Split(null);
            var magnitude = ToInt(directions[1]);
            switch (directions[0])
            {
                case "forward":
                    horizontal += magnitude;
                    depth += magnitude * aim;
                    break;
                case "up":
                    aim -= magnitude;
                    break;
                case "down":
                    aim += magnitude;
                    break;
                default:
                    break;
            }
        }

        Assert.Equal(1957, horizontal);
        Assert.Equal(1004584, depth);
        Assert.Equal(1_965_970_888, horizontal * depth);
    }

    private static int ToInt(string s)
    {
        if (int.TryParse(s, out var n))
            return n;
        return 0;
    }
}
