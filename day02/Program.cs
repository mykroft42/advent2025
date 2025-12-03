var input = File.ReadAllLines("input.txt");

long total = 0;
foreach(var line in input)
{
    var ranges = line.Split(',');
    foreach(var range in ranges)
    {
        var bounds = range.Split('-');
        var start = long.Parse(bounds[0]);
        var end = long.Parse(bounds[1]);
        for (long i = start; i <= end; i++)
        {
            string s = i.ToString();
            for (int j = 1; j <= s.Length / 2; j++)
            {
                if (s.Length % j != 0)
                    continue;

                List<string> parts = new List<string>();
                for (int k = 0; k < s.Length; k+= j)
                {
                    parts.Add(s.Substring(k, j));
                }
                
                if (parts.All(p => p == parts[0]))
                {
                    total += i;
                    break;
                }
            }
        }
    }
}

Console.WriteLine($"Total sum of all matching numbers: {total}");
