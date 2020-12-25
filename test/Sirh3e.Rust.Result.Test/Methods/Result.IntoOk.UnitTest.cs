using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_IntoOk()
        {
            var s = Result<string, None>.Ok("this is fine");

            s.IsErr.Should().BeFalse();
            s.IsOk.Should().BeTrue();

            s.IntoOk().Should().Be("this is fine");
        }
    }
}