using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_UnwrapOrElse()
        {
            var k = 10;
            {
                var option = Option<int>.Some(4);

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.UnwrapOrElse(() => k * 2).Should().Be(4);
            }

            {
                var option = Option<int>.None; //ToDo

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                option.UnwrapOrElse(() => k * 2).Should().Be(20);
            }
        }
    }
}