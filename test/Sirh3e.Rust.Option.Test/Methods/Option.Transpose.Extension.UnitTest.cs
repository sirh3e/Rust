using FluentAssertions;
using Sirh3e.Rust.Result;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        struct SomeErr { }

        [Fact]
        public void Option_Transpose()
        {

            var x = Result<Option<int>, SomeErr>.Ok(Option<int>.Some(5));
            var y = Option<Result<int, SomeErr>>.Some(Result<int, SomeErr>.Ok(5));

            x.Should().BeEquivalentTo(y.Transpose());
        }
    }
}