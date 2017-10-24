namespace TestConsoleApp.Intefaces
{
    public interface IIocImpl
    {
        T Resolve<T>();
        void Register<TFrom, TTo>() where TTo : TFrom;
        void Register<T>(T o);
    }
}
