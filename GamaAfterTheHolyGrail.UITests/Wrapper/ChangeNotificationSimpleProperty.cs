using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GamaAfterTheHolyGrail.UITests.Wrapper
{
    [TestClass]
    public class ChangeNotificationSimpleProperty
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
        public void ShouldRaisePropertyChangedEventOnPropertyChanged()
        {
            var wrapper = new ProyectoWrapper(_proyecto);

            var fired = false;
            wrapper.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == nameof(wrapper.Titulo))
                {
                    fired = true;
                }
            };

            wrapper.Titulo = "Another title";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldNotRaisePropertyChangedEventIfPropertyIsSetToSameValue()
        {
            var wrapper = new ProyectoWrapper(_proyecto);

            var fired = false;
            wrapper.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == nameof(wrapper.Titulo))
                {
                    fired = true;
                }
            };

            wrapper.Titulo = "Título del Primer Proyecto";
            Assert.IsFalse(fired);
        }
    }
}
