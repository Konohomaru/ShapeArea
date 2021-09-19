using System;
using System.Collections.Generic;
using ShapeArea;
using Xunit;
using static Xunit.Assert;

namespace ShapeAreaTests
{
    public class CircleTests
    {
        public static readonly IEnumerable<object[]> InvalidRadii = new[] {
            new object[] { -100 },
            new object[] { -0 },
            new object[] { 0 }
        };

        public static readonly IEnumerable<object[]> ValidRadii = new[] {
            new object[] { 1 },
            new object[] { .1 },
            new object[] { 1_000_000 }
        };

        [Theory]
        [MemberData(nameof(InvalidRadii))]
        public void ThrowExceptionIfInvalidRadius(double radius)
        {
            Throws<ArgumentException>(() => new Circle(radius));
        }

        [Theory]
        [MemberData(nameof(ValidRadii))]
        public void CreateInstanceIfValidRadius(double radius)
        {
            var circle = new Circle(radius);

            Equal(radius, circle.Radius);
        }

        [Fact]
        public void CorrectAreaForSpecifiedRadius()
        {
            var actualArea = new CircleBuilder()
                .WithRadius(1.784576525621695)
                .Build()
                .GetArea();
            
            Equal(10.005072145202432, actualArea);
        }
    }
}