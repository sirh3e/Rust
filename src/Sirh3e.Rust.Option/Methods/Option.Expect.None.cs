namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public void ExpectNone(string message)
            => Match(some => { }, some => ExpectNoneFailed(message, some));
    }
}