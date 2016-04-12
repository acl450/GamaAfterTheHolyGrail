using GamaAfterTheHolyGrail.Core.Util;
using System;
using System.ComponentModel;

namespace GamaAfterTheHolyGrail.Business
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum TipoDeColaborador
    {
        [Description("No disponible")]
        NoDisponible,
        [Description("Voluntario")]
        Voluntario,
        [Description("Personal de Gamá")]
        PersonalDeGama,
        [Description("Personal de otra Entidad")]
        PersonalDeOtraEntidad,
        [Description("Entidad")]
        Entidad
    }

    public class Colaborador : TimestampedPOCO
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string InformacionAdicional { get; set; }

        public string Avatar { get; set; }
        public Byte[] AvatarB { get; set; }

        public TipoDeColaborador Tipo { get; set; }
        public PerfilSocial PerfilSocial { get; set; }
    }
}