using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.CooperacionModule.Converters;
using GamaAfterTheHolyGrail.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.CooperacionModule.Wrapper
{
    public class ProyectoWrapper : TimestampedWrapper<Proyecto>
    {
        private StringListToCommaSeparatedStringConverter _converter;

        public ProyectoWrapper(Proyecto model) : base(model)
        {
            _converter = new StringListToCommaSeparatedStringConverter();

            InitializeComplexProperties(model);
            InitializeCollectionProperties(model);
        }

        private void InitializeCollectionProperties(Proyecto model)
        {
            if (model.Objetivos == null)
            {
                throw new ArgumentException("La lista de objetivos no puede ser nula");
            }
            else if (model.Tags == null)
            {
                throw new ArgumentException("La lista de tags no puede ser nula");
            }
            else if (model.Colaboradores == null)
            {
                throw new ArgumentException("La lista de colaboradores no puede ser nula");
            }
            else if (model.Eventos == null)
            {
                throw new ArgumentException("La lista de eventos no puede ser nula");
            }

            this.Objetivos = new ChangeTrackingCollection<ObjetivoWrapper>(
                model.Objetivos.Select(o => new ObjetivoWrapper(o)));
            this.RegisterCollection(this.Objetivos, model.Objetivos);

            model.TagsAsString = (string)_converter.Convert(model.Tags, null, null, null);

            this.Colaboradores = new ChangeTrackingCollection<ColaboradorWrapper>(
                model.Colaboradores.Select(c => new ColaboradorWrapper(c)));
            this.RegisterCollection(this.Colaboradores, model.Colaboradores);

            this.Eventos = new ChangeTrackingCollection<EventoWrapper>(
                model.Eventos.Select(e => new EventoWrapper(e)));
            this.RegisterCollection(this.Eventos, model.Eventos);
        }

        private void InitializeComplexProperties(Proyecto model)
        {
            if (model.Estado == null)
            {
                throw new ArgumentException("'Estado' no puede ser nulo");
            }

            this.Estado = new EstadoDeProyectoWrapper(model.Estado);
            RegisterComplex(this.Estado);
        }


        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public string Titulo
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string TituloOriginalValue => GetOriginalValue<string>(nameof(Titulo));

        public bool TituloIsChanged => GetIsChanged(nameof(Titulo));

        public string Descripcion
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string DescripcionOriginalValue => GetOriginalValue<string>(nameof(Descripcion));

        public bool DescripcionIsChanged => GetIsChanged(nameof(Descripcion));

        public string Seguimiento
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string SeguimientoOriginalValue => GetOriginalValue<string>(nameof(Seguimiento));

        public bool SeguimientoIsChanged => GetIsChanged(nameof(Seguimiento));

        public DateTime? FechaDeInicio
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }

        public DateTime? FechaDeInicioOriginalValue => GetOriginalValue<DateTime?>(nameof(FechaDeInicio));

        public bool FechaDeInicioIsChanged => GetIsChanged(nameof(FechaDeInicio));

        public DateTime? FechaDeFinalizacion
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }

        public DateTime? FechaDeFinalizacionOriginalValue => GetOriginalValue<DateTime?>(nameof(FechaDeFinalizacion));

        public bool FechaDeFinalizacionIsChanged => GetIsChanged(nameof(FechaDeFinalizacion));


        public string TagsAsString
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string TagsAsStringOriginalValue => GetOriginalValue<string>(nameof(TagsAsString));

        public bool TagsAsStringIsChanged => GetIsChanged(nameof(TagsAsString));


        public EstadoDeProyectoWrapper Estado { get; private set; }
        public ChangeTrackingCollection<ObjetivoWrapper> Objetivos { get; private set; }
        public ChangeTrackingCollection<ColaboradorWrapper> Colaboradores { get; private set; }
        public ChangeTrackingCollection<EventoWrapper> Eventos { get; private set; }
    }
}
