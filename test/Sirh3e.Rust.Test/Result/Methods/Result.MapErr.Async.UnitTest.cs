namespace Sirh3e.Rust.Test.Result;

public partial class ResultUnitTest
{
    private Task<string> Stringify(uint number) => Task.FromResult($"error code {number}");

    [Fact]
    public async Task Result_MapErrAsync_Ok()
    {
        Result<uint, uint> ok = Ok(2U);
        var result = await ok.MapErrAsync(Stringify);

        result.IsOk.Should().BeTrue();
        result.IsErr.Should().BeFalse();

        result.Ok().IsSome.Should().BeTrue();
        result.Ok().IsNone.Should().BeFalse();

        result.Ok().Unwrap().Should().Be(2);
    }

    [Fact]
    public async Task Result_MapErrAsync_Ok_With_Extension()
    {
        Result<uint, uint> ok = Ok(2U);
        var result = await ok.MapErrAsync(Stringify)
                             .MapErrAsync(error => Task.FromResult((uint)error.Length))
                             .MapErrAsync(Stringify);

        result.IsOk.Should().BeTrue();
        result.IsErr.Should().BeFalse();

        result.Ok().IsSome.Should().BeTrue();
        result.Ok().IsNone.Should().BeFalse();

        result.Ok().Unwrap().Should().Be(2);
    }

    [Fact]
    public void Result_MapErrAsync_Ok_Null_Func()
    {
        Result<uint, uint> ok = Ok(2U);
        var func = () => ok.MapErrAsync(null as Func<uint, Task<string>>)
                           .Result;

        func.Should().NotBeNull();
        func.Should().NotThrow();

        var result = func();

        result.IsOk.Should().BeTrue();
        result.IsErr.Should().BeFalse();

        result.Unwrap().Should().Be(2);
    }

    [Fact]
    public void Result_MapErrAsync_Ok_With_Extension_Null_Func()
    {
        Result<uint, uint> ok = Ok(13U);

        var func = () => ok.MapErrAsync(Stringify)
                           .MapErrAsync(null as Func<string, Task<string>>)
                           .Result;

        func.Should().NotBeNull();
        func.Should().NotThrow();

        var result = func();

        result.IsOk.Should().BeTrue();
        result.IsErr.Should().BeFalse();

        result.Unwrap().Should().Be(13);
    }

    [Fact]
    public async Task Result_MapErrAsync_Err()
    {
        Result<uint, uint> err = Err(13U);
        var result = await err.MapErrAsync(Stringify);

        result.IsOk.Should().BeFalse();
        result.IsErr.Should().BeTrue();

        result.Err().IsSome.Should().BeTrue();
        result.Err().IsNone.Should().BeFalse();

        result.Err().Unwrap().Should().Be("error code 13");
    }

    [Fact]
    public async Task Result_MapErrAsync_Err_With_Extension()
    {
        Result<uint, uint> err = Err(2U);
        var result = await err.MapErrAsync(Stringify)
                              .MapErrAsync(error => Task.FromResult((uint)error.Length))
                              .MapErrAsync(Stringify);

        result.IsOk.Should().BeFalse();
        result.IsErr.Should().BeTrue();

        result.Err().IsSome.Should().BeTrue();
        result.Err().IsNone.Should().BeFalse();

        result.Err().Unwrap().Should().Be("error code 12");
    }

    [Fact]
    public void Result_MapErrAsync_Err_Null_Func()
    {
        Result<uint, uint> result = Err(13U);

        var func = () => result.MapErrAsync(null as Func<uint, Task<string>>)
                               .Result;

        func.Should().NotBeNull();
        func.Should().ThrowExactly<AggregateException>();
    }

    [Fact]
    public void Result_MapErrAsync_Err_With_Extension_Null_Func()
    {
        Result<uint, uint> result = Err(13U);

        var func = () => result.MapErrAsync(Stringify)
                               .MapErrAsync(null as Func<string, Task<string>>)
                               .Result;

        func.Should().NotBeNull();
        func.Should().ThrowExactly<AggregateException>();
    }
}