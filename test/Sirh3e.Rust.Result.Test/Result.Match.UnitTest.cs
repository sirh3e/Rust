using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Match()
        {
            {
                var result = Result<string, string>.Ok("foo");

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                result.Match(s =>
                {
                    s.Length.Should().Be(3);
                    s.Should().Be("foo");
                }, _ => throw new NotImplementedException());
            }

            {
                var result = Result<string, string>.Err("bar");

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.Match(_ => throw new NotImplementedException(), s =>
                {
                    s.Length.Should().Be(3);
                    s.Should().Be("bar");
                });
            }
        }
    }
}