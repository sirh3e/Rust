using System;
using FluentAssertions;
using Sirh3e.Rust.Panic;
using Sirh3e.Rust.Result;
using static Sirh3e.Rust.Result.Extension;
using Xunit;

namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Extension_Construct_From_Error()
        {
            Result<int, string> x = Err("Some error message");

            x.IsOk.Should().BeFalse();
            x.IsErr.Should().BeTrue();

            Action action = () => x.Ok().Unwrap();
            action.Should().ThrowExactly<PanicException>();

            x.Err().IsSome.Should().BeTrue();
            x.Err().IsNone.Should().BeFalse();

            x.Err().Unwrap().Should().Be("Some error message");
        }
    }
}