namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public bool IsNone => IsSome == false;
    }
}