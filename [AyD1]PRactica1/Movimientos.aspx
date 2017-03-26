<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Movimientos.aspx.cs" Inherits="_AyD1_PRactica1.Movimientos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8"/>
  <title>Movimientos</title>  
  
  <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Open+Sans:600'/>

      <link rel="stylesheet" href="css/style.css"/>

  
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-wrap">
            <div class="login-html">
                <input id="tab-1" type="radio" name="tab" class="sign-in" checked/><label for="tab-1" class="tab">Movimientos</label>
                <input id="tab-2" type="radio" name="tab" class="sign-up" /><label for="tab-2" class="tab"></label>
                <div class="login-form">
                    <div class="sign-in-htm">
                        <div class="group">
                            <label for="cuentaOR" class="label">Cuenta Actual</label>
                            <asp:Label ID="cuentaOR" runat="server" class="label">  </asp:Label>
                        </div> 
                        <div class="group">
                            <label for="Button1" class="label">Pago de Servicios</label>
                            <asp:Button ID="Button1" runat="server" Text="Pago de Servicios" OnClick="Button1_Click" class="button" />
                        </div>
                        <div class="group">
                            <asp:Button ID="Button2" runat="server" Text="Transferencias" OnClick="Button2_Click" class="button" />
                        </div>
                        <div class="group">
                            <asp:Button ID="Button3" runat="server" Text="Consultar Saldo" OnClick="Button3_Click" class="button" />
                        </div>
                        <div class="group">
                            <asp:Button ID="Button4" runat="server" Text="Credito" OnClick="Button4_Click" class="button" />
                        </div>
                        <div class="group">
                            <asp:Button ID="Button5" runat="server" Text="Debito" OnClick="Button5_Click" class="button" />
                        </div>
                        <div class="group">
                            <asp:Button ID="Button6" runat="server" Text="Log out" OnClick="Button6_Click" class="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>



    </form>    
</body>
</html>
