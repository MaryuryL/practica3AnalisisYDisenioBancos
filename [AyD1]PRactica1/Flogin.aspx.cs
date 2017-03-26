using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace _AyD1_PRactica1
{
    public partial class Flogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
           


        protected void Button1_Click(object sender, EventArgs e)
        {
             if ( Metodos.PLogin(Convert.ToInt32(TextBox3.Text), TextBox1.Text, TextBox2.Text) )
            {
                Session["cuenta"] = TextBox3.Text;

                Conexion con = new Conexion();
                GridView campos = new GridView();
                campos.DataSource = con.MostrarRegistros_Condición("CUENTA", "numero = " + TextBox3.Text);
                campos.DataBind();

                Session["nombre"] = campos.Rows[0].Cells[2].Text;
                Response.Redirect("Movimientos.aspx");
            }
            else
            {
                 info.Text = Metodos.error;
                 TextBox3.Text = "";
                 TextBox1.Text = "";
                 TextBox2.Text = "";
            }            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int cuenta = Metodos.Registro(TextBox4.Text, TextBox5.Text, TextBox7.Text, TextBox6.Text);
            if (cuenta == -1)
            {
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox7.Text = "";
                TextBox6.Text = "";
                info2.Text = Metodos.error;
            }
            else
            {
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox7.Text = "";
                TextBox6.Text= "";
                info2.Text = "su numero de cuenta es: " + cuenta + "\nAhora ya puede ingresar al sistema";
            }
        }
    }
}