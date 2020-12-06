using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_MapOrElse()
        {
            var k = 21;
            {
                var result = Result<string, string>.Ok("foo");

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                result.MapOrElse(s => k * 2, s => s.Length).Should().Be(3);
            }

            {
                var result = Result<string, string>.Err("bar");

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.MapOrElse(s => k * 2, s => s.Length).Should().Be(42);
            }
        }
    }
}