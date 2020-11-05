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
    }
}
