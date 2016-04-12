using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.Core
{
    public interface ITimestamps
    {
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        DateTime? RemovedAt { get; set; }
    }
}
