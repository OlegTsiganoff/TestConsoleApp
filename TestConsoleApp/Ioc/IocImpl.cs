using Ninject;
using TestConsoleApp.Intefaces;

namespace TestConsoleApp.Ioc
{
    public class IocImpl : IIocImpl
    {
        private readonly StandardKernel _kernel;

        public IocImpl()
        {
            _kernel = new StandardKernel();
        }

        public T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        public void Register<TFrom, TTo>() where TTo : TFrom
        {
            _kernel.Unbind<TFrom>();
            _kernel.Bind<TFrom>().To<TTo>();
        }

        public void Register<T>(T o)
        {
            _kernel.Unbind<T>();
            _kernel.Bind<T>().ToConstant(o);
        }
    }
}
