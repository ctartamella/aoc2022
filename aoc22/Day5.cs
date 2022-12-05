using System.Text.RegularExpressions;

namespace aoc22;

public static class Day5
{
    private static readonly string Reg = @"move\s(\d+)\sfrom\s(\d+)\sto\s(\d+)";
    private static readonly string[] Moves;
    private static readonly Stack<char>[] Stacks;

    private struct Move
    {
        public int Quantity;
        public int Source;
        public int Destination;
    }
    
    static Day5()
    {
        Moves = File.ReadAllLines("Input/5.txt");
        Stacks = new []
        {
            new Stack<char>(new[] { 'L', 'N', 'W', 'T', 'D' }),
            new Stack<char>(new[] { 'C', 'P', 'H' }),
            new Stack<char>(new[] { 'W', 'P', 'H', 'N', 'D', 'G', 'M', 'J' }),
            new Stack<char>(new[] { 'C', 'W', 'S', 'N', 'T', 'Q', 'L' }),
            new Stack<char>(new[] { 'P', 'H', 'C', 'N' }),
            new Stack<char>(new[] { 'T', 'H', 'N', 'D', 'M', 'W', 'Q', 'B' }),
            new Stack<char>(new[] { 'M', 'B', 'R', 'J', 'G', 'S', 'L' }),
            new Stack<char>(new[] { 'Z', 'N', 'W', 'G', 'V', 'B', 'R', 'T' }),
            new Stack<char>(new[] { 'W', 'G', 'D', 'N', 'P', 'L', }),
        };
    }

    public static string PartA()
    {
        var moves = Moves.Select(x => Regex.Match(x, Reg).Groups)
            .Select(x => new Move
            {
                Quantity = Convert.ToInt32(x[1].Value),
                Source = Convert.ToInt32(x[2].Value),
                Destination = Convert.ToInt32(x[3].Value)
            });

        foreach (var move in moves)
        {
            for (var i = 0; i < move.Quantity; i++)
            {
                var value = Stacks[move.Source - 1].Pop();
                Stacks[move.Destination-1].Push(value);
            }
        }

        return new string(Stacks.Select(x => x.Pop()).ToArray());
    }
    
    public static string PartB()
    {
        var moves = Moves.Select(x => Regex.Match(x, Reg).Groups)
            .Select(x => new Move
            {
                Quantity = Convert.ToInt32(x[1].Value),
                Source = Convert.ToInt32(x[2].Value),
                Destination = Convert.ToInt32(x[3].Value)
            });

        foreach (var move in moves)
        {
            Stack<char> temp = new();
            for (var i = 0; i < move.Quantity; i++)
            {
                temp.Push(Stacks[move.Source - 1].Pop());
            }

            while (temp.Count > 0)
            {
                Stacks[move.Destination-1].Push(temp.Pop());
            }
        }

        return new string(Stacks.Select(x => x.Pop()).ToArray());
    }
}