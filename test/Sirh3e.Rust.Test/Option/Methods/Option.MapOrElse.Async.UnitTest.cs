namespace Sirh3e.Rust.Test.Option;

public partial class OptionUnitTest
{
    private static Task<int> ProviderAsync() => Task.FromResult(42);

    [Fact]
    public async Task Option_MapOrElseAsync_Some()
    {
        var some = Some("String");

        var length = await some.MapOrElseAsync(ProviderAsync, GetLengthAsync);

        length.Should().Be(6);
    }

    [Fact]
    public async Task Option_MapOrElseAsync_Some_With_Extension()
    {
        var some = Some("String");

        var length = await some.MapAsync(GetLengthAsync)
                                    .MapOrElseAsync(ProviderAsync, DoubleOrNothingAsync);

        length.Should().Be(12);
    }

    [Fact]
    public async Task Option_MapOrElseAsync_None()
    {
        Option<string> none = None.Value;

        var length = await none.MapOrElseAsync(ProviderAsync, GetLengthAsync);

        length.Should().Be(42);
    }

    [Fact]
    public async Task Option_MapOrElseAsync_None_With_Extension()
    {
        Option<string> none = None.Value;

        var length = await none.MapAsync(GetLengthAsync)
                                    .MapOrElseAsync(ProviderAsync, DoubleOrNothingAsync);

        length.Should().Be(42);
    }
}