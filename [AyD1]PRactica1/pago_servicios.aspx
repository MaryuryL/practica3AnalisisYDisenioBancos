<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pago_servicios.aspx.cs" Inherits="_AyD1_PRactica1.pago_servicios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8"/>
  <title>Pago de Servicios</title>  
  
  <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Open+Sans:600'/>

      <link rel="stylesheet" href="css/style.css"/>

  
</head>
<body style="height: 271px; width: 934px">
    <form id="form1" runat="server">
        <div class="login-wrap">
            <div class="login-html">
                <input id="tab-1" type="radio" name="tab" class="sign-in" checked /><label for="tab-1" class="tab">Pago de Servicios</label>                
                <input id="tab-2" type="radio" name="tab" class="sign-up" /><label for="tab-2" class="tab"></label>
                 <div class="login-form">
                    <div class="sign-in-htm">
                        <div class="group">
                            <label for="cuentaOR" class="label">Cuenta Actual</label>
                            <asp:Label ID="cuentaOR" runat="server" class="label">  </asp:Label>
                        </div>
                        <div class="group">
                            <label for="DropDownList2" class="label">Servicio</label>
                            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" class="input" AutoPostBack="True" DataTextField="Nombre" DataValueField="Nombre">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Practica2AyDBancoConnectionString %>" SelectCommand="SELECT [Nombre] FROM [SERVICIO]"></asp:SqlDataSource>
                        </div>
                        <div class="group">
                            <label for="TextBox2" class="label">Monto</label>
                            <asp:TextBox ID="TextBox2" runat="server" class="input"></asp:TextBox>
                        </div>
                        <div class="group">
                            <asp:Button ID="Button1" class="button" runat="server" Text="Hecho" OnClick="Button1_Click" />
                            <asp:Label ID="info" runat="server" class="label"></asp:Label>
                        </div>
                        <div class="group">
                            <asp:Button ID="Button2" class="button" runat="server" Text="Regresar" OnClick="Button2_Click1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    
</body>
</html>
