using System;
using static System.Math;

namespace ShapeArea
{
    public readonly struct Circle : IShapeArea
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentException(
                "Radius must be greater 0",
                nameof(radius));
            
            Radius = radius;
        }
        
        public double GetArea()
        {
            return PI * Pow(Radius, 2);
        }
    }
}