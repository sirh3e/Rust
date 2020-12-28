using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
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
    }
}