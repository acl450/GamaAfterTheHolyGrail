using Gama.Atenciones.Business;
using Gama.AtencionesModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama.AtencionesModule.DesignTimeData
{
    public class DashboardViewModel_DTT 
    {
        public string Title { get; set; }

        public DashboardViewModel_DTT()
        {
            this.Title = "Dashborad";

            var repo = new FakePersonaRepository();

            this.Personas = new List<Persona>();

            this.Personas = repo.GetAll();
        }

        public List<Persona> Personas { get; set; }
    }
}
