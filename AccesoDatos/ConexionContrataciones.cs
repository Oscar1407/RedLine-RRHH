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
using System.Security.Cryptography;

namespace AccesoDatos
{
    public class ConexionContrataciones
    {

        private SqlConnection conexionA;
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter adaptador;
        private DataSet datos;

        public ConexionContrataciones()
        {
            Aspirante aspirante = new Aspirante();

        }

        //metodo de abrir conexion
        public void abrirConexion()
        {
            try
            {
                string StrConexion = @"Data Source=DESKTOP-M0HE3VI\MSSQLSERVERDEV;Initial Catalog=RedLine-DataBase;User ID=RedLine-UserAdmin;Password=Osc.pac1407";
                this.conexionA = new SqlConnection(StrConexion);
                this.conexionA.Open();
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
                this.conexionA.Close();
                this.conexionA.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int consultaExistencia(string identificador)
        {
            try
            {
                int existe = 0;
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_ExistenciaDespido]";
                this.comando.Parameters.AddWithValue("@idColaborador", identificador);
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


        //metodo de consultar existencia del aspirante
        public int consultaExistenciaAspirante(string identificador)
        {
            try
            {
                int existe = 0;
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_ExistenciaAspirante]";
                this.comando.Parameters.AddWithValue("@ID", identificador);
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
                new Exception("Debe ingresar un valor en el ID para el aspirante");
                return 0;
            }
        }



        //metodo para consulta de aspirante existente en la base de datos por medio del ID
        public Aspirante ConsultaAspirantes(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_Aspirantes]";
                this.comando.Parameters.AddWithValue("@idAspirante", ID);
                this.lector = this.comando.ExecuteReader();

                Aspirante aspirante = new Aspirante();
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
                    aspirante.descripcion = this.lector.GetValue(8).ToString();
                }
                else
                {
                    throw new Exception("No existe ningún registro con el ID: " + ID);
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


        //métodos para agregar un nuevo aspirante
        public int guardarAspirante(Aspirante aspirante)
        {
            try
            {
                if (aspirante != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.conexionA;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_Aspirante]";

                    this.comando.Parameters.AddWithValue("@idAspirante", aspirante.idAspirante);
                    this.comando.Parameters.AddWithValue("@cedula", aspirante.cedula);
                    this.comando.Parameters.AddWithValue("@nombre", aspirante.nombre);
                    this.comando.Parameters.AddWithValue("@primerApellido", aspirante.primerApellido);
                    this.comando.Parameters.AddWithValue("@segundoApellido", aspirante.segundoApellido);
                    this.comando.Parameters.AddWithValue("@descripcion", aspirante.descripcion);
                    this.comando.Parameters.AddWithValue("@puestoAspirar", aspirante.puestoAspirar);


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

        public int guardarCorreoAspirante(Aspirante aspirante)
        {
            try
            {
                if (aspirante != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.conexionA;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_CorreoAspirante]";

                    this.comando.Parameters.AddWithValue("@idAspirante", aspirante.idAspirante);
                    this.comando.Parameters.AddWithValue("@correo", aspirante.correo);

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
                new Exception("Debe ingresar un valor en el ID del aspirante");
                return 0;
            }
        }

        public int guardarTelefonoAspirante(Aspirante aspirante)
        {
            try
            {
                if (aspirante != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.conexionA;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_TelefonoAspirante]";

                    this.comando.Parameters.AddWithValue("@idAspirante", aspirante.idAspirante);
                    this.comando.Parameters.AddWithValue("@telefono", aspirante.telefono);

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
                new Exception("Debe ingresar un valor en el ID del aspirante");
                return 0;
            }
        }

        //metodo para consulta de colaborador existente en la nómina, por medio del IdInstitucional
        public Colaborador consultaNomina(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_NominaDespidos]";
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
                    colaborador.puestoTrabajo = this.lector.GetValue(7).ToString();

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

        //métodos de agregar colaborador despedido a la tabla de despidos
        public int guardarDespido(Despido despido)
        {
            try
            {
                if (despido != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.conexionA;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_Despido]";

                    this.comando.Parameters.AddWithValue("@idColaborador", despido.IDInstitucional);
                    this.comando.Parameters.AddWithValue("@cedula", despido.cedula);
                    this.comando.Parameters.AddWithValue("@nombre", despido.nombre);
                    this.comando.Parameters.AddWithValue("@primerApellido", despido.primerApellido);
                    this.comando.Parameters.AddWithValue("@segundoApellido", despido.segundoApellido);
                    this.comando.Parameters.AddWithValue("@puesto", despido.puestoTrabajo);
                    this.comando.Parameters.AddWithValue("@motivo", despido.motivoDespido);
                    this.comando.Parameters.AddWithValue("@fechaDespido", despido.fechaDespido);

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

        public int guardarCorreoDespido(Despido despido)
        {
            try
            {
                if (despido != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.conexionA;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_CorreoDespido]";

                    this.comando.Parameters.AddWithValue("@idColaborador", despido.IDInstitucional);
                    this.comando.Parameters.AddWithValue("@correo", despido.correo);

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

        public int guardarTelefonoDespido(Despido despido)
        {
            try
            {
                if (despido != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.conexionA;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_TelefonoDespido]";

                    this.comando.Parameters.AddWithValue("@idColaborador", despido.IDInstitucional);
                    this.comando.Parameters.AddWithValue("@telefono", despido.telefono);

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

        //metodos para eliminar al colaborador de la nómina
        public void eliminarColaboradorNomina(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_ColaboradorNomina]";
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
        public void eliminarColaboradorCorreoNomina(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_ColaboradorCorreoNomina]";
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

        public void eliminarColaboradorTelefonoNomina(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_ColaboradorTelefonoNomina]";
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

        public void eliminarColaboradorHorarioNomina(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_ColaboradorHorarioNomina]";
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

        public void eliminarColaboradorDeduccionLaboralNomina(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_ColaboradorDeduccionLaboralNomina]";
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

        public void eliminarColaboradorAguinaldoNomina(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_ColaboradorAguinaldolNomina]";
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

        public void eliminarColaboradorDeduccionAguinaldoNomina(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_ColaboradorDecuccionAguinaldoNomina]";
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


        //metodo que trae el dataset para llenar la tabla
        public DataSet consultaListaAspirantes(string puesto)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_ListaAspirantes]";
                this.comando.Parameters.AddWithValue("@puestoTrabajo", puesto);

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


        //metodo para consultar la lista de despidos
        public DataSet consultaListaDespidos(DateTime fechaInicial, DateTime fechaFinal )
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexionA;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[Sp_Cns_Despidos_X_Fechas]";
                this.comando.Parameters.AddWithValue("@fechaInicial", fechaInicial);
                this.comando.Parameters.AddWithValue("@fechaFinal", fechaFinal);

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


    }// Fin de la clase
}// FIn del namespace