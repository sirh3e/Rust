using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_MapOr()
        {
            {
                var x = Option<string>.Some("foo");

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.MapOr(42, s => s.Length).Should().Be(3);
            }

            {
                var x = Option<string>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                x.MapOr(42, s => s.Length).Should().Be(42);
            }
        }
    }
}