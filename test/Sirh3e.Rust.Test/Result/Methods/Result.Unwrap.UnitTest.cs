using System;
using FluentAssertions;
using Sirh3e.Rust.Panic;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Unwrap()
        {
            {
                var x = Result<uint, string>.Ok(2);

                x.IsErr.Should().BeFalse();
                x.IsOk.Should().BeTrue();

                x.Unwrap().Should().Be(2);
            }

            {
                var errorMessage = "emergency failure";
                var x = Result<uint, string>.Err(errorMessage);

                x.IsErr.Should().BeTrue();
                x.IsOk.Should().BeFalse();

                Action action = () => x.Unwrap();

                action.Should()
                    .ThrowExactly<PanicException>()
                    .WithMessage($"Cannot unwrap \"Ok\" when the result is \"Err\": {errorMessage}.");
            }

            {
                var errorMessage = "emergency failure";
                var x = Result<uint, string>.Err(errorMessage);

                x.IsErr.Should().BeTrue();
                x.IsOk.Should().BeFalse();

                Func<string, string> func = null;
                Action action = () => x.Unwrap(func);

                action.Should()
                    .ThrowExactly<ArgumentNullException>();
            }
        }
    }
}