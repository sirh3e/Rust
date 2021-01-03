using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_MapOr()
        {
            {
                var result = Result<string, string>.Ok("foo");

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                result.MapOr(42, s => s.Length).Should().Be(3);
            }

            {
                var result = Result<string, string>.Err("foo");

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.MapOr(42, s => s.Length).Should().Be(42);
            }

            {
                var result = Result<string, string>.Err("foo");

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                Action action = () => result.MapOr(null, s => s);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}