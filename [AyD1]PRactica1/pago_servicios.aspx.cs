using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace _AyD1_PRactica1
{
    public partial class pago_servicios : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            cuentaOR.Text = Session["cuenta"].ToString() + "\nNombre: " + Session["nombre"].ToString();
        }                

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s = TextBox2.Text;
            float monto;

            if(TextBox2.Text == "")
            {
                monto = 0;                
            }
            else
            {
                 monto = float.Parse(s);
            }

            if (Metodos.PagoServicio(int.Parse(Session["cuenta"].ToString()), monto, DropDownList2.SelectedValue.ToString()))
            {
                info.Text = "Pago realizado correctamente";
            }
            else
            {
                info.Text = Metodos.error;
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Movimientos.aspx");
        }
    }
}