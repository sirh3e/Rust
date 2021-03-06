﻿using FluentAssertions;
using Sirh3e.Rust.Option;
using Sirh3e.Rust.Result;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        private struct SomeOk { }
        private struct SomeErr { }

        [Fact]
        public void Option_Transpose()
        {
            {
                var x = Result<Option<int>, SomeErr>.Ok(Option<int>.Some(5));
                var y = Option<Result<int, SomeErr>>.Some(Result<int, SomeErr>.Ok(5));

                x.Should().BeEquivalentTo(y.Transpose());
            }

            {
                var x = Result<Option<SomeOk>, int>.Err(5);
                var y = Option<Result<SomeOk, int>>.Some(Result<SomeOk, int>.Err(5));

                x.Should().BeEquivalentTo(y.Transpose());
            }

            {
                var x = Result<Option<int>, SomeErr>.Ok(Option<int>.None);
                var y = Option<Result<int, SomeErr>>.None;

                x.Should().BeEquivalentTo(y.Transpose());
            }
        }
    }
}