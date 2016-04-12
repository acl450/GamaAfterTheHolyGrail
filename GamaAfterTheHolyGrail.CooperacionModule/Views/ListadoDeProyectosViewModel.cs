using GamaAfterTheHolyGrail.CooperacionModule.Services;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using GamaAfterTheHolyGrail.Core;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.CooperacionModule.Views
{
    public class ListadoDeProyectosViewModel : ViewModelBase
    {
        private IRegionManager _regionManager;
        private IProyectoRepository _proyectoRepository;

        public ListadoDeProyectosViewModel(IRegionManager regionManager, IProyectoRepository proyectoRepository)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);

            _proyectoRepository = proyectoRepository;

            this.Proyectos = new ObservableCollection<ProyectoWrapper>(
                 proyectoRepository.GetAll().Select(p => new ProyectoWrapper(p)));

            this.Proyectos.AddRange(new ObservableCollection<ProyectoWrapper>(this.Proyectos));
            this.Proyectos.AddRange(new ObservableCollection<ProyectoWrapper>(this.Proyectos));
            this.Proyectos.AddRange(new ObservableCollection<ProyectoWrapper>(this.Proyectos));

            this.Title = "Explorar";
            
        }

        public ObservableCollection<ProyectoWrapper> Proyectos { get; set; }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        private void Navigate(string navigationPath)
        {
            //_regionManager.RequestNavigate("ContentRegion", navigationPath, parameters);
        }
    }
}
