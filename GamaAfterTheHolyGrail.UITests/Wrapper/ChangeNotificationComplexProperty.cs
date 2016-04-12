using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.UITests.Wrapper
{
    [TestClass]
    public class ChangeNotificationComplexProperty
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

        [TestMethod]
        public void ShouldInitializeEstadoProperty()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            Assert.IsNotNull(wrapper.Estado);
            Assert.AreEqual(_proyecto.Estado, wrapper.Estado.Model);
        }
    }
}
