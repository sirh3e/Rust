﻿using System;
using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_OkOrElse()
        {
            {
                var x = Option<string>.Some("foo");

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                x.Unwrap().Should().Be("foo");

                var result = x.OkOrElse(() => 0);

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                result.Unwrap().Should().Be("foo");
            }

            {
                var x = Option<string>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                var result = x.OkOrElse(() => 0);

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.UnwrapErr().Should().Be(0);
            }

            {
                var x = Option<string>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                Action action = () => x.OkOrElse<string>(null);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}