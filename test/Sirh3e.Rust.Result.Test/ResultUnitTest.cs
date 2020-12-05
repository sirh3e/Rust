using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public class ResultUnitTest
    {
        [Fact]
        public void Result_Construct()
        {
            var result = Result<string, string>.Ok("1");
            var rr = result.Match(Convert.ToInt32, s => s);

            rr.Should().Be(1);
        }
    }
}