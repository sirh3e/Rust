using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Zip()
        {
            var x = Option<uint>.Some(1);

            x.IsSome.Should().BeTrue();
            x.IsNone.Should().BeFalse();

            var y = Option<string>.Some("hi");

            y.IsSome.Should().BeTrue();
            y.IsNone.Should().BeFalse();

            var z = Option<byte>.None;

            z.IsSome.Should().BeFalse();
            z.IsNone.Should().BeTrue();

            var option = x.Zip(y);

            option.Should().BeEquivalentTo(Option<(uint, string)>.Some((1, "hi")));
            x.Zip(z).Should().BeEquivalentTo(Option<(uint, byte)>.None);
        }
    }
}