using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.CooperacionModule.Wrapper
{
    public class EventoWrapper : ModelWrapper<Evento>
    {
        public EventoWrapper(Evento model) : base(model)
        {

        }

        public string Titulo
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string TituloOriginalValue => GetOriginalValue<string>(nameof(this.Titulo));

        public bool TituloIsChange => GetIsChanged(nameof(this.Titulo));

        public DateTime? Fecha
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }

        public DateTime? FechaOriginalValue => GetOriginalValue<DateTime?>(nameof(Fecha));

        public bool FechaIsChanged => GetIsChanged(nameof(Fecha));
    }
}
