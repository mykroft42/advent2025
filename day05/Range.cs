public class Range
{
    public long Start { get; set; }
    public long End { get; set; }

    public Range(long start, long end)
    {
        Start = start;
        End = end;
    }

    public bool Contains(long point)
    {
        return point >= Start && point <= End;
    }
}

public class RangeList
{
    public readonly List<Range> Ranges = new List<Range>();
    public void AddRange(long start, long end)
    {
        Ranges.Where(r => r.Start >= start && r.End <= end).ToList().ForEach(r => Ranges.Remove(r));
        var lowerRange = Ranges.SingleOrDefault(r => r.Contains(start));
        var upperRange = Ranges.SingleOrDefault(r => r.Contains(end));
        if (lowerRange == null && upperRange == null)
        {
            Ranges.Add(new Range(start, end));
        }
        else if (lowerRange == upperRange)
        {
            return;
        }
        else if (lowerRange != null && upperRange == null)
        {
            lowerRange.End = Math.Max(lowerRange.End, end);
        }
        else if (lowerRange == null && upperRange != null)
        {
            upperRange.Start = Math.Min(upperRange.Start, start);
        }
        else if (lowerRange != null && upperRange != null)
        {
            lowerRange.End = Math.Max(lowerRange.End, upperRange.End);
            Ranges.Remove(upperRange);
        }
    }
}