using GamaAfterTheHolyGrail.Core.Util;
using System;
using System.ComponentModel;

namespace GamaAfterTheHolyGrail.Business
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum EstadoDeProyectoEnum
    {
        [Description("No proporcionado")]
        NoProporcionado,
        [Description("No iniciado")]
        NoIniciado,
        [Description("Activo")]
        Activo,
        [Description("Inactivo")]
        Inactivo,
        [Description("Finalizado")]
        Finalizado
    }

    public class EstadoDeProyecto 
    {
        public EstadoDeProyectoEnum Estado { get; set; }
        public string UltimaInformacion { get; set; }
        public DateTime? UltimaActualizacion { get; set; }
    }
}