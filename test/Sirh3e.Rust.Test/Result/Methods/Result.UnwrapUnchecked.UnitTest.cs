namespace Sirh3e.Rust.Test.Result;

public partial class ResultUnitTest
{
    [Theory]
    [InlineData("Marvin")]
    [InlineData("Mario")]
    [InlineData("Michi")]
    [InlineData("Katari")]
    public void Result_UnwrapUnchecked_Ok(string name)
    {
        Result<string, int> result = Ok(name);

        var func = () => result.UnwrapUnchecked();

        func.Should().NotThrow();

        var ok = func();

        ok.Should().Be(name);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(8)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(23)]
    [InlineData(42)]
    public void Result_UnwrapUnchecked_Err(int number)
    {
        Result<string, int> result = Err(number);

        var func = () => result.UnwrapUnchecked();

        func.Should().NotThrow();

        var value = func();
        
        value.Should().Be(default);
    }
}