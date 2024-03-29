﻿namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Returns true if the option is a None value.
    /// </summary>
    public bool IsNone => IsSome == false;
}