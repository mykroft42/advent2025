var lines = File.ReadAllLines("input.txt");

List<Point> points = lines.Select(line => new Point(int.Parse(line.Split(',')[0]), int.Parse(line.Split(',')[1]), int.Parse(line.Split(',')[2]))).ToList();

List<DistanceSet> combine (Point p1, List<Point> p2)
 {
    if (p2.Count == 0) return new List<DistanceSet>();

    List<DistanceSet> result = new List<DistanceSet>();
    foreach(Point p in p2)
    {
        result.Add(new DistanceSet
        {
            Point1 = p1,
            Point2 = p,
            Distance = p1.DistanceTo(p),
        });
    }
    return result.Union(combine(p2.First(), p2.Skip(1).ToList())).ToList();
};

List<DistanceSet> distanceSets = combine(points.First(), points.Skip(1).ToList());
distanceSets = distanceSets.OrderBy(ds => ds.Distance).ToList();

//int num = 1000;
int num = distanceSets.Count;
long output = 0;
for (int i = 0; i < num; i++)
{
    var set = distanceSets[i];
    if (set.Point1.CircuitId == null || set.Point2.CircuitId == null)
    {
        if (set.Point1.CircuitId == null && set.Point2.CircuitId != null)
        {
            set.Point1.CircuitId = set.Point2.CircuitId;
        }
        else if (set.Point2.CircuitId == null && set.Point1.CircuitId != null)
        {
            set.Point2.CircuitId = set.Point1.CircuitId;
        }
        else
        {
            set.Point2.CircuitId = set.Point1.CircuitId = Guid.NewGuid();
        }
    }
    else
    {
        if (set.Point1.CircuitId == set.Point2.CircuitId)
        {
            //num++;
        }
        else
        {
            points.Where(p => p.CircuitId == set.Point2.CircuitId).ToList().ForEach(p => p.CircuitId = set.Point1.CircuitId);
        }
    }
    if (points.Select(p => p.CircuitId).Distinct().Count() == 1) 
    {
        output = set.Point1.X * set.Point2.X;
        break;
    }
}

// var counts = (from p in points
//               group p by p.CircuitId into g
//               select new { CircuitId = g.Key, Count = g.Count() }).ToList();
// counts = counts.Where(c => c.CircuitId != null).OrderByDescending(c => c.Count).ToList();

// int result = 1;
// for (int i = 0; i < 3; i++)
// {
//     result *= counts[i].Count;
// }

Console.WriteLine(output);