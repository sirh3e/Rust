using FluentAssertions;
using Sirh3e.Rust.Result;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Or()
        {
            {
                var x = Option<int>.Some(2);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.Unwrap().Should().Be(2);

                var y = Option<int>.None;

                y.IsSome.Should().BeFalse();
                y.IsNone.Should().BeTrue();

                var option = x.Or(y);

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be(2);
            }

            {
                var x = Option<int>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                var y = Option<int>.Some(100);

                y.IsSome.Should().BeTrue();
                y.IsNone.Should().BeFalse();

                y.Unwrap().Should().Be(100);

                var option = x.Or(y);

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be(100);
            }
        }
    }
}