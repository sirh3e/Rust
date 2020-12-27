using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_IsErr()
        {
            {
                var x = Result<int, string>.Ok(-3);

                x.IsErr.Should().BeFalse();
            }

            {
                var x = Result<int, string>.Err("Some error message");

                x.IsErr.Should().BeTrue();
            }
        }
    }
}