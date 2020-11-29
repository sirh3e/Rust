using System;

namespace Sirh3e.Rust.Option
{
    public class Option<T>
    {
        private readonly T _some;
        public readonly bool IsSome;
        public bool IsNone => !IsSome;

        private Option()
        {
            IsSome = false;
        }

        private Option(T some)
        {
            _some = some;
            IsSome = typeof(T).IsValueType || some != null;
        }

        public static Option<T> Some(T some) => new(some);

        public T Unwrap() => Unwrap(() => $"Cannot unwrap \"None\" of type {typeof(T)}.");

        public static Option<T> None => new();
        public static implicit operator Option<T>(None none) => None;

        public T Unwrap(Func<string> error)
        {
            if (IsSome)
                return Unwrap(error.Invoke());

            if (error is null)
                throw new ArgumentNullException(nameof(error));

            throw new NotImplementedException(); //ToDo create own exception
        }

        public T Unwrap(string error)
        {
            if (string.IsNullOrEmpty(error))
                throw new ArgumentNullException(nameof(error));

            if (IsNone)
                throw new NotImplementedException(error); //ToDo create own exception

            return _some;
        }

        public T UnwrapOr(T other) => IsSome ? _some : other;

        public T UnwrapOrElse(Func<T> alternative)
        {
            if (IsSome)
                return _some;

            return alternative() ?? throw new ArgumentNullException(nameof(alternative));
        }

        public Option<F> Map<F>(Func<T, F> mapper)
        {
            if (IsNone)
                throw new NotImplementedException(); //ToDo create own exception

            return Option<F>.Some(mapper(_some) ?? throw new ArgumentNullException(nameof(mapper)));
        }

        public F MapOr<F>(F @default, Func<T, F> mapper)
        {
            if (IsSome)
                return mapper(_some) ?? throw new ArgumentNullException(nameof(mapper));

            return @default ?? throw new ArgumentNullException(nameof(@default));
        }

        public U MapOrElse<U, F>(Func<U> @default, Func<T, F> mapper)
            where F : U
        {
            if (IsSome)
                return mapper is null ? @default() ?? throw new ArgumentNullException(nameof(@default)) : mapper(_some);
            return @default() ?? throw new ArgumentNullException(nameof(@default));
        }
    }
}