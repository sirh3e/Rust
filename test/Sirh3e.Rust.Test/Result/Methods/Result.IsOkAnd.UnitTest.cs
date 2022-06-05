namespace Sirh3e.Rust.Test.Result;

public partial class ResultUnitTest
{
    [Fact]
    public void Result_IsOkAnd()
    {
        {
            Result<uint, string> result = Ok(2u);

            result.IsOk.Should().BeTrue();
            result.IsErr.Should().BeFalse();

            result.IsOkWith(x => x > 1).Should().BeTrue();
        }

        {
            Result<uint, string> result = Ok(0u);

            result.IsOk.Should().BeTrue();
            result.IsErr.Should().BeFalse();

            result.IsOkWith(x => x > 1).Should().BeFalse();
        }

        {
            Result<uint, string> result = Err("hey");

            result.IsOk.Should().BeFalse();
            result.IsErr.Should().BeTrue();

            result.IsOkWith(x => x > 1).Should().BeFalse();
        }
    }
}