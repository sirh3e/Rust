using System;
using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
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
                    return new Point(x, y);
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
#if NET2_1_OR_GREATER
                return HashCode.Combine(X, Y);
#else
                //Thx to https://rehansaeed.com/gethashcode-made-easy/
                var hashCode = 17;

                hashCode = hashCode * 23 + X.GetHashCode();
                hashCode = hashCode * 23 + Y.GetHashCode();

                return hashCode;
#endif
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

        [Fact]
        public void Option_ZipWith_Helper_Point_Equals()
        {
            var x = new Point(412263.269, 399111.36);
            var y = new Point(412263.269, 399111.36);

            x.Equals(y).Should().BeTrue();
        }

        [Fact]
        public void Option_ZipWith_Helper_Point_Equals_Object()
        {
            var x = new Point(412263.269, 399111.36);
            var y = new Point(412263.269, 399111.36);

            x.Equals(y as object).Should().BeTrue();
        }

        [Fact]
        public void Option_ZipWith_Helper_Point_HashCode()
        {
            var x = new Point(412263.269, 399111.36);
            var y = new Point(412263.269, 399111.36);

            x.GetHashCode().Should().Be(y.GetHashCode());
        }

        [Fact]
        public void Option_ZipWith_Helper_Point_Operator_Equals()
        {
            var x = new Point(412263.269, 399111.36);
            var y = new Point(412263.269, 399111.36);

            (x == y).Should().BeTrue();
        }

        [Fact]
        public void Option_ZipWith_Helper_Point_Operator_Not_Equals()
        {
            var x = new Point(412263.269, 399111.36);
            var y = new Point(412263.269, 399111.36);

            (x != y).Should().BeFalse();
        }
    }
}