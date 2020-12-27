﻿using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public TSome Expect(string message)
            => Match(s => s, () => throw new NotImplementedException());
    }
}