using System;
using System.Collections;
using System.Collections.Generic;

namespace Sirh3e.Rust.Result
{
    public struct ResultEnumerator<TOk> : IEnumerator<TOk>
    {
        private readonly TOk[] _oks;
        private int _position;

        public ResultEnumerator(TOk[] oks) : this()
        {
            _oks = oks ?? throw new ArgumentNullException(nameof(oks));
        }

        public bool MoveNext()
        {
            return ++_position < _oks.Length;
        }

        public void Reset()
        {
            _position = -1;
        }

        public TOk Current => _oks[_position];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}