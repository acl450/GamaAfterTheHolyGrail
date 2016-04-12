using Gama.Atenciones.Business;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama.AtencionesModule.Views
{
    public class CitasViewModel : BindableBase
    {
        public CitasViewModel()
        {
            this.DummyCommand = new DelegateCommand<object>(OnDummy);

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

        private void OnDummy(object obj)
        {
            int a = 2;
            System.Console.WriteLine(a);
        }

        public DelegateCommand<object> DummyCommand { get; private set; }

        public List<PeriodoSemanal> Citas { get; set; }
    }
}
