using GamaAfterTheHolyGrail.Business;
using System.Collections.Generic;

namespace GamaAfterTheHolyGrail.CooperacionModule.Services
{
    public interface IProyectoRepository
    {
        List<Proyecto> GetAll();
    }
}