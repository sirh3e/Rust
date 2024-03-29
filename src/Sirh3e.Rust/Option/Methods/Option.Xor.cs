﻿namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Returns Some if exactly one of self, option is Some, otherwise returns None.
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    public Option<TSome> Xor(Option<TSome> option)
        => (IsSome, option.IsSome) switch
        {
            (true, false) => this,
            (false, true) => option,
            _ => None,
        };
}