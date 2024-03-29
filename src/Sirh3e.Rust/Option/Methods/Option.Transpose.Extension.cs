﻿namespace Sirh3e.Rust.Option;

public static partial class OptionExtension
{
    /// <summary>
    /// Transposes an Option of a Result into a Result of an Option.
    /// None will be mapped to Ok(None). Some(Ok(_)) and Some(Err(_)) will be mapped to Ok(Some(_)) and Err(_).
    /// </summary>
    /// <param name="option"></param>
    /// <typeparam name="TSome"></typeparam>
    /// <typeparam name="TErr"></typeparam>
    /// <returns></returns>
    public static Result<Option<TSome>, TErr> Transpose<TSome, TErr>(this Option<Result<TSome, TErr>> option)
        => option.Match(
                        some => some.IsOk ? Ok(Some(some.Unwrap())) : Err(some.UnwrapErr()),
                        () => Result<Option<TSome>, TErr>.Ok(None.Value));
}