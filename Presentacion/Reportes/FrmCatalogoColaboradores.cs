using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Reportes
{
    public partial class FrmCatalogoColaboradores : Form
    {
        FrmNomina frmNomina;
        public FrmCatalogoColaboradores()
        {
            InitializeComponent();
        }

        private void FrmCatalogoColaboradores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dtsModeloDatos.Nomina' Puede moverla o quitarla según sea necesario.
            this.NominaTableAdapter.Fill(this.dtsModeloDatos.Nomina);

            this.reportViewer1.RefreshReport();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            try
            {
                this.frmNomina = new FrmNomina();
                this.frmNomina.Show();
                this.Close();
                this.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
