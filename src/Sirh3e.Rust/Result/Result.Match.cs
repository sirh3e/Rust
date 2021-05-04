using System;

namespace Sirh3e.Rust.Result
{
    public readonly partial struct Result<TOk, TErr>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="onOk"></param>
        /// <param name="onErr"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Match(Action<TOk> onOk, Action<TErr> onErr)
        {
            if ( IsOk )
            {
                if ( onOk is null )
                {
                    throw new ArgumentNullException(nameof(onOk));
                }

                onOk(_ok);
            }
            else
            {
                if ( onErr is null )
                {
                    throw new ArgumentNullException(nameof(onErr));
                }

                onErr(_err);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onOk"></param>
        /// <param name="onErr"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T Match<T>(Func<TOk, T> onOk, Func<TErr, T> onErr)
        {
            if ( IsOk )
            {
                if ( onOk is null )
                {
                    throw new ArgumentNullException(nameof(onOk));
                }

                return onOk(_ok);
            }

            if ( onErr is null )
            {
                throw new ArgumentNullException(nameof(onErr));
            }

            return onErr(_err);
        }
    }
}