using System;
using Xunit;

namespace Sirh3e.Rust.Option.Test
{
    public class OptionUnitTest
    {
        [Fact]
        public void Test1()
        {
            var option = Option<string>("");
        }
    }
}