using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.CooperacionModule.Wrapper
{
    public class ObjetivoWrapper : ModelWrapper<Objetivo>
    {
        public ObjetivoWrapper(Objetivo model)
            : base(model)
        { }

        public string Titulo
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string TituloOriginalValue => GetOriginalValue<string>(nameof(Titulo));

        public bool TituloIsChanged => GetIsChanged(nameof(Titulo));

        public PrioridadEnum Prioridad
        {
            get { return GetValue<PrioridadEnum>(); }
            set { SetValue(value); }
        }

        public PrioridadEnum PrioridadOriginalValue => GetOriginalValue<PrioridadEnum>(nameof(Prioridad));

        public bool PrioridadIsChanged => GetIsChanged(nameof(Prioridad));
    }
}
