using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _AyD1_PRactica1
{
    public partial class Movimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["cuenta"] = 1;
            cuentaOR.Text = Session["cuenta"].ToString() + "\nNombre: " + Session["nombre"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("pago_servicios.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("transferencia.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("consultaSaldo.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("credito.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Debitar.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Session["cuenta"] = "";
            Session["nombre"] = "";
            Response.Redirect("Flogin.aspx");
        }
    }
}