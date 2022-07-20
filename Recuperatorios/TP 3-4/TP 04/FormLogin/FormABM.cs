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

        private FormABM()
        {
            InitializeComponent();
        }

        public FormABM(MostrarInfo mostrarInfo): this()
        {
            CambiarColor();
            this.mostrarInfo = mostrarInfo;
        }
        /// <summary>
        /// Cambia el color de la aplicacion en base a los permisos del usuario logueado
        /// </summary>
        private void CambiarColor()
        {
            if (ControladorABM.UsuarioEsAdmin)
            {
                BackColor = Color.LightSkyBlue;

                foreach (Control control in Controls)
                {
                    if(control is Button || control is TextBox)
                    {
                        control.BackColor = Color.PowderBlue;
                    }
                }
            }
            else
            {
                BackColor = Color.Tan;
                foreach (Control control in Controls)
                {
                    if (control is Button || control is TextBox)
                    {
                        control.BackColor = Color.Moccasin;
                    }
                }
            }
        }

        private void FormABM_Load(object sender, EventArgs e)
        {
            OcultarControles();
            ModificarTexto();
            ControladorABM.LimpiarIngredientes();
        }
        /// <summary>
        /// Cambia el texto de los controles en base al tipo de informacion a cargar
        /// </summary>
        private void ModificarTexto()
        {
            switch (mostrarInfo)
            {
                case MostrarInfo.Inventario:
                    ModificarTexto("Nombre", "Precio", "Cantidad", "Alta de stock", "Cantidad Minima");
                    break;
                case MostrarInfo.Menu:
                    ModificarTexto("Nombre", "Precio", "", "Nuevo plato", "Es bebida?", "Incluir ingredientes", "Nombre",
                        "Precio", "Ver ingredientes", "Ingredientes", "Agregar Ingrediente");
                    break;
                    //Por defecto es alta de empleado
                default:
                    ModificarTexto("Nombre", "Apellido", "DNI", "Alta de empleado", "Administrador", 
                                   "Agregar datos de cuenta", "Usuario", "Contraseña", "Validar usuario",
                                   "Datos de la cuenta");
                    break;
            }
        }
        /// <summary>
        /// Asigna el valor de la propiedad Text de los controles indicados
        /// </summary>
        /// <param name="primerCampo">Valor a asignar a la propiedad Text del label lblPrimerCampo</param>
        /// <param name="segundoCampo">Valor a asignar a la propiedad Text del label lblPrimerCampo</param>
        /// <param name="tercerCampo">Valor a asignar a la propiedad Text del label lblPrimerCampo</param>
        /// <param name="titulo">Valor a asignar al título del formulario</param>
        /// <param name="opcionAdicional">Valor a asignar a la propiedad Text del checkbox chkOpcionAdicional</param>
        private void ModificarTexto(string primerCampo, string segundoCampo, string tercerCampo, string titulo,
                                    string opcionAdicional)
        {
            lblPrimerCampo.Text = primerCampo;
            lblSegundoCampo.Text = segundoCampo;
            lblTercerCampo.Text = tercerCampo;
            this.Text = titulo;
            chkOpcionAdicional.Text = opcionAdicional;
        }
        /// <summary>
        /// Asigna el valor de la propiedad Text de los controles indicados
        /// </summary>
        /// <param name="primerCampo">Valor a asignar a la propiedad Text del label lblPrimerCampo</param>
        /// <param name="segundoCampo">Valor a asignar a la propiedad Text del label lblSegundoCampo</param>
        /// <param name="tercerCampo">Valor a asignar a la propiedad Text del label lblTercerCampo</param>
        /// <param name="titulo">Valor a asignar al título del formulario</param>
        /// <param name="opcionAdicional">Valor a asignar a la propiedad Text del checkbox chkOpcionAdicional</param>
        /// <param name="camposAdicionales">Valor a asignar a la propiedad Text del checkbox chkCamposAdicionales</param>
        /// <param name="cuartoCampo">Valor a asignar a la propiedad Text del label lblCuartoCampo</param>
        /// <param name="quintoCampo">Valor a asignar a la propiedad Text del label lblQuintoCampo</param>
        /// <param name="adicional1">Valor a asignar a la propiedad Text del boton btnAdicional1</param>
        /// <param name="groupbox">Valor a asignar a la propiedad text del group box grpAdicionales</param>
        private void ModificarTexto(string primerCampo, string segundoCampo, string tercerCampo, string titulo, 
                                    string opcionAdicional, string camposAdicionales, string cuartoCampo, 
                                    string quintoCampo, string adicional1, string groupbox)
        {
            ModificarTexto(primerCampo, segundoCampo, tercerCampo, titulo, opcionAdicional);
            grpAdicionales.Text = groupbox;
            chkCamposAdicionales.Text = camposAdicionales;
            lblCuartoCampo.Text = cuartoCampo;
            lblQuintoCampo.Text = quintoCampo;
            btnAdicional1.Text = adicional1;
        }
        /// <summary>
        /// Asigna el valor de la propiedad Text de los controles indicados
        /// </summary>
        /// <param name="primerCampo">Valor a asignar a la propiedad Text del label lblPrimerCampo</param>
        /// <param name="segundoCampo">Valor a asignar a la propiedad Text del label lblSegundoCampo</param>
        /// <param name="tercerCampo">Valor a asignar a la propiedad Text del label lblTercerCampo</param>
        /// <param name="titulo">Valor a asignar al título del formulario</param>
        /// <param name="opcionAdicional">Valor a asignar a la propiedad Text del checkbox chkOpcionAdicional</param>
        /// <param name="camposAdicionales">Valor a asignar a la propiedad Text del checkbox chkCamposAdicionales</param>
        /// <param name="cuartoCampo">Valor a asignar a la propiedad Text del label lblCuartoCampo</param>
        /// <param name="quintoCampo">Valor a asignar a la propiedad Text del label lblQuintoCampo</param>
        /// <param name="adicional1">Valor a asignar a la propiedad Text del boton btnAdicional1</param>
        /// <param name="groupbox">Valor a asignar a la propiedad Text del boton btnAdicional1</param>
        /// <param name="adicional2">Valor a asignar a la propiedad Text del boton btnAdicional2</param>
        private void ModificarTexto(string primerCampo,string segundoCampo, string tercerCampo, string titulo, 
                                    string opcionAdicional, string camposAdicionales, string cuartoCampo, 
                                    string quintoCampo, string adicional1, string groupbox, string adicional2)
        {
            ModificarTexto(primerCampo, segundoCampo, tercerCampo, titulo, opcionAdicional, camposAdicionales, cuartoCampo,
                            quintoCampo, adicional1, groupbox);
            btnAdicional2.Text = adicional2;
        }
        /// <summary>
        /// Oculta controles del formulario que no sean necesarios para dar de alta un elemento
        /// </summary>
        private void OcultarControles()
        {
            if(mostrarInfo == MostrarInfo.Inventario)
            {
                chkCamposAdicionales.Hide();
                grpAdicionales.Hide();
            }
            else
            {
                nudCantidadMinima.Hide();
                if(mostrarInfo == MostrarInfo.Empleado)
                {
                    btnAdicional2.Hide();
                }
                else
                {
                    txtTercerCampo.Hide();
                }
            }
        }

        private void chkOpcionAlternativa_CheckedChanged(object sender, EventArgs e)
        {
            CambiarEstadoGroupbox();
        }
        /// <summary>
        /// Habilita o deshabilita el groupbox
        /// </summary>
        private void CambiarEstadoGroupbox()
        {
             grpAdicionales.Enabled = !grpAdicionales.Enabled;
        }

        private void btnAdicional1_Click(object sender, EventArgs e)
        {
            //Para el usuario este boton representa verificar que el nombre de usuario no exista
            if(mostrarInfo == MostrarInfo.Empleado)
            {
                string mensaje;
                string titulo;
                MessageBoxButtons boton = MessageBoxButtons.OK;
                MessageBoxIcon icono;
                if(ControladorABM.ValidarUsuario(txtCuartoCampo.Text))
                {
                    mensaje = "El usuario se encuentra disponible";
                    titulo = "Usuario disponible";
                    icono = MessageBoxIcon.Information;
                    MessageBox.Show(mensaje, titulo, boton, icono);
                }
            }
            else
            {
                //En caso del menu, permite ver y agregar ingredientes a nuestro plato
                if(mostrarInfo == MostrarInfo.Menu)
                {
                    FormAgregar form = new FormAgregar();
                    DialogResult = form.ShowDialog();
                    if(DialogResult == DialogResult.OK)
                    {
                        ControladorABM.AgregarIngredientes();
                    }
                }
            }
        }

        private void btnAdicional2_Click(object sender, EventArgs e)
        {
            FormABM form = new FormABM(MostrarInfo.Inventario);
            form.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string mensaje;
            string titulo;
            MessageBoxButtons boton = MessageBoxButtons.OK;
            MessageBoxIcon icono;
            DialogResult resultado;
            //Guardo el valor del numeric up down para usar en el metodo CargarElemento
            GuardarCantidadMinima();
            //Cargo informacion para mostrar un mensaje en base a si pude crear o no un nuevo elemento
            if(ControladorABM.CargarElemento(mostrarInfo, chkCamposAdicionales.Checked, chkOpcionAdicional.Checked,
                txtPrimerCampo.Text, txtSegundoCampo.Text, txtTercerCampo.Text, txtCuartoCampo.Text, txtQuintoCampo.Text))
            {
                mensaje = "El alta se ha completado satisfactoriamente";
                titulo = "Alta exitosa";
                icono = MessageBoxIcon.Information;
                resultado = DialogResult.OK;
            }
            else
            {
                mensaje = "Se produjo un error al dar de alta este elemento";
                titulo = "Error";
                icono = MessageBoxIcon.Warning;
                resultado = DialogResult.Ignore;
            }
            MessageBox.Show(mensaje, titulo, boton, icono);
            if(resultado == DialogResult.OK)
            {
                DialogResult = resultado;
            }
        }
        /// <summary>
        /// En caso de estar ingresando un nuevo elemento a stock en donde sea necesario conservar informacion sobre
        /// la cantidad minima se almacena el valor almacenardo en el numeric up down en el textbox txtCuartoCampo,
        /// cuyo valor es utilizado en el constructor general para crear un nuevo objeto
        /// </summary>
        private void GuardarCantidadMinima()
        {
            if(mostrarInfo == MostrarInfo.Inventario)
            {
                txtCuartoCampo.Text = nudCantidadMinima.Value.ToString();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
