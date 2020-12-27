namespace Sirh3e.Rust.Option.Extensions
{
    public static partial class OptionExtension
    {
        public static Option<TSome> Flatten<TSome>(this Option<Option<TSome>> option)
            => option.IsNone ? Option<TSome>.None : option.Unwrap();
    }
}