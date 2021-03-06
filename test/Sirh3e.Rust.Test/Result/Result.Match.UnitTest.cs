﻿using System;
using FluentAssertions;
using Sirh3e.Rust.Result;
using Xunit;

namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Match_Action()
        {
            {
                var result = Result<string, string>.Ok("foo");

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                result.Match(s =>
                {
                    s.Length.Should().Be(3);
                    s.Should().Be("foo");
                }, _ => throw new NotImplementedException());
            }

            {
                var result = Result<string, string>.Err("bar");

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.Match(_ => throw new NotImplementedException(), s =>
                {
                    s.Length.Should().Be(3);
                    s.Should().Be("bar");
                });
            }
        }

        [Fact]
        public void Result_Match_Func()
        {
            {
                var x = Parse("1909");

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                var year = x.Match(
                    o => o,
                    e => e.Length
                    );

                year.Should().Be(1909);
            }

            {
                var x = Parse("190blarg");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                var year = x.Match(
                    o => o,
                    e => e.Length
                );

                year.Should().Be(8);
            }

            {
                var x = Parse("1909");

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                Action action = () => x.Match(
                    null,
                    e => e.Length
                );

                action.Should().ThrowExactly<ArgumentNullException>();
            }

            {
                var x = Parse("190blarg");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                Action action = () => x.Match(
                    o => o,
                    null
                );

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}