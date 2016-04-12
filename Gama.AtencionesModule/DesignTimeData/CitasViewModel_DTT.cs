using Gama.Atenciones.Business;
using Gama.AtencionesModule.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama.AtencionesModule.DesignTimeData
{
    public class CitasViewModel_DTT
    {
        public List<PeriodoSemanal> Citas { get; set; }

        public CitasViewModel_DTT()
        {
            this.Citas = new List<PeriodoSemanal>()
            {
                new PeriodoSemanal()
                {
                     Dias = new List<Appointment>(7)
                     {
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now.AddDays(1) },
                         new Appointment() { Inicio = DateTime.Now.AddDays(2) },
                         new Appointment() { Inicio = DateTime.Now.AddDays(3) },
                         new Appointment() { Inicio = DateTime.Now.AddDays(4) },
                         new Appointment() { Inicio = DateTime.Now.AddDays(4) },
                         new Appointment() { Inicio = DateTime.Now.AddDays(4) },
                     }
                },
                new PeriodoSemanal()
                {
                     Dias = new List<Appointment>(7)
                     {
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now.AddDays(1) },
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now.AddDays(4) },
                         new Appointment() { Inicio = DateTime.Now.AddDays(4) },
                     }
                },
                new PeriodoSemanal()
                {
                     Dias = new List<Appointment>(7)
                     {
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now.AddDays(1) },
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now.AddDays(4) },
                         new Appointment() { Inicio = DateTime.Now.AddDays(4) },
                     }
                },
                new PeriodoSemanal()
                {
                     Dias = new List<Appointment>(7)
                     {
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now.AddDays(1) },
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now },
                         new Appointment() { Inicio = DateTime.Now.AddDays(4) },
                         new Appointment() { Inicio = DateTime.Now.AddDays(4) },
                     }
                }
            };
        }
    }
}
