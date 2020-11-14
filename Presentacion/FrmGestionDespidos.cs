using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//llamado a la capa de logica de negocios
using LogicaNegocio;

//llamado a la capa de acceso a datos
using AccesoDatos;

//implementacion control de transacciones
using System.Transactions;

namespace Presentacion
{
    public partial class FrmGestionDespidos : Form
    {

        FrmContratacionesDespidos frmContrataciones;

        ConexionContrataciones conexionA = null;

        public FrmGestionDespidos()
        {
            InitializeComponent();
        }


        private void pictureBoxBuscarAsp_Click_1(object sender, EventArgs e)
        {
                try
                {
                    if (string.IsNullOrEmpty(this.txtID.Text))
                    {
                        MessageBox.Show("Debe ingresar el ID Institucional del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Colaborador colaborador = this.conexionA.consultaNomina(this.txtID.Text.Trim());

                        if (colaborador != null)
                        {
                            this.txtCedula.Text = colaborador.cedula;
                            this.txtNombre.Text = colaborador.nombre;
                            this.txtPApellido.Text = colaborador.primerApellido;
                            this.txtSApellido.Text = colaborador.segundoApellido;
                            this.txtCorreo.Text = colaborador.correo;
                            this.txtTelefono.Text = colaborador.telefono;
                            this.txtPuesto.Text = colaborador.puestoTrabajo;
                            //this.habilitar();
                            this.txtID.Enabled = false;
                            MessageBox.Show("Se encontró un empleado con el ID Institucional indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se encontró ningún colaborador con el ID Institucional indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new Exception("No existe ningún colaborador con ese ID Institucional");
                }
        }

        //Método para volver a mostrar la pantalla principal
        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.frmContrataciones = new FrmContratacionesDespidos();
                this.frmContrataciones.Show();
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Método para cerrar la sesion
        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmGestionDespidos_Load(object sender, EventArgs e)
        {
            try
            {
                this.conexionA = new ConexionContrataciones();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
