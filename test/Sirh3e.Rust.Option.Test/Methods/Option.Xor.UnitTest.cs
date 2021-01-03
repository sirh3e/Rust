using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Xor()
        {
            {
                var x = Option<uint>.Some(2);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                var y = Option<uint>.None;

                y.IsSome.Should().BeFalse();
                y.IsNone.Should().BeTrue();

                var option = x.Xor(y);

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Should().BeEquivalentTo(Option<uint>.Some(2));
            }

            {
                var x = Option<uint>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                var y = Option<uint>.Some(2);

                y.IsSome.Should().BeTrue();
                y.IsNone.Should().BeFalse();

                var option = x.Xor(y);

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Should().BeEquivalentTo(Option<uint>.Some(2));
            }

            {
                var x = Option<uint>.Some(2);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                var y = Option<uint>.Some(2);

                y.IsSome.Should().BeTrue();
                y.IsNone.Should().BeFalse();

                var option = x.Xor(y);

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Should().BeEquivalentTo(Option<uint>.Some(2));
            }

            {
                var x = Option<uint>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                var y = Option<uint>.None;

                y.IsSome.Should().BeFalse();
                y.IsNone.Should().BeTrue();

                var option = x.Xor(y);

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                option.Should().BeEquivalentTo(Option<uint>.None);
            }
        }
    }
}