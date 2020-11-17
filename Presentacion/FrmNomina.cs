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
using Presentacion.Reportes;

namespace Presentacion
{
    public partial class FrmNomina : Form
    {
        FrmCatalogoColaboradores frmReporte;

        Aspirante aspirante;

        Colaborador colaborador;

        ConexionNomina conexion = null;

        public FrmNomina()
        {
            InitializeComponent();
        }

        private void FrmNomina_Load(object sender, EventArgs e)
        {
            try
            {
                this.conexion = new ConexionNomina();
                this.cbxTipoHorario.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void eliminar()
        {
            try
            {
                this.conexion.eliminarColaboradorTelefono(this.txtID.Text.Trim());
                this.conexion.eliminarColaboradorCorreo(this.txtID.Text.Trim());
                this.conexion.eliminarAspirante(this.txtID.Text.Trim());
                MessageBox.Show("Se eliminó correctamente de Aspirantes", "Proceso aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void guardarAspirante()
        {
            try
            {
                double salarioBruto;
                double salarioNeto;
                colaborador = new Colaborador();

                if (string.IsNullOrEmpty(this.txtDireccion.Text))
                {
                    MessageBox.Show("Debe ingresar la direccion para el colaborador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.colaborador.IDInstitucional = this.txtID.Text.Trim();
                    this.colaborador.cedula = this.txtCedula.Text.Trim();
                    this.colaborador.nombre = this.txtNombre.Text.Trim();
                    this.colaborador.primerApellido = this.txtPApellido.Text.Trim();
                    this.colaborador.segundoApellido = this.txtSApellido.Text.Trim();
                    this.colaborador.telefono = this.txtTelefono.Text.Trim();
                    this.colaborador.correo = this.txtEmail.Text.Trim();
                    this.colaborador.puestoTrabajo = this.txtPuesto.Text.Trim();
                    this.colaborador.direccion = this.txtDireccion.Text.Trim();
                    this.colaborador.tipoHorario = this.cbxTipoHorario.Text.Trim();

                    salarioBruto = this.colaborador.salarioBruto(this.txtPuesto.Text.Trim());
                    this.colaborador.SalarioBruto = salarioBruto;

                    salarioNeto = this.colaborador.calculoSalarioNeto(this.txtPuesto.Text.Trim());
                    this.colaborador.SalarioNeto = salarioNeto;

                    if (MessageBox.Show("¿Está seguro de que quiere agregar al colaborador?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //control de transaccion
                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (this.conexion.guardarNomina(colaborador) == 1 &&
                                this.conexion.guardarNominaTelefono(colaborador) == 1 &&
                                this.conexion.guardarNominaCorreo(colaborador) == 1 &&
                                this.conexion.guardarNominaHorario(colaborador) == 1)
                            {
                                MessageBox.Show("Colaborador agregado a la nómina con éxito", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.eliminar();
                                scope.Complete();
                            }
                            else
                            {
                                MessageBox.Show("La transacción falló", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }//fin del control de transacción
                    }
                }              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
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
                    Aspirante aspirante = this.conexion.consultaAspirante(this.txtID.Text.Trim());

                    if (aspirante != null)
                    {
                        this.txtCedula.Text = aspirante.cedula;
                        this.txtNombre.Text = aspirante.nombre;
                        this.txtPApellido.Text = aspirante.primerApellido;
                        this.txtSApellido.Text = aspirante.segundoApellido;
                        this.txtTelefono.Text = aspirante.telefono;
                        this.txtEmail.Text = aspirante.correo;
                        this.txtPuesto.Text = aspirante.puestoAspirar;

                        MessageBox.Show("Se encontró un aspirante con el ID indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ningún colaborador con el ID Institucional indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Exception("No existe ningún colaborador con ese ID Institucional");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.guardarAspirante();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                
                frmReporte = new FrmCatalogoColaboradores();
                frmReporte.Show();
               
                this.Close();
                this.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
