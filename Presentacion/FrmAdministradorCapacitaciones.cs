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
                this.groupAgregar.Visible = true;
                this.groupLista.Visible = false;
                this.groupBuscar.Visible = false;
                this.groupNueva.Visible = false;
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
                this.groupLista.Visible = true;
                this.groupAgregar.Visible = false;
                this.groupBuscar.Visible = false;
                this.groupNueva.Visible = false;
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
                this.groupBuscar.Visible = true;
                this.groupLista.Visible = false;
                this.groupAgregar.Visible = false;
                this.groupNueva.Visible = false;
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
                this.groupNueva.Visible = true;
                this.groupAgregar.Visible = false;
                this.groupBuscar.Visible = false;
                this.groupLista.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
