namespace Sirh3e.Rust.Test.Option;

public partial class OptionUnitTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(42)]
    [InlineData(69)]
    public void Option_GetOrInsertDefault_Some(int number)
    {
        var option = Some(number);

        option.IsNone.Should().BeFalse();
        option.IsSome.Should().BeTrue();

        var tmp = option.GetOrInsertDefault();
        number.Should().Be(tmp);
        
        option.IsNone.Should().BeFalse();
        option.IsSome.Should().BeTrue();
    }
    
    [Fact]
    public void Option_GetOrInsertDefault_None()
    {
        var option = Option<int>.None;

        option.IsSome.Should().BeFalse();
        option.IsNone.Should().BeTrue();
        
        var number = option.GetOrInsertDefault();
        default(int).Should().Be(number);

        option.IsSome.Should().BeTrue();
        option.IsNone.Should().BeFalse();
    }
}