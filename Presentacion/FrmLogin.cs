using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//referencia capa DAL
using AccesoDatos;

//referencia capa BL
using LogicaNegocio;

namespace Presentacion
{
    public partial class FrmLogin : Form
    {
        private bool autenticado = false;

        private FrmPrincipal principal;

        private FrmAdministradorCapacitaciones capacitaciones;

        private FrmContratacionesDespidos contrataciones;

        private FrmNomina nomina;

        private Conexion conexion;

        private Usuario user;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.cbxRol.SelectedIndex = 0;
        }

        public void padre(FrmPrincipal frmPrincipal)
        {
            this.principal = frmPrincipal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.capacitaciones = new FrmAdministradorCapacitaciones();
            this.contrataciones = new FrmContratacionesDespidos();
            this.nomina = new FrmNomina();
            this.conexion = new Conexion();
            this.user = new Usuario();

            //evaluación de si el id institucional está vacio
            if (string.IsNullOrEmpty(this.txtIDInstitucional.Text))
            {
                MessageBox.Show("Debe llenar el campo de la identificación institucional", "Proceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.user.idInstitucional = this.txtIDInstitucional.Text.Trim();
            }//fin validacion id

            //evaluacion de si la contraseña esta vacia
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Debe llenar el campo de la contraseña", "Proceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.user.password = this.txtPassword.Text.Trim();
            }//fin validacion contraseña

            //validacion combobox
            switch (this.cbxRol.SelectedIndex)
                {
                    case 0:
                        this.user.rol = "Administrador Contrataciones";
                        break;

                    case 1:
                        this.user.rol = "Administrador Capacitaciones";
                        break;

                    case 2:
                        this.user.rol = "Administrador Nomina";
                        break;
                }
            //fin validacion combo box

            //metodo de autenticacion Capacitaciones
            if (this.conexion.autenticacion(this.user))
            {
                if (this.user.rol.Equals("Administrador Capacitaciones"))
                {
                    this.autenticado = true;
                    this.capacitaciones.Show();
                    this.Dispose();
                }
                //agregar demás módulos para esta parte

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //metodo de autenticacion Contrataciones
            if (this.conexion.autenticacion(this.user))
            {
                if (this.user.rol.Equals("Administrador Contrataciones"))
                {
                    this.autenticado = true;
                    this.contrataciones.Show();
                    this.Dispose();
                }
                //agregar demás módulos para esta parte

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.user.rol.Equals("Administrador Nomina"))
            {
                this.autenticado = true;
                this.nomina.Show();
                this.Dispose();
            }//Login Nomina


        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
