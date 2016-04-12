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
    public class ChangeTrackingCollectionTests
    {
        private List<ColaboradorWrapper> _colaboradores;

        [TestInitialize]
        public void Initialize()
        {
            _colaboradores = new List<ColaboradorWrapper>()
            {
                new ColaboradorWrapper(new Colaborador() { Nombre = "Colaborador 1" }),
                new ColaboradorWrapper(new Colaborador() { Nombre = "Colaborador 2" }),
            };
        }

        #region Manipulando la lista
        [TestMethod]
        public void ShouldTrackAddedItems()
        {
            var colaboradorToAdd = new ColaboradorWrapper(new Colaborador());

            var c = new ChangeTrackingCollection<ColaboradorWrapper>(_colaboradores);
            Assert.AreEqual(2, c.Count);
            Assert.IsFalse(c.IsChanged);

            c.Add(colaboradorToAdd);
            Assert.AreEqual(3, c.Count);
            Assert.AreEqual(1, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.AreEqual(colaboradorToAdd, c.AddedItems.First());
            Assert.IsTrue(c.IsChanged);

            c.Remove(colaboradorToAdd);
            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.IsFalse(c.IsChanged);
        }

        [TestMethod]
        public void ShouldTrackRemovedItems()
        {
            var colaboradorToRemove = _colaboradores[0];

            var c = new ChangeTrackingCollection<ColaboradorWrapper>(_colaboradores);
            Assert.AreEqual(2, c.Count);
            Assert.IsFalse(c.IsChanged);

            c.Remove(colaboradorToRemove);
            Assert.AreEqual(1, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(1, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.AreEqual(colaboradorToRemove, c.RemovedItems.First());
            Assert.IsTrue(c.IsChanged);

            c.Add(colaboradorToRemove);
            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.IsFalse(c.IsChanged);
        }

        [TestMethod]
        public void ShouldTrackModifiedItems()
        {
            var colaboradorToModify = _colaboradores[0];

            var c = new ChangeTrackingCollection<ColaboradorWrapper>(_colaboradores);
            Assert.AreEqual(2, c.Count);
            Assert.IsFalse(c.IsChanged);

            colaboradorToModify.Nombre = "Nuevo Colaborador 1";

            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(1, c.ModifiedItems.Count);
            Assert.IsTrue(c.IsChanged);

            colaboradorToModify.Nombre = "Colaborador 1";
            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.IsFalse(c.IsChanged);
        }

        [TestMethod]
        public void ShouldNotTrackAddedItemsAsModified()
        {
            var colaboradorToAdd = new ColaboradorWrapper(new Colaborador());

            var c = new ChangeTrackingCollection<ColaboradorWrapper>(_colaboradores);
            Assert.AreEqual(2, c.Count);
            Assert.IsFalse(c.IsChanged);

            c.Add(colaboradorToAdd);
            colaboradorToAdd.Nombre = "Nuevo Colaborador";

            Assert.AreEqual(3, c.Count);
            Assert.AreEqual(1, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.AreEqual(colaboradorToAdd, c.AddedItems.First());
            Assert.IsTrue(c.IsChanged);

            c.Remove(colaboradorToAdd);
            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.IsFalse(c.IsChanged);
        }

        [TestMethod]
        public void ShouldNotTrackRemovedItemsAsModified()
        {
            var colaboradorToRemove = _colaboradores[0];

            var c = new ChangeTrackingCollection<ColaboradorWrapper>(_colaboradores);
            Assert.AreEqual(2, c.Count);
            Assert.IsFalse(c.IsChanged);

            colaboradorToRemove.Nombre = "Nuevo Colaborador 1";
            c.Remove(colaboradorToRemove);
            Assert.AreEqual(1, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(1, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.AreEqual(colaboradorToRemove, c.RemovedItems.First());
            Assert.IsTrue(c.IsChanged);

            c.Add(colaboradorToRemove);
            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(1, c.ModifiedItems.Count);
            Assert.IsTrue(c.IsChanged);
        }
        #endregion

        #region Accept and Reject Changes
        [TestMethod]
        public void ShouldAcceptChanges()
        {
            var colaboradorToModify = _colaboradores[0];
            var colaboradorToRemove = _colaboradores[1];

            var c = new ChangeTrackingCollection<ColaboradorWrapper>(_colaboradores);
            Assert.AreEqual(2, c.Count);
            Assert.IsFalse(c.IsChanged);

            colaboradorToModify.Nombre = "Nuevo Colaborador 1";
            var colaboradorToAdd1 = new ColaboradorWrapper(new Colaborador());
            var colaboradorToAdd2 = new ColaboradorWrapper(new Colaborador());
            c.Add(colaboradorToAdd1);
            c.Add(colaboradorToAdd2);
            c.Remove(colaboradorToRemove);

            Assert.AreEqual(3, c.Count);
            Assert.AreEqual(2, c.AddedItems.Count);
            Assert.AreEqual(1, c.RemovedItems.Count);
            Assert.AreEqual(1, c.ModifiedItems.Count);
            Assert.IsTrue(c.IsChanged);

            c.AcceptChanges();
            Assert.AreEqual(3, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.IsFalse(c.IsChanged);
        }

        [TestMethod]
        public void ShouldRejectChanges()
        {
            var colaboradorToModify = _colaboradores[0];
            var colaboradorToRemove = _colaboradores[1];

            var c = new ChangeTrackingCollection<ColaboradorWrapper>(_colaboradores);
            Assert.AreEqual(2, c.Count);
            Assert.IsFalse(c.IsChanged);

            colaboradorToModify.Nombre = "Nuevo Colaborador 1";
            var colaboradorToAdd1 = new ColaboradorWrapper(new Colaborador());
            var colaboradorToAdd2 = new ColaboradorWrapper(new Colaborador());
            c.Add(colaboradorToAdd1);
            c.Add(colaboradorToAdd2);
            c.Remove(colaboradorToRemove);

            Assert.AreEqual(3, c.Count);
            Assert.AreEqual(2, c.AddedItems.Count);
            Assert.AreEqual(1, c.RemovedItems.Count);
            Assert.AreEqual(1, c.ModifiedItems.Count);
            Assert.IsTrue(c.IsChanged);

            c.RejectChanges();
            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.IsFalse(c.IsChanged);
        }
        #endregion
    }
}
