using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_OrElse()
        {
            Func<uint, Result<uint, uint>> sq = input => Result<uint, uint>.Ok(input * input);
            Func<uint, Result<uint, uint>> err = Result<uint, uint>.Err;

            {
                Result<uint, uint>.Ok(2).OrElse(sq).OrElse(sq).Should().Be(Result<uint, uint>.Ok(2));
                Result<uint, uint>.Ok(2).OrElse(err).OrElse(sq).Should().Be(Result<uint, uint>.Ok(2));
                Result<uint, uint>.Err(3).OrElse(sq).OrElse(err).Should().Be(Result<uint, uint>.Ok(9));
                Result<uint, uint>.Err(3).OrElse(err).OrElse(err).Should().Be(Result<uint, uint>.Err(3));
            }

            {

                Func<uint, Result<uint, uint>> func = null;
                Action action = () => Result<uint, uint>.Ok(2).OrElse(func);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}