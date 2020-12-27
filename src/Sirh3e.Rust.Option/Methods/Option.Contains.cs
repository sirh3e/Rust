namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public bool Contains(TSome some)
            => Match(s => s.Equals(some), () => false);
    }
}