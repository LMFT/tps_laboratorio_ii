using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace Pruebas_Unitarias
{
    [TestClass]
    public class PruebaClinica
    {
        [TestMethod]
        public void Clinica_BuscarUsuario_DeberiaRetornarNullSiNoEncuentraUsuario()
        {
            //Arrange
            Usuario usuario;
            //Act

            usuario = Clinica.BuscarUsuario("EsteUsuarioNoExiste");

            //Assert
            Assert.AreEqual(null,usuario);
        }
        [TestMethod]
        public void Clinica_BuscarUsuario_DeberiaRetornarUsuarioSiNombreUsuarioExiste()
        {
            //Arrange
            Usuario usuario;
            string expected = "rfernandez";
            //Act
            usuario = Clinica.BuscarUsuario(expected);
            string actual = string.Empty;
            if(usuario is not null)
            {
                actual = usuario.NombreUsuario;
            }
            //Assert
            Assert.AreEqual(expected,actual);
        }
    }
}
