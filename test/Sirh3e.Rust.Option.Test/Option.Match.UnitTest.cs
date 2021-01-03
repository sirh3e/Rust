using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public partial class OptionUnitTest
    {
        [Fact]
        public void Option_Match_Action()
        {
            {
                var option = Option<string>.Some("liegens");

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                option.Match(
                    some =>
                    {
                        some.Should().Be("liegens");
                    },
                    () => { }
                );
            }

            {
                var option = Option<string>.None;

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                option.Match(
                    _ => throw new NotImplementedException(),
                    () => { }
                );
            }

            {
                var option = Option<string>.Some("liegens");

                option.IsSome.Should().BeTrue();
                option.IsNone.Should().BeFalse();

                Action<string> some = null;
                Action match = () => option.Match(
                    some,
                    () => { }
                );

                match.Should().ThrowExactly<ArgumentNullException>();
            }

            {
                var option = Option<string>.None;

                option.IsSome.Should().BeFalse();
                option.IsNone.Should().BeTrue();

                Action none = null;
                Action match = () => option.Match(
                    _ => throw new NotImplementedException(),
                    none
                );

                match.Should().ThrowExactly<ArgumentNullException>();
            }
        }

        [Fact]
        public void Option_Match_Func()
        {
            {
                var x = Option<string>.Some("liegens");

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                var match = x.Match(some => some, () => throw new NotImplementedException());

                match.Should().Be("liegens");
            }

            {
                var x = Option<string>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                var match = x.Match(_ => throw new NotImplementedException(), () => "liegens");

                match.Should().Be("liegens");
            }

            {
                var x = Option<string>.Some("liegens");

                x.IsSome.Should().BeTrue();
                x.IsNone.Should().BeFalse();

                Func<string, string> func = null;

                Action action = () => x.Match(func, () => throw new NotImplementedException());

                action.Should().ThrowExactly<ArgumentNullException>();
            }

            {
                var x = Option<string>.None;

                x.IsSome.Should().BeFalse();
                x.IsNone.Should().BeTrue();

                Func<string> func = null;

                Action action = () => x.Match(_ => throw new NotImplementedException(), func);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}