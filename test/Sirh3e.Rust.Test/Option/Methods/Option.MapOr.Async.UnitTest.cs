namespace Sirh3e.Rust.Test.Option;

public partial class OptionUnitTest
{
    [Fact]
    public async Task Option_MapOrAsync_Some()
    {
        var some = Some("foo");

        var length = await some.MapOrAsync(42, GetLengthAsync);

        length.Should().Be(3);
    }

    [Fact]
    public async Task Option_MapOrAsync_Some_With_Extension()
    {
        var some = Some("foo");

        var length = await some.MapAsync(GetLengthAsync).MapOrAsync(42, DoubleOrNothingAsync);

        length.Should().Be(6);
    }

    [Fact]
    public async Task Option_MapOrAsync_None()
    {
        var none = Option<string>.None;

        var length = await none.MapOrAsync(42, GetLengthAsync);

        length.Should().Be(42);
    }

    [Fact]
    public async Task Option_MapOrAsync_None_With_Extension()
    {
        var some = Option<string>.None;

        var length = await some.MapAsync(GetLengthAsync).MapOrAsync(42, DoubleOrNothingAsync);

        length.Should().Be(42);
    }
}