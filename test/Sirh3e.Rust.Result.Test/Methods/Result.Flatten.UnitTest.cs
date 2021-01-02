using FluentAssertions;
using Sirh3e.Rust.Result.Extensions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Flatten()
        {
            {
                var x = Result<Result<string, uint>, uint>.Ok(Result<string, uint>.Ok("hello"));

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                var flattenResult = x.Flatten();

                flattenResult.IsOk.Should().BeTrue();
                flattenResult.IsErr.Should().BeFalse();

                flattenResult.Should().BeEquivalentTo(Result<string, uint>.Ok("hello"));
            }

            {
                var x = Result<Result<string, uint>, uint>.Ok(Result<string, uint>.Err(6));

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                var flattenResult = x.Flatten();

                flattenResult.IsOk.Should().BeFalse();
                flattenResult.IsErr.Should().BeTrue();

                flattenResult.Should().BeEquivalentTo(Result<string, uint>.Err(6));
            }

            {
                var x = Result<string, uint>.Err(6);

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                var flattenResult = x.Flatten();

                flattenResult.IsOk.Should().BeFalse();
                flattenResult.IsErr.Should().BeTrue();

                flattenResult.Should().BeEquivalentTo(Result<string, uint>.Err(6));
            }
        }
    }
}