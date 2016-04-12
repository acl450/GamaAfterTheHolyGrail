using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gama.Atenciones.Business;

namespace Gama.AtencionesModule.Services
{
    public class FakePersonaRepository : IPersonaRepository
    {
        public List<Persona> GetAll()
        {
            var persona1 = new Persona()
            {
                Nombre = "Algún Nombre Conapellidos",
                FechaDeNacimiento = DateTime.Now.AddYears(-23),
                Dni = "00000000T",
            };

            var resultado = new List<Persona>() { persona1 };

            resultado.AddRange(new List<Persona>(resultado));
            resultado.AddRange(new List<Persona>(resultado));
            resultado.AddRange(new List<Persona>(resultado));

            return resultado;
        }
    }
}
