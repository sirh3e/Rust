namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_AndThen()
        {
            Func<uint, Result<uint, uint>> sq = x => Result<uint, uint>.Ok(x * x);
            Func<uint, Result<uint, uint>> err = Result<uint, uint>.Err;

            {
                var value = Result<uint, uint>.Ok(2);

                var result = value.AndThen(sq).AndThen(sq);
                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                result.Ok().Unwrap().Should().Be(16);
            }

            {
                var value = Result<uint, uint>.Ok(2);

                var result = value.AndThen(sq).AndThen(err);
                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.Err().Unwrap().Should().Be(4);
            }

            {
                var value = Result<uint, uint>.Ok(2);

                var result = value.AndThen(err).AndThen(sq);
                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.Err().Unwrap().Should().Be(2);
            }

            {
                var value = Result<uint, uint>.Err(3);

                var result = value.AndThen(err).AndThen(err);
                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.Err().Unwrap().Should().Be(3);
            }

            {
                var value = Result<uint, uint>.Ok(3);

                Action action = () => value.AndThen(null as Func<uint, Result<uint, uint>>);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}