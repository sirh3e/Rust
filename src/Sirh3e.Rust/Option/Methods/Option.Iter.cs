namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    //ToDo add documentation
    public IEnumerator<TSome> Iter()
        => GetEnumerator();
}