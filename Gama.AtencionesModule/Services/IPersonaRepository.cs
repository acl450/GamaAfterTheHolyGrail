using Gama.Atenciones.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gama.AtencionesModule.Services
{
    public interface IPersonaRepository
    {
        List<Persona> GetAll();
    }
}
