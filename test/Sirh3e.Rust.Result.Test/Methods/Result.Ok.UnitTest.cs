using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Ok()
        {
            {
                var x = Result<uint, string>.Ok(2);

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                var option = x.Ok();

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be(2);
            }

            {
                var x = Result<uint, string>.Err("Nothing here");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                var option = x.Ok();

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();
            }
        }
    }
}