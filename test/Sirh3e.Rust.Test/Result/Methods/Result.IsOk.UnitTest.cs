using FluentAssertions;
using Sirh3e.Rust.Result;
using Xunit;

namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_IsOk()
        {
            {
                var x = Result<int, string>.Ok(-3);

                x.IsOk.Should().BeTrue();
            }

            {
                var x = Result<int, string>.Err("Some error message");

                x.IsOk.Should().BeFalse();
            }
        }
    }
}