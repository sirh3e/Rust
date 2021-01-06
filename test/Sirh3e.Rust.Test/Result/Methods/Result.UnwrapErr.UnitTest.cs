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
        public void Result_UnwrapErr()
        {
            {
                var x = Result<uint, string>.Ok(2);

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                Action action = () => x.UnwrapErr();

                action.Should()
                    .ThrowExactly<PanicException>()
                    .WithMessage("Cannot unwrap \"Err\" when the result is \"Ok\": 2.");
            }

            {
                var x = Result<uint, string>.Err("emergency failure");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                x.UnwrapErr().Should().Be("emergency failure");
            }

            {
                var x = Result<uint, string>.Err("emergency failure");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                Func<uint, string> func = null;

                Action action = () => x.UnwrapErr(func);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}