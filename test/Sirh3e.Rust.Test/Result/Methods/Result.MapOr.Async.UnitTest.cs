namespace Sirh3e.Rust.Test.Result;

public partial class ResultUnitTest
{
    private Task<int> Map(string @string) => Task.FromResult(@string.Length);
    private Task<int> Map(int number) => Task.FromResult(number * 2);

    [Fact]
    public async Task Result_MapOrAsync_Ok()
    {
        Result<string, string> ok = Ok("foo");

        var number = await ok.MapOrAsync(42, Map);

        number.Should().Be(3);
    }

    [Fact]
    public async Task Result_MapOrAsync_Ok_With_Extension()
    {
        Result<string, string> ok = Ok("foo");

        var number = await ok.MapAsync(Map).MapOrAsync(42, Map);

        number.Should().Be(6);
    }

    [Fact]
    public void Result_MapOrAsync_Ok_Null_Func()
    {
        Result<string, string> ok = Ok("foo");

        var func = () => ok.MapOrAsync(42, null as Func<string, Task<int>>).Result;

        func.Should().NotBeNull();
        func.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Result_MapOrAsync_Ok_With_Extension_Null_Func()
    {
        Result<string, string> ok = Ok("foo");

        var func = () => ok.Map(@string => @string.Length)
                           .MapOrAsync(42, null as Func<int, Task<int>>).Result;

        func.Should().NotBeNull();
        func.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public async Task Result_MapOrAsync_Err()
    {
        Result<string, string> err = Err("foo");

        var number = await err.MapOrAsync(42, Map);

        number.Should().Be(42);
    }

    [Fact]
    public async Task Result_MapOrAsync_Err_With_Extension()
    {
        Result<string, string> err = Err("foo");

        var number = await err.MapAsync(Task.FromResult)
                                   .MapOrAsync(42, Map);

        number.Should().Be(42);
    }

    [Fact]
    public void Result_MapOrAsync_Err_Null_Func()
    {
        Result<string, string> err = Err("foo");

        var func = () => err.MapOrAsync(42, null).Result;

        func.Should().NotBeNull();
        func.Should().NotThrow();

        func().Should().Be(42);
    }

    [Fact]
    public void Result_MapOrAsync_Err_With_Extension_Null_Func()
    {
        Result<string, string> err = Err("foo");

        var func = () => err.MapAsync(Task.FromResult)
                            .MapOrAsync(42, null)
                            .Result;

        func.Should().NotBeNull();
        func.Should().NotThrow();

        func().Should().Be(42);
    }
}