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
    public partial class FrmGestionColaborador : Form
    {

        FrmAdministradorCapacitaciones administradorCapacitaciones;

        Colaborador colaborador;

        ConexionCapacitaciones conexion = null;

        public FrmGestionColaborador()
        {
            InitializeComponent();
        }

        /************************************************************************************************************************************************************************************************************************/
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
        /************************************************************************************************************************************************************************************************************************/

        /************************************************************************************************************************************************************************************************************************/

        //habilita los campos del formulario y los botones
        private void habilitar()
        {
            this.txtCedula.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtPrimerApellido.Enabled = true;
            this.txtSegundoApellido.Enabled = true;
            this.txtCorreo.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.btnModificar.Enabled = true;
            this.btnEliminar.Enabled = true;
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
            this.btnModificar.Enabled = false;
            this.btnEliminar.Enabled = false;
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

        public void modificarColaborador()
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

                if (MessageBox.Show("¿Está seguro de que quiere modificar al colaborador?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //control de transaccion
                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (this.conexion.modificarColaborador(colaborador) == 1 &&
                        this.conexion.modificarCorreoColaborador(colaborador) == 1 &&
                        this.conexion.modificarTelefonoColaborador(colaborador) == 1)
                        {
                            MessageBox.Show("Colaborador modificado con éxito", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /************************************************************************************************************************************************************************************************************************/

        /************************************************************************************************************************************************************************************************************************/
        private void FrmGestionColaborador_Load(object sender, EventArgs e)
        {
            try
            {
                this.conexion = new ConexionCapacitaciones();
                this.deshabilitar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
            this.deshabilitar();
            this.txtIDInstitucional.Enabled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtIDInstitucional.Text))
                {
                    MessageBox.Show("Debe ingresar el ID Institucional del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Colaborador colaborador = this.conexion.consultaColaborador(this.txtIDInstitucional.Text.Trim());

                    if (colaborador != null)
                    {
                        this.txtCedula.Text = colaborador.cedula;
                        this.txtNombre.Text = colaborador.nombre;
                        this.txtPrimerApellido.Text = colaborador.primerApellido;
                        this.txtSegundoApellido.Text = colaborador.segundoApellido;
                        this.txtCorreo.Text = colaborador.correo;
                        this.txtTelefono.Text = colaborador.telefono;
                        this.habilitar();
                        this.txtIDInstitucional.Enabled = false;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtIDInstitucional.Text))
                {
                    MessageBox.Show("Debe ingresar el ID Institucional del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("¿Está seguro de que quiere eliminar al colaborador?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.conexion.eliminarColaboradorTelefono(this.txtIDInstitucional.Text.Trim());
                        this.conexion.eliminarColaboradorCorreo(this.txtIDInstitucional.Text.Trim());
                        this.conexion.eliminarColaborador(this.txtIDInstitucional.Text.Trim());
                        MessageBox.Show("Colaborador eliminado", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.limpiarCampos();
                        this.deshabilitar();
                        this.txtIDInstitucional.Enabled = true;
                    }
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.modificarColaborador();
            this.limpiarCampos();
            this.deshabilitar();
            this.txtIDInstitucional.Enabled = true;
        }

        /************************************************************************************************************************************************************************************************************************/
    }
}
