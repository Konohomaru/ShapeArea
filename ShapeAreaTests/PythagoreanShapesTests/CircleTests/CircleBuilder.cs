using ShapeArea;

namespace ShapeAreaTests
{
    public class CircleBuilder : EntityBuilder<Circle, CircleBuilder>
    {
        public CircleBuilder WithRadius(double radius)
        {
            return SetValue(nameof(Circle.Radius), radius);
        }

        public override Circle Build()
        {
            return new Circle(GetValue<double>(nameof(Circle.Radius)));
        }
    }
}