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
    public partial class FrmGestionCursos : Form
    {

        FrmAdministradorCapacitaciones administradorCapacitaciones;

        ConexionCapacitaciones conexion = null;

        Curso curso;

        HorarioCurso horario;

        public FrmGestionCursos()
        {
            InitializeComponent();
        }

        private void FrmGestionCursos_Load(object sender, EventArgs e)
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

        public void deshabilitar()
        {
            this.btnGuardarHorario.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.txtDia.Enabled = false;
            this.txtHoraFin.Enabled = false;
            this.txtHoraInicio.Enabled = false;
        }

        public void habilitar()
        {
            this.btnGuardarHorario.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.txtDia.Enabled = true;
            this.txtHoraFin.Enabled = true;
            this.txtHoraInicio.Enabled = true;
        }

        public void limpiarCampos()
        {
            this.txtIDCurso.Clear();
            this.txtNombreCurso.Clear();
            this.txtDuracion.Clear();
            this.txtDia.Clear();
            this.txtHoraInicio.Clear();
            this.txtHoraFin.Clear();
        }

        public void guardarHorario()
        {
            try
            {
                horario = new HorarioCurso();

                //evaluaciones de que los campos se encuentren en un estado válido para la base de datos
                if (string.IsNullOrEmpty(this.txtIDCurso.Text))
                {
                    MessageBox.Show("Debe ingresar un ID del curso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.horario.IDCurso = this.txtIDCurso.Text.Trim();
                }

                if (string.IsNullOrEmpty(this.txtDia.Text))
                {
                    MessageBox.Show("Debe ingresar un día de la semana para el horario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.horario.dia = this.txtDia.Text.Trim();
                }

                if (string.IsNullOrEmpty(this.txtHoraInicio.Text))
                {
                    MessageBox.Show("Debe ingresar una hora de inicio para las sesiones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.horario.horaInicio = int.Parse(this.txtHoraInicio.Text.Trim());
                }

                if (string.IsNullOrEmpty(this.txtHoraFin.Text))
                {
                    MessageBox.Show("Debe ingresar una hora de final para las sesiones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.horario.horaFin = int.Parse(this.txtHoraFin.Text.Trim());
                }

                try
                {
                    //comprobacion de que la hora de entrada siempre sea menor a la hora de salida
                    if (int.Parse(this.txtHoraFin.Text.Trim()) < int.Parse(this.txtHoraInicio.Text.Trim()))
                    {
                        MessageBox.Show("La hora de salida tiene que ser mayor que la hora de entrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (this.horario.comprobacionHorario(int.Parse(this.txtHoraInicio.Text.Trim()), int.Parse(this.txtHoraFin.Text.Trim())) == 0)
                        {
                            MessageBox.Show("Debe ingresar valores que estén en el intervalo de 0 a 24 horas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (MessageBox.Show("¿Está seguro de que quiere agregar el horario indicado para este curso? No podrá hacerle cambios después", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //control de transaccion
                                using (TransactionScope scope = new TransactionScope())
                                {
                                    if (this.conexion.guardarHorario(horario) == 1)
                                    {
                                        MessageBox.Show("Horario almacenado con éxito", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        scope.Complete();
                                    }
                                    else
                                    {
                                        MessageBox.Show("La transacción falló por un problema interno o porque repitió un mismo día de horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }//fin de transaccion
                            }//fin de confirmacion
                        }
                    }//fin de comprobacion de que la hora fin sea mayor que la hora inicio
                }
                catch (Exception ex)
                {
                    new Exception("Error", ex);
                    MessageBox.Show("Debe ingresar los en los datos campos de texto para poder hacer operaciones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnBuscar_Click(object sender, EventArgs e)
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
                        this.habilitar();
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
            this.limpiarCampos();
            this.deshabilitar();
            this.txtIDCurso.Enabled = true;
        }

        private void btnGuardarHorario_Click(object sender, EventArgs e)
        {
           this.guardarHorario();
           this.limpiarCampos();
           this.txtIDCurso.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtIDCurso.Text))
                {
                    MessageBox.Show("Debe ingresar el ID Institucional del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("¿Está seguro de que quiere eliminar al colaborador?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.conexion.eliminarCurso(this.txtIDCurso.Text.Trim());
                        this.conexion.eliminarHorarios(this.txtIDCurso.Text.Trim());
                        MessageBox.Show("Curso eliminado", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.limpiarCampos();
                        this.deshabilitar();
                        this.txtIDCurso.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
