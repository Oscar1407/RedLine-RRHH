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
    public partial class FrmAgregarNuevoCurso : Form
    {

        FrmAdministradorCapacitaciones administradorCapacitaciones;

        ConexionCapacitaciones conexion = null;

        Curso curso;

        public FrmAgregarNuevoCurso()
        {
            InitializeComponent();
        }

        private void FrmAgregarNuevoCurso_Load(object sender, EventArgs e)
        {
            try
            {
                this.conexion = new ConexionCapacitaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para limpiar los campos
        public void limpiarCampos()
        {
            this.txtIDCurso.Clear();
            this.txtNombreCurso.Clear();
            this.txtDuracion.Clear();
        }

        //metodo para guardar un curso
        public void guardarCurso()
        {
            try
            {
                this.curso = new Curso();

                if (string.IsNullOrEmpty(this.txtIDCurso.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del curso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(this.txtNombreCurso.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del curso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(this.txtDuracion.Text))
                {
                    MessageBox.Show("Debe ingresar la duración del curso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.conexion.consultaExistenciaCurso(this.txtIDCurso.Text) == 1)
                {
                    MessageBox.Show("Ya existe un curso con ese identificador", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.curso.IDCurso = this.txtIDCurso.Text.Trim();
                    this.curso.nombreCurso = this.txtNombreCurso.Text.Trim();
                    this.curso.duracion = this.txtDuracion.Text.Trim();

                    if (MessageBox.Show("¿Está seguro de que quiere agregar al colaborador? No podrá editar la información después", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //control de transaccion
                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (this.conexion.agregarCurso(curso) == 1)
                            {
                                MessageBox.Show("Curso agregado", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                throw ex;
                throw new TransactionAbortedException(String.Format("No se pudo completar la transacción"), ex);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.guardarCurso();
            this.limpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }
    }
}
