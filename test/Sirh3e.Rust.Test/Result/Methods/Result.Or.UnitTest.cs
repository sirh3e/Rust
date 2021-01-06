using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Or()
        {
            {
                var x = Result<uint, string>.Ok(2);

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                var y = Result<uint, string>.Err("late error");

                y.IsOk.Should().BeFalse();
                y.IsErr.Should().BeTrue();

                var result = x.Or(y);

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                var option = result.Ok();

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be(2);
            }

            {
                var x = Result<uint, string>.Err("late error");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                var y = Result<uint, string>.Ok(2);

                y.IsOk.Should().BeTrue();
                y.IsErr.Should().BeFalse();

                var result = x.Or(y);

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                var option = result.Ok();

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be(2);
            }

            {
                var x = Result<uint, string>.Err("not a 2");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                var y = Result<uint, string>.Err("late error");

                y.IsOk.Should().BeFalse();
                y.IsErr.Should().BeTrue();

                var result = x.Or(y);

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                var option = result.Err();

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be("late error");
            }

            {
                var x = Result<uint, string>.Ok(2);

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                var y = Result<uint, string>.Ok(100);

                y.IsOk.Should().BeTrue();
                y.IsErr.Should().BeFalse();

                var result = x.Or(y);

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                var option = result.Ok();

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be(2);
            }
        }
    }
}