namespace Uno.Logic
{
    public interface IFactory<TReturn>
    {
        TReturn Create();
    }
    public interface IFactory<TParam1, TReturn>
    {
        TReturn Create(TParam1 simbolo);
    }

    public interface IFactory<TParam1, TParam2, TReturn>
    {
        TReturn Create(TParam1 simbolo, TParam2 color);
    }
}