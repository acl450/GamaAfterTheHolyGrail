using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace GamaAfterTheHolyGrail.Core
{
    public abstract class ModuleBase : IModule
    {
        protected IUnityContainer Container { get; set; }
        protected IRegionManager RegionManager { get; private set; }

        public ModuleBase(IUnityContainer container, IRegionManager regionManager)
        {
            this.Container = container;
            this.RegionManager = regionManager;
        }

        public abstract void Initialize();
    }
}
