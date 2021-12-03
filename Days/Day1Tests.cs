using System.Collections.Generic;
using Xunit;

namespace Depth;

public class Day1Tests
{
    [Fact]
    public void TestIncreases()
    {
        var input = ReadInput(@"C:\repos\AdventOfCode2021\Days\input.day1");
        var increases = Increases(input);
        Assert.Equal(1451, increases);
    }

    [Fact]
    public void TestWindowIncreases()
    {
        var input = ReadInput(@"C:\repos\AdventOfCode2021\Days\input.day1");
        var increases = WindowIncreases(input); // new[] { 4, 4, 4, 5});
        Assert.Equal(1395, increases);
    }

    private static int WindowIncreases(IList<int> depths)
    {
        if (depths.Count < 4) return 0;

        var increases = 0;
        for (var i = 3; i < depths.Count; i++)
            if (depths[i] > depths[i - 3])
                increases++;

        return increases;
    }

    private static int Increases(IList<int> depths)
    {
        if (depths.Count < 2) return 0;

        var increases = 0;
        for (var i = 1; i < depths.Count; i++)
        {
            if (depths[i] > depths[i - 1])
                increases++;
        }

        return increases;
    }

    private static IList<int> ReadInput(string fileName)
    {
        var input = new List<int>();
        foreach (var line in System.IO.File.ReadLines(fileName))
        {
            if (int.TryParse(line, out var n))
                input.Add(n);
        }
        return input;
    }
}

