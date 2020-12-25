using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Flatten()
        {
            /*
            var x = Result<Result<string, uint>, uint>.Ok(Result<string, uint>.Ok("marvin"));

            x.IsOk.Should().BeTrue();
            x.IsErr.Should().BeFalse();

            var flattenResult = x.Flatten();
            
            flattenResult.IsOk.Should().BeTrue();
            flattenResult.IsOk.Should().BeFalse();

            var flatten = flattenResult.Ok().Unwrap(); //ToDo check for panic
            
            flatten.IsOk.Should().BeTrue();
            flatten.IsErr.Should().BeFalse();

            flatten.Unwrap().Should().Be("hello"); //ToDo check for panic
            */
        }
    }
}