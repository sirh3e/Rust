using System.Collections;
using System.Collections.Generic;

namespace Sirh3e.Rust.Option
{
    public struct OptionEnumerator<TSome> : IEnumerator<TSome>
    {
        private readonly TSome[] _somes;
        private int _position;

        public OptionEnumerator(TSome[] somes) : this()
        {
            _somes = somes ?? throw new ArgumentNullException(nameof(somes));
        }

        public bool MoveNext()
            => ++_position < _somes.Length;

        public void Reset()
        {
            _position = -1;
        }

        public TSome Current => _somes[_position];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}