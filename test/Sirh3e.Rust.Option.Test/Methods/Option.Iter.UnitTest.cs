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
                
                Action action = () => x.Iter();

                action.Should().ThrowExactly<NotImplementedException>(); //ToDo
            }
        }
    }
}