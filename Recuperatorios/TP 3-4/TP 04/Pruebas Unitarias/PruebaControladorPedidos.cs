using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica.AgregarPedidos;
using Entidades;
namespace Pruebas_Unitarias
{
    [TestClass]
    public class PruebaControladorPedidos
    {
        [TestMethod]
        public void AgregarPedido_CuandoCantidadEsMenorA0_DeberiaRetornarFalse()
        {
            //Arrange
            int cantidad = -1;
            Producto producto = CasaElectronica.BuscarProducto(1);
            bool expected = false;
            //Act
            bool actual = ControladorAgregar.NuevoPedido(producto, cantidad);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AgregarPedido_CuandoCantidadEsMayorAStockDisponible_DeberiaRetornarFalse()
        {
            //Arrange
            int cantidad = int.MaxValue;
            Producto producto = CasaElectronica.BuscarProducto(1);
            bool expected = false;
            //Act
            bool actual = ControladorAgregar.NuevoPedido(producto, cantidad);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
