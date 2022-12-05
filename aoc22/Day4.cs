namespace aoc22;

public static class Day4
{
    private static readonly IEnumerable<string> File;

    static Day4()
    {
        File = System.IO.File.ReadLines("Input\\4.txt");
    }

    // Nothing tricky here.  Once the lines are parsed, 
    // we just need to do some set operations. To be 
    // "Fully Contained" all numbers in one set must be in
    // the other or vice versa.
    public static int PartA()
    {
        return File.Select(x =>
        {
            var elves = x.Split(',')
                .Select(GetRange)
                .ToArray();
            
            return elves[0].All(elves[1].Contains) || elves[1].All(elves[0].Contains);
        }).Count(y => y);
    }

    // Even easier.  Same parsing, just a different Linq clause.
    public static int PartB()
    {
        return File.Select(x =>
        {
            var elves = x.Split(',')
                .Select(GetRange)
                .ToArray();

            return elves[0].Any(i => elves[1].Contains(i));
        }).Count(y => y);
    }
    
    // Really just used to parse a line into two arrays containing
    // the full range of integers an elf is responsible for.
    private static IEnumerable<int> GetRange(string y)
    {
        var data = y.Split('-')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

        return Enumerable.Range(data[0], data[1] - data[0] + 1);
    }
}