var lines = File.ReadAllLines("input.txt").ToList();

List<long> beamIndexes = new List<long>();
Dictionary<long, long> beams = new Dictionary<long, long>();
beams[lines[0].IndexOf('S')] = 1;
lines.RemoveAt(0);

int beamHit = 0;
foreach (var line in lines)
{
    List<long> indices = beams.Keys.ToList();
    foreach (long index in indices)
    {
        if (line[(int)index] == '^')
        {
            beamHit++;
            if (!beams.ContainsKey(index + 1))
            {
                beams[index + 1] = 0;
            }
            if (!beams.ContainsKey(index - 1))
            {
                beams[index - 1] = 0;
            }
            beams[index + 1] += beams[index];
            beams[index - 1] += beams[index];
            beams[index] = 0;
        }
    }
}

Console.WriteLine($"Total beam hits: {beamHit}");
Console.WriteLine($"Total beams: {beams.Values.Sum()}");