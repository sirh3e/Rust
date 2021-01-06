using System;
using FluentAssertions;
using Sirh3e.Rust.Result;
using Xunit;

namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_MapErr()
        {
            Func<uint, string> stringify = s => $"error code {s}";

            {
                var result = Result<uint, uint>.Ok(2);

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                var t = result.MapErr(stringify);
                t.IsOk.Should().BeTrue();
                t.IsErr.Should().BeFalse();

                t.Ok().IsSome.Should().BeTrue();
                t.Ok().IsNone.Should().BeFalse();

                t.Ok().Unwrap().Should().Be(2);
            }

            {
                var result = Result<uint, uint>.Err(13);

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                var t = result.MapErr(stringify);
                t.IsOk.Should().BeFalse();
                t.IsErr.Should().BeTrue();

                t.Err().IsSome.Should().BeTrue();
                t.Err().IsNone.Should().BeFalse();

                t.Err().Unwrap().Should().Be("error code 13");
            }

            {
                var result = Result<uint, uint>.Err(13);

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                Action action = () => result.MapErr(null as Func<uint, uint>);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}