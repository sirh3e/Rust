using System;
using FluentAssertions;
using Sirh3e.Rust.Panic;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Construct_From_Ok()
        {
            var x = Result<int, string>.Ok(-3);

            x.IsOk.Should().BeTrue();
            x.IsErr.Should().BeFalse();

            x.Ok().IsSome.Should().BeTrue();
            x.Ok().IsNone.Should().BeFalse();

            x.Ok().Unwrap().Should().Be(-3);

            x.Err().IsSome.Should().BeFalse();
            x.Err().IsNone.Should().BeTrue();

            Action action = () => x.Err().Unwrap();
            action.Should().ThrowExactly<PanicException>();
        }

        [Fact]
        public void Result_Construct_From_Error()
        {
            var x = Result<int, string>.Err("Some error message");

            x.IsOk.Should().BeFalse();
            x.IsErr.Should().BeTrue();

            Action action = () => x.Ok().Unwrap();
            action.Should().ThrowExactly<PanicException>();

            x.Err().IsSome.Should().BeTrue();
            x.Err().IsNone.Should().BeFalse();

            x.Err().Unwrap().Should().Be("Some error message");
        }

        [Fact]
        public void Result_Operator_Equals()
        {
            var x = Result<string, int>.Ok("liegens");
            var y = Result<string, int>.Ok("liegens");

            (x == y).Should().BeTrue();
        }

        [Fact]
        public void Result_Operator_Not_Equals()
        {
            var x = Result<string, int>.Ok("liegens");
            var y = Result<string, int>.Ok("liegens");

            (x != y).Should().BeFalse();
        }
    }
}