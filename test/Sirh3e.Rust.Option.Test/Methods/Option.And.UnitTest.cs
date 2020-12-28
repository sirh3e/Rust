using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_And()
        {
            {
                var x = Option<uint>.Some(2);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();
                
                var y = Option<string>.None;

                y.IsSome.Should().BeFalse();
                y.IsNone.Should().BeTrue();

                var option = x.And(y);
                
                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();
                
                option.UnwrapNone();
            }
        }
    }
}