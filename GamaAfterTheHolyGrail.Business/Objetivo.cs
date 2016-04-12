using GamaAfterTheHolyGrail.Core.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.Business
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum PrioridadEnum
    {
        [Description("Alta")]
        Alta,
        [Description("Normal")]
        Media,
        [Description("Baja")]
        Baja,
        [Description("Sin especificar")]
        SinEspecificar,
    }

    public class Objetivo
    {
        public string Titulo { get; set; }
        public PrioridadEnum Prioridad { get; set; }

        public override string ToString()
        {
            return Titulo;
        }
    }
}
