using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//driver del sql sever
using System.Data.SqlClient;

//librería del data set
using System.Data;

//capa de lógica de negocios
using LogicaNegocio;

namespace AccesoDatos
{
    public class ConexionCapacitaciones
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

        /*************************************************************************************************************************************************************************************************************************/
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

        //metodo para consulta de colaborador existente en la nomina por medio del ID Institucional
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

        //metodo que trae el dataset para llenar la tabla
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

        //metodos para modificar la informacion del colaborador
        public int modificarColaborador(Colaborador colaborador)
        {
            try
            {
                if (colaborador != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Act_Colaborador]";

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
                //throw ex;
                new Exception("Debe ingresar un valor en el ID Institucional");
                return 0;
            }
        }

        public int modificarCorreoColaborador(Colaborador colaborador)
        {
            try
            {
                if (colaborador != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Act_ColaboradorCorreo]";

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
                //throw ex;                
                new Exception("Debe ingresar un valor en el ID Institucional");
                return 0;
            }
        }

        public int modificarTelefonoColaborador(Colaborador colaborador)
        {
            try
            {
                if (colaborador != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Act_ColaboradorTelefono]";

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
                //throw ex;
                new Exception("Debe ingresar un valor en el ID Institucional");
                return 0;
            }
        }

        //metodos para eliminar la información del colaborador
        public void eliminarColaborador(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_Colaborador]";
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
                this.comando.CommandText = "[PA_Eli_ColaboradorCorreo]";
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
                this.comando.CommandText = "[PA_Eli_ColaboradorTelefono]";
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

        //método para agregar un correo secundario
        /*public void agregarCorreoSecundario(Colaborador colaborador)
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
                    this.comando.Parameters.AddWithValue("@correo", colaborador.correoSecundario);

                    this.comando.ExecuteNonQuery();
                    this.cerrarConexion();
                    this.comando.Dispose();

                }
            }
            catch (Exception ex)
            {
                new Exception("Debe ingresar un valor en el ID Institucional");
            }
        }

        //método para agregar un telefono secundario
        public void agregarTelefonoSecundario(Colaborador colaborador)
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
                    this.comando.Parameters.AddWithValue("@telefono", colaborador.telefonoSecundario);

                    this.comando.ExecuteNonQuery();
                    this.cerrarConexion();
                    this.comando.Dispose();

                }
            }
            catch (Exception ex)
            {
                new Exception("Debe ingresar un valor en el ID Institucional");
            }
        }*/

        /*************************************************************************************************************************************************************************************************************************/

        //metodo para controlar existencia del curso
        public int consultaExistenciaCurso(string identificador)
        {
            try
            {
                int existe = 0;
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_ExistenciaCurso]";
                this.comando.Parameters.AddWithValue("@IDCurso", identificador);
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

        //metodo para agregar un nuevo curso a la bd
        public int agregarCurso(Curso curso)
        {
            try
            {
                if (curso != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_Curso]";

                    this.comando.Parameters.AddWithValue("@IDCurso", curso.IDCurso);
                    this.comando.Parameters.AddWithValue("@nombreCurso", curso.nombreCurso);
                    this.comando.Parameters.AddWithValue("@duracion", curso.duracion);

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
                throw ex;
                /*new Exception("Debe ingresar un valor en el ID Institucional");
                return 0;*/
            }
        }

        //metodo para consultar un curso, para su gestión
        public Curso consultaCurso (string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_Curso]";
                this.comando.Parameters.AddWithValue("@IDCurso", ID);
                this.lector = this.comando.ExecuteReader();

                Curso curso = null;
                if (this.lector.Read())
                {
                    curso = new Curso();

                    curso.IDCurso = ID;
                    curso.nombreCurso = this.lector.GetValue(1).ToString();
                    curso.duracion = this.lector.GetValue(2).ToString();
                }
                else
                {
                    throw new Exception("No existe ningun curso con el ID " + ID);
                }

                this.cerrarConexion();
                this.comando.Dispose();
                this.lector = null;

                return curso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para guardar el horario de los cursos
        public int guardarHorario(HorarioCurso horario)
        {
            try
            {
                if (horario != null)
                {
                    this.abrirConexion();
                    this.comando = new SqlCommand();
                    this.comando.Connection = this.cnx;
                    this.comando.CommandType = CommandType.StoredProcedure;
                    this.comando.CommandText = "[PA_Ins_Horario]";

                    this.comando.Parameters.AddWithValue("@IDCurso", horario.IDCurso);
                    this.comando.Parameters.AddWithValue("@dia", horario.dia);
                    this.comando.Parameters.AddWithValue("@horaInicio", horario.horaInicio);
                    this.comando.Parameters.AddWithValue("@horaFin", horario.horaFin);

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
                new Exception("Error de transacción", ex);
                return 0;
            }
        }

        //metodo para eliminar un curso
        public void eliminarCurso(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_Curso]";
                this.comando.Parameters.AddWithValue("@IDCurso", ID);

                this.comando.ExecuteNonQuery();
                this.cerrarConexion();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para eliminar los horarios de los cursos que se eliminaron
        public void eliminarHorarios(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Eli_CursoHorario]";
                this.comando.Parameters.AddWithValue("@IDCurso", ID);

                this.comando.ExecuteNonQuery();
                this.cerrarConexion();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para el datagrid view del curso
        public DataSet consultaCursoLista(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_Curso]";
                this.comando.Parameters.AddWithValue("@IDCurso", ID);

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

        //metodo para el datagrid view del horario
        public DataSet consultaHorario(string ID)
        {
            try
            {
                this.abrirConexion();
                this.comando = new SqlCommand();
                this.comando.Connection = this.cnx;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.CommandText = "[PA_Cns_Horario]";
                this.comando.Parameters.AddWithValue("@IDCurso", ID);

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
