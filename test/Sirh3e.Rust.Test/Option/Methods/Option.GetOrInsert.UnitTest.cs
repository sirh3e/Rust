using System;
using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_GetOrInsert()
        {
            var option = Option<int>.None;

            option.IsNone.Should().BeTrue();
            option.IsSome.Should().BeFalse();

            option.GetOrInsert(5).Should().Be(5);
        }
    }
}