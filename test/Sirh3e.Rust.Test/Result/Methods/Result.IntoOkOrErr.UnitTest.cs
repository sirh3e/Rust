namespace Sirh3e.Rust.Test.Result;

public partial class ResultUnitTest
{
    [Fact]
    public void Result_IntoOkOrErr_Ok()
    {
        Result<int, int> result = Ok(3);

        result.IsOk.Should().BeTrue();
        result.IsErr.Should().BeFalse();

        var number = result.IntoOkOrErr();

        number.Should().Be(3);
    }

    [Fact]
    public void Result_IntoOkOrErr_Err()
    {
        Result<int, int> result = Err(4);

        result.IsOk.Should().BeFalse();
        result.IsErr.Should().BeTrue();

        var number = result.IntoOkOrErr();

        number.Should().Be(4);
    }
}