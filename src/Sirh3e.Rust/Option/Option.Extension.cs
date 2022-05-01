namespace Sirh3e.Rust.Option;

public static partial class Extension
{
    public static Option<TSome> Some<TSome>(TSome some) => Option<TSome>.Some(some);
}