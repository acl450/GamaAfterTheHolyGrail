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
    public class ChangeTrackingSimpleProperty
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
        public void ShouldStoreOriginalValue()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            Assert.AreEqual("Título del Primer Proyecto", wrapper.TituloOriginalValue);

            wrapper.Titulo = "Nuevo título";
            Assert.AreEqual("Título del Primer Proyecto", wrapper.TituloOriginalValue);
        }

        [TestMethod]
        public void ShouldSetIsChanged()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            Assert.IsFalse(wrapper.TituloIsChanged);
            Assert.IsFalse(wrapper.IsChanged);

            wrapper.Titulo = "Nuevo título";
            Assert.IsTrue(wrapper.TituloIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.Titulo = "Título del Primer Proyecto";
            Assert.IsFalse(wrapper.TituloIsChanged);
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForTituloIsChanged()
        {
            var wrapper = new ProyectoWrapper(_proyecto);

            var fired = false;
            wrapper.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == nameof(wrapper.TituloIsChanged))
                {
                    fired = true;
                }
            };

            wrapper.Titulo = "Another title";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsChanged()
        {
            var wrapper = new ProyectoWrapper(_proyecto);

            var fired = false;
            wrapper.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(wrapper.IsChanged))
                {
                    fired = true;
                }
            };

            wrapper.Titulo = "Another title";
            Assert.IsTrue(fired);

            fired = false;
            wrapper.Titulo = "Título del Primer Proyecto"; // Valor original
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldAcceptChanges()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            Assert.IsFalse(wrapper.IsChanged);
            wrapper.Titulo = "Nuevo título";
            Assert.AreEqual("Nuevo título", wrapper.Titulo);
            Assert.AreEqual("Título del Primer Proyecto", wrapper.TituloOriginalValue);
            Assert.IsTrue(wrapper.TituloIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.AcceptChanges();

            Assert.AreEqual("Nuevo título", wrapper.Titulo);
            Assert.AreEqual("Nuevo título", wrapper.TituloOriginalValue);
            Assert.IsFalse(wrapper.TituloIsChanged);
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRejectChanges()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            Assert.IsFalse(wrapper.IsChanged);
            wrapper.Titulo = "Nuevo título";
            Assert.AreEqual("Nuevo título", wrapper.Titulo);
            Assert.AreEqual("Título del Primer Proyecto", wrapper.TituloOriginalValue);
            Assert.IsTrue(wrapper.TituloIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.RejectChanges();

            Assert.AreEqual("Título del Primer Proyecto", wrapper.Titulo);
            Assert.AreEqual("Título del Primer Proyecto", wrapper.TituloOriginalValue);
            Assert.IsFalse(wrapper.TituloIsChanged);
            Assert.IsFalse(wrapper.IsChanged);
        }
    }
}
