namespace Sirh3e.Rust.Test.Result;

public partial class ResultUnitTest
{

    [Fact]
    public void Result_IsErrAnd()
    {
        {
            Result<uint, Error> result = Err(new Error(ErrorKind.NotFound, "!"));

            result.IsErr.Should().BeTrue();
            result.IsOk.Should().BeFalse();

            result.IsErrAnd(e => e.Kind.Equals(ErrorKind.NotFound)).Should().BeTrue();
        }

        {
            Result<uint, Error> result = Err(new Error(ErrorKind.PermissionDenied, "!"));

            result.IsErr.Should().BeTrue();
            result.IsOk.Should().BeFalse();

            result.IsErrAnd(e => e.Kind.Equals(ErrorKind.NotFound)).Should().BeFalse();
        }

        {
            Result<uint, Error> result = Ok(123u);

            result.IsErr.Should().BeFalse();
            result.IsOk.Should().BeTrue();

            result.IsErrAnd(e => e.Kind.Equals(ErrorKind.NotFound)).Should().BeFalse();
        }
    }

    private enum ErrorKind
    {
        NotFound,
        PermissionDenied
    }

    private record Error(ErrorKind Kind, string Text);
}