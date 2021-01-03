namespace Sirh3e.Rust.Option
{
    public static partial class OptionExtension
    {
        /// <summary>
        /// Converts from Option&lt;Option&lt;TSome&gt;&gt; to Option&lt;TSome&gt; 
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="TSome"></typeparam>
        /// <returns></returns>
        public static Option<TSome> Flatten<TSome>(this Option<Option<TSome>> option)
            => option.IsNone ? Option<TSome>.None : option.Unwrap();
    }
}