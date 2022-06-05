namespace Sirh3e.Rust.Test.Option;

public partial class OptionUnitTest
{
    private static bool IsLargerThenZero(int number) => number > 0;

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(11)]
    public void Option_IsSomeAnd_Some_True(int number)
    {
        var option = Some(number);

        option.IsNone.Should().BeFalse();
        option.IsSome.Should().BeTrue();

        option.IsSomeAnd(IsLargerThenZero).Should().BeTrue();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-3)]
    [InlineData(-5)]
    [InlineData(-7)]
    [InlineData(-11)]
    public void Option_IsSomeAnd_Some_False(int number)
    {
        var option = Some(number);

        option.IsNone.Should().BeFalse();
        option.IsSome.Should().BeTrue();

        option.IsSomeAnd(IsLargerThenZero).Should().BeFalse();
    }
}