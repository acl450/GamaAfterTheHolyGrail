using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.CooperacionModule.Wrapper
{
    public class TagWrapper : ModelWrapper<Tag>
    {
        public TagWrapper(Tag model) : base(model)
        {

        }

        public string Value
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string ValueOriginalValue => GetOriginalValue<string>(nameof(this.Value));

        public bool ValueIsChange => GetIsChanged(nameof(this.Value));
    }
}
