// See https://aka.ms/new-console-template for more information
var input = File.ReadAllLines("input.txt");

int dial = 50;
int zeroes = 0;
foreach(var line in input)
{
    //Console.WriteLine(line);
    var dir = line[0];
    var dist = int.Parse(line[1..]);
    if (dir == 'R')
    {
        dial += dist;
        if (dial >= 100)
            zeroes += dial / 100;
    }
    else if (dir == 'L')
    {
        var prev = dial;
        dial -= dist;
        if (dial <= 0)
        {
            zeroes += 1 + ((-1 * dial) / 100);
        }

        if (prev == 0)
            zeroes -= 1;
    }
    dial = dial % 100;
    if (dial < 0)
        dial += 100;
    
    Console.WriteLine($"After moving {dir}{dist}, dial is at {dial}");
    Console.WriteLine($"Dial position: {dial}");
    Console.WriteLine($"Number of times dial hit zero: {zeroes}");
}

Console.WriteLine($"Final dial position: {dial}");
Console.WriteLine($"Number of times dial hit zero: {zeroes}");