namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_And()
        {
            {
                var x = Result<uint, string>.Ok(2);
                var y = Result<uint, string>.Err("late error");

                var option = x.And(y).Err();

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be("late error");
            }

            {
                var x = Result<uint, string>.Err("early error");
                var y = Result<string, string>.Ok("foo");

                var option = x.And(y).Err();

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be("early error");
            }

            {
                var x = Result<uint, string>.Err("not a 2");
                var y = Result<string, string>.Err("late error");

                var option = x.And(y).Err();

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be("not a 2");
            }

            {
                var x = Result<uint, string>.Ok(2);
                var y = Result<string, string>.Ok("different result type");

                var option = x.And(y).Ok();

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Unwrap().Should().Be("different result type");
            }
        }
    }
}