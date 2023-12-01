namespace AdventOfCode2023;

internal class Sample
{
    private static readonly IEnumerable<string> Lines = File.ReadLines("Sample.txt");


    public static void Run()
    {
        Part1();
        Part2();
    }

    private static void Part2()
    {
        long sum = 0;
        foreach (var line in Lines)
        {
            var left = line.Take(line.Length / 2);
            var right = line.Skip(line.Length / 2);
            var x = left.Intersect(right).First();
            if (Char.IsLower(x))
                sum += (int)x - 96;
            else sum += x - 38;
        }

        Console.WriteLine(sum);
    }

    private static void Part1()
    {
        long sum = 0;
        var list = new List<string>(Lines);
        for (int i = 0; i < list.Count(); i += 3)
        {
            var items = list.Skip(i).Take(3).ToList();
            var left = items[0];
            var center = items[1];
            var right = items[2];
            var x = left.Intersect(center).Intersect(right).First();
            if (Char.IsLower(x))
                sum += (int)x - 96;
            else sum += x - 38;
        }

        Console.WriteLine(sum);
    }
}