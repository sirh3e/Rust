namespace Sirh3e.Rust.Test.Result;

public partial class ResultUnitTest
{
    [Fact]
    public async Task Result_MapOrElseAsync_Ok()
    {
        Result<string, string> ok = Ok("foo");

        var result = await ok.MapOrElseAsync(s => Task.FromResult(21 * 2), s => Task.FromResult(s.Length));

        result.Should().Be(3);
    }

    [Fact]
    public async Task Result_MapOrElseAsync_Ok_With_Extension()
    {
        Result<string, string> ok = Ok("foo");

        var result = await ok.MapAsync(s => Task.FromResult(s.Length))
                                  .MapOrElseAsync(s => Task.FromResult(s.Length * 2), Task.FromResult);

        result.Should().Be(3);
    }

    [Fact]
    public void Result_MapOrElseAsync_Ok_Null_Default_Func()
    {
        var ok = Result<string, string>.Ok("foo");

        var func = () => ok.MapOrElseAsync(_ => null, _ => Task.FromResult(42)).Result;

        func.Should().NotBeNull();
        func.Should().NotThrow();

        var result = func();

        result.Should().Be(42);
    }

    [Fact]
    public void Result_MapOrElseAsync_Ok_Null_Map_Func()
    {
        var ok = Result<string, string>.Ok("foo");

        var func = () => ok.MapOrElseAsync(Task.FromResult, _ => null)
                           .Result;

        func.Should().NotBeNull();
        func.Should().ThrowExactly<NullReferenceException>();
    }

    [Fact]
    public async Task Result_MapOrElseAsync_Err()
    {
        Result<string, string> err = Err("foo");

        var number = await err.MapOrElseAsync(_ => Task.FromResult(42), Map);

        number.Should().Be(42);
    }
}