namespace aoc22;

public static class Day1
{
    private static readonly string File;
    
    static Day1()
    {
        File = System.IO.File.ReadAllText("1.txt");
    }
    
    public static int PartA()
    {
        return File
            .Split("\n\n")
            .Select(x => x.Split('\n'))
            .Select(x => x.Select(y => !string.IsNullOrWhiteSpace(y) ? Convert.ToInt32(y) : 0))
            .Max(x => x.Sum());
    }

    public static int PartB()
    {
        return File
            .Split("\n\n")
            .Select(x => x.Split('\n'))
            .Select(x => x.Select(y => !string.IsNullOrWhiteSpace(y) ? Convert.ToInt32(y) : 0))
            .Select(x => x.Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
    }
}