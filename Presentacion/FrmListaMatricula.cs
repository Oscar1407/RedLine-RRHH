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
    public partial class FrmListaMatricula : Form
    {

        FrmAdministradorCapacitaciones administradorCapacitaciones;

        ConexionCapacitaciones conexion = null;

        public FrmListaMatricula()
        {
            InitializeComponent();
        }
        private void consultaMatricula()
        {
            try
            {
                this.dtgMatricula.DataSource = this.conexion.consultaMatriculaLista(this.txtIDCurso.Text.Trim()).Tables[0];
                this.dtgMatricula.AutoResizeColumns();
                this.dtgMatricula.ReadOnly = true;
                this.dtgMatricula.ClearSelection();
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

        private void FrmListaMatricula_Load(object sender, EventArgs e)
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
                this.consultaMatricula();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
