using System;
using FluentAssertions;
using Sirh3e.Rust.Panic;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_ExpectNone()
        {
            {
                var x = Option<string>.Some("air");

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                Action action = () => x.Unwrap();

                action.Should().NotThrow();
            }

            {
                var x = Option<string>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                Action action = () => x.Expect("fruits are healthy");

                action.Should()
                    .ThrowExactly<PanicException>()
                    .WithMessage("fruits are healthy");
            }
        }
    }
}