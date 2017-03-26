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
    public partial class consultaSaldo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cuentaOR.Text = Session["cuenta"].ToString() + "\nNombre: " + Session["nombre"].ToString();
            float g = Metodos.Consulta(int.Parse(Session["cuenta"].ToString()));
            if(g != null)
            {
                info.Text = "Su Saldo es de: " + g;
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