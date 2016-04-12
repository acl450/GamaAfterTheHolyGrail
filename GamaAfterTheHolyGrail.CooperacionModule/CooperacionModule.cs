using GamaAfterTheHolyGrail.CooperacionModule.Services;
using GamaAfterTheHolyGrail.CooperacionModule.Views;
using GamaAfterTheHolyGrail.Core;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.CooperacionModule
{
    public class CooperacionModule : ModuleBase
    {
        public CooperacionModule(IUnityContainer container, IRegionManager regionManager)
           : base(container, regionManager)
        {

        }

        public override void Initialize()
        {
            this.Container.RegisterType<SearchBoxView>();
            this.Container.RegisterType<ToolbarView>();
            this.Container.RegisterType<PanelSwitcherView>();
            this.Container.RegisterType<StatusBarView>();
            this.Container.RegisterType<ListadoDeProyectosView>();

            this.Container.RegisterType<object, ContentView>("ContentView");
            this.Container.RegisterType<IProyectoRepository, FakeProyectoRepository>();
            this.Container.RegisterType<ContentViewModel>();

            this.RegionManager.RegisterViewWithRegion(RegionNames.TabContentRegion, typeof(ListadoDeProyectosView));
            this.RegionManager.RegisterViewWithRegion(RegionNames.SearchBoxRegion, typeof(SearchBoxView));
            this.RegionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarView));
            this.RegionManager.RegisterViewWithRegion(RegionNames.PanelSwitcherRegion, typeof(PanelSwitcherView));
            this.RegionManager.RegisterViewWithRegion(RegionNames.StatusBarRegion, typeof(StatusBarView));
        }
    }
}
