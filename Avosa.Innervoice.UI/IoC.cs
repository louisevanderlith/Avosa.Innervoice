using Avosa.Innervoice.Core;
using Unity;

namespace Avosa.Innervoice.UI
{
    public static class IoC
    {
        private static readonly IUnityContainer _container;

        static IoC()
        {
            _container = new UnityContainer();
            SetupContainer();
        }

        private static void SetupContainer()
        {
            _container.RegisterType<IStorage, Storage>();
            _container.RegisterType<IManageProfile, ManageProfile>();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
