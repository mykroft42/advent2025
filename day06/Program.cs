var lines = File.ReadAllLines("input.txt").ToList();

var ops = lines.Last();
var opsList = ops.Split(" ").Where(s => !string.IsNullOrEmpty(s)).ToList();
opsList.Reverse();
lines.Remove(ops);
// var numbers = lines.Select(l => l.Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(s => long.Parse(s))).ToList();  

long total = 0;
// for (int i = 0; i < numbers[0].Count(); i++)
// {
//     if (opsList[i] == "+")
//     {
//         total += numbers.Sum(n => n.ElementAt(i));
//     }
//     else if (opsList[i] == "*")
//     {
//         total += numbers.Aggregate(1L, (acc, n) => acc * n.ElementAt(i));
//     }
// }
lines = lines.Select(l => new string(l.Reverse().ToArray())).ToList();
int opI = 0;
List<long> current = new List<long>();
for (int i = 0; i < lines[0].Length; i++)
{
    string col = new string(lines.Select(l => l.ElementAt(i)).ToArray()).Trim();
    if (string.IsNullOrEmpty(col))
    {
        if (opsList[opI] == "+")
        {
            total += current.Sum();
        }
        else if (opsList[opI] == "*")
        {
            total += current.Aggregate(1L, (acc, n) => acc * n);
        }
        opI++;
        current.Clear();
        continue;
    }

    current.Add(long.Parse(col));
}
 if (opsList[opI] == "+")
{
    total += current.Sum();
}
else if (opsList[opI] == "*")
{
    total += current.Aggregate(1L, (acc, n) => acc * n);
}
Console.WriteLine($"Total: {total}"); // 32844258621