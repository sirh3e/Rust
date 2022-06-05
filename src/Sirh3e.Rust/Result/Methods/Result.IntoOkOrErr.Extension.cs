namespace Sirh3e.Rust.Result;

public static partial class ResultExtension
{
    /// <summary>
    /// Returns the Ok value if self is Ok, and the Err value if self is Err.
    /// In other words, this function returns the value (the T) of a Result<T, T>, regardless of whether or not that result is Ok or Err.
    /// </summary>
    /// <param name="result"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [Docs("https://doc.rust-lang.org/std/result/enum.Result.html#method.into_ok_or_err")]
    [Unstable("result_into_ok_or_err", 19)]
    public static T IntoOkOrErr<T>(this Result<T, T> result)
        => result.Match(ok => ok, err => err);
}