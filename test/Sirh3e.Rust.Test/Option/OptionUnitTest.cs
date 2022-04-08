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
                var option = Option<string>.None;

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action action = () => option.Unwrap();
                action.Should().ThrowExactly<PanicException>();
            }

            {
                var option = Option<object>.None;

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action action = () => option.Unwrap();
                action.Should().ThrowExactly<PanicException>();
            }
        }

        [Fact]
        public void Option_Equals_None_None()
        {
            var x = Option<object>.None;
            var y = Option<object>.None;

            x.Equals(y).Should().BeTrue();
        }

        [Fact]
        public void Option_Equals_Object_None_Some()
        {
            var x = Option<object>.None;
            var y = Some("Marvin");

            x.Equals(y).Should().BeFalse();
        }

        [Fact]
        public void Option_Equals_Object_Some_None()
        {
            var x = Some("Marvin");
            var y = Option<object>.None;

            x.Equals(y).Should().BeFalse();
        }

        [Fact]
        public void Option_Equals_Object_Some_Some()
        {
            var x = Some("Marvin");
            var y = Some("Marvin");

            x.Equals(y).Should().BeTrue();
        }

        [Fact]
        public void Option_GetHashCode()
        {
            var x = Option<object>.None;
            var y = Option<object>.None;

            x.GetHashCode().Should().Be(y.GetHashCode());
        }

        [Fact]
        public void Option_Operator_Equals()
        {
            var x = Option<object>.None;
            var y = Option<object>.None;

            (x == y).Should().BeTrue();
        }

        [Fact]
        public void Option_Operator_Not_Equals()
        {
            var x = Option<object>.None;
            var y = Option<object>.None;

            (x != y).Should().BeFalse();
        }

        [Fact]
        public void Option_Implicit_Operator_None()
        {
            var none = None.Value;

            none.Should().As<Option<string>>().Should().BeEquivalentTo(Option<string>.None);
        }
    }
}