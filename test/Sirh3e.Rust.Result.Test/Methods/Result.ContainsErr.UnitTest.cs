using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_ContainsErr()
        {
            {
                var x = Result<uint, string>.Ok(2);

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                x.ContainsErr("Some error message")
                    .Should()
                    .BeFalse();
            }

            {
                var x = Result<uint, string>.Err("Some error message");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                x.ContainsErr("Some error message")
                    .Should()
                    .BeTrue();
            }

            {
                var x = Result<uint, string>.Err("Some other error message");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                x.ContainsErr("Some other error message")
                    .Should()
                    .BeTrue();
            }
        }
    }
}