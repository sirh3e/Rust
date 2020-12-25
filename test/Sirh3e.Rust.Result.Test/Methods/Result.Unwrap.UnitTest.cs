using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Unwrap()
        {
            {
                var x = Result<uint, string>.Ok(2);

                x.IsErr.Should().BeFalse();
                x.IsOk.Should().BeTrue();

                x.Unwrap().Should().Be(2);
            }

            {
                var x = Result<uint, string>.Err("emergency failure");

                x.IsErr.Should().BeTrue();
                x.IsOk.Should().BeFalse();

                x.Unwrap();
            }
        }
    }
}