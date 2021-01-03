using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Iter()
        {
            {
                var x = Option<uint>.Some(4);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.Iter().Current.Should().Be(4);
            }

            {
                var x = Option<uint>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                Func<uint> func = () => x.Iter().Current;

                func.Should().ThrowExactly<IndexOutOfRangeException>();
            }
        }
    }
}