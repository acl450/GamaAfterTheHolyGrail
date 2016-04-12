using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.CooperacionModule.Wrapper
{
    public class EstadoDeProyectoWrapper : ModelWrapper<EstadoDeProyecto>
    {
        public EstadoDeProyectoWrapper(EstadoDeProyecto model) : base(model)
        {
        }

        public EstadoDeProyectoEnum Estado
        {
            get { return GetValue<EstadoDeProyectoEnum>(); }
            set { SetValue(value); }
        }

        public EstadoDeProyectoEnum EstadoOriginalValue => GetOriginalValue<EstadoDeProyectoEnum>(nameof(Estado));

        public bool EstadoIsChanged => GetIsChanged(nameof(Estado));

        public string UltimaInformacion
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string UltimaInformacionOriginalValue => GetOriginalValue<string>(nameof(UltimaInformacion));

        public bool UltimaInformacionIsChanged => GetIsChanged(nameof(UltimaInformacion));

        public DateTime? UltimaActualizacion
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }

        public DateTime? UltimaActualizacionOriginalValue => GetOriginalValue<DateTime?>(nameof(UltimaActualizacion));

        public bool UltimaActualizacionIsChanged => GetIsChanged(nameof(UltimaInformacion));
    }
}
