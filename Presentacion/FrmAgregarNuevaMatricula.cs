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
    public partial class FrmAgregarNuevaMatricula : Form
    {

        FrmAdministradorCapacitaciones administradorCapacitaciones;

        Colaborador colaborador;

        ConexionCapacitaciones conexion = null;

        Matricula matricula;

        public FrmAgregarNuevaMatricula()
        {
            InitializeComponent();
        }

        private void FrmAgregarNuevaMatricula_Load(object sender, EventArgs e)
        {
            try
            {
                this.conexion = new ConexionCapacitaciones();
                this.cbxPeriodo.SelectedIndex = 0;
                this.deshabilitar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void limpiarCampos()
        {
            this.txtIDCurso.Clear();
            this.txtNombreCurso.Clear();
            this.txtDuracion.Clear();

            this.txtIDInstitucional.Clear();
            this.txtCedula.Clear();
            this.txtNombreColaborador.Clear();
            this.txtPrimerApellido.Clear();
            this.txtSegundoApellido.Clear();
            this.txtCorreo.Clear();
            this.txtTelefono.Clear();
        }

        private void deshabilitar()
        {
            this.txtNombreCurso.Enabled = false;
            this.txtDuracion.Enabled = false;
            this.txtCedula.Enabled = false;
            this.txtNombreColaborador.Enabled = false;
            this.txtPrimerApellido.Enabled = false;
            this.txtSegundoApellido.Enabled = false;
            this.txtCorreo.Enabled = false;
            this.txtTelefono.Enabled = false;
        }

        private void guardarMatricula()
        {
            try
            {
                matricula = new Matricula();

                if (string.IsNullOrEmpty(this.txtIDCurso.Text))
                {
                    MessageBox.Show("Debe realizar la consulta del curso antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(this.txtIDInstitucional.Text))
                {
                    MessageBox.Show("Debe realizar la consulta del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.matricula.IDCurso = this.txtIDCurso.Text.Trim();
                    this.matricula.IDInstitucional = this.txtIDInstitucional.Text.Trim();
                    this.matricula.estado = "En curso";

                    //switch para el tipo del empleado
                    switch (cbxPeriodo.SelectedIndex)
                    {
                        case 0:
                            this.matricula.periodo = "Primer";
                            break;

                        case 1:
                            this.matricula.periodo = "Segundo";
                            break;
                    }//fin del switch

                    if (MessageBox.Show("¿Está seguro de que quiere agregar la matrícula?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //control de transaccion
                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (this.conexion.agregarMatricula(matricula) == 1)
                            {
                                MessageBox.Show("Matrícula agregada con éxito", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Colaborador colaborador = this.conexion.consultaColaborador(this.txtIDInstitucional.Text.Trim());

                    if (colaborador != null)
                    {
                        this.txtCedula.Text = colaborador.cedula;
                        this.txtNombreColaborador.Text = colaborador.nombre;
                        this.txtPrimerApellido.Text = colaborador.primerApellido;
                        this.txtSegundoApellido.Text = colaborador.segundoApellido;
                        this.txtCorreo.Text = colaborador.correo;
                        this.txtTelefono.Text = colaborador.telefono;

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

        private void btnBuscarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtIDCurso.Text))
                {
                    MessageBox.Show("Debe ingresar el ID del curso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Curso curso = this.conexion.consultaCurso(this.txtIDCurso.Text.Trim());

                    if (curso != null)
                    {
                        this.txtNombreCurso.Text = curso.nombreCurso;
                        this.txtDuracion.Text = curso.duracion;

                        this.txtIDCurso.Enabled = false;
                        MessageBox.Show("Se encontró un empleado con el ID Institucional indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ningún curso con el ID indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Exception("No existe ningún curso con ese ID");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtIDInstitucional.Enabled = true;
            this.txtIDCurso.Enabled = true;
            this.limpiarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.guardarMatricula();
            this.limpiarCampos();
            this.txtIDInstitucional.Enabled = true;
            this.txtIDCurso.Enabled = true;
        }

        private void pictureBoxFace_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.srp.ucr.ac.cr/");
        }

        private void pictureBoxInsta_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/aeusp.ucr/?hl=es-la");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/UniversidadCR?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor");
        }
    }
}
