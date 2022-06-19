namespace Sirh3e.Rust.Result;

public struct ResultEnumerator<TOk> : IEnumerator<TOk>
{
    private readonly TOk[] _oks;
    private int _position;

    public ResultEnumerator(TOk[] oks)
    {
        _oks = oks ?? throw new ArgumentNullException(nameof(oks));
    }

    public bool MoveNext()
        => ++_position < _oks.Length;

    public void Reset()
        => _position = -1;

    object IEnumerator.Current => Current;

    public TOk Current => _oks[_position];

    public void Dispose()
    {
        if ( _oks.Length > 0 && _oks[0] is IDisposable disposable )
        {
            disposable.Dispose();
        }
    }
}