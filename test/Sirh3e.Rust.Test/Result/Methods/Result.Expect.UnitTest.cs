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
        public void Result_Expect()
        {
            {
                var x = Result<uint, string>.Err("emergency failure");

                Action action = () => x.Expect("Testing expect");

                action.Should().ThrowExactly<PanicException>();
            }

            {
                var x = Result<uint, string>.Err("emergency failure");

                Action action = () => x.Expect(null);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}