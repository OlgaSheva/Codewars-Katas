using System;

namespace Building_Spheres
{
    class Program
    {
        static void Main(string[] args)
        {
            Sphere ball = new Sphere(2, 50);
            Console.WriteLine(ball.GetVolume());
            Console.WriteLine(ball.GetSurfaceArea());
            Console.ReadKey();
        }
    }

    public class Sphere
    {
        int radius;
        int mass;

        public Sphere(int radius, int mass)
        {
            this.radius = radius;
            this.mass = mass;
        }

        public int GetRadius() { return radius; }
        public int GetMass() { return mass; }
        public double GetVolume() { return Math.Round(4 * Math.PI * Math.Pow(radius, 3) / 3, 5); }
        public double GetSurfaceArea() { return Math.Round(4 * Math.PI * radius* radius, 5); }
        public double GetDensity() { return Math.Round(mass / (4 * Math.PI * Math.Pow(radius, 3) / 3), 5); }
    }
}
