using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Contains()
        {
            {
                var x = Option<uint>.Some(2);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.Contains(2).Should().BeTrue();
            }

            {
                var x = Option<uint>.Some(3);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.Contains(2).Should().BeFalse();
            }

            {
                var x = Option<uint>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                x.Contains(2).Should().BeFalse();
            }
        }
    }
}