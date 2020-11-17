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
    public partial class FrmListaAspirantes : Form
    {
        FrmContratacionesDespidos frmContrataciones;

        FrmContratacionesDespidos frmDespidos;

        ConexionContrataciones conexionA = null;

       

        public FrmListaAspirantes()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        //Metodo para cargar el frame y las instancia de la conexion

        private void btnAtras_Click(object sender, EventArgs e)
        {
            try
            {
                this.frmDespidos = new FrmContratacionesDespidos();
                this.frmDespidos.Show();
                this.Close();
                this.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void consultarLista(String puesto)
        {
            try
            {
                this.dtgListaAspirantes.DataSource = this.conexionA.consultaListaAspirantes(puesto).Tables[0];
                this.dtgListaAspirantes.AutoResizeColumns();
                this.dtgListaAspirantes.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dtgListaAspirantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Metodo para lanzar el frame con el grid actualizado segun el item del Cbox
        private void cboxPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboxPuesto.Text.Trim().Equals("Administrador de bases de datos"))
            {
                this.conexionA = new ConexionContrataciones();
                this.consultarLista(this.cboxPuesto.Text.Trim());

            }
            else if (this.cboxPuesto.Text.Trim().Equals("Desarrollador Junior"))
            {
                this.conexionA = new ConexionContrataciones();
                this.consultarLista(this.cboxPuesto.Text.Trim());
            }
            else if (this.cboxPuesto.Text.Trim().Equals("Analista de sistemas"))
            {
                this.conexionA = new ConexionContrataciones();
                this.consultarLista(this.cboxPuesto.Text.Trim());
            }
            else if (this.cboxPuesto.Text.Trim().Equals("Scrum Master"))
            {
                this.conexionA = new ConexionContrataciones();
                this.consultarLista(this.cboxPuesto.Text.Trim());
            }
            else if (this.cboxPuesto.Text.Trim().Equals("Contador"))
            {
                this.conexionA = new ConexionContrataciones();
                this.consultarLista(this.cboxPuesto.Text.Trim());
            }
            else if (this.cboxPuesto.Text.Trim().Equals("Asistente contable"))
            {
                this.conexionA = new ConexionContrataciones();
                this.consultarLista(this.cboxPuesto.Text.Trim());
            }
            else if (this.cboxPuesto.Text.Trim().Equals("Secretaria"))
            {
                this.conexionA = new ConexionContrataciones();
                this.consultarLista(this.cboxPuesto.Text.Trim());
            }
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
    }//Fin del namespace
}// Fin de la clase
