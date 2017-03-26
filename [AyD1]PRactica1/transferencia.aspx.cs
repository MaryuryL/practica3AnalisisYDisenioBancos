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
    public partial class transferencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cuentaOR.Text = Session["cuenta"].ToString() + "\nNombre: " + Session["nombre"].ToString();
        }        

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Metodos.Transferencia(int.Parse(Session["cuenta"].ToString()), float.Parse(TextBox3.Text), int.Parse(TextBox2.Text)))
            {
                info.Text = "Transferencia realizada con exito";
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