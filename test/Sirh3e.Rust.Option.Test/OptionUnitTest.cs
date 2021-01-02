using System;
using FluentAssertions;
using Sirh3e.Rust.Panic;
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
                var option = Option<string>.None;

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action action = () => option.Unwrap();
                action.Should().ThrowExactly<NotImplementedException>();
            }

            {
                var option = Option<object>.None;

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
                var option = Option<string>.None;

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action action = () => option.Unwrap();
                action.Should().ThrowExactly<PanicException>();
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

        [Fact]
        public void Option_UnwrapOrElse()
        {
            var k = 10;
            {
                var option = Option<int>.Some(4);

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.UnwrapOrElse(() => k * 2).Should().Be(4);
            }

            {
                var option = Option<int>.None; //ToDo

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                option.UnwrapOrElse(() => k * 2).Should().Be(20);
            }
        }

        [Fact]
        public void Option_Map()
        {
            {
                var option = Option<string>.Some("Hello, World!");

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                var lenght = option.Map(s => s.Length).Unwrap();
                lenght.Should().Be(13);
            }

            {
                var option = Option<string>.Some("Hello, World!");

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                var length = option.Map(s => s.Length).Unwrap(); //ToDo must be equal to rust doc
                length.Should().Be(13);
            }
        }

        [Fact]
        public void Option_MapOr()
        {
            {
                var x = Option<string>.Some("foo");

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.MapOr(42, s => s.Length).Should().Be(3);
            }

            {
                var x = Option<string>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                x.MapOr(42, s => s.Length).Should().Be(42);
            }
        }

        [Fact]
        public void Option_MapOrElse()
        {
            var k = 21;
            {
                var x = Option<string>.Some("foo");

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.MapOrElse(() => 2 * k, s => s.Length).Should().Be(3);
            }

            {
                var x = Option<string>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                x.MapOrElse(() => 2 * k, s => s.Length).Should().Be(42);
            }
        }
    }
}