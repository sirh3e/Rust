using System;

namespace Sirh3e.Rust.Option
{
    public readonly partial struct Option<TSome>
    {
        public void Match(Action<TSome> onSome, Action onNone)
        {
            if (IsSome)
            {
                if (onSome is null)
                {
                    throw new ArgumentNullException(nameof(onSome));
                }

                onSome(_some);
            }
            else
            {
                if (onNone is null)
                {
                    throw new ArgumentNullException(nameof(onNone));
                }

                onNone();
            }
        }

        private void Match(Action<TSome> onSome, Action<TSome> onNone) 
        {
            if (IsSome)
            {
                if (onSome is null)
                {
                    throw new ArgumentNullException(nameof(onSome));
                }

                onSome(_some);
            }
            else
            {
                if (onNone is null)
                {
                    throw new ArgumentNullException(nameof(onNone));
                }

                onNone(_some);
            }
        }

        public T Match<T>(Func<TSome, T> onSome, Func<T> onNone)
        {
            if (IsSome)
            {
                if (onSome is null)
                {
                    throw new ArgumentNullException(nameof(onSome));
                }

                return onSome(_some);
            }

            if (onNone is null)
            {
                throw new ArgumentNullException(nameof(onNone));
            }

            return onNone();
        }
    }
}