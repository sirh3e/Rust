namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Option<TSome> Or(Option<TSome> option)
        {
            return Match(Some, () => option);
        }
    }
}