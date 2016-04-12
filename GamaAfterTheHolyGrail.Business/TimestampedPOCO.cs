using GamaAfterTheHolyGrail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.Business
{
    /// <summary>
    /// Permite conocer cuándo se ha creado, actualizado o 
    /// eliminado un modelo en la base de datos. Los
    /// modelos no se eliminan completamente, sino
    /// que permanecen como 'Inactivo'.
    /// </summary>
    public class TimestampedPOCO : ITimestamps
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
