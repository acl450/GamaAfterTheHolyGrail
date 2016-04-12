using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.Business
{
    public class Tag
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
