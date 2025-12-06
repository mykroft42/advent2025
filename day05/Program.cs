var lines = File.ReadAllLines("input.txt");

RangeList ranges = new RangeList();
bool start = false;
long total = 0;
foreach(var line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        start = true;
        continue;
    }

    if (!start)
    {
        var parts = line.Split('-').Select(long.Parse).ToArray();
        ranges.AddRange(parts[0], parts[1]);
    }
    else
    {
        var point = long.Parse(line);
        if (ranges.Ranges.Any(r => r.Contains(point)))
        {
            total++;
        }
    }
}

Console.WriteLine($"Total fresh points: {total}");
var totals = ranges.Ranges.Sum(r => r.End - r.Start + 1);
Console.WriteLine($"Total covered points: {totals}");