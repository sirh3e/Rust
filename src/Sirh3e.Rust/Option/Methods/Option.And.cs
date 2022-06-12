﻿namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Returns None if the option is None, otherwise returns option.
    /// </summary>
    /// <param name="option"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [GitHub(24, "https://github.com/sirh3e/Rust/issues/24")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.and")]
    [Stable("rust1", "1.0.0")]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#1203-1206")]
    public Option<T> And<T>(Option<T> option)
        => IsNone
            ? Option<T>.None
            : option;
}