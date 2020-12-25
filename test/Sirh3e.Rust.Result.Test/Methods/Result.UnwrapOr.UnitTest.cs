using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_UnwrapOr()
        {
            uint @default = 2;
            {
                var x = Result<uint, string>.Ok(9);

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                x.UnwrapOr(@default).Should().Be(9);
            }

            {
                var x = Result<uint, string>.Err("error");

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                x.UnwrapOr(@default).Should().Be(2);
            }
        }
    }
}