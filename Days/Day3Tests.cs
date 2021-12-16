using System.Linq;
using Xunit;

namespace Days;

public class Day3Tests
{
    static string[] _lines =
    {
        "100",
        "110",
        "111"
    };

    [Fact]
    public void TestGamma()
    {
        var expectedGamma = 6;
        var expectedEpsilon = 1;
        var (gamma, epsilon) = Rates(_lines);
        Assert.Equal(expectedGamma, gamma);
        Assert.Equal(expectedEpsilon, epsilon);
    }

    private static (int, int) Rates(string[] lines)
    {
        var bits = lines[0].Length;
        var sums = new int[bits];
        foreach (var line in lines)
        {
            var characters = line.ToCharArray();
            for (var i = 0; i < characters.Length; i++)
            {
                if (characters[i] == '1')
                    sums[i]++;
            }
        }

        var gamma = 0;
        var epsilon = 0;

        var majority = lines.Length / 2;
        var offset = bits - 1;
        for (var i = 0; i < bits; i++)
            if (sums[i] > majority)
            {
                gamma |= 1 << (offset - i);
            }
            else
            {
                epsilon |= 1 << (offset - i);
            }

        return (gamma, epsilon);
    }

    [Fact]
    public void RunSolution()
    {
        var (gamma, epsilon) = Rates(System.IO.File.ReadLines(@"C:\repos\AdventOfCode2021\Days\input.day3").ToArray());
        Assert.Equal(2531, gamma);
        Assert.Equal(1564, epsilon);
        Assert.Equal(3958484, gamma * epsilon);
    }
}
