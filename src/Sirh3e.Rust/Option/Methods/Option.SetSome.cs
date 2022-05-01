namespace Sirh3e.Rust.Option;

public partial struct Option<TSome>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SetSome(TSome some)
    {
        _some = some;
        IsSome = Helper.IsSome(_some);
    }
}