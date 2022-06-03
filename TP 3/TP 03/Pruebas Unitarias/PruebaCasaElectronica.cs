using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
namespace Pruebas_Unitarias
{
    [TestClass]
    public class PruebaCasaElectronica
    {
        [TestMethod]
        public void RetirarDeStock_CuandoCantidadSuperaStockActual_DeberiaEliminarProducto()
        {
            //Arrange
            Producto producto = CasaElectronica.BuscarProducto(1);
            int expected = CasaElectronica.Stock.Count - 1;
            //Act
            CasaElectronica.RetirarDeStock(producto, int.MaxValue);
            int actual = CasaElectronica.Stock.Count;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
