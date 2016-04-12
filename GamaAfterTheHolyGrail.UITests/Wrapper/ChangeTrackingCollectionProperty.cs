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
    public class ChangeTrackingCollectionProperty
    {
        private Proyecto _proyecto;
        private List<ColaboradorWrapper> _colaboradores;


        [TestInitialize]
        public void Initialize()
        {
            _colaboradores = new List<ColaboradorWrapper>()
            {
                new ColaboradorWrapper(new Colaborador() { Nombre = "Colaborador 1" }),
                new ColaboradorWrapper(new Colaborador() { Nombre = "Colaborador 2" }),
            };

            _proyecto = new Proyecto()
            {
                Objetivos = new List<Objetivo>(),
                Colaboradores = new List<Colaborador>(),
                Tags = new List<Tag>(),
                Eventos = new List<Evento>(),
                Estado = new EstadoDeProyecto(),
            };
        }

        [TestMethod]
        public void ShouldSetIsChangedOfProyectoWrapper()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            Assert.IsFalse(wrapper.IsChanged);

            wrapper.Colaboradores.Add(new ColaboradorWrapper(new Colaborador()));
            Assert.IsTrue(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsChangedPropertyOfProyectoWrapper()
        {
            var fired = false;
            var wrapper = new ProyectoWrapper(_proyecto);

            wrapper.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == nameof(wrapper.IsChanged))
                {
                    fired = true;
                }
            };

            wrapper.Colaboradores.Add(new ColaboradorWrapper(new Colaborador()));
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldAcceptChanges()
        {
            var wrapper = new ProyectoWrapper(new Proyecto()
            {
                Objetivos = new List<Objetivo>(),
                Colaboradores = new List<Colaborador>(_colaboradores.Select(cw => cw.Model)),
                Tags = new List<Tag>(),
                Eventos = new List<Evento>(),
                Estado = new EstadoDeProyecto(),
            });

            var colaboradorToRemove = wrapper.Colaboradores[0];
            var colaboradorToModify = wrapper.Colaboradores[1];

            var colaboradorToAdd1 = new ColaboradorWrapper(new Colaborador());
            var colaboradorToAdd2 = new ColaboradorWrapper(new Colaborador());
            wrapper.Colaboradores.Add(colaboradorToAdd1);
            wrapper.Colaboradores.Add(colaboradorToAdd2);
            wrapper.Colaboradores.Remove(colaboradorToRemove);
            colaboradorToModify.Nombre = "Otro Nombre";

            Assert.IsTrue(wrapper.IsChanged);
            Assert.AreEqual(3, wrapper.Colaboradores.Count);
            Assert.AreEqual(2, wrapper.Colaboradores.AddedItems.Count);
            Assert.AreEqual(1, wrapper.Colaboradores.RemovedItems.Count);
            Assert.AreEqual(1, wrapper.Colaboradores.ModifiedItems.Count);

            wrapper.AcceptChanges();

            Assert.IsFalse(wrapper.IsChanged);
            Assert.AreEqual(3, wrapper.Colaboradores.Count);
            Assert.AreEqual(0, wrapper.Colaboradores.AddedItems.Count);
            Assert.AreEqual(0, wrapper.Colaboradores.RemovedItems.Count);
            Assert.AreEqual(0, wrapper.Colaboradores.ModifiedItems.Count);
        }

        [TestMethod]
        public void ShouldRejectChanges()
        {
            var wrapper = new ProyectoWrapper(new Proyecto()
            {
                Objetivos = new List<Objetivo>(),
                Colaboradores = new List<Colaborador>(_colaboradores.Select(cw => cw.Model)),
                Tags = new List<Tag>(),
                Eventos = new List<Evento>(),
                Estado = new EstadoDeProyecto(),
            });

            var colaboradorToRemove = wrapper.Colaboradores[0];
            var colaboradorToModify = wrapper.Colaboradores[1];

            var colaboradorToAdd1 = new ColaboradorWrapper(new Colaborador());
            var colaboradorToAdd2 = new ColaboradorWrapper(new Colaborador());
            wrapper.Colaboradores.Add(colaboradorToAdd1);
            wrapper.Colaboradores.Add(colaboradorToAdd2);
            wrapper.Colaboradores.Remove(colaboradorToRemove);
            colaboradorToModify.Nombre = "Otro Nombre";

            Assert.IsTrue(wrapper.IsChanged);
            Assert.AreEqual(3, wrapper.Colaboradores.Count);
            Assert.AreEqual(2, wrapper.Colaboradores.AddedItems.Count);
            Assert.AreEqual(1, wrapper.Colaboradores.RemovedItems.Count);
            Assert.AreEqual(1, wrapper.Colaboradores.ModifiedItems.Count);

            wrapper.RejectChanges();

            Assert.IsFalse(wrapper.IsChanged);
            Assert.AreEqual(2, wrapper.Colaboradores.Count);
            Assert.AreEqual(0, wrapper.Colaboradores.AddedItems.Count);
            Assert.AreEqual(0, wrapper.Colaboradores.RemovedItems.Count);
            Assert.AreEqual(0, wrapper.Colaboradores.ModifiedItems.Count);
        }
      
    }
}
