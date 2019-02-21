using System;
using System.Collections.Generic;
using System.Linq;

namespace Sortable_Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            double width, height, triangleBase, side, radius, area;
            Random random = new Random((int)DateTime.UtcNow.Ticks);

            var expected = new List<Shape>();

            area = 1.1234;
            expected.Add(new CustomShape(area));

            side = 1.1234;
            expected.Add(new Square(side));

            radius = 1.1234;
            expected.Add(new Circle(radius));

            triangleBase = 5;
            height = 2;
            expected.Add(new Triangle(triangleBase, height));

            height = 3;
            triangleBase = 4;
            expected.Add(new Triangle(triangleBase, height));

            width = 4;
            expected.Add(new Rectangle(width, height));

            area = 16.1;
            expected.Add(new CustomShape(area));


            var actual = expected.OrderBy(x => random.Next()).ToList();

            // Act
            actual.Sort();

            for (var i = 0; i < 5; i++)
                Console.WriteLine(expected[i] + " " + actual[i]);
        }
    }

    abstract class Shape : IComparable<Shape>
    {
        public virtual double Area()
        {
            return 0;
        }

        public int CompareTo(Shape s)
        {
            return this.Area().CompareTo(s.Area());
        }
    }

    class ShapesComparer : IComparer<Shape>
    {
        public int Compare(Shape s1, Shape s2)
        {
            if (s1.Area() > s2.Area())
                return 1;
            else if (s1.Area() < s2.Area())
                return -1;
            else
                return 0;
        }
    }

    class CustomShape : Shape
    {
        double area;

        public CustomShape(double area)
        {
            this.area = area;
        }
        public override double Area()
        {
            return area;
        }
    }

    class Square : Shape
    {
        double side;

        public Square(double side)
        {
            this.side = side;
        }

        public override double Area()
        {
            return side * side;
        }
    }

    class Rectangle : Shape
    {
        double width;
        double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double Area()
        {
            return width * height;
        }
    }

    class Triangle : Shape
    {
        double triangleBase;
        double height;

        public Triangle(double triangleBase, double height)
        {
            this.triangleBase = triangleBase;
            this.height = height;
        }

        public override double Area()
        {
            return triangleBase * (height/2);
        }
    }

    class Circle : Shape
    {
        double radius;

        public Circle (double radius)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return radius * radius * System.Math.PI;
        }
    }
}
