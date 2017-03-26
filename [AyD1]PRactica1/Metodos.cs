using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace _AyD1_PRactica1
{
    public class Metodos
    {
        public static String error = "";
        public static bool PLogin(int cuenta, String usuario, String pass)
        {
            try
            {
                //  @nombre varchar(80), @contrasenia varchar(80) 
                string ConnectionString = @"Data Source=DARKHORSE\LEINDER;Initial Catalog=Practica2AyDBanco;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("LoginCuenta", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@numeroCuenta", SqlDbType.Int);
                cmd.Parameters.Add("@userName", SqlDbType.Char, 80);
                cmd.Parameters.Add("@contrasenia", SqlDbType.Char, 80);

                cmd.Parameters["@numeroCuenta"].Value = cuenta;
                cmd.Parameters["@userName"].Value = usuario;
                cmd.Parameters["@contrasenia"].Value = pass;
                cnn.Open();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                GridView GridView1 = new GridView();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                if(GridView1.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    error = "No se encontro su cuenta";
                    return false;
                }                

            }
            catch (Exception ex)
            {
                String Text = "Ocurrio un error durante el proceso " + ex.ToString();
                return false;
            }
        }

        public static int Registro(String nombre, String usuario, String pass, String correo)
        {
            try
            {
                //  @nombre varchar(80), @contrasenia varchar(80) 
                string ConnectionString = @"Data Source=DARKHORSE\LEINDER;Initial Catalog=Practica2AyDBanco;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("VerificacionUsuario", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userName", SqlDbType.Char, 80);

                cmd.Parameters["@userName"].Value = usuario;
                cnn.Open();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                GridView GridView1 = new GridView();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                cnn.Close();
                if (GridView1.Rows.Count > 0)
                {
                    error = "El usuario ya existe";
                    return -1;
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("RegistroCuenta", cnn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@userName", SqlDbType.Char, 80);
                    cmd2.Parameters.Add("@nombreCompleto", SqlDbType.Char, 80);
                    cmd2.Parameters.Add("@contrasenia", SqlDbType.Char, 80);
                    cmd2.Parameters.Add("@correo", SqlDbType.Char, 80);

                    cmd2.Parameters["@nombreCompleto"].Value = nombre;
                    cmd2.Parameters["@userName"].Value = usuario;
                    cmd2.Parameters["@contrasenia"].Value = pass;
                    cmd2.Parameters["@correo"].Value = correo;

                    cnn.Open();
                    SqlDataReader reader2;
                    reader2 = cmd2.ExecuteReader();

                    GridView GridView2 = new GridView();
                    GridView2.DataSource = reader2;
                    GridView2.DataBind();
                    cnn.Close();

                    return int.Parse(GridView2.Rows[0].Cells[0].Text);
                }
            }
            catch (Exception ex)
            {
                error = "Ocurrio un error: " + ex.ToString();
                return -1;
            }
        }


        public static float Consulta(int cuenta)
        {
            try
            {
                //  @nombre varchar(80), @contrasenia varchar(80) 
                string ConnectionString = @"Data Source=DARKHORSE\LEINDER;Initial Catalog=Practica2AyDBanco;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("ConsultarSaldo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@numeroCuenta", SqlDbType.Int);

                cmd.Parameters["@numeroCuenta"].Value = cuenta;
                cnn.Open();

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                GridView GridView1 = new GridView();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                cnn.Close();

                if (GridView1.Rows.Count > 0)
                {
                    return float.Parse(GridView1.Rows[0].Cells[0].Text);
                }
                else
                {
                    error = "No se encontro el numero de cuenta";
                    return -1;
                }
            }
            catch (Exception ex)
            {
                error = "Ocurrio un error: " + ex.ToString();
                return -1;
            }
        }

        public static bool Credito(int cuentaOr, int cuenta, float monto, String descripcion)
        {
            bool acr = AcreditarSaldo(cuentaOr, cuenta, monto, descripcion); // acredito a la otra cuenta
            bool deb = DebitarSaldo(cuentaOr, monto, descripcion); //debito de mi cuenta            

            if(acr == true && deb == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Debito(int cuentaOr, int cuenta, float monto, String descripcion)
        {
            bool acr = AcreditarSaldo(cuenta, cuentaOr, monto, descripcion); // acredito a mi cuenta
            bool deb = DebitarSaldo(cuenta, monto, descripcion); //debito de la otra cuenta          

            if (acr == true && deb == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AcreditarSaldo(int cuentaOr, int cuenta, float monto, String descripcion)
        {
            try
            {
                Conexion con = new Conexion();

                GridView campos = new GridView();
                campos.DataSource = con.MostrarRegistros_Condición("CUENTA", "numero = " + cuentaOr);
                campos.DataBind();

                if (campos.Rows.Count > 0)
                {
                    double saldo = double.Parse(campos.Rows[0].Cells[5].Text);
                    if (saldo >= monto)
                    {
                        //  @nombre varchar(80), @contrasenia varchar(80) 
                        string ConnectionString = @"Data Source=DARKHORSE\LEINDER;Initial Catalog=Practica2AyDBanco;Integrated Security=True";
                        SqlConnection cnn = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand("AcreditarSaldo", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@numeroCuenta", SqlDbType.Int);
                        cmd.Parameters.Add("@monto", SqlDbType.Float);
                        cmd.Parameters.Add("@descripcion", SqlDbType.Char, 250);

                        cmd.Parameters["@numeroCuenta"].Value = cuenta;
                        cmd.Parameters["@monto"].Value = monto;
                        cmd.Parameters["@descripcion"].Value = descripcion;
                        cnn.Open();

                        SqlDataReader reader;
                        reader = cmd.ExecuteReader();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                error = "Ocurrio un error durante el proceso " + ex.ToString();
                return false;
            }
        }


        public static bool DebitarSaldo(int cuenta, float monto, String descripcion)
        {
            /*debito saldo de cualqueir cuenta*/
            try
            {
                Conexion con = new Conexion();

                GridView campos = new GridView();
                campos.DataSource = con.MostrarRegistros_Condición("CUENTA", "numero = " +cuenta);
                campos.DataBind();

                if(campos.Rows.Count > 0)
                {
                    double saldo = double.Parse(campos.Rows[0].Cells[5].Text);

                    if (saldo >= monto)
                    {
                        string ConnectionString = @"Data Source=DARKHORSE\LEINDER;Initial Catalog=Practica2AyDBanco;Integrated Security=True";
                        SqlConnection cnn = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand("DebitarSaldo", cnn);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@numeroCuenta", SqlDbType.Int);
                        cmd.Parameters.Add("@monto", SqlDbType.Float);
                        cmd.Parameters.Add("@descripcion", SqlDbType.Char, 250);

                        cmd.Parameters["@numeroCuenta"].Value = cuenta;
                        cmd.Parameters["@monto"].Value = monto;
                        cmd.Parameters["@descripcion"].Value = descripcion;
                        cnn.Open();

                        SqlDataReader reader;
                        reader = cmd.ExecuteReader();

                        return true;
                    }
                    else
                    {
                        return false;
                    }                   
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                error = "Ocurrio un error durante el proceso " + ex.ToString();
                return false;
            }
        }


        public static bool PagoServicio(int cuentaOrigen, float monto, String Servicio)
        {         
            try
            {
                Conexion con = new Conexion();
                GridView campos = new GridView();
                campos.DataSource = con.MostrarRegistros_Condición("SERVICIO", "Nombre = '" + Servicio + "'");
                campos.DataBind();

                GridView campos2 = new GridView();
                campos2.DataSource = con.MostrarRegistros_Condición("CUENTA", "numero = " +cuentaOrigen);
                campos2.DataBind();

                if (campos2.Rows.Count > 0)
                {
                    float saldo = float.Parse(campos2.Rows[0].Cells[5].Text);

                    if (saldo >= monto)
                    {
                        string ConnectionString = @"Data Source=DARKHORSE\LEINDER;Initial Catalog=Practica2AyDBanco;Integrated Security=True";
                        SqlConnection cnn = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand("PagarServicio", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@numeroCuentaOrigen", SqlDbType.Int);
                        cmd.Parameters.Add("@montoPagar", SqlDbType.Float);
                        cmd.Parameters.Add("@numeroCuentaServicio", SqlDbType.Int);

                        cmd.Parameters["@numeroCuentaOrigen"].Value = cuentaOrigen;
                        cmd.Parameters["@montoPagar"].Value = monto;
                        cmd.Parameters["@numeroCuentaServicio"].Value = int.Parse(campos.Rows[0].Cells[0].Text);
                        cnn.Open();

                        SqlDataReader reader;
                        reader = cmd.ExecuteReader();

                        GridView GridView1 = new GridView();
                        GridView1.DataSource = reader;
                        GridView1.DataBind();

                        return true;
                    }
                    else
                    {
                        error = "El monto es mayor que el saldo en la cuenta";
                        return false;
                    }
                }
                else
                {
                    error = "No se encontro el numero de cuenta";
                    return false;
                }                
                
            }
            catch (Exception ex)
            {
                error = "Ocurrio un error durante el proceso " + ex.ToString();
                return false;
            }
        }


        public static bool Transferencia(int cuentaOrigen, float monto, int cuentaDest)
        {
            try
            {
                Conexion con = new Conexion();

                GridView campos = new GridView();
                campos.DataSource = con.MostrarRegistros_Condición("CUENTA", "numero = " +cuentaOrigen);
                campos.DataBind();

                if (campos.Rows.Count > 0)
                {
                    double saldo = double.Parse(campos.Rows[0].Cells[5].Text);

                    if (saldo >= monto)
                    {
                        string ConnectionString = @"Data Source=DARKHORSE\LEINDER;Initial Catalog=Practica2AyDBanco;Integrated Security=True";
                        SqlConnection cnn = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand("TransferirSaldo", cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@numeroCuentaOrigen", SqlDbType.Int);
                        cmd.Parameters.Add("@montoTransferir", SqlDbType.Float);
                        cmd.Parameters.Add("@numeroCuentaDestino", SqlDbType.Int);

                        cmd.Parameters["@numeroCuentaOrigen"].Value = cuentaOrigen;
                        cmd.Parameters["@montoTransferir"].Value = monto;
                        cmd.Parameters["@numeroCuentaDestino"].Value = cuentaDest;
                        cnn.Open();

                        SqlDataReader reader;
                        reader = cmd.ExecuteReader();

                        GridView GridView1 = new GridView();
                        GridView1.DataSource = reader;
                        GridView1.DataBind();

                        return true;
                    }
                    else
                    {
                        error = "El monto es mayor que el saldo en la cuenta";
                        return false;
                    }
                }
                else
                {
                    error = "No se encontro el numero de cuenta";
                    return false;
                }      
                
            }
            catch (Exception ex)
            {
                error = "Ocurrio un error durante el proceso " + ex.ToString();
                return false;
            }
        }


    }
}