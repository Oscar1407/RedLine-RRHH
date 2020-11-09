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
                    if (MessageBox.Show("¿Está seguro de que quiere agregar al colaborador?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            this.deshabilitar();
        }

        //accion de cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
            this.deshabilitar();
        }

        //accion de verificar si el empleado que se agregará a capacitaciones ya existe en la BD
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtIDInstitucional.Text))
                {
                    MessageBox.Show("Debe ingresar el ID Institucional del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Colaborador colaborador = this.conexion.consultaNomina(this.txtIDInstitucional.Text.Trim());

                    if (colaborador != null)
                    {
                        this.txtCedula.Text = colaborador.cedula;
                        this.txtNombre.Text = colaborador.nombre;
                        this.txtPrimerApellido.Text = colaborador.primerApellido;
                        this.txtSegundoApellido.Text = colaborador.segundoApellido;
                        this.txtCorreo.Text = colaborador.correo;
                        this.txtTelefono.Text = colaborador.telefono;

                        MessageBox.Show("Se encontró un empleado con el ID Institucional indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ningún colaborador con el ID Institucional indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Exception("No existe ningún colaborador con ese ID Institucional");
                this.habilitar();
            }
        }

        //habilita los campos del formulario y los botones
        private void habilitar()
        {
            this.txtCedula.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtPrimerApellido.Enabled = true;
            this.txtSegundoApellido.Enabled = true;
            this.txtCorreo.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.btnGuardar.Enabled = true;
        }

        //deshabilita los campos del formulario y los botones
        private void deshabilitar()
        {
            this.txtCedula.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtPrimerApellido.Enabled = false;
            this.txtSegundoApellido.Enabled = false;
            this.txtCorreo.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.btnGuardar.Enabled = false;
        }

        //carga la clase de conexion desde que inicia la ejecucion de la pantalla
        private void FrmAgregarNuevoColaborador_Load(object sender, EventArgs e)
        {
            try
            {
                this.conexion = new Conexion();
                this.deshabilitar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
