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

        Conexion conexion = null;

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
                this.conexion = new Conexion();
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
                this.dtgListaColaboradores.ClearSelection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
