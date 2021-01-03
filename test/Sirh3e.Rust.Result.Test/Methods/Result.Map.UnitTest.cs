using System;
using FluentAssertions;
using Xunit;

namespace Sirh3e.Rust.Result.Test
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_Map()
        {
            var counter = 0;
            var results = new[] { 1, 2, 3, 4 };
            var lines = "1\n2\n3\n4\n".Split("\n");

            {
                foreach (var line in lines)
                {
                    Parse(line).Map(Convert.ToInt32).Match(i =>
                    {
                        i.Should().Be(results[counter++]);
                    }, s =>
                    {
                        counter++;
                    });
                }
            }

            {
                foreach (var line in lines)
                {
                    Action action = () => Parse(line).Map(Convert.ToInt32).Match(null, null);

                    action.Should().ThrowExactly<ArgumentNullException>();
                }
            }

            {
                Func<int, int> map = null;

                Action action = () => Parse("1909").Map(map);

                action.Should().ThrowExactly<ArgumentNullException>();
            }
        }
    }
}