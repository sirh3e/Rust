using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Cloned()
        {
            {
                var x = Option<uint>.Some(2);

                x.Cloned().Should().BeEquivalentTo(Option<uint>.Some(2));
            }

            {
                var x = Option<uint>.None;

                x.Cloned().Should().BeEquivalentTo(Option<uint>.None);
            }
        }
    }
}