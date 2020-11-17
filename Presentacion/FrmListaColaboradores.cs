using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmListaColaboradores : Form
    {
        FrmAdministradorCapacitaciones administradorCapacitaciones;

        ConexionCapacitaciones conexion = null;

        public FrmListaColaboradores()
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

        private void FrmListaColaboradores_Load(object sender, EventArgs e)
        {
            try
            {
                this.conexion = new ConexionCapacitaciones();
                this.consultarLista();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void consultarLista()
        {
            try
            {
                this.dtgListaColaboradores.DataSource = this.conexion.consultaListaEmpleados().Tables[0];
                this.dtgListaColaboradores.AutoResizeColumns();
                this.dtgListaColaboradores.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dtgListaColaboradores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
