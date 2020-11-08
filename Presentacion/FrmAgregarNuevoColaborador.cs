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
    public partial class FrmAgregarNuevoColaborador : Form
    {

        FrmAdministradorCapacitaciones administradorCapacitaciones;

        Colaborador colaborador;

        Conexion conexion = null;

        public FrmAgregarNuevoColaborador()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.administradorCapacitaciones = new FrmAdministradorCapacitaciones();
            this.administradorCapacitaciones.Show();
            this.Close();
            this.Dispose();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        //metodo para limpiar los campos
        public void limpiarCampos()
        {
            this.txtIDInstitucional.Clear();
            this.txtCedula.Clear();
            this.txtNombre.Clear();
            this.txtPrimerApellido.Clear();
            this.txtSegundoApellido.Clear();
            this.txtCorreo.Clear();
            this.txtTelefono.Clear();
        }

        
        //metodo de obtener informacion de los campos y almacenarlos en la BD
        public void guardarColaborador()
        {
            try
            {
                colaborador = new Colaborador();

                //evaluaciones de que los campos se encuentren en un estado válido para la base de datos
                if (string.IsNullOrEmpty(this.txtIDInstitucional.Text))
                {
                    MessageBox.Show("Debe ingresar el ID Institucional del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.colaborador.IDInstitucional = this.txtIDInstitucional.Text.Trim();
                }

                if (string.IsNullOrEmpty(this.txtCedula.Text))
                {
                    MessageBox.Show("Debe ingresar la cédula del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.colaborador.cedula = this.txtCedula.Text.Trim();
                }

                if (string.IsNullOrEmpty(this.txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.colaborador.nombre = this.txtNombre.Text.Trim();
                }

                if (string.IsNullOrEmpty(this.txtPrimerApellido.Text))
                {
                    MessageBox.Show("Debe ingresar el primer apellido del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.colaborador.primerApellido = this.txtPrimerApellido.Text.Trim();
                }

                if (string.IsNullOrEmpty(this.txtSegundoApellido.Text))
                {
                    MessageBox.Show("Debe ingresar el segundo apellido del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.colaborador.segundoApellido = this.txtSegundoApellido.Text.Trim();
                }

                if (string.IsNullOrEmpty(this.txtCorreo.Text))
                {
                    MessageBox.Show("Debe ingresar el correo del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.colaborador.correo = this.txtCorreo.Text.Trim();
                }

                if (string.IsNullOrEmpty(this.txtTelefono.Text))
                {
                    MessageBox.Show("Debe ingresar el telefono del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.colaborador.telefono = this.txtTelefono.Text.Trim();
                }

                if (this.conexion.consultaExistencia(this.colaborador.IDInstitucional) == 1)
                {
                    MessageBox.Show("Ya existe un colaborador con ese ID Institucional", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //control de transaccion
                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (this.conexion.guardarColaborador(colaborador) == 1 && 
                            this.conexion.guardarCorreoColaborador(colaborador) == 1 && 
                            this.conexion.guardarTelefonoColaborador(colaborador) == 1)
                        {
                            MessageBox.Show("Empleado agregado", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            scope.Complete();
                        }
                        else
                        {
                            MessageBox.Show("La transacción falló", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }//fin del control de transacción
                }

            }
            catch (TransactionAbortedException ex)
            {
                throw new TransactionAbortedException(String.Format("No se pudo completar la transacción"), ex);               
            }
        }

        //accion de guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.guardarColaborador();           
            this.limpiarCampos();
        }

        //action de cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            //esperar a tener los datos del modulo de nomina
        }

        //carga la clase de conexion desde que inicia la ejecucion de la pantalla
        private void FrmAgregarNuevoColaborador_Load(object sender, EventArgs e)
        {
            try
            {
                this.conexion = new Conexion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
