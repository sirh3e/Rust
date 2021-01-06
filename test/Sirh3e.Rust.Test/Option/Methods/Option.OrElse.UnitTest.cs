using System;
using FluentAssertions;
using Sirh3e.Rust.Option;
using Xunit;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_OrElse()
        {
            Func<Option<string>> nobody = () => Option<string>.None;
            Func<Option<string>> vikings = () => Option<string>.Some("vikings");

            Option<string>.Some("barbarians").OrElse(vikings).Should().BeEquivalentTo(Option<string>.Some("barbarians"));
            Option<string>.None.OrElse(vikings).Should().BeEquivalentTo(Option<string>.Some("vikings"));
            Option<string>.None.OrElse(nobody).Should().BeEquivalentTo(Option<string>.None);
        }
    }
}