namespace Sirh3e.Rust.Option;

public struct OptionEnumerator<TSome> : IEnumerator<TSome>
{
    private readonly TSome[] _somes;
    private int _position;

    public OptionEnumerator(TSome[] somes) : this()
    {
        _somes = somes ?? throw new ArgumentNullException(nameof(somes));
    }

    public bool MoveNext()
        => ++_position < _somes.Length;

    public void Reset()
        => _position = -1;

    object IEnumerator.Current => Current;

    public TSome Current => _somes[_position];


    public void Dispose()
    {
        if ( _somes.Length > 0 && _somes[0] is IDisposable disposable )
        {
            disposable.Dispose();
        }
    }
}