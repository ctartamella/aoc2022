namespace aoc22;

public static class Day3
{
    private static readonly IEnumerable<string> File;

    public enum Values
    {
        a=1,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,
        A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z
    }
    
    static Day3()
    {
        File = System.IO.File.ReadLines("3.txt");
    }

    // Pretty straightforward.  Split the string in half then take the union.
    // I used the enum to map char values back to ints.  Note that I "seeded"
    // the value for 'a' to be 1 and they all increase from there.
    // Could have used ASCII values, but 'A' comes before 'a' in the table
    // so the logic to do so was more complex and frankly ugly.
    public static int PartA()
    {
        return File.Select(x =>
        {
            var midIndex = x.Length / 2;
            var part1 = x[..midIndex];
            var part2 = x[midIndex..];
            
            var intersection = part1.ToCharArray()
                .Intersect(part2.ToCharArray())
                .ToArray();
            
            return (int) Enum.Parse<Values>(intersection[0].ToString());
        }).Sum();
    }

    // I lowkey hate this solution because in 15 years ive NEVER written a
    // for statement like this in C#.  I feel like theres a better way, but
    // I can not figure out how to select 3 at a time, then skip ahead 3 in 
    // Linq.
    public static int PartB()
    {
        var data = File.ToArray();
        var sum = 0;
        for (var i = 0; i < data.Length; i += 3)
        {
            var member1 = data[i];
            var member2 = data[i+1];
            var member3 = data[i+2];

            var badge = member1.Intersect(member2).Intersect(member3).ToArray();
            sum += (int)Enum.Parse<Values>(badge.First().ToString());
        }

        return sum;
    }
}