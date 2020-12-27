using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        public void Match(Action<TOk> onOk, Action<TErr> onErr)
        {
            if (IsOk)
            {
                if (onOk is null)
                    throw new ArgumentNullException(nameof(onOk));

                onOk(_ok);
            }
            else
            {
                if (onErr is null)
                    throw new ArgumentNullException(nameof(onErr));
                onErr(_err);
            }
        }

        public T Match<T>(Func<TOk, T> onOk, Func<TErr, T> onErr)
        {
            if (IsOk)
            {
                if (onOk is null)
                    throw new ArgumentNullException(nameof(onOk));
                return onOk(_ok);
            }

            if (onErr is null)
                throw new ArgumentNullException(nameof(onErr));
            return onErr(_err);
        }
    }
}