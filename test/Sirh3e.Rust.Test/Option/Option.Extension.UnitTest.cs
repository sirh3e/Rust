using FluentAssertions;
using Xunit;
using static Sirh3e.Rust.Option.Extension;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Extension_Construct_Some_FromValue()
        {
            {
                var option = Some("liegens");

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be("liegens");
            }

            {
                var option = Some(42);

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be(42);
            }
        }
    }
}