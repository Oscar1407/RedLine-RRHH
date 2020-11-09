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
    public class Conexion
    {
        private SqlConnection cnx;
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter adaptador;
        private DataSet datos;

        //metodo de abrir conexion
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

        //metodo de autenticacion
        public bool autenticacion (Usuario user)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_IntentoAutenticacion]";
                this.comando.Parameters.AddWithValue("@ID", user.idInstitucional);
                this.comando.Parameters.AddWithValue("@password", user.password);
                this.comando.Parameters.AddWithValue("@perfil", user.rol);
                this.lector = this.comando.ExecuteReader();

                bool autorizacion = false;
                if (this.lector.Read())
                {
                    if (this.lector.GetValue(0).ToString().Equals(user.idInstitucional))
                    {
                        if (this.lector.GetValue(1).ToString().Equals(user.password))
                        {
                            if(this.lector.GetValue(2).ToString().Equals(user.rol))
                                autorizacion = true;
                        }
                    }                   
                }

                this.cerrarConexion();
                this.comando.Dispose();

                return autorizacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo de consultar existencia de colaborador
        public int consultaExistencia(string identificador)
        {
            try
            {
                int existe = 0;
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_ExistenciaColaborador]";
                this.comando.Parameters.AddWithValue("@IDInstitucional", identificador);
                this.lector = this.comando.ExecuteReader();

                if (this.lector.Read())
                {
                    if (this.lector.GetValue(0).ToString().Equals("1"))
                    {
                        existe = 1;
                    }
                    else
                    {
                        existe = 0;
                    }
                }              

                this.cerrarConexion();
                this.comando.Dispose();
                this.lector = null;

                return existe;
            }
            catch (Exception ex)
            {
               new Exception("Debe ingresar un valor en el ID Institucional");
               return 0;
            }
        }

        //métodos de agregar colaborador a capacitación
        public int guardarColaborador(Colaborador colaborador)
        {
            try
            {
                if (colaborador != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_Colaborador]";

                    this.comando.Parameters.AddWithValue("@IDInstitucional", colaborador.IDInstitucional);
                    this.comando.Parameters.AddWithValue("@cedula", colaborador.cedula);
                    this.comando.Parameters.AddWithValue("@nombre", colaborador.nombre);
                    this.comando.Parameters.AddWithValue("@primerApellido", colaborador.primerApellido);
                    this.comando.Parameters.AddWithValue("@segundoApellido", colaborador.segundoApellido);

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

        public int guardarCorreoColaborador(Colaborador colaborador)
        {
            try
            {
                if (colaborador != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_ColaboradorCorreo]";

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

        public int guardarTelefonoColaborador(Colaborador colaborador)
        {
            try
            {
                if (colaborador != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_ColaboradorTelefono]";

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

        //método de consultar colaboradores por medio del ID Institucional
        public Colaborador consultaColaborador(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_Colaboradores]";
                this.comando.Parameters.AddWithValue("@IDInstitucional", ID);
                this.lector = this.comando.ExecuteReader();

                Colaborador colaborador = null;
                if (this.lector.Read())
                {
                    colaborador = new Colaborador();

                    colaborador.IDInstitucional = ID;
                    colaborador.cedula = this.lector.GetValue(1).ToString();
                    colaborador.nombre = this.lector.GetValue(2).ToString();
                    colaborador.primerApellido = this.lector.GetValue(3).ToString();
                    colaborador.segundoApellido = this.lector.GetValue(4).ToString();
                    colaborador.correo = this.lector.GetValue(5).ToString();
                    colaborador.telefono = this.lector.GetValue(6).ToString();
                }
                else
                {
                    throw new Exception ("No existe ningún registro con el IDInstitucional" + ID);
                }

                this.cerrarConexion();
                this.comando.Dispose();
                this.lector = null;

                return colaborador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //procedimiento para consulta de colaborador existente en la nomina por medio del ID Institucional
        public Colaborador consultaNomina(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_Nomina]";
                this.comando.Parameters.AddWithValue("@IDInstitucional", ID);
                this.lector = this.comando.ExecuteReader();

                Colaborador colaborador = null;
                if (this.lector.Read())
                {
                    colaborador = new Colaborador();

                    colaborador.IDInstitucional = ID;
                    colaborador.cedula = this.lector.GetValue(1).ToString();
                    colaborador.nombre = this.lector.GetValue(2).ToString();
                    colaborador.primerApellido = this.lector.GetValue(3).ToString();
                    colaborador.segundoApellido = this.lector.GetValue(4).ToString();
                    colaborador.correo = this.lector.GetValue(5).ToString();
                    colaborador.telefono = this.lector.GetValue(6).ToString();
                }
                else
                {
                    throw new Exception("No existe ningún registro con el IDInstitucional" + ID);
                }

                this.cerrarConexion();
                this.comando.Dispose();
                this.lector = null;

                return colaborador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet consultaListaEmpleados()
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_ListaColaboradores]";

                this.adaptador = new SqlDataAdapter();
                this.adaptador.SelectCommand = this.comando;
                this.datos = new DataSet();
                this.adaptador.Fill(this.datos);

                this.cerrarConexion();
                this.comando.Dispose();
                this.adaptador.Dispose();

                return this.datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
