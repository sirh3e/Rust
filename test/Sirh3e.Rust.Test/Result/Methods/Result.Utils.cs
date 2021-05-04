using System;
using Sirh3e.Rust.Result;

namespace Sirh3e.Rust.Test.Result
{
    public partial class ResultUnitTest
    {
        private static Result<int, string> Parse(string text)
        {
            int number;
            try
            {
                number = Convert.ToInt32(text);
            }
            catch ( Exception )
            {
                return Result<int, string>.Err(text);
            }
            return Result<int, string>.Ok(number);
        }
    }
}