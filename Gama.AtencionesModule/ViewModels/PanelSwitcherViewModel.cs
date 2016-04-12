using GamaAfterTheHolyGrail.Core;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama.AtencionesModule.Views
{
    public class PanelSwitcherViewModel : ViewModelBase
    {
        private IRegionManager _regionManager;

        public PanelSwitcherViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            this.NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }
    }
}
