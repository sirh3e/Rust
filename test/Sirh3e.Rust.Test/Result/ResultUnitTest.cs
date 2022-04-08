using System;
using FluentAssertions;
using Sirh3e.Rust.Panic;
using Sirh3e.Rust.Result;
using Xunit;

namespace Sirh3e.Rust.Test.Result
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
        public void Result_Equals()
        {
            var x = Result<string, int>.Ok("liegens");
            var y = Result<string, int>.Ok("liegens");

            x.Equals(y).Should().BeTrue();
        }

        [Fact]
        public void Result_Not_Equals()
        {
            var x = Result<string, int>.Ok("liegens");
            var y = Result<string, int>.Err("liegens".Length);

            x.Equals(y).Should().BeFalse();
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

        [Fact]
        public void Result_GetHashCode()
        {
            var x = Result<string, int>.Ok("liegens");
            var y = Result<string, int>.Ok("liegens");

            x.GetHashCode().Should().Be(y.GetHashCode());
        }

        [Fact]
        public void Result_Implicit_Operator_Ok()
        {
            Result<int, int> ok = Ok(1);

            ok.Should().As<Result<int, int>>().Should().BeEquivalentTo(Result<int, int>.Ok(1));

            ok.IsOk.Should().BeTrue();
            ok.IsErr.Should().BeFalse();

            ok.Unwrap().Should().Be(1);
        }

        [Fact]
        public void Result_Implicit_Operator_Err()
        {
            Result<int, int> err = Err(1);

            err.Should().As<Result<int, int>>().Should().BeEquivalentTo(Result<int, int>.Err(1));

            err.IsOk.Should().BeFalse();
            err.IsErr.Should().BeTrue();

            err.UnwrapErr().Should().Be(1);
        }
    }
}