using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_IsNone()
        {
            {
                var x = Option<uint>.Some(2);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();
            }

            {
                var x = Option<uint>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();
            }
        }
    }
}