// See https://aka.ms/new-console-template for more information

using static Sirh3e.Rust.Generated.Results;
using Sirh3e.Rust.Generator.Attributes;
using Sirh3e.Rust.Result;
using static Sirh3e.Rust.Result.Extension;

//using MathResult = Sirh3e.Rust.Result.Result<int, string>;

var result = MathResult.Ok(42).Inspect(Console.WriteLine);

async Task<MathResult> Do()
{
    //var ok = Ok(1);
    return Sirh3e.Rust.Generated.Results.MathResult.Ok(1);
}

public static partial class Results
{
    [Result<int, string>]
    public static partial class MathResult
    {
        public static Result<int, string> Ok(int value) => Result<int, string>.Ok(value);
    }

    public static class IntoExtension
    {
        public static Result<TOk, TErr> Into<T, TOk, TErr>(T value)
            where T : IInto<T, TOk>
            where TOk : T
        {
            var v = value.Into(value, into => (TOk)into);
        }
    }

    public interface IInto<TIn, TOut>
    {
        TOut Into(TIn @in, Func<TIn, TOut> mapper);
    }
}

public static partial class Results
{
    public static class Math<T>
    {
        public class Error{}
        
        //public static Result<T, Error> Div(T lhs, T rhs) => ;
    }
}

namespace Gucci
{
    using Result = Sirh3e.Rust.Result.Result<int, string>;

    public static class Demo
    {
        public static Result Do() => Result.Ok(1);
    }
}

namespace YoLo
{
    using Result = Sirh3e.Rust.Result.Result<int, string>;
}