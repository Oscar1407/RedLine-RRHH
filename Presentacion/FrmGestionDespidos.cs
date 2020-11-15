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
        FrmListaAspirantes listaAspirantes;

        FrmContratacionesDespidos frmContrataciones;

        Despido despido;

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
                            this.txtID.Enabled = false;
                            
                        MessageBox.Show("Se encontró un colaborador con el ID Institucional indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtMotivoDes.Enabled = true;
                        this.btnAgregarDespido.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se encontró ningún colaborador con el ID Institucional indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new Exception("No existe ningún colaborador con ese ID Institucional");
                    this.deshabilitar();
                    
                }
        }

        //Método para limpiar los campos de texto luego de agregar un despido
        public void limpiarCampos()
        {
            this.txtID.Clear();
            this.txtCedula.Clear();
            this.txtNombre.Clear();
            this.txtPApellido.Clear();
            this.txtSApellido.Clear();
            this.txtCorreo.Clear();
            this.txtTelefono.Clear();
            this.txtMotivoDes.Clear();
            this.txtPuesto.Clear();
        }

        //Método para deshabilitar los campos de texto
        private void deshabilitar()
        {
            txtID.Enabled = true;
            this.txtCedula.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtPApellido.Enabled = false;
            this.txtSApellido.Enabled = false;
            this.txtCorreo.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.txtMotivoDes.Enabled = false;
            this.txtPuesto.Enabled = false;
            this.btnAgregarDespido.Enabled = false;

        }

        public void guardarDespido()
        {
            try
            {
                despido = new Despido();

                //evaluaciones de que los campos se encuentren en un estado válido para la base de datos

                if (string.IsNullOrEmpty(this.txtMotivoDes.Text))
                {
                    MessageBox.Show("Debe ingresar el motivo de despido del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 
                }
                else{
                    this.despido.IDInstitucional = this.txtID.Text.Trim();
                    this.despido.cedula = this.txtCedula.Text.Trim();
                    this.despido.nombre = this.txtNombre.Text.Trim();
                    this.despido.primerApellido = this.txtPApellido.Text.Trim();
                    this.despido.segundoApellido = this.txtSApellido.Text.Trim();
                    this.despido.telefono = this.txtTelefono.Text.Trim();
                    this.despido.correo = this.txtCorreo.Text.Trim();
                    this.despido.puestoTrabajo = this.txtPuesto.Text.Trim();
                    this.despido.motivoDespido = this.txtMotivoDes.Text.Trim();

                    if (MessageBox.Show("¿Está seguro de que quiere agregar al colaborador a despidos?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (this.conexionA.consultaExistencia(this.despido.IDInstitucional) == 1)
                        {
                            MessageBox.Show("Ya existe un colaborador con ese ID Institucional el la lista de despidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.limpiarCampos();
                            this.txtMotivoDes.Enabled = false;
                            this.txtID.Enabled = true;
                            this.btnAgregarDespido.Enabled = false;
                        }
                        else {
                            //control de transaccion
                            using (TransactionScope scope = new TransactionScope())
                            {
                                if (this.conexionA.guardarDespido(despido) == 1 &&
                                    this.conexionA.guardarCorreoDespido(despido) == 1 &&
                                    this.conexionA.guardarTelefonoDespido(despido) == 1)
                                {
                                    MessageBox.Show("Despido agregado", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
          // Llamado al metodo eliminar, para que se elimine el colaborador de la nómina, solo si el proceso de agregar a Despido se realiza correctamente.
                                    this.eliminarColaboradorNomina();
                                    scope.Complete();    
                                    this.limpiarCampos();
                                    this.deshabilitar();
                                }
                                else
                                {
                                    MessageBox.Show("La transacción falló", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }//fin del control de transacción
                    }
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw new TransactionAbortedException(String.Format("No se pudo completar la transacción"), ex);
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
                this.deshabilitar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarColaboradorNomina() {
            try
            {
                this.conexionA.eliminarColaboradorTelefonoNomina(this.txtID.Text.Trim());
                this.conexionA.eliminarColaboradorCorreoNomina(this.txtID.Text.Trim());
                this.conexionA.eliminarColaboradorHorarioNomina(this.txtID.Text.Trim());
                this.conexionA.eliminarColaboradorDeduccionLaboralNomina(this.txtID.Text.Trim());
                this.conexionA.eliminarColaboradorAguinaldoNomina(this.txtID.Text.Trim());
                this.conexionA.eliminarColaboradorDeduccionAguinaldoNomina(this.txtID.Text.Trim());

                this.conexionA.eliminarColaboradorNomina(this.txtID.Text.Trim());

                MessageBox.Show("Colaborador eliminado correctamente de la nómina.", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private void btnAgregarDespido_Click(object sender, EventArgs e)
        {
            this.guardarDespido(); 
        }

        private void btnCoonsultarDesp_Click(object sender, EventArgs e)
        {
        }
    }//Fin de la clase
}//Fin del namespace
