namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Will clone the value if it is Some.
    /// </summary>
    /// <returns></returns>
    [ToDo(28, "Add where clause on TSome needs to implement ICloneable or Clone. Clone must be published first :D")]
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(30, "https://github.com/sirh3e/Rust/issues/30")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.cloned")]
    [Stable("rust1", "1.0.0")]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#1775-1777")]
    public readonly Option<TSome> Clone()
        => IsSome
            ? Some(_some)
            : None;

    [Pure]
    object ICloneable.Clone()
        => Clone();
}