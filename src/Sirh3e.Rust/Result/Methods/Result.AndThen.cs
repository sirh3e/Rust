namespace Sirh3e.Rust.Result;

public readonly partial struct Result<TOk, TErr>
{
    /// <summary>
    ///     Calls op if the result is Ok, otherwise returns the Err value of self.
    ///     This function can be used for control flow based on Result values.
    /// </summary>
    /// <param name="op"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Throws only if op is null</exception>
    public Result<T, TErr> AndThen<T>(Func<TOk, Result<T, TErr>> op)
        => Match(ok => (_ = op ?? throw new ArgumentNullException(nameof(op)))(ok), Result<T, TErr>.Err);
}