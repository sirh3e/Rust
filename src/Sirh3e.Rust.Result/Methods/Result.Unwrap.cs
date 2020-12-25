using System;
using Sirh3e.Rust.Panic;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public TOk Unwrap()
        {
            return Unwrap(error =>
            {
                return error switch
                {
                    _ => $"Cannot unwrap \"Ok\" when the result is \"Err\": {error}."
                };
            });
        }

        public TOk Unwrap(string error)
        {
            if (IsOk)
                return _ok;

            if (string.IsNullOrEmpty(error))
                throw new ArgumentNullException(nameof(error));
            throw new PanicException(error); //ToDo create a panic like exception
        }

        public TOk Unwrap(Func<TErr, string> error)
        {
            if (error is null)
                throw new ArgumentNullException(nameof(error));
            return Unwrap(error(_err));
        }
    }
}