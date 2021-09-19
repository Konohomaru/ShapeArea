using System;
using System.Collections.Generic;
using ShapeArea;
using Xunit;
using static Xunit.Assert;

namespace ShapeAreaTests
{
    public class TriangleTests
    {
        public static readonly IEnumerable<object[]> InvalidSides = new[] {
            new object[] { -100, -100, -100 },
            new object[] { -100,    1,    1 },
            new object[] {    1, -100,    1 },
            new object[] {    1,    1, -100 },
            new object[] { 0, 0, 0 },
            new object[] { 0, 1, 1 },
            new object[] { 1, 0, 1 },
            new object[] { 1, 1, 0 },
            new object[] { 2, 3, 5 },
            new object[] { 2, 5, 3 },
            new object[] { 5, 2, 3 },
            new object[] { 2, 3, 6 },
            new object[] { 2, 6, 3 },
            new object[] { 6, 2, 3 }
        };

        public static readonly IEnumerable<object[]> ValidSides = new[] {
            new object[] { 1, 1, 1 },
            new object[] { 2, 3, 4 },
            new object[] { .5, .5, .7 }
        };
        
        [Theory]
        [MemberData(nameof(InvalidSides))]
        public void ThrowExceptionIfInvalidSides(double a, double b, double c)
        {
            Throws<ArgumentException>(() => new Triangle(a, b, c));
        }

        [Theory]
        [MemberData(nameof(ValidSides))]
        public void CreateInstanceIfValidSides(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            
            Equal(a, triangle.A);
            Equal(b, triangle.B);
            Equal(c, triangle.C);
        }

        [Fact]
        public void CorrectAreaForSpecifiedSides()
        {
            var actualArea = new TriangleBuilder()
                .WithSides(3, 4, 5)
                .Build()
                .GetArea();

            Equal(6, actualArea);
        }

        [Fact]
        public void TrueIfRectangular()
        {
            var isActualRectangular = new TriangleBuilder()
                .WithSides(3, 4, 5)
                .Build()
                .IsRectangular();

            True(isActualRectangular);
        }

        [Fact]
        public void FalseIfNotRectangular()
        {
            var isActualRectangular = new TriangleBuilder()
                .WithSides(1, 1, 1)
                .Build()
                .IsRectangular();

            False(isActualRectangular);
        }
    }
}