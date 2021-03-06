﻿using System;
using FluentAssertions;
using Sirh3e.Rust.Option;
using Sirh3e.Rust.Panic;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
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
                action.Should().ThrowExactly<PanicException>();
            }

            {
                var option = Option<string>.None;

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action action = () => option.Unwrap(null as string);

                action.Should().ThrowExactly<ArgumentNullException>();
            }

            {
                var option = Option<string>.None;

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Func<string> func = null;
                Action action = () => option.Unwrap(func);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}