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
    public class ChangeTrackingComplexProperty
    {
        private Proyecto _proyecto;

        [TestInitialize]
        public void Initialize()
        {
            _proyecto = new Proyecto()
            {
                Titulo = "Título del Primer Proyecto",
                Objetivos = new List<Objetivo>(),
                Estado = new EstadoDeProyecto() { Estado = EstadoDeProyectoEnum.Activo },
                Colaboradores = new List<Colaborador>(),
                Tags = new List<Tag>(),
            };
        }
    
        [TestMethod]
        public void ShouldSetIsChangedOfProyectoWrapper()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            wrapper.Estado.Estado = EstadoDeProyectoEnum.Finalizado;
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.Estado.Estado = EstadoDeProyectoEnum.Activo;
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsChangedPropertyOfProyectoWrapper()
        {
            var fired = false;
            var wrapper = new ProyectoWrapper(_proyecto);
            wrapper.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(wrapper.IsChanged))
                {
                    fired = true;
                }
            };

            wrapper.Estado.Estado = EstadoDeProyectoEnum.Finalizado;
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldAcceptChanges()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            wrapper.Estado.Estado = EstadoDeProyectoEnum.Finalizado;
            Assert.AreEqual(EstadoDeProyectoEnum.Activo, wrapper.Estado.EstadoOriginalValue);
            
            wrapper.AcceptChanges();

            Assert.IsFalse(wrapper.IsChanged);
            Assert.AreEqual(EstadoDeProyectoEnum.Finalizado, wrapper.Estado.Estado);
            Assert.AreEqual(EstadoDeProyectoEnum.Finalizado, wrapper.Estado.EstadoOriginalValue);
        }

        [TestMethod]
        public void ShouldRejectChanges()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            wrapper.Estado.Estado = EstadoDeProyectoEnum.Finalizado;
            Assert.AreEqual(EstadoDeProyectoEnum.Activo, wrapper.Estado.EstadoOriginalValue);

            wrapper.RejectChanges();

            Assert.IsFalse(wrapper.IsChanged);
            Assert.AreEqual(EstadoDeProyectoEnum.Activo, wrapper.Estado.Estado);
            Assert.AreEqual(EstadoDeProyectoEnum.Activo, wrapper.Estado.EstadoOriginalValue);
        }
    }
}
