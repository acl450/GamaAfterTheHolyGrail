using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using GamaAfterTheHolyGrail.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.UITests.Wrapper
{
    [TestClass]
    public class TimestampedWrapperTests
    {
        private Proyecto _proyecto;

        [TestInitialize]
        public void Initialize()
        {
            _proyecto = new Proyecto()
            {
                Titulo = "Título del Primer Proyecto",
                Objetivos = new List<Objetivo>(),
                Estado = new EstadoDeProyecto(),
                Colaboradores = new List<Colaborador>(),
                Tags = new List<Tag>(),
            };
        }

        [TestMethod()]
        public void TimePropertiesInBaseClassShouldBeNull()
        {
            var wrapper = new TimestampedWrapper<Proyecto>(_proyecto);

            Assert.IsNull(wrapper.CreatedAt);
            Assert.IsNull(wrapper.UpdatedAt);
            Assert.IsNull(wrapper.RemovedAt);
        }

        [TestMethod()]
        public void TimePropertiesInConcreteClassShouldBeThereAndShouldBeNull()
        {
            var wrapper = new ProyectoWrapper(_proyecto);

            Assert.IsNull(wrapper.CreatedAt);
            Assert.IsNull(wrapper.UpdatedAt);
            Assert.IsNull(wrapper.RemovedAt);
        }
    }
}
