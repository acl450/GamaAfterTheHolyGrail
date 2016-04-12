using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.CooperacionModule.Wrapper
{
    public class ColaboradorWrapper : ModelWrapper<Colaborador>
    {
        public ColaboradorWrapper(Colaborador model)
            : base(model)
        { }

        public string Nombre
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string NombreOriginalValue => GetOriginalValue<string>(nameof(Nombre));

        public bool NombreIsChanged => GetIsChanged(nameof(Nombre));

        public string Telefono
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string TelefonoOriginalValue => GetOriginalValue<string>(nameof(Telefono));

        public bool TelefonoIsChanged => GetIsChanged(nameof(Telefono));

        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string EmailOriginalValue => GetOriginalValue<string>(nameof(Email));

        public bool EmailIsChanged => GetIsChanged(nameof(Email));

        public string Avatar
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string AvatarOriginalValue => GetOriginalValue<string>(nameof(Avatar));

        public bool AvatarIsChanged => GetIsChanged(nameof(Avatar));

        public Byte[] AvatarB
        {
            get { return GetValue<Byte[]>(); }
            set { SetValue(value); }
        }

        public string AvatarBOriginalValue => GetOriginalValue<string>(nameof(AvatarB));

        public bool AvatarBIsChanged => GetIsChanged(nameof(AvatarB));
    }
}
