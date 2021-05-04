using System.Collections.Generic;

namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        //ToDo
        public IEnumerator<TSome> Iter()
        {
            return GetEnumerator();
        }
    }
}