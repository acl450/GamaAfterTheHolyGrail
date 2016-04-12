using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using GamaAfterTheHolyGrail.Business;

namespace GamaAfterTheHolyGrail.CooperacionModule.Wrapper.Tests
{
    [TestClass]
    public class BasicTests
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
        public void ShouldContainModelInModelProperty()
        {
            var wrapper = new ProyectoWrapper(_proyecto);

            Assert.AreEqual(_proyecto, wrapper.Model);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionIfModelIsNull()
        {
            try
            {
                var wrapper = new ProyectoWrapper(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionIfEstadoIsNull()
        {
            try
            {
                _proyecto.Estado = null;
                var wrapper = new ProyectoWrapper(_proyecto);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("'Estado' no puede ser nulo", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionIfLaListaDeColaboradoresIsNull()
        {
            try
            {
                _proyecto.Colaboradores = null;
                var wrapper = new ProyectoWrapper(_proyecto);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("La lista de colaboradores no puede ser nula", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionIfLaListaDeTagsIsNull()
        {
            try
            {
                _proyecto.Tags = null;
                var wrapper = new ProyectoWrapper(_proyecto);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("La lista de tags no puede ser nula", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void ShouldGetValueOfUnderlyingModelProperty()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            Assert.AreEqual(_proyecto.Titulo, wrapper.Titulo);
        }

        [TestMethod]
        public void ShouldSetValueOfUnderlyingModelProperty()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            wrapper.Titulo = "My title";
            Assert.AreEqual(_proyecto.Titulo, wrapper.Titulo);
        }
    }
}