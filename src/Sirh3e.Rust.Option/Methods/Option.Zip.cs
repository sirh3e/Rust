namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Option<(TSome, T)> Zip<T>(Option<T> option)
        {
            return (IsSome, option.IsSome) switch
            {
                (true, true) => Option<(TSome, T)>.Some((_some, option._some)),
                _ => Option<(TSome, T)>.None
            };
        }
    }
}