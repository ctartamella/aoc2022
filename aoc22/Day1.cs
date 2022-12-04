namespace aoc22;

// One thing i don't like.... this assumes certain line endings as I discovered when commiting on my 
// mac then pulling on windows later.  Change between \r\n on Windows and \n on Unix machines.

public static class Day1
{
    private static readonly string File;
    
    static Day1()
    {
        File = System.IO.File.ReadAllText("Input\\1.txt");
    }
    
    public static int PartA()
    {
        // Split the file into groups by double new lines (blank line) -> array[string], sizeof(NElves)
        // Convert to array[array[string]] by reading the lines from each group. sizeof(NElves) x sizeof(NItemsForElf), sum(NItemsForElf)=NLines
        // For each element, return the same list with strings converted to ints.  Where that fails, 0 is fine since we are summing.
        // Take the max for each elf, computing the sum of each elves list as we go.
        return File
            .Split("\r\n\r\n")
            .Select(x => x.Split("\r\n")
            .Select(x => x.Trim()))
            .Select(x => x.Select(y => !string.IsNullOrWhiteSpace(y) ? Convert.ToInt32(y) : 0))
            .Max(x => x.Sum());
    }

    public static int PartB()
    {
        // Same as before, but generate the full list of sums, sort them, then take the top 3, then sum them.
        return File
            .Split("\r\n\r\n")
            .Select(x => x.Split("\r\n"))
            .Select(x => x.Select(y => !string.IsNullOrWhiteSpace(y) ? Convert.ToInt32(y) : 0))
            .Select(x => x.Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
    }
}