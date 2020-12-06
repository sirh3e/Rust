using System;

namespace Sirh3e.Rust.Result.Test
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
            catch (Exception e)
            {
                return Result<int, string>.Err(e.Message);
            }
            return Result<int, string>.Ok(number);
        }
    }
}