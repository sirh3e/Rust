namespace Sirh3e.Rust.Test.Option;

public partial class OptionUnitTest
{
    [Fact]
    public void Option_UnwrapOrDefault()
    {
        var goodYearFromInput = "1909";
        var badYearFromInput  = "190blarg";

        var goodYear = Parse(goodYearFromInput).Ok().UnwrapOrDefault();
        var badYear  = Parse(badYearFromInput).Ok().UnwrapOrDefault();

        goodYear.Should().Be(1909);
        badYear.Should().Be(0);
    }
}