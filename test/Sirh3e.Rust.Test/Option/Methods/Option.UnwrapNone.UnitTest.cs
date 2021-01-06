using System;
using FluentAssertions;
using Sirh3e.Rust.Option;
using Sirh3e.Rust.Panic;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_UnwrapNone()
        {
            {
                var option = Option<string>.None;

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action action = () => option.UnwrapNone();

                action.Should().NotThrow();
            }

            {
                var option = Option<string>.Some("liegens");

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                Action action = () => option.UnwrapNone();

                action.Should().ThrowExactly<PanicException>();
            }
        }
    }
}