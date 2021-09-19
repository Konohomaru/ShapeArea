using ShapeArea;

namespace ShapeAreaTests
{
    public class TriangleBuilder : EntityBuilder<Triangle, TriangleBuilder>
    {
        public TriangleBuilder WithSides(double a, double b, double c)
        {
            SetValue(nameof(Triangle.A), a);
            SetValue(nameof(Triangle.B), b);
            SetValue(nameof(Triangle.C), c);

            return this;
        }
        
        public override Triangle Build()
        {
            return new Triangle(
                GetValue<double>(nameof(Triangle.A)),
                GetValue<double>(nameof(Triangle.B)),
                GetValue<double>(nameof(Triangle.C)));
        }
    }
}