using System;

namespace Sirh3e.Rust.Option
{
    public class Option<T>
    {
        private readonly T _some;
        public readonly bool IsSome;
        public bool IsNone => !IsSome;

        private Option(T some)
        {
            _some = some;
            IsSome = typeof(T).IsValueType || some != null;
        }

        public T Unwrap() => Unwrap(() => $"Cannot unwrap \"None\" of type {typeof(T)}.");

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
            
            if (alternative is null)
                throw new ArgumentNullException(nameof(alternative));

            return alternative();
        }

        public F Map<U, F>(Func<T, F> mapper)
            where F : Option<U>
        {
            if (IsNone)
                throw new NotImplementedException(); //ToDo create own exception

            return mapper(_some);
        }

        public U MapOr<U, F>(U @default, Func<T, F> mapper)
            where F : Option<U>
        {
            if (IsNone)
                throw new NotImplementedException(); //ToDo create own exception

            var option = mapper(_some);
            if (option.IsSome)
                return option.Unwrap();

            if (@default is null)
                throw new ArgumentNullException(nameof(@default));
            
            return @default;
        }

        /*
        public U MapOrElse<U, D, F>(Func<D> @default, Func<T, F> mapper)
            where D : U
            where F : Option<U>
        {
            if(IsNone)
        }
        */
    }
}