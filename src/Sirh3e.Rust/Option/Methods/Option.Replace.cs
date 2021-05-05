namespace Sirh3e.Rust.Option
{
    public partial struct Option<TSome>
    {
        public Option<TSome> Replace(TSome some)
        {
            var option = this;

            SetSome(some);

            return option;
        }
    }
}