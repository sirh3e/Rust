using System;
using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Filter()
        {
            {
                Func<int, bool> isEven = number => number % 2 == 0;

                Option<int>.None.Filter(isEven).Should().BeEquivalentTo(Option<int>.None);
                Option<int>.Some(3).Filter(isEven).Should().BeEquivalentTo(Option<int>.None);
                Option<int>.Some(4).Filter(isEven).Should().BeEquivalentTo(Option<int>.Some(4));
            }

            {
                Func<int, bool> isEven = null;

                Action action = () => Option<int>.Some(1).Filter(isEven);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}