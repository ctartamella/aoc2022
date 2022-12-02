namespace aoc22;

public static class Day2
{
    private enum Them { A, B, C }
    private enum Us { X, Y, Z }
    private enum Outcome { L, D, W }
    
    private static readonly IEnumerable<string> File;

    private static readonly int[,] Results;
    private static readonly int[,] Results2;
    
    static Day2()
    {
        File = System.IO.File.ReadLines("2.txt");
        Results = new[,] {{4, 8, 3}, {1, 5, 9}, {7, 2, 6}};
        Results2 = new[,] {{2,0,1}, {0,1,2}, {1,2,0}};
    }
    
    public static int PartA()
    {
        int sum = 0;
        foreach (var line in File)
        {
            var play = line.Split(' ');
            var them = (int) Enum.Parse<Them>(play[0]);
            var us = (int) Enum.Parse<Us>(play[1]);
            var result = Results[them, us];
            
            sum += result;
        }

        return sum;
    }
    
    public static int PartB()
    {
        int sum = 0;
        foreach (var line in File)
        {
            var data = line.Split(' ');
            var them = (int) Enum.Parse<Them>(data[0]);
            var play = (int) Enum.Parse<Us>(data[1]);
            var us = Results2[them, play];
            var result = Results[them, us];
            
            sum += result;
        }

        return sum;
    }
}