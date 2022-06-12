namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    ///     Maps an Option &TSome to an Option TSome by cloning the contents of the option.
    /// </summary>
    /// <returns></returns>
    [ToDo(28, "Add where clause on TSome needs to implement ICloneable or Clone. Clone must be published first :D")]
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [GitHub(26, "https://github.com/sirh3e/Rust/issues/26")]
    [Docs("https://doc.rust-lang.org/std/option/enum.Option.html#method.cloned")]
    [Stable("rust1", "1.0.0")]
    [Source("https://doc.rust-lang.org/src/core/option.rs.html#1775-1777")]
    public readonly Option<TSome> Cloned()
        => Clone();
}