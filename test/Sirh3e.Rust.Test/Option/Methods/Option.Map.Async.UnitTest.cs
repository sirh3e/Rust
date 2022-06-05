namespace Sirh3e.Rust.Test.Option;

public partial class OptionUnitTest
{
    private static Task<int> GetLengthAsync(string @string) => Task.FromResult(@string.Length);
    private static Task<int> DoubleOrNothingAsync(int number) => Task.FromResult(number * 2);

    [Fact]
    public async Task Option_MapAsync_Some()
    {
        var some = Some("Hello, World!");

        var option = await some.MapAsync(GetLengthAsync);

        option.IsSome.Should().BeTrue();
        option.IsNone.Should().BeFalse();

        var unwrap = () => option.Unwrap();

        unwrap.Should().NotThrow();
        unwrap().Should().Be(13);
    }

    [Fact]
    public async Task Option_MapAsync_Some_With_Extension()
    {
        var some = Some("Hello, World!");

        var option = await some.MapAsync(GetLengthAsync)
                               .MapAsync(DoubleOrNothingAsync);

        option.IsSome.Should().BeTrue();
        option.IsNone.Should().BeFalse();

        var unwrap = () => option.Unwrap();

        unwrap.Should().NotThrow();
        unwrap().Should().Be(26);
    }

    [Fact]
    public async Task Option_MapAsync_None()
    {
        var none = Option<string>.None;

        var option = await none.MapAsync(GetLengthAsync);

        option.IsSome.Should().BeFalse();
        option.IsNone.Should().BeTrue();

        var unwrap = () => option.Unwrap();
        unwrap.Should().Throw<PanicException>();

        var unwrapNone = () => option.UnwrapNone();
        unwrapNone.Should().NotThrow();
    }

    [Fact]
    public async Task Option_MapAsync_None_With_Extension()
    {
        var none = Option<string>.None;

        var option = await none.MapAsync(GetLengthAsync)
                               .MapAsync(DoubleOrNothingAsync);

        option.IsSome.Should().BeFalse();
        option.IsNone.Should().BeTrue();

        var unwrap = () => option.Unwrap();
        unwrap.Should().Throw<PanicException>();

        var unwrapNone = () => option.UnwrapNone();
        unwrapNone.Should().NotThrow();
    }
}