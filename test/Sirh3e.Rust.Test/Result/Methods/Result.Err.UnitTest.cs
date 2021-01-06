using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Err()
        {
            {
                var x = Result<uint, string>.Ok(2);

                var option = x.Err();

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();
            }

            {
                var x = Result<uint, string>.Err("Nothing here");

                var option = x.Err();

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be("Nothing here");
            }
        }
    }
}