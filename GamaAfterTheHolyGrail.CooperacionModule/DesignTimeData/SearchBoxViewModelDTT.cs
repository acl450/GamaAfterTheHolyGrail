using GamaAfterTheHolyGrail.CooperacionModule.Services;
using GamaAfterTheHolyGrail.CooperacionModule.Views;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.CooperacionModule.DesignTimeData
{
    public class SearchBoxViewModelDTT : BindableBase
    {
        IProyectoRepository _proyectoRepository;

        public SearchBoxViewModelDTT()
        {
            _proyectoRepository = new FakeProyectoRepository();

            this.LookupText = "";

            this.Proyectos = new ObservableCollection<ProyectoWrapper>(
                _proyectoRepository.GetAll().Select(p => new ProyectoWrapper(p)));

            this.Proyectos.AddRange(new ObservableCollection<ProyectoWrapper>(this.Proyectos));
            this.Proyectos.AddRange(new ObservableCollection<ProyectoWrapper>(this.Proyectos));
            this.Proyectos.AddRange(new ObservableCollection<ProyectoWrapper>(this.Proyectos));

            OnPropertyChanged("Proyectos");
        }

        private string _lookupText;
        public string LookupText
        {
            get { return _lookupText; }
            set { SetProperty(ref _lookupText, value); }
        }

        public ObservableCollection<ProyectoWrapper> Proyectos { get; set; }
    }
}
