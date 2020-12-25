using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Contains()
        {
            {
                var x = Result<uint, string>.Ok(2);

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                x.Contains(2)
                    .Should()
                    .BeTrue();
            }

            {
                var x = Result<uint, string>.Ok(3);

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                x.Contains(2)
                    .Should()
                    .BeFalse();
            }

            {
                var x = Result<uint, string>.Err("Some error message");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                x.Contains(2)
                    .Should()
                    .BeFalse();
            }
        }
    }
}