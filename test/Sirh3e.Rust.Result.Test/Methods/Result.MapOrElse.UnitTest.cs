using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_MapOrElse()
        {
            var k = 21;
            {
                var result = Result<string, string>.Ok("foo");

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                result.MapOrElse(s => k * 2, s => s.Length).Should().Be(3);
            }

            {
                var result = Result<string, string>.Err("bar");

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.MapOrElse(s => k * 2, s => s.Length).Should().Be(42);
            }

            {
                var result = Result<string, string>.Ok("foo");

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                Func<string, int> map = null;

                Action action = () => result.MapOrElse(s => k * 2, map);

                action.Should().ThrowExactly<ArgumentNullException>();
            }

            {
                var result = Result<string, string>.Err("foo");

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                Func<string, int> @default = null;

                Action action = () => result.MapOrElse(@default, _ => throw new NotImplementedException());

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}