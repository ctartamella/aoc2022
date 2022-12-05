namespace aoc22;

public static class Day2
{
    // This is an interesting one.  You can define this more clearly mathematically.
    // let R, P, S be unit vectors (1,0,0), (0,1,0), and (0,0,1) respectively.
    // (for part 2, you can define L, W, D similarly)
    //
    // We define "transform matrices" that are precomputed to give the results
    // of a given game (our move x their move => score) and for their move x desired outcome => our move.
    //
    // For Part A, the result is simply Them * ScoreTransform * Us^T.
    // (^-1 meaning the "transform" of the vector, i.e. convert the column to a row, and vice versa)
    //
    // For Part B, Them x ScoreTransform x (Them x OutcomeTransform x Desired^T)^T
    // I probably overthought this, and I didnt want to bring in Linear Algebra packages, so I did it below more simply.

    // Enums internally _are_ ints, so we can effectively map the char values to int for indices.
    private enum Them { A, B, C }
    private enum Us { X, Y, Z }
    
    private static readonly IEnumerable<string> File;

    // List of RPS outcomes and score values for us.  Them x Us for the axes. Value is the score.
    private static readonly int[,] Results = {{4, 8, 3}, {1, 5, 9}, {7, 2, 6}};
    
    // Given their play and the desired result, what should we play?  Them x Desired for the axes here. Value is our play.
    private static readonly int[,] Results2 = {{2,0,1}, {0,1,2}, {1,2,0}};
    
    static Day2()
    {
        File = System.IO.File.ReadLines("Input\\2.txt");
    }
    
    public static int PartA()
    {
        var scores =
            from line in File
            select line.Split(' ') into play
            let them = (int) Enum.Parse<Them>(play[0])
            let us = (int) Enum.Parse<Us>(play[1])
            select Results[them, us];

        return scores.Sum();
    }
    
    public static int PartB()
    {
        var scores = from line in File
            select line.Split(' ') into data
            let them = (int) Enum.Parse<Them>(data[0])
            let play = (int) Enum.Parse<Us>(data[1])
            let us = Results2[them, play]
            select Results[them, us];

        return scores.Sum();
    }
}