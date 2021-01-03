using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Cloned()
        {
            {
                var x = Result<uint, string>.Ok(2);

                x.Cloned().Should().BeEquivalentTo(Result<uint, string>.Ok(2));
            }

            {
                var x = Result<uint, string>.Err("foo");

                x.Cloned().Should().BeEquivalentTo(Result<uint, string>.Err("foo"));
            }
        }
    }
}