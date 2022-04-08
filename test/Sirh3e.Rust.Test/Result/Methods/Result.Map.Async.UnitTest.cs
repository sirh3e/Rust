namespace Sirh3e.Rust.Test.Result;

public partial class ResultUnitTest
{
    private Task<int> DoubleAsync(int number) => Task.FromResult(number * 2);

    [Fact]
    public async Task Result_Map_Async()
    {
        {
            var result = Result<int, string>.Ok(1);

            result.IsOk.Should().BeTrue();
            result.IsErr.Should().BeFalse();

            var task = result
                    .MapAsync(DoubleAsync)
                    .MapAsync(DoubleAsync);

            result = await task;

            result.IsOk.Should().BeTrue();
            result.IsErr.Should().BeFalse();

            result.Unwrap().Should().Be(4);
        }

        {
            var result = Result<int, string>.Err("1");

            result.IsOk.Should().BeFalse();
            result.IsErr.Should().BeTrue();

            var task = result
                       .MapAsync(DoubleAsync)
                       .MapAsync(DoubleAsync);

            result = await task;

            result.IsOk.Should().BeFalse();
            result.IsErr.Should().BeTrue();

            result.UnwrapErr().Should().Be("1");
        }
    }
}