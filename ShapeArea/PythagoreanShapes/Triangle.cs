using System;
using static System.Math;

namespace ShapeArea
{
    public readonly struct Triangle : IShapeArea
    {
        public double A { get; }
        
        public double B { get; }
        
        public double C { get; }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0
                || a + b <= c && a < c && b < c
                || a + c <= b && a < b && c < b
                || b + c <= a && b < a && c < a)
                throw new ArgumentException("Invalid side values");
            
            A = a;
            B = b;
            C = c;
        }
        
        public double GetArea()
        {
            var semi = (A + B + C) / 2;
            return Sqrt(semi * (semi - A) * (semi - B) * (semi - C));
        }

        public bool IsRectangular()
        {
            var powA = Pow(A, 2);
            var powB = Pow(B, 2);
            var powC = Pow(C, 2);

            if ((powA + powB).CompareTo(powC) == 0) return true;
            if ((powA + powC).CompareTo(powB) == 0) return true;
            if ((powB + powC).CompareTo(powA) == 0) return true;

            return false;
        }
    }
}