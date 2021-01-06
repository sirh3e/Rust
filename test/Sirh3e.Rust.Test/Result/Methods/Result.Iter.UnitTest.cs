using System;
using FluentAssertions;
using Sirh3e.Rust.Result;
using Xunit;

namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Iter()
        {
            {
                var x = Result<uint, string>.Ok(7);

                x.Iter().Current.Should().Be(7);
            }

            {
                var x = Result<uint, string>.Err("nothing!");

                Func<uint> action = () => x.Iter().Current;

                action.Should().ThrowExactly<IndexOutOfRangeException>();
            }
        }
    }
}