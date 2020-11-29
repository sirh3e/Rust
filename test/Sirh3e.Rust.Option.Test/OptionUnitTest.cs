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

        [Fact]
        public void Option_UnwrapOrElse()
        {
            {
                var k = 10;

                var option = Option<int>.Some(4);

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();
                
                option.UnwrapOrElse(() => k * 2).Should().Be(4);
            }
            
            {
                var k = 10;

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

                var someLenght = option.Map(s => s.Length);
                someLenght.Should().Be(Option<int>.Some(13));
            }
        }
    }
}