var input = File.ReadAllLines("input.txt");

long total = 0;
foreach(var line in input)
{
    var numbers  = line.Select(c => int.Parse(c.ToString())).ToList();
    int[] digits = new int[12];
    for(int i = 0; i < numbers.Count; i++)
    {
        var n = numbers[i];
        for (int j = 0; j < digits.Length; j++)
        {
            if (n > digits[j] && i <= numbers.Count - (digits.Length - j))
            {
                digits[j] = n;
                for (int k = j +1; k < digits.Length; k++)
                {
                    digits[k] = 0;
                }
                j = digits.Length;
            }
        }
    }
    total += long.Parse(string.Join("", digits));
}

Console.WriteLine($"Total sum of all line scores: {total}");