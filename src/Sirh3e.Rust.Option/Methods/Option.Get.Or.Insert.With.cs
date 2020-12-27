using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public Option<TSome> GetOrInsertWith(Func<TSome> func)
        {
            throw new NotImplementedException();
        }
    }
}