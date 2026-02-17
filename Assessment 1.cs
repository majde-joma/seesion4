using System;

struct Point
{
    public double X;
    public double Y;

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}

class Program
{
    static void Main()
    {
        // Define two points
        Point A = new Point(1, 2);
        Point B = new Point(4, 6);

        // Calculate Euclidean distance
        double distance = Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));

        Console.WriteLine($"Point A: ({A.X}, {A.Y})");
        Console.WriteLine($"Point B: ({B.X}, {B.Y})");
        Console.WriteLine($"The Euclidean distance is: {distance:F2}");
    }
}
