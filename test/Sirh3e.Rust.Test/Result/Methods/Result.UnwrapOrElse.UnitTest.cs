using System;
using FluentAssertions;
using Sirh3e.Rust.Result;
using Xunit;

namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_UnwrapOrElse()
        {
            {
                Func<string, int> count = s => s.Length;

                Result<int, string>.Ok(2)
                    .UnwrapOrElse(count)
                    .Should().Be(2);

                Result<int, string>.Err("foo")
                    .UnwrapOrElse(count)
                    .Should().Be(3);
            }

            {
                Func<string, int> count = null;

                Action action = () => Result<int, string>.Err("foo")
                    .UnwrapOrElse(count);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}