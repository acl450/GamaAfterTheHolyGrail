using GamaAfterTheHolyGrail.CooperacionModule.Services;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.CooperacionModule.DesignTimeData
{
    public class ContentViewModelDTT
    {
        IProyectoRepository _proyectoRepository;

        public ContentViewModelDTT()
        {
            _proyectoRepository = new FakeProyectoRepository();

            this.Proyecto = new ProyectoWrapper(_proyectoRepository.GetAll()[0]);
        }

        public ProyectoWrapper Proyecto { get; set; }
    }
}
