using System.Text;

namespace AdventOfCode2023;

internal class Day01
{
    private static readonly IEnumerable<string> Lines = File.ReadLines("Day01.txt");
    private static readonly IEnumerable<string> SampleLines = File.ReadLines("Day01Sample.txt");

    private static readonly IDictionary<string, string> DigitSegments = new Dictionary<string, string>
    {
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"}
    };

    public static void Run()
    {
        Part1(Lines);
        Part2(Lines);
    }

    private static void Part1(IEnumerable<string> lines)
    {
        Console.WriteLine(lines.Sum(ExtractDigits));
    }

    private static void Part2(IEnumerable<string> lines)
    {
        Console.WriteLine(lines.Sum(line => ExtractDigits(Clean(line))));
    }

    private static int ExtractDigits(string s)
    {
         var chars = s.Where(char.IsDigit).ToList();
        return int.Parse(new string(new[] {chars.First(), chars.Last()}));
    }

    private static string Clean(string input)
    {
        var stringBuilder = new StringBuilder();
        for (int index = 0; index < input.Length; index++)
        {
            var substring = input[index..];
            var firstCharacter = substring[0];
            if (char.IsDigit(firstCharacter))
                stringBuilder.Append(firstCharacter);
            else
                foreach (var keyValuePair in DigitSegments)
                    if (substring.StartsWith(keyValuePair.Key))
                    {
                        stringBuilder.Append(keyValuePair.Value);
                        break;
                    }
        }
        return stringBuilder.ToString();
    }
}