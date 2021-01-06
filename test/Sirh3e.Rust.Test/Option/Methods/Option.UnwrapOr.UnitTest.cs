using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_UnwrapOr()
        {
            {
                var option = Option<string>.Some("car");

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.UnwrapOr("bike").Should().Be("car");
            }

            {
                var option = Option<string>.Some(null);

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                option.UnwrapOr("bike").Should().Be("bike");
            }
        }
    }
}