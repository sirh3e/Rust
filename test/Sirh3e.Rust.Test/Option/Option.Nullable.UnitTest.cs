namespace Sirh3e.Rust.Test.Option;

public partial class OptionUnitTest
{
    [Theory]
    [InlineData("Marvin", "Marvin")]
    [InlineData("Mario", "Mario")]
    [InlineData("Dario", "Dario")]
    public void Option_Nullable_Not_Null(string? name, string should)
    {
        Option<string> some = name;

        some.IsNone.Should().BeFalse();
        some.IsSome.Should().BeTrue();

        var func = () => some.Unwrap();
        func.Should().NotThrow();
        func().Should().Be(should);
    }

    [Theory]
    [InlineData(null)]
    public void Option_Nullable_Null(string? name)
    {
        Option<string> some = name;

        some.IsNone.Should().BeTrue();
        some.IsSome.Should().BeFalse();

        var func = () => some.Unwrap();
        func.Should().Throw<PanicException>();
    }
}