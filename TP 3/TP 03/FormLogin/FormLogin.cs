using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica.Login;

namespace Formularios
{
    public partial class FormLogin : Form
    { 
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }
        /// <summary>
        /// Intenta ingresar en la aplicacion usando el usuario y contraseña ingresados
        /// </summary>
        private void Ingresar()
        {
            if (ControladorLogin.ValidarIngreso(txtUsuario.Text, txtPassword.Text))
            {
                FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();
                menuPrincipal.ShowDialog();
            }
            else
            {
                MessageBoxButtons boton = MessageBoxButtons.OK;
                MessageBoxIcon icono = MessageBoxIcon.Error;
                MessageBox.Show("Error: El usuario o la contraseña son incorrectos", "Error", boton, icono);
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnAutoCompletar_Click(object sender, EventArgs e)
        {
            AutoCompletarCampos();
        }
        /// <summary>
        /// Llama al formulario para autocompletar los datos y rellena los 
        /// campos segun la opcion ingresada
        /// </summary>
        private void AutoCompletarCampos()
        {
            string usuario;
            string password;
            FormAutoCompletar formAutoCompletar = new FormAutoCompletar();
            DialogResult autocompletarAdministrador = formAutoCompletar.ShowDialog();
            switch (autocompletarAdministrador)
            {
                case DialogResult.Yes:
                    ControladorLogin.CargarInformacion(true,out usuario, out password);
                    break;
                case DialogResult.No:
                    ControladorLogin.CargarInformacion(false,out usuario, out password);
                    break;
                default:
                    return;
            }
            txtUsuario.Text = usuario;
            txtPassword.Text = password;
        }
    }
}
