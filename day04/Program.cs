var rawlines = File.ReadAllLines("input.txt");
var lines = rawlines.Select(l => l.ToCharArray()).ToArray();
int prevTotal = -1;
int total = 0;
while (total != prevTotal)
{
    prevTotal = total;
    for (int y = 0; y < lines.Length; y++)
    {
        for (int x = 0; x < lines[y].Length; x++)
        {
            if (lines[y][x] == '.')
            {
                continue;
            }
            else if (lines[y][x] == '@')
            {
                int count = 0;
                if (y > 0 && x > 0 && lines[y - 1][x - 1] == '@') count++;
                if (y > 0 && lines[y - 1][x] == '@') count++;
                if (y > 0 && x < lines[y].Length - 1 && lines[y - 1][x + 1] == '@') count++;
                if (x > 0 && lines[y][x - 1] == '@') count++;
                if (x < lines[y].Length - 1 && lines[y][x + 1] == '@') count++;
                if (y < lines.Length - 1 && x > 0 && lines[y + 1][x - 1] == '@') count++;
                if (y < lines.Length - 1 && lines[y + 1][x] == '@') count++;
                if (y < lines.Length - 1 && x < lines[y].Length - 1 && lines[y + 1][x + 1] == '@') count++;

                if (count < 4)
                {
                    total++;
                    lines[y][x] = '.';
                }
            }
        }
    }
}
Console.WriteLine($"Total safe spots: {total}");