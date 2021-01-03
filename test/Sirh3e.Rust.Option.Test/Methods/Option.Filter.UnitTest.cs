using System;
using FluentAssertions;
using Sirh3e.Rust.Panic;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Filter()
        {
            {
                var x = Option<uint>.Some(42);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                Action action = () => x.Expect("fruits are healthy");

                action.Should()
                    .ThrowExactly<PanicException>()
                    .WithMessage("fruits are healthy");
            }

            {
                var x = Option<uint>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                Action action = () => x.Expect("fruits are healthy");

                action.Should().NotThrow();
            }
        }
    }
}