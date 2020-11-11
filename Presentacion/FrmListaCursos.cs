using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Presentacion
{
    public partial class FrmListaCursos : Form
    {

        FrmAdministradorCapacitaciones administradorCapacitaciones;

        ConexionCapacitaciones conexion = null;

        public FrmListaCursos()
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

        private void FrmListaCursos_Load(object sender, EventArgs e)
        {
            try
            {
                this.conexion = new ConexionCapacitaciones();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIDCurso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.consultarCurso();
                this.consultarHorario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //llena la tabla con los datos del cliente
        private void consultarCurso()
        {
            try
            {
                this.dtgCurso.DataSource = this.conexion.consultaCursoLista(this.txtIDCurso.Text.Trim()).Tables[0];
                this.dtgCurso.AutoResizeColumns();
                this.dtgCurso.ReadOnly = true;
                this.dtgCurso.ClearSelection();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void consultarHorario()
        {
            try
            {
                this.dtgHorarios.DataSource = this.conexion.consultaHorario(this.txtIDCurso.Text.Trim()).Tables[0];
                this.dtgHorarios.AutoResizeColumns();
                this.dtgHorarios.ReadOnly = true;
                this.dtgHorarios.ClearSelection();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
