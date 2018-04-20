using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Logic;

namespace UnitTest
{
    [TestClass]
    public class PruebaAdapters
    {
        [TestMethod]
        public void VuelveTablaDeMaterias()
        {
            //Arrange
            MateriaLogic ml = new MateriaLogic();
            //DataTable dt = new DataTable();

            //Act
            //dt = ma.GetAllWithDescripcionPlan();

            //Assert
            Assert.IsNotNull(ml.GetAll());
        }
    }
}
