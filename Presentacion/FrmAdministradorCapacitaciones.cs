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

        FrmListaColaboradores frameLista;

        FrmGestionColaborador frameColaborador;

        FrmAgregarNuevoCurso frameCurso;

        FrmListaCursos frameListaCurso;

        FrmAgregarNuevaMatricula frameMatricula;

        FrmGestionMatricula frameGestMatricula;

        FrmListaMatricula frameListaMatricula;

        FrmGestionCursos frameGestCursos;

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
                this.frameAgregar.Show();
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
                this.frameLista = new FrmListaColaboradores();
                this.frameLista.Show();
                this.Close();
                this.Dispose();
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
                this.frameColaborador = new FrmGestionColaborador();
                this.frameColaborador.Show();
                this.Close();
                this.Dispose();
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
                this.frameCurso = new FrmAgregarNuevoCurso();
                this.frameCurso.Show();
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnConsultaListaCursos_Click(object sender, EventArgs e)
        {
            try
            {
                this.frameListaCurso = new FrmListaCursos();
                this.frameListaCurso.Show();
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnHacerMatricula_Click(object sender, EventArgs e)
        {
            try
            {
                this.frameMatricula = new FrmAgregarNuevaMatricula();
                this.frameMatricula.Show();
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnListaMatricula_Click(object sender, EventArgs e)
        {
            try
            {
                this.frameListaMatricula = new FrmListaMatricula();
                this.frameListaMatricula.Show();
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnConsultaMatricula_Click(object sender, EventArgs e)
        {
            try
            {
                this.frameGestMatricula = new FrmGestionMatricula();
                this.frameGestMatricula.Show();
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGestionCursos_Click(object sender, EventArgs e)
        {
            try
            {
                this.frameGestCursos = new FrmGestionCursos();
                this.frameGestCursos.Show();
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
