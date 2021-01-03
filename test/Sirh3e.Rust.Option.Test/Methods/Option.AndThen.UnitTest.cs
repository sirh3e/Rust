using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_AndThen()
        {
            Func<uint, Option<uint>> sq = x => Option<uint>.Some(x * x);
            Func<uint, Option<uint>> nope = _ => Option<uint>.None;

            Option<uint>.Some(2).AndThen(sq).AndThen(sq).Should().Be(Option<uint>.Some(16));
            Option<uint>.Some(2).AndThen(sq).AndThen(nope).Should().Be(Option<uint>.None);
            Option<uint>.Some(2).AndThen(nope).AndThen(sq).Should().Be(Option<uint>.None);
            Option<uint>.None.AndThen(sq).AndThen(sq).Should().Be(Option<uint>.None);
        }
    }
}