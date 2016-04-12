using GamaAfterTheHolyGrail.CooperacionModule.Services;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using GamaAfterTheHolyGrail.Core;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Regions;

namespace GamaAfterTheHolyGrail.CooperacionModule.Views
{
    public class ContentViewModel : ViewModelBase
    {
        IProyectoRepository _proyectoRepository;

        public ContentViewModel(IProyectoRepository proyectoRepository)
        {
            this.GuardarCommand = new DelegateCommand<ProyectoWrapper>(OnGuardarExecute, OnGuardarCanExecute);
            this.ResetCommand = new DelegateCommand<ProyectoWrapper>(OnResetExecute, OnResetCanExecute);
            this.CancelarCommand = new DelegateCommand<ProyectoWrapper>(OnCancelarExecute, OnCancelarCanExecute);

            _proyectoRepository = proyectoRepository;

            this.Proyecto = new ProyectoWrapper(_proyectoRepository.GetAll().Where(p => p.Id == 1).First());

            this.Proyecto.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(this.Proyecto.IsChanged))
                {
                    this.InvalidateCommands();
                }
            };

            this.InvalidateCommands();

            this.Title = this.Proyecto.Titulo.Substring(0, 20);
        }

        private ProyectoWrapper _proyecto;
        public ProyectoWrapper Proyecto
        {
            get { return _proyecto; }
            private set
            {
                _proyecto = value;
                OnPropertyChanged();
            }
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var proyecto = navigationContext.Parameters["Proyecto"] as ProyectoWrapper;

            return proyecto.Id == this.Proyecto.Id;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var proyecto = navigationContext.Parameters["Proyecto"] as ProyectoWrapper;

            if (proyecto != null) 
                this.Proyecto = proyecto;
        }

        #region Commands

        public ICommand GuardarCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand CancelarCommand { get; private set; }

        private void OnGuardarExecute(ProyectoWrapper wrapper)
        {
            Console.WriteLine("OnGuardarExecute");
        }

        private bool OnGuardarCanExecute(ProyectoWrapper wrapper)
        {
            return this.Proyecto.IsChanged;
        }

        private void OnResetExecute(ProyectoWrapper wrapper)
        {
            Console.WriteLine("OnResetExecute");
        }

        private bool OnResetCanExecute(ProyectoWrapper wrapper)
        {
            return true;
        }

        private void OnCancelarExecute(ProyectoWrapper wrapper)
        {
            Console.WriteLine("OnCancelarExecute");
        }

        private bool OnCancelarCanExecute(ProyectoWrapper wrapper)
        {
            return true;
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand<ProyectoWrapper>)GuardarCommand).RaiseCanExecuteChanged();
            ((DelegateCommand<ProyectoWrapper>)ResetCommand).RaiseCanExecuteChanged();
            ((DelegateCommand<ProyectoWrapper>)CancelarCommand).RaiseCanExecuteChanged();
        }

        #endregion
    }
}
