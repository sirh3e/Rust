using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        private struct Point : IEquatable<Point>
        {
            public readonly double X;
            public readonly double Y;

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public struct Factory
            {
                public static Point New(double x, double y)
                {
                    return new(x, y);
                }
            }

            public bool Equals(Point other)
            {
                return X.Equals(other.X) && Y.Equals(other.Y);
            }

            public override bool Equals(object obj)
            {
                return obj is Point other && Equals(other);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }

            public static bool operator ==(Point left, Point right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Point left, Point right)
            {
                return !left.Equals(right);
            }
        }

        [Fact]
        public void Option_ZipWith()
        {
            var x = Option<double>.Some(17.5);

            x.IsSome.Should().BeTrue();
            x.IsNone.Should().BeFalse();

            var y = Option<double>.Some(42.7);

            y.IsSome.Should().BeTrue();
            y.IsNone.Should().BeFalse();

            x.ZipWith(y, Point.Factory.New).Should().BeEquivalentTo(Option<Point>.Some(new Point(17.5, 42.7)));
            x.ZipWith(Option<double>.None, Point.Factory.New).Should().BeEquivalentTo(Option<Point>.None);
        }
    }
}