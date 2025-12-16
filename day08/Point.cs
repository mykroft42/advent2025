public class Point
{
    public Guid? CircuitId { get; set; } = null;

    public long X { get; set; }
    public long Y { get; set; }
    public long Z { get; set; }

    public Point(long x, long y, long z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public double DistanceTo(Point other)
    {
        long dx = X - other.X;
        long dy = Y - other.Y;
        long dz = Z - other.Z;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Point other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }
        return false;
    }

    public override int GetHashCode()       
    {
        return HashCode.Combine(X, Y, Z);
    }

    public static bool operator ==(Point a, Point b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }
        if (a is null || b is null)
        {
            return false;
        }
        return a.Equals(b);
    }

    public static bool operator !=(Point a, Point b)
    {
        return !(a == b);
    }
}