using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Flatten()
        {
            {
                var x = Option<Option<uint>>.Some(Option<uint>.Some(6));

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                var flatten = x.Flatten();

                flatten.IsSome.Should().BeTrue();
                flatten.IsNone.Should().BeFalse();

                flatten.Should().BeEquivalentTo(Option<uint>.Some(6));
            }

            {
                var x = Option<Option<uint>>.Some(Option<uint>.None);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                var flatten = x.Flatten();

                flatten.IsSome.Should().BeFalse();
                flatten.IsNone.Should().BeTrue();

                flatten.Should().BeEquivalentTo(Option<uint>.None);
            }

            {
                var x = Option<Option<uint>>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                var flatten = x.Flatten();

                flatten.IsSome.Should().BeFalse();
                flatten.IsNone.Should().BeTrue();

                flatten.Should().BeEquivalentTo(Option<uint>.None);
            }
        }
    }
}