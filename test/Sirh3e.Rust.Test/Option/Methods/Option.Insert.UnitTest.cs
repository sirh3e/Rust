using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Insert()
        {
            var option = Option<int>.None;

            option.IsNone.Should().BeTrue();
            option.IsSome.Should().BeFalse();

            var value = option.Insert(1);
            
            option.IsNone.Should().BeFalse();
            option.IsSome.Should().BeTrue();

            option.Unwrap().Should().Be(1);
            value.Should().Be(1);

            value = option.Insert(2);
            
            option.IsNone.Should().BeFalse();
            option.IsSome.Should().BeTrue();

            option.Unwrap().Should().Be(2);
            value.Should().Be(2);
            
            value = option.Insert(3);
            
            option.IsNone.Should().BeFalse();
            option.IsSome.Should().BeTrue();

            option.Unwrap().Should().Be(3);
            value.Should().Be(3);
        }
    }
}