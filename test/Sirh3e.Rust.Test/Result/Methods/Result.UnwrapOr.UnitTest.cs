namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_UnwrapOr()
        {
            uint @default = 2;
            {
                var x = Result<uint, string>.Ok(9);

                x.IsOk.Should().BeTrue();
                x.IsErr.Should().BeFalse();

                x.UnwrapOr(@default).Should().Be(9);
            }

            {
                var x = Result<uint, string>.Err("error");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                x.UnwrapOr(@default).Should().Be(2);
            }

            {
                var x = Result<string, string>.Err("error");

                x.IsOk.Should().BeFalse();
                x.IsErr.Should().BeTrue();

                Action action = () => x.UnwrapOr(null);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}