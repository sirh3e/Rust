using System;
using FluentAssertions;
using Sirh3e.Rust.Panic;
using Sirh3e.Rust.Result;
using Xunit;
using static Sirh3e.Rust.Result.Extension;

namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Extension_Construct_From_Ok()
        {
            Result<int, string> x = Ok(-3);

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
    }
}