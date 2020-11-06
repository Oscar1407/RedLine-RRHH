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
    public partial class FrmAdministradorCapacitaciones : Form
    {

        FrmAgregarNuevoColaborador frameAgregar;

        public FrmAdministradorCapacitaciones()
        {
            InitializeComponent();
        }

        private void FrmAdministradorCapacitaciones_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregarColaborador_Click(object sender, EventArgs e)
        {
            try
            {
                this.frameAgregar = new FrmAgregarNuevoColaborador();
                this.frameAgregar.ShowDialog();
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnConsultarLista_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnBuscarColaborador_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void btnNuevaCapacitacion_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
