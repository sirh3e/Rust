﻿namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_ExpectErr()
        {
            {
                var x = Result<uint, string>.Ok(10);

                Action action = () => x.ExpectErr("Testing expect");

                action.Should().ThrowExactly<PanicException>();
            }

            {
                var x = Result<uint, string>.Ok(42);

                Action action = () => x.ExpectErr(null);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}