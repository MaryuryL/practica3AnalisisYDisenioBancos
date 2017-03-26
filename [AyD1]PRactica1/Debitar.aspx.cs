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
    public partial class Debitar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cuentaOR.Text = Session["cuenta"].ToString() + "\nNombre: " + Session["nombre"].ToString();
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Metodos.Debito(int.Parse(Session["cuenta"].ToString()), int.Parse(TextBox1.Text), float.Parse(TextBox2.Text), TextBox3.Text))
            {
                info.Text = "Acreditacion realizada con exito";
            }
            else
            {
                info.Text = Metodos.error;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movimientos.aspx");
        }
    }
}