using Gama.AtencionesModule.Services;
using Gama.AtencionesModule.Views;
using GamaAfterTheHolyGrail.Core;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama.AtencionesModule
{
    public class AtencionesModule : ModuleBase
    {
        public AtencionesModule(IUnityContainer container, IRegionManager regionManager)
           : base(container, regionManager)
        {

        }

        public override void Initialize()
        {
            this.Container.RegisterType<PanelSwitcherView>();
            this.Container.RegisterType<SearchBoxView>();
            this.Container.RegisterType<ToolbarView>();

            this.Container.RegisterType<DashboardView>();
            this.Container.RegisterType<PersonasContentView>();
            this.Container.RegisterType<CitasContentView>();
            //this.Container.RegisterType<AtencionesContentView>();
            //this.Container.RegisterType<EstadisticasContentView>();

            this.Container.RegisterType<object, PersonaDetailTabView>("PersonaDetailTabView");
            this.Container.RegisterType<object, CitasContentView>("CitasContentView");

            this.Container.RegisterType<IPersonaRepository, FakePersonaRepository>();
            
            this.RegionManager.RegisterViewWithRegion(
                RegionNames.PanelSwitcherRegion, typeof(PanelSwitcherView));
            this.RegionManager.RegisterViewWithRegion(
                RegionNames.ContentRegion, typeof(DashboardView));
            this.RegionManager.RegisterViewWithRegion(
                RegionNames.TabContentRegion, typeof(PersonaDetailTabView));
        }
    }
}
