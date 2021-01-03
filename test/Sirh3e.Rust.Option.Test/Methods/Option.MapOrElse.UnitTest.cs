using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_MapOrElse()
        {
            var k = 21;
            {
                var x = Option<string>.Some("foo");

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.MapOrElse(() => 2 * k, s => s.Length).Should().Be(3);
            }

            {
                var x = Option<string>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                x.MapOrElse(() => 2 * k, s => s.Length).Should().Be(42);
            }
        }
    }
}