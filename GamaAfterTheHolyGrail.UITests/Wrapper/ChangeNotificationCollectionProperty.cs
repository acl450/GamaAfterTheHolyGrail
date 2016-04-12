using GamaAfterTheHolyGrail.Business;
using GamaAfterTheHolyGrail.CooperacionModule.Converters;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using GamaAfterTheHolyGrail.Core;

namespace GamaAfterTheHolyGrail.UITests.Wrapper
{
    [TestClass]
    public class ChangeNotificationCollectionProperty
    {
        private Proyecto _proyecto;
        private Colaborador _colaborador;
        private Objetivo _objetivo;
        private Tag _tag;

        [TestInitialize]
        public void Initialize()
        {
            _objetivo = new Objetivo() { Titulo = "Lorem ipsum endeleble intosqui causa ateanum maravillae" };
            _tag = new Tag() { Value = "Tag segundo" };

            _colaborador = new Colaborador()
            {
                Nombre = "Agua Rocosa Artificial",
            };

            _proyecto = new Proyecto()
            {
                Titulo = "Título del Primer Proyecto",
                Objetivos = new List<Objetivo>()
                {
                    new Objetivo() { Titulo = "Objetivo número 1 para conseguir algo más o menos concreto" },
                    new Objetivo() { Titulo = "A veces los objetivos se escriben de diferentes maneras" },
                    new Objetivo() { Titulo = "Las piedras preciosas han llevado a más de un rey a la locura" },
                    _objetivo,
                },
                Estado = new EstadoDeProyecto(),
                Colaboradores = new List<Colaborador>()
                {
                    new Colaborador() { Nombre = "Agua Mineral Natural" },
                    _colaborador,
                },
                Tags = new List<Tag>() {
                    new Tag() { Value = "Tag primero" },
                    _tag
                },
            };
        }

        [TestMethod]
        public void ShouldInitializeObjetivosProperty()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            Assert.IsNotNull(wrapper.Objetivos);
            CheckIfModelObjetivosIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldInitializeColaboradoresProperty()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            Assert.IsNotNull(wrapper.Colaboradores);
            CheckIfModelColaboradoresIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterAddingObjetivo()
        {
            _proyecto.Objetivos.Remove(_objetivo);
            var wrapper = new ProyectoWrapper(_proyecto);
            wrapper.Objetivos.Add(new ObjetivoWrapper(_objetivo));
            CheckIfModelObjetivosIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterRemovingObjetivo()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            var objetivoToRemove = wrapper.Objetivos.Single(o => o.Model == _objetivo);
            wrapper.Objetivos.Remove(objetivoToRemove);
            CheckIfModelObjetivosIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterClearingObjetivos()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            wrapper.Objetivos.Clear();
            CheckIfModelObjetivosIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterAddingTag()
        {
            _proyecto.Tags.Remove(_tag);
            var wrapper = new ProyectoWrapper(_proyecto);
            var converter = new StringListToCommaSeparatedStringConverter();
            string before = (string)converter.Convert(wrapper.Model.Tags, null, null, null);

            string expected = before + ", " + _tag; // Simula la adición manual del tag en la UI
            wrapper.Model.Tags = (List<Tag>)converter.ConvertBack(expected, null, null, null);
            string actual = (string)converter.Convert(wrapper.Model.Tags, null, null, null);

            Assert.AreEqual(expected, actual);
            CheckIfModelTagsIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterRemovingTag()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            var converter = new StringListToCommaSeparatedStringConverter();
            string before = (string)converter.Convert(wrapper.Model.Tags, null, null, null);

            // Simula la eliminación manual del tag en la UI
            string expected = before.Substring(0, before.Length - _tag.Value.Length - ", ".Length);
             
            wrapper.Model.Tags = (List<Tag>)converter.ConvertBack(expected, null, null, null);
            string actual = (string)converter.Convert(wrapper.Model.Tags, null, null, null);

            Assert.AreEqual(expected, actual);

            CheckIfModelTagsIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterAddingColaborador()
        {
            _proyecto.Colaboradores.Remove(_colaborador);
            var wrapper = new ProyectoWrapper(_proyecto);
            wrapper.Colaboradores.Add(new ColaboradorWrapper(_colaborador));
            CheckIfModelColaboradoresIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterRemovingColaborador()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            var colaboradorToRemove = wrapper.Colaboradores.Single(w => w.Model == _colaborador);
            wrapper.Colaboradores.Remove(colaboradorToRemove);
            CheckIfModelColaboradoresIsInSync(wrapper);
        }

        private void CheckIfModelObjetivosIsInSync(ProyectoWrapper wrapper)
        {
            Assert.AreEqual(_proyecto.Objetivos.Count, wrapper.Objetivos.Count);
            Assert.IsTrue(_proyecto.Objetivos.All(o => wrapper.Objetivos.Any(wo => wo.Model == o)));
        }

        private void CheckIfModelTagsIsInSync(ProyectoWrapper wrapper)
        {
            Assert.AreEqual(_proyecto.Tags.Count, wrapper.Model.Tags.Count);
            Assert.IsTrue(_proyecto.Tags.All(t => wrapper.Model.Tags.Any(wt => wt == t)));
        }

        private void CheckIfModelColaboradoresIsInSync(ProyectoWrapper wrapper)
        {
            Assert.AreEqual(_proyecto.Colaboradores.Count, wrapper.Colaboradores.Count);
            Assert.IsTrue(_proyecto.Colaboradores.All(
                c => wrapper.Colaboradores.Any(wc => wc.Model == c)));
        }
    }
}
