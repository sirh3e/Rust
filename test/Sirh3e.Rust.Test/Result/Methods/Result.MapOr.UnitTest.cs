using System;
using FluentAssertions;
using Sirh3e.Rust.Result;
using Xunit;

namespace Sirh3e.Rust.Test.Result
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

            {
                var result = Result<string, string>.Ok("foo");

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                Func<string, string> func = null;

                Action action = () => result.MapOr("liegens", func);

                action.Should().ThrowExactly<ArgumentNullException>();
            }

            {
                var result = Result<string, string>.Ok("foo");

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                Func<string, int> map = null;

                Action action = () => result.MapOr(42, map);

                action.Should().ThrowExactly<ArgumentNullException>();
            }

            {
                var result = Result<string, string>.Err("foo");

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                Func<string, int> @default = null;

                Action action = () => result.MapOr(@default, _ => throw new NotImplementedException());

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}