﻿using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Take()
        {
            {
                var x = Option<int>.Some(2);

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.Unwrap().Should().Be(2);

                var y = x.Take();

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                y.IsSome.Should().BeTrue();
                y.IsNone.Should().BeFalse();

                y.Unwrap().Should().Be(2);
            }

            {
                var x = Option<int>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                var y = x.Take();

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                y.IsSome.Should().BeFalse();
                y.IsNone.Should().BeTrue();
            }
        }
    }
}