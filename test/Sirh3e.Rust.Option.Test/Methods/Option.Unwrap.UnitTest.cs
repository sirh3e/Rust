using System;
using FluentAssertions;
using Sirh3e.Rust.Panic;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Unwrap()
        {
            {
                var option = Option<string>.Some("air");

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be("air");
            }

            {
                var option = Option<string>.None;

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action action = () => option.Unwrap();
                action.Should().ThrowExactly<PanicException>();
            }
        }
    }
}