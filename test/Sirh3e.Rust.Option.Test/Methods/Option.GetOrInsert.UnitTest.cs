using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_GetOrInsert()
        {
            var option = Option<int>.None;

            Action action = () => option.GetOrInsert(5);

            action.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}