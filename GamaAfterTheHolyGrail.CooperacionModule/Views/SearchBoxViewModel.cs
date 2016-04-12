using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.CooperacionModule.Services;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using GamaAfterTheHolyGrail.Core;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GamaAfterTheHolyGrail.CooperacionModule.Views
{
    public class SearchBoxViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IProyectoRepository _proyectoRepository;

        public SearchBoxViewModel(IRegionManager regionManager, IProyectoRepository proyectoRepository)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
            this.SearchCommand = new DelegateCommand<object>(OnSearch);

            _proyectoRepository = proyectoRepository;

            this.Proyectos = new ObservableCollection<ProyectoWrapper>(
                 proyectoRepository.GetAll().Select(p => new ProyectoWrapper(p)));

            this.UltimoProyectoSeleccionado = this.Proyectos[0];
        }

        private ProyectoWrapper _ultimoProyectoSeleccionado;
        public ProyectoWrapper UltimoProyectoSeleccionado
        {
            get { return _ultimoProyectoSeleccionado; }
            set
            {
                if (/*_ultimoProyectoSeleccionado != value && */value != null)
                {
                    SetProperty(ref _ultimoProyectoSeleccionado, value);
                    var navigationParameters = new NavigationParameters();

                    navigationParameters.Add("Proyecto", _ultimoProyectoSeleccionado);

                    _regionManager.RequestNavigate(RegionNames.TabContentRegion, "ContentView", navigationParameters);
                }
            }
        }

        public ObservableCollection<ProyectoWrapper> Proyectos { get; set; }

        private string _lookupText;
        public string LookupText
        {
            get { return _lookupText; }
            set { SetProperty(ref _lookupText, value); }
        }

        public DelegateCommand<object> SearchCommand { get; private set; }

        private void OnSearch(object param)
        {
            this.Buscar(this.TextoDeBusqueda);
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        private void Navigate(string navigationPath)
        {
            //_regionManager.RequestNavigate("ContentRegion", navigationPath, parameters);
        }

        private List<string> _mensajeDeEspera = new List<string>() { "Espera por favor..." };
        public IEnumerable MensajeDeEspera { get { return _mensajeDeEspera; } }

        private string _textoDeBusqueda;
        public string TextoDeBusqueda
        {
            get { return _textoDeBusqueda; }
            set
            {
                if (_textoDeBusqueda != value)
                {
                    _textoDeBusqueda = value;
                    OnPropertyChanged();

                    _resultadoDeBusqueda = null;
                    OnPropertyChanged("ResultadoDeBusqueda");
                }
            }
        }

        public IEnumerable _resultadoDeBusqueda = null;
        public IEnumerable ResultadoDeBusqueda
        {
            get
            {
                //Buscar(TextoDeBusqueda);
                return _resultadoDeBusqueda;
            }
        }

        private void Buscar(string textoDeBusqueda)
        {
            ObservableCollection<ProyectoWrapper> result = this.Proyectos;
            //result = result.FindAll(p => p.Titulo.Contains(textoDeBusqueda));

            _resultadoDeBusqueda = result;
            OnPropertyChanged("ResultadoDeBusqueda");
        }
    }
}
