using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//driver del sql sever
using System.Data.SqlClient;

//librería del data set
using System.Data;

using LogicaNegocio;

namespace AccesoDatos
{
    public class ConexionNomina
    {
        private SqlConnection cnx;
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter adaptador;
        private DataSet datos;

        public void abrirConexion()
        {
            try
            {
                string StrConexion = @"Data Source=DESKTOP-M0HE3VI\MSSQLSERVERDEV;Initial Catalog=RedLine-DataBase;User ID=RedLine-UserAdmin;Password=Osc.pac1407";
                this.cnx = new SqlConnection(StrConexion);
                this.cnx.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para cerrar la conexion
        public void cerrarConexion()
        {
            try
            {
                this.cnx.Close();
                this.cnx.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //método de consultar colaboradores por medio del ID Institucional
        public Aspirante consultaAspirante(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_Aspirantes_Nom]";
                this.comando.Parameters.AddWithValue("@idAspirante", ID);
                this.lector = this.comando.ExecuteReader();

                Aspirante aspirante = null;
                if (this.lector.Read())
                {
                    aspirante = new Aspirante();

                    aspirante.idAspirante = ID;
                    aspirante.cedula = this.lector.GetValue(1).ToString();
                    aspirante.nombre = this.lector.GetValue(2).ToString();
                    aspirante.primerApellido = this.lector.GetValue(3).ToString();
                    aspirante.segundoApellido = this.lector.GetValue(4).ToString();
                    aspirante.telefono = this.lector.GetValue(5).ToString();
                    aspirante.correo = this.lector.GetValue(6).ToString();
                    aspirante.puestoAspirar = this.lector.GetValue(7).ToString();
                }
                else
                {
                    throw new Exception("No existe ningún registro con el IDInstitucional" + ID);
                }

                this.cerrarConexion();
                this.comando.Dispose();
                this.lector = null;

                return aspirante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int guardarNomina(Colaborador colaborador)
        {
            try
            {
                if (colaborador != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_ColaboradorNomina]";

                    this.comando.Parameters.AddWithValue("@idColaborador", colaborador.IDInstitucional);
                    this.comando.Parameters.AddWithValue("@cedula", colaborador.cedula);
                    this.comando.Parameters.AddWithValue("@nombre", colaborador.nombre);
                    this.comando.Parameters.AddWithValue("@primerApellido", colaborador.primerApellido);
                    this.comando.Parameters.AddWithValue("@segundoApellido", colaborador.segundoApellido);
                    this.comando.Parameters.AddWithValue("@direccion", colaborador.direccion);
                    this.comando.Parameters.AddWithValue("@puestoTrabajo", colaborador.puestoTrabajo);
                    this.comando.Parameters.AddWithValue("@salarioBruto", colaborador.SalarioBruto);
                    this.comando.Parameters.AddWithValue("@salarioNeto", colaborador.SalarioNeto);

                    this.comando.ExecuteNonQuery();
                    this.cerrarConexion();
                    this.comando.Dispose();

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                new Exception("Debe ingresar un valor en el ID Institucional");
                return 0;
            }
        }

        public int guardarNominaTelefono(Colaborador colaborador)
        {
            try
            {
                if (colaborador != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_NominaTelefono]";

                    this.comando.Parameters.AddWithValue("@IDInstitucional", colaborador.IDInstitucional);
                    this.comando.Parameters.AddWithValue("@telefono", colaborador.telefono);

                    this.comando.ExecuteNonQuery();
                    this.cerrarConexion();
                    this.comando.Dispose();

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                new Exception("Debe ingresar un valor en el ID Institucional");
                return 0;
            }
        }

        public int guardarNominaCorreo(Colaborador colaborador)
        {
            try
            {
                if (colaborador != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_NominaCorreo]";

                    this.comando.Parameters.AddWithValue("@IDInstitucional", colaborador.IDInstitucional);
                    this.comando.Parameters.AddWithValue("@correo", colaborador.correo);

                    this.comando.ExecuteNonQuery();
                    this.cerrarConexion();
                    this.comando.Dispose();

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                new Exception("Debe ingresar un valor en el ID Institucional");
                return 0;
            }
        }

        public int guardarNominaHorario(Colaborador colaborador)
        {
            try
            {
                if (colaborador != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_NominaHorario]";

                    this.comando.Parameters.AddWithValue("@IDInstitucional", colaborador.IDInstitucional);
                    this.comando.Parameters.AddWithValue("@tipoHorario", colaborador.tipoHorario);

                    this.comando.ExecuteNonQuery();
                    this.cerrarConexion();
                    this.comando.Dispose();

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                new Exception("Debe ingresar un valor en el ID Institucional");
                return 0;
            }
        }

        public void eliminarAspirante(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_Aspirante]";
                this.comando.Parameters.AddWithValue("@IDInstitucional", ID);

                this.comando.ExecuteNonQuery();
                this.cerrarConexion();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //elimina el correo del colaborador
        public void eliminarColaboradorCorreo(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_AspiranteCorreo]";
                this.comando.Parameters.AddWithValue("@IDInstitucional", ID);

                this.comando.ExecuteNonQuery();
                this.cerrarConexion();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarColaboradorTelefono(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_AspiranteTelefono]";
                this.comando.Parameters.AddWithValue("@IDInstitucional", ID);

                this.comando.ExecuteNonQuery();
                this.cerrarConexion();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
