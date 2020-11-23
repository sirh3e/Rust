using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public class OptionUnitTest
    {
        [Fact]
        public void Option_Construct_Some_FromValue()
        {
            {
                var option = Option<string>.Some("liegens");

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be("liegens");
            }

            {
                var option = Option<int>.Some(42);

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be(42);
            }
        }

        [Fact]
        public void Option_Construct_None_FromNull()
        {
            {
                var option = Option<string>.Some(null);

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action action = () => option.Unwrap();
                action.Should().ThrowExactly<NotImplementedException>();
            }

            {
                var option = Option<object>.Some(null);

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action action = () => option.Unwrap();
                action.Should().ThrowExactly<NotImplementedException>();
            }
        }

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
                var option = Option<string>.Some(null);

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action action = () => option.Unwrap();
                action.Should().ThrowExactly<NotImplementedException>();
            }
        }

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