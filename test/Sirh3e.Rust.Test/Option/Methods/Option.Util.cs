using Sirh3e.Rust.Result;

namespace Sirh3e.Rust.Test.Option
{
    public partial class OptionUnitTest
    {
        public static Result<int, string> Parse(string text)
        {
            if (string.IsNullOrEmpty(text))
                Result<int, string>.Err(text);

            return int.TryParse(text, out var number) ? Result<int, string>.Ok(number) : Result<int, string>.Err(text);
        }
    }
}