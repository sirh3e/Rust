﻿namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        [Fact]
        public void Result_UnwrapOrDefault()
        {
            var goodYearFromInput = "1909";
            var badYearFromInput = "190blarg";

            var goodYear = Parse(goodYearFromInput).UnwrapOrDefault();
            var badYear = Parse(badYearFromInput).UnwrapOrDefault();

            goodYear.Should().Be(1909);
            badYear.Should().Be(0);
        }
    }
}