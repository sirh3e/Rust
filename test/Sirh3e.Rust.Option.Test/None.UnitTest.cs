using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public class NoneUnitTest
    {
        [Fact]
        public void None_Equals()
        {
            var x = None.Value;
            var y = None.Value;

            x.Equals(y).Should().BeTrue();
        }

        [Fact]
        public void None_Equals_Object()
        {
            var x = None.Value;
            var y = None.Value;

            x.Equals(y as object).Should().BeTrue();
        }

        [Fact]
        public void None_GetHashCode()
        {
            var x = None.Value;
            var y = None.Value;

            x.GetHashCode().Should().Be(y.GetHashCode());
        }

        [Fact]
        public void None_Operator_Equals()
        {
            var x = None.Value;
            var y = None.Value;

            (x == y).Should().BeTrue();
        }

        [Fact]
        public void None_Operator_Not_Equals()
        {
            var x = None.Value;
            var y = None.Value;

            (x != y).Should().BeFalse();
        }
    }
}