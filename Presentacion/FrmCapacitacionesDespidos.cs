using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//llamado a la capa de logica de negocios
using LogicaNegocio;

//llamado a la capa de acceso a datos
using AccesoDatos;

//implementacion control de transacciones
using System.Transactions;


namespace Presentacion
{
    public partial class FrmContratacionesDespidos : Form
    {
        //Referencias

        FrmGestionDespidos frmDespidos;

        Aspirante aspirante;

        ConexionContrataciones conexionA = null;


        public FrmContratacionesDespidos()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }



        //metodo para limpiar los campos
        public void limpiarCampos()
        {
            //this.txtID.Clear();
            this.txtCedula.Clear();
            this.txtNombre.Clear();
            this.txtPApellido.Clear();
            this.txtSApellido.Clear();
            this.txtEmail.Clear();
            this.txtTelefono.Clear();
            this.txtDesc.Clear();
        }

        //metodo de obtener informacion de los campos y almacenarlos en la BD
        public void guardarAspirante()
        {
            try
            {
                aspirante = new Aspirante();

                //evaluaciones de que los campos se encuentren en un estado válido para la base de datos
                if (string.IsNullOrEmpty(this.txtID.Text))
                {
                    MessageBox.Show("Debe ingresar el ID  del aspirante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(this.txtCedula.Text))
                {
                    MessageBox.Show("Debe ingresar la cédula del aspirante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(this.txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(this.txtPApellido.Text))
                {
                    MessageBox.Show("Debe ingresar el primer apellido del aspirante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);              
                }
                else if (string.IsNullOrEmpty(this.txtSApellido.Text))
                {
                    MessageBox.Show("Debe ingresar el segundo apellido del aspirante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(this.txtEmail.Text))
                {
                    MessageBox.Show("Debe ingresar el correo del aspirante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(this.txtTelefono.Text))
                {
                    MessageBox.Show("Debe ingresar el telefono del aspirante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(this.txtDesc.Text))
                {
                    MessageBox.Show("Debe ingresar la descripción del aspirante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.conexionA.consultaExistenciaAspirante(this.aspirante.idAspirante) == 1)
                {
                    MessageBox.Show("Ya existe un aspirante con ese ID ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.aspirante.idAspirante = this.txtID.Text.Trim();
                    this.aspirante.cedula = this.txtCedula.Text.Trim();
                    this.aspirante.nombre = this.txtNombre.Text.Trim();
                    this.aspirante.primerApellido = this.txtPApellido.Text.Trim();
                    this.aspirante.segundoApellido = this.txtSApellido.Text.Trim();
                    this.aspirante.telefono = this.txtTelefono.Text.Trim();
                    this.aspirante.correo = this.txtEmail.Text.Trim();                
                    this.aspirante.puestoAspirar = this.cboxPuestoAs.Text.Trim();
                    this.aspirante.descripcion = this.txtDesc.Text.Trim();

                    if (MessageBox.Show("¿Está seguro de que quiere agregar al aspirante?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //control de transaccion
                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (this.conexionA.guardarAspirante(aspirante) == 1 &&
                                this.conexionA.guardarCorreoAspirante(aspirante) == 1 &&
                                this.conexionA.guardarTelefonoAspirante(aspirante) == 1)
                            {
                                MessageBox.Show("Aspirante agregado", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                scope.Complete();
                                this.limpiarCampos();
                            }
                            else
                            {
                                MessageBox.Show("La transacción falló", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }//fin del control de transacción
                    }
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw new TransactionAbortedException(String.Format("No se pudo completar la transacción"), ex);
            }
        }

        //Funcionalidad del boton para agregar un nuevo aspirante
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.guardarAspirante();          
        }

        //deshabilita los campos del formulario y los botones
        private void deshabilitar()
        {
            this.txtCedula.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtPApellido.Enabled = false;
            this.txtSApellido.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.txtDesc.Enabled = false;
            this.cboxPuestoAs.Enabled = false;
            this.btnAgregar.Enabled = false;
        }


        //habilita los campos del formulario y los botones
        private void habilitar()
        {
            this.txtCedula.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtPApellido.Enabled = true;
            this.txtSApellido.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.txtDesc.Enabled = true;
            this.cboxPuestoAs.Enabled = true;
            this.btnAgregar.Enabled = true;
        }

        private void pictureBoxBuscarAsp_Click(object sender, EventArgs e)
        {
        
                try
                {
                    if (string.IsNullOrEmpty(this.txtID.Text))
                    {
                        MessageBox.Show("Debe ingresar el ID Institucional del colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Aspirante aspirante = this.conexionA.ConsultaAspirantes(this.txtID.Text.Trim());

                        if (aspirante != null)
                        {
                            this.txtCedula.Text = aspirante.cedula;
                            this.txtNombre.Text = aspirante.nombre;
                            this.txtPApellido.Text = aspirante.primerApellido;
                            this.txtSApellido.Text = aspirante.segundoApellido;
                            this.txtTelefono.Text = aspirante.telefono;
                            this.txtEmail.Text = aspirante.correo;
                            this.cboxPuestoAs.SelectedItem = aspirante.puestoAspirar;
                            this.txtDesc.Text = aspirante.descripcion;

                            MessageBox.Show("Se encontró un aspirante con el ID indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se encontró ningún colaborador con el ID Institucional indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new Exception("No existe ningún colaborador con ese ID Institucional");
                    this.habilitar();
                    this.limpiarCampos();
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

        //carga la clase de conexion desde que inicia la ejecucion de la pantalla
        private void FrmContratacionesDespidos_Load(object sender, EventArgs e)
        {
             
            try
                {
                    this.conexionA = new ConexionContrataciones();
                    this.deshabilitar();
                }
                catch (Exception ex)
                {
                    throw ex;
            }
            
        }

        //Método para mostrar el frame con la lista de los aspirantes agregados
        private void btnCoonsultarAsp_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarDespidos_Click(object sender, EventArgs e)
        {
            try
            {
                this.frmDespidos = new FrmGestionDespidos();
                this.frmDespidos.Show();
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }//Fin de la clase
}//FIn del namespace
