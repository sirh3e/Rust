namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Option<TSome> Xor(Option<TSome> option)
        {
            return (IsSome, option.IsSome) switch
            {
                (true, false) => this,
                (false, true) => option,
                _ => None,
            };
        }
    }
}