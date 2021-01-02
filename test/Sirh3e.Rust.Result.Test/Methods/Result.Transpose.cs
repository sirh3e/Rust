﻿using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Transpose()
        {
            var x = Result<Option<int>, string>.Ok(Option<int>.Some(5));
            var y = Option<Result<int, string>>.Some(Result<int, string>.Ok(5));

            x.Transpose().Equals(y).Should().BeTrue();
        }
    }
}