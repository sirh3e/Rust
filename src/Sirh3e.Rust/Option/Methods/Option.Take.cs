namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        public Option<TSome> Take()
        {
            var option = this;

            _some = default;
            IsSome = false;

            return option;
        }
    }
}