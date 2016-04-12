using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama.Atenciones.Business
{
    public class Appointment
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Sala { get; set; }
        public string Asistente { get; set; }
    }
    public class PeriodoSemanal
    {
        public List<Appointment> Dias { get; set; }

        public PeriodoSemanal()
        {
            this.Dias = new List<Appointment>(7);
        }
    }
}
