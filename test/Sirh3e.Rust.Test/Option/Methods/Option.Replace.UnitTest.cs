using System;
using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Replace()
        {
            Action action = () => Option<int>.Some(69).Replace(42);
            action.Should().ThrowExactly<NotImplementedException>(); //ToDo Implement
            /*
            {
                var x = Option<int>.Some(2);
                
                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.Unwrap().Should().Be(5);

                var old = x.Replace(5);

                old.IsSome.Should().BeTrue();
                old.IsNone.Should().BeFalse();

                old.Unwrap().Should().Be(5);
            }
            
            {
                var x = Option<int>.None;
                
                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                var old = x.Replace(3);

                old.IsSome.Should().BeFalse();
                old.IsNone.Should().BeTrue();
                
                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                x.Unwrap().Should().Be(3);
            }
            */
        }
    }
}