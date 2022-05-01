namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    /// <summary>
    /// Zips self and another Option with function f.
    /// If self is Some(TSome) and other is Some(TU), this method returns Some(f(TSome, TU)). Otherwise, None is returned.
    /// </summary>
    /// <param name="option"></param>
    /// <param name="func"></param>
    /// <typeparam name="TU"></typeparam>
    /// <typeparam name="TR"></typeparam>
    /// <returns></returns>
    public Option<TR> ZipWith<TU, TR>(Option<TU> option, Func<TSome, TU, TR> func)
        => (IsSome, option.IsSome) switch
        {
            (true, true) => Option<TR>.Some(func(_some, option._some) ??
                                            throw new ArgumentNullException(nameof(func))),
            _ => Option<TR>.None
        };
}