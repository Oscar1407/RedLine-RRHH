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
    public partial class FrmGestionMatricula : Form
    {

        FrmAdministradorCapacitaciones administradorCapacitaciones;

        Matricula matricula;

        ConexionCapacitaciones conexion = null;

        public FrmGestionMatricula()
        {
            InitializeComponent();
        }

        private void deshabilitar()
        {
            this.txtIDCurso.Enabled = false;
            this.txtNombreCurso.Enabled = false;
            this.txtDuracion.Enabled = false;
            this.txtPeriodo.Enabled = false;
            this.txtCedula.Enabled = false;
            this.txtNombreColaborador.Enabled = false;
            this.txtPrimerApellido.Enabled = false;
            this.txtSegundoApellido.Enabled = false;
            this.txtCorreo.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.cbxEstado.Enabled = false;
            this.btnFinalizar.Enabled = false;
        }

        private void limpiar()
        {
            this.txtIDCurso.Clear();
            this.txtNombreCurso.Clear();
            this.txtDuracion.Clear();
            this.txtPeriodo.Clear();
            this.txtIDInstitucional.Clear();
            this.txtCedula.Clear();
            this.txtNombreColaborador.Clear();
            this.txtPrimerApellido.Clear();
            this.txtSegundoApellido.Clear();
            this.txtCorreo.Clear();
            this.txtTelefono.Clear();
            this.cbxEstado.SelectedIndex = 0;
            this.btnFinalizar.Enabled = false;
        }

        private void FrmGestionMatricula_Load(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            this.txtIDInstitucional.Enabled = true;
        }

        private void btnBuscarColaborador_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtIDInstitucional.Text))
                {
                    MessageBox.Show("Debe ingresar el ID Institucional del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Matricula matricula = this.conexion.consultaMatricula(this.txtIDInstitucional.Text.Trim());

                    if (matricula != null)
                    {
                        this.txtIDCurso.Text = matricula.IDCurso;
                        this.txtNombreCurso.Text = matricula.nombreCurso;
                        this.txtDuracion.Text = matricula.duracion;
                        this.txtPeriodo.Text = matricula.periodo;
                        if (matricula.estado.Equals("En curso"))
                        {
                            this.cbxEstado.SelectedIndex = 0;
                        } 
                        else if (matricula.estado.Equals("Finalizado"))
                        {
                            this.cbxEstado.SelectedIndex = 1;
                        }
                        this.txtIDInstitucional.Text = matricula.IDInstitucional;
                        this.txtCedula.Text = matricula.cedula;
                        this.txtNombreColaborador.Text = matricula.nombre;
                        this.txtPrimerApellido.Text = matricula.primerApellido;
                        this.txtSegundoApellido.Text = matricula.segundoApellido;
                        this.txtCorreo.Text = matricula.correo;
                        this.txtTelefono.Text = matricula.telefono;

                        this.btnFinalizar.Enabled = true;
                        this.cbxEstado.Enabled = true;
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

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                matricula = new Matricula();

                if(this.cbxEstado.SelectedItem.Equals("En curso"))
                {
                    MessageBox.Show("Debe actualizar el estado de la matrícula", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.matricula.IDCurso = this.txtIDCurso.Text.Trim();
                    this.matricula.IDInstitucional = this.txtIDInstitucional.Text.Trim();
                    switch (this.cbxEstado.SelectedIndex)
                    {
                        case 1:
                            this.matricula.estado = "Finalizado";
                            break;
                    }

                    if (MessageBox.Show("¿Está seguro de que quiere modificar al colaborador?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //control de transaccion
                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (this.conexion.actualizarEstado(matricula) == 1)
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
            }
            catch (TransactionAbortedException ex)
            {
                throw new TransactionAbortedException(String.Format("No se pudo completar la transacción"), ex);
            }
        }
    }
}
