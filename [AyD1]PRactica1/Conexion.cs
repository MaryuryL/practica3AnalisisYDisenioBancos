using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _AyD1_PRactica1
{
    public class Conexion
    {
        SqlConnection conex = new SqlConnection();

        string Error;

        public string MotrarError
        {
            get
            {
                return Error;
            }

            set
            {
                Error = value;
            }
        }

        public bool Conectar()
        {
            bool respuesta = false;
            string cadenaConexion = @"Data Source=DARKHORSE\LEINDER;Initial Catalog=Practica2AyDBanco;Integrated Security=True";
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                respuesta = true;

            }
            catch (Exception ex)
            {
                respuesta = false;
                MotrarError = "No se ha podido conectar con el servidor. Mensaje de la exepción: " + ex.Message.ToString();
            }
            return respuesta;
        }

        public bool Registrar(string tabla, string campos, string valores)
        {
            bool respuesta = false;

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conex;
                comando.CommandText = "INSERT INTO " + tabla + "(" + campos + ") VALUES (" + valores + ");";
                if (Conectar())
                {
                    if (comando.ExecuteNonQuery() == 1)
                        respuesta = true;
                    else
                        respuesta = false;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                MotrarError = "Mensaje de la excepción: " + ex.Message.ToString();
            }
            finally
            {
                conex.Close();
            }

            return respuesta;
        }

        public bool Modificar(string tabla, string campos, string condicion)
        {
            bool respuesta = false;

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conex;
                comando.CommandText = "UPDATE " + tabla + " SET " + campos + " WHERE " + condicion + ";";
                if (Conectar())
                {
                    if (comando.ExecuteNonQuery() == 1)
                        respuesta = true;
                    else
                        respuesta = false;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                MotrarError = "Mensaje de la excepción: " + ex.Message.ToString();
            }
            finally
            {
                conex.Close();
            }

            return respuesta;
        }

        public bool Eliminar(string tabla, string condicion)
        {
            bool respuesta = false;

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conex;
                comando.CommandText = "DELETE FROM " + tabla + " WHERE " + condicion + ";";
                if (Conectar())
                {
                    if (comando.ExecuteNonQuery() == 1)
                        respuesta = true;
                    else
                        respuesta = false;
                }
                else
                {
                    respuesta = false;
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                MotrarError = "Mensaje de la excepción: " + ex.Message.ToString();
            }
            finally
            {
                conex.Close();
            }

            return respuesta;
        }

        public DataSet MostrarRegistros(string tabla)
        {
            DataSet respuesta = new DataSet();
            try
            {
                //SELECT * FROM Productos;
                string instruccionSQL = "SELECT * FROM " + tabla + ";";
                SqlDataAdapter adaptador = new SqlDataAdapter(instruccionSQL, conex);
                if (Conectar())
                {
                    adaptador.Fill(respuesta, tabla);
                }
            }
            catch (Exception ex)
            {
                MotrarError = "Mensaje de la exepción: " + ex.Message.ToString();
            }
            finally
            {
                conex.Close();
            }
            return respuesta;
        }

        public bool buscar(string tabla, string condicion)
        {
            bool respuesta = false;

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conex;
                comando.CommandText = "SELECT * FROM " + tabla + " WHERE " + condicion + ";";
                if (Conectar())
                {
                    SqlDataReader leer = comando.ExecuteReader();
                    if (leer.HasRows)
                        respuesta = true;
                    else
                        respuesta = false;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                MotrarError = "Mensaje de la exepción: " + ex.Message.ToString();
            }
            finally
            {
                conex.Close();
            }

            return respuesta;
        }

        public DataSet MostrarRegistros_Condición(string tabla, string condicion)
        {
            DataSet respuesta = new DataSet();
            try
            {
                string instruccionSQL = "SELECT * FROM " + tabla + " WHERE " + condicion + ";";
                SqlDataAdapter adaptador = new SqlDataAdapter(instruccionSQL, conex);
                if (Conectar())
                {
                    adaptador.Fill(respuesta, tabla);
                }
            }
            catch (Exception ex)
            {
                MotrarError = "Mensaje de la exepción: " + ex.Message.ToString();
            }
            finally
            {
                conex.Close();
            }
            return respuesta;
        }

        public DataSet Mostrar_Comando(string instruccion)
        {
            DataSet respuesta = new DataSet();
            try
            {
                string instruccionSQL = instruccion + ";";
                SqlDataAdapter adaptador = new SqlDataAdapter(instruccionSQL, conex);
                if (Conectar())
                {
                    adaptador.Fill(respuesta, instruccion);
                }
            }
            catch (Exception ex)
            {
                MotrarError = "Mensaje de la exepción: " + ex.Message.ToString();
            }
            finally
            {
                conex.Close();
            }
            return respuesta;
        }
    }
}