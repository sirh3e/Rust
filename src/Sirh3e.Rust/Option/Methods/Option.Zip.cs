namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        /// <summary>
        /// Zips self with another Option.
        /// If self is Some(TSome) and other is Some(T), this method returns Some((TSome, T)). Otherwise, None is returned.
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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