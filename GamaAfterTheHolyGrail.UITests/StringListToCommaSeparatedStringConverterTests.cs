using GamaAfterTheHolyGrail.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamaAfterTheHolyGrail.CooperacionModule.Converters;
using GamaAfterTheHolyGrail.CooperacionModule.Wrapper;
using System.Collections.ObjectModel;
using GamaAfterTheHolyGrail.Core;

namespace GamaAfterTheHolyGrail.UITests
{
    [TestClass]
    public class StringListToCommaSeparatedStringConverterTests
    {
        Proyecto _proyecto;
        StringListToCommaSeparatedStringConverter _converter;

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

            _converter = new StringListToCommaSeparatedStringConverter();
        }

        [TestMethod]
        public void ConvertShouldNotHaveEffectOnAnEmptyList()
        {
            var wrapper = new ProyectoWrapper(_proyecto);

            var expected = "";
            var actual = _converter.Convert(wrapper.Model.Tags, null, null, null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldConvertSingleWordsWithASpaceAfterTheCommas()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            wrapper.Model.Tags.Add(new Tag() { Value = "príméró" });
            wrapper.Model.Tags.Add(new Tag() { Value = "segundo" });
            wrapper.Model.Tags.Add(new Tag() { Value = "tercero" });

            var expected = "príméró, segundo, tercero";
            var actual = _converter.Convert(wrapper.Model.Tags, null, null, null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldConvertCompoundWordsWithASpaceAfterTheCommas()
        {
            var wrapper = new ProyectoWrapper(_proyecto);
            wrapper.Model.Tags.Add(new Tag() { Value = "primero si primero" });
            wrapper.Model.Tags.Add(new Tag() { Value = "segundo no" });
            wrapper.Model.Tags.Add(new Tag() { Value = "tercero si tercero" });

            var expected = "primero si primero, segundo no, tercero si tercero";
            var actual = _converter.Convert(wrapper.Model.Tags, null, null, null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldConvertAnyCombinationOfWords()
        {
            var wrapper = new ProyectoWrapper(_proyecto);

            wrapper.Model.Tags.Add(new Tag() { Value = "primero si primero" });
            wrapper.Model.Tags.Add(new Tag() { Value = "segundo" });
            wrapper.Model.Tags.Add(new Tag() { Value = "tercero si tercero" });
            wrapper.Model.Tags.Add(new Tag() { Value = "cuartamente cuatro suelen ser cuatro" });
            wrapper.Model.Tags.Add(new Tag() { Value = "cinco cinquenas hacen cinco" });
            wrapper.Model.Tags.Add(new Tag() { Value = "seis" });

            var expected = "primero si primero, segundo, tercero si tercero, " + 
                "cuartamente cuatro suelen ser cuatro, cinco cinquenas hacen cinco, seis";
            var actual = _converter.Convert(wrapper.Model.Tags, null, null, null);


            Assert.AreEqual(expected, actual);
        }
    }
}
