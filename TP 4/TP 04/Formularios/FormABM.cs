using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Mostrar;
using Logica.ABM;

namespace Formularios
{
    public partial class FormABM : Form
    {
        private MostrarInfo mostrarInfo;
        object? elemento;

        private FormABM()
        {
            InitializeComponent();
        }

        public FormABM(MostrarInfo mostrarInfo, object? elemento): this()
        {
            this.mostrarInfo = mostrarInfo;
            this.elemento = elemento;
        }

        public FormABM(MostrarInfo mostrarInfo) : this(mostrarInfo, null)
        {

        }

        private void FormABM_Load(object sender, EventArgs e)
        {
            ModificarTexto();
        }
        /// <summary>
        /// Cambia el texto de los controles en base al tipo de informacion a cargar
        /// </summary>
        private void ModificarTexto()
        {
            switch (mostrarInfo)
            {
                //Adapta el texto para mostrar un producto
                case MostrarInfo.Producto:
                    AltaProducto();
                    break;
                    //Por defecto es alta de empleado
                default:
                    AltaEmpleado();
                    break;
            }
        }

        private void AltaProducto()
        {
            Text = "Nuevo Producto";
            lblPrimerCampo.Text = "Descripcion:";
            lblSegundoCampo.Text = "Precio:";
            lblCantidad.Text = "Cantidad:";
            rdoCable.Checked = true;

            lblQuintoCampo.Hide();
            txtQuintoCampo.Hide();
            btnAdicional1.Hide();
            btnAdicional2.Hide();
            
            CambiarFormularioPorTipoDeProducto();
        }

        private void CambiarFormularioPorTipoDeProducto()
        {
            if (rdoCable.Checked)
            {
                lblTercerCampo.Text = "Seccion:";
                chkOpcionAdicional.Text = "Doble aislacion";
                lblCuartoCampo.Hide();
                txtCuartoCampo.Hide();
            }
            if (rdoComponente.Checked)
            {
                lblTercerCampo.Text = "Capacidad:";
                lblCuartoCampo.Text = "Unidad de medicion:";
            }
        }

        private void AltaProveedor()
        {
            Text = "Alta de proveedor";
            lblPrimerCampo.Text = "Nombre";
            lblSegundoCampo.Text = "Apellido";
            lblTercerCampo.Text = "DNI";
            btnAdicional1.Text = "Agregar productos";
            btnAdicional2.Text = "Nuevo producto";

            txtCuartoCampo.Hide();
            txtQuintoCampo.Hide();
            lblCuartoCampo.Hide();
            lblQuintoCampo.Hide();
            chkOpcionAdicional.Hide();
            rdoCable.Hide();
            rdoComponente.Hide();
            lblCantidad.Hide();
            nudCantidad.Hide();
        }

        private void AltaEmpleado()
        {
            Text = "Nuevo empleado";
            lblPrimerCampo.Text = "Nombre";
            lblSegundoCampo.Text = "Apellido";
            lblTercerCampo.Text = "DNI";
            lblCuartoCampo.Text = "Usuario";
            lblQuintoCampo.Text = "Contraseña";
            txtQuintoCampo.PasswordChar = '*';
            chkOpcionAdicional.Text = "Administrador";
            btnAdicional1.Text = "Validar usuario";

            if (ControladorABM.UsuarioEsAdmin)
            {
                chkOpcionAdicional.Checked = false;
                chkOpcionAdicional.Hide();
            }
            
            lblCantidad.Hide();
            nudCantidad.Hide();
            btnAdicional2.Hide();
            rdoCable.Hide();
            rdoComponente.Hide();
        }


        private void btnAdicional1_Click(object sender, EventArgs e)
        {
            //Para el usuario este boton representa verificar que el nombre de usuario no exista
            if (mostrarInfo == MostrarInfo.Empleado)
            {
                try
                {
                    ControladorABM.ValidarUsuario(txtCuartoCampo.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Para un proveedor me permite asignar un producto ya existente
                FormAgregar formAgregar = new FormAgregar(false);
                formAgregar.ShowDialog();
                if (formAgregar.DialogResult == DialogResult.OK)
                {
                    ControladorABM.AgregarProductos();
                }
            }
        }



        private void btnAdicional2_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ConfirmarAlta();
        }

        private void ConfirmarAlta()
        {
            string mensaje;
            string titulo;
            MessageBoxButtons boton = MessageBoxButtons.OK;
            MessageBoxIcon icono = MessageBoxIcon.Error;
            DialogResult resultado;

            try
            {
                if (ControladorABM.CrearElemento(mostrarInfo, chkOpcionAdicional.Checked, txtPrimerCampo.Text,
                                                txtSegundoCampo.Text, txtTercerCampo.Text, txtCuartoCampo.Text,
                                                txtQuintoCampo.Text, rdoCable.Checked, (int)nudCantidad.Value))
                {
                    mensaje = "El alta se ha completado satisfactoriamente";
                    titulo = "Alta exitosa";
                    icono = MessageBoxIcon.Information;
                    resultado = DialogResult.OK;
                }
                else
                {
                    throw new Exception("Se produjo un error al dan de alta este elemento");
                }
                MessageBox.Show(mensaje, titulo, boton, icono);
                if (resultado == DialogResult.OK)
                {
                    DialogResult = resultado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", boton,icono);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
