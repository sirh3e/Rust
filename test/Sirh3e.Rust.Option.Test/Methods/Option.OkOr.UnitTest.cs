using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_OkOr()
        {
            {
                var x = Option<string>.Some("foo");

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.Unwrap().Should().Be("foo");

                var result = x.OkOr(0);

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                result.Unwrap().Should().Be("foo");
            }

            {
                var x = Option<string>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                var result = x.OkOr(0);

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.UnwrapErr().Should().Be(0);
            }
        }
    }
}