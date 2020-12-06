using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Construct_From_Ok()
        {
            var x = Result<int, string>.Ok(-3);

            x.IsOk.Should().BeTrue();
            x.IsErr.Should().BeFalse();

            x.Ok().IsSome.Should().BeTrue();
            x.Ok().IsNone.Should().BeFalse();

            x.Ok().Unwrap().Should().Be(-3);

            x.Err().IsSome.Should().BeFalse();
            x.Err().IsNone.Should().BeTrue();

            Action action = () => x.Err().Unwrap();
            action.Should().ThrowExactly<NotImplementedException>();
        }

        [Fact]
        public void Result_Construct_From_Error()
        {
            var x = Result<int, string>.Err("Some error message");

            x.IsOk.Should().BeFalse();
            x.IsErr.Should().BeTrue();

            Action action = () => x.Ok().Unwrap();
            action.Should().ThrowExactly<NotImplementedException>();

            x.Err().IsSome.Should().BeTrue();
            x.Err().IsNone.Should().BeFalse();

            x.Err().Unwrap().Should().Be("Some error message");
        }





        [Fact]
        public void Result_MapOrElse()
        {
            var k = 21;
            {
                var result = Result<string, string>.Ok("foo");

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                result.MapOrElse(s => k * 2, s => s.Length).Should().Be(3);
            }

            {
                var result = Result<string, string>.Err("bar");

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                result.MapOrElse(s => k * 2, s => s.Length).Should().Be(42);
            }
        }

        [Fact]
        public void Result_MapErr()
        {
            Func<uint, string> stringify = s => $"error code {s}";

            {
                var result = Result<uint, uint>.Ok(2);

                result.IsOk.Should().BeTrue();
                result.IsErr.Should().BeFalse();

                var t = result.MapErr(stringify);
                t.IsOk.Should().BeTrue();
                t.IsErr.Should().BeFalse();

                t.Ok().IsSome.Should().BeTrue();
                t.Ok().IsNone.Should().BeFalse();

                t.Ok().Unwrap().Should().Be(2);
            }

            {
                var result = Result<uint, uint>.Err(13);

                result.IsOk.Should().BeFalse();
                result.IsErr.Should().BeTrue();

                var t = result.MapErr(stringify);
                t.IsOk.Should().BeFalse();
                t.IsErr.Should().BeTrue();

                t.Err().IsSome.Should().BeTrue();
                t.Err().IsNone.Should().BeFalse();

                t.Err().Unwrap().Should().Be("error code 13");
            }
        }

        [Fact]
        public void Result_Match_Ok()
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

        [Fact]
        public void Result_Match_Err()
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