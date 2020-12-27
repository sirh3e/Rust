namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public void ExpectNone(string message)
            => Match(_ => { }, some => ExpectNoneFailed(message, some));
    }
}