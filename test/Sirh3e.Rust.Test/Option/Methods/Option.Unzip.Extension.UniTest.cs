namespace Sirh3e.Rust.Test.Option;

public partial class OptionUnitTest
{
    [Fact]
    public void Unzip_UnitTest_Some()
    {
        var option = Some((1, "hi"));

        option.IsNone.Should().BeFalse();
        option.IsSome.Should().BeTrue();

        var (lhs, rhs) = option.Unzip();

        lhs.IsNone.Should().BeFalse();
        lhs.IsSome.Should().BeTrue();

        lhs.Unwrap().Should().Be(1);

        rhs.IsNone.Should().BeFalse();
        rhs.IsSome.Should().BeTrue();

        rhs.Unwrap().Should().Be("hi");
    }

    [Fact]
    public void Unzip_UnitTest_None()
    {
        var option = Option<(int, string)>.None;

        option.IsNone.Should().BeTrue();
        option.IsSome.Should().BeFalse();

        var (lhs, rhs) = option.Unzip();

        lhs.IsNone.Should().BeTrue();
        lhs.IsSome.Should().BeFalse();

        var lhsUnwrap = () => lhs.Unwrap();
        lhsUnwrap.Should().ThrowExactly<PanicException>();

        rhs.IsNone.Should().BeTrue();
        rhs.IsSome.Should().BeFalse();

        var rhsUnwrap = () => rhs.Unwrap();
        rhsUnwrap.Should().ThrowExactly<PanicException>();
    }
}