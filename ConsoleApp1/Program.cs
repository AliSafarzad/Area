using System;
using System.Collections.Generic;

class Polygon
{
    private List<(double x, double y)> points;

    public Polygon()
    {
        points = new List<(double x, double y)>();
    }

    public void AddPoint(double x, double y)
    {
        points.Add((x, y));
    }

    public double CalculateArea()
    {
        int n = points.Count;
        if (n < 3)
        {
            throw new InvalidOperationException("A polygon must have at least 3 points.");
        }

        double area = 0;

        for (int i = 0; i < n - 1; i++)
        {
            area += points[i].x * points[i + 1].y - points[i].y * points[i + 1].x;
        }

        area += points[n - 1].x * points[0].y - points[n - 1].y * points[0].x;

        return Math.Abs(area) / 2.0;
    }
}

class TestPolygon
{
    static void Main()
    {
        Polygon polygon = new Polygon();

        Console.WriteLine("Enter the number of points:");
        int numberOfPoints = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPoints; i++)
        {
            Console.WriteLine($"Enter x and y for point {i + 1}:");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            polygon.AddPoint(x, y);
        }

        try
        {
            double area = polygon.CalculateArea();
            Console.WriteLine($"Area of the polygon is: {area}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
