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
    public partial class FrmListaDespidos : Form
    {
        FrmGestionDespidos frmDespidos;

        ConexionContrataciones conexionA = null;

        public FrmListaDespidos()
        {
            InitializeComponent();
        }



        private void consultarLista(DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                this.dtgListaDespidos.DataSource = this.conexionA.consultaListaDespidos(fechaInicial, fechaFinal).Tables[0];
                this.dtgListaDespidos.AutoResizeColumns();
                this.dtgListaDespidos.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmListaDespidos_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmDespidos = new FrmGestionDespidos();
            frmDespidos.Show();
            this.Close();
            this.Dispose();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.conexionA = new ConexionContrataciones();
            this.consultarLista(DateTime.Parse(this.dateTimeInicial.Text.Trim()), DateTime.Parse(this.dateTimeFinal.Text.Trim()));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pictureBoxFace_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.srp.ucr.ac.cr/");
        }

        private void pictureBoxInsta_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/aeusp.ucr/?hl=es-la");
        }
    }
}
