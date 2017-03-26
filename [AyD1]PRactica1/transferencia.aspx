<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transferencia.aspx.cs" Inherits="_AyD1_PRactica1.transferencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8"/>
  <title>Transferencias</title>  
  
  <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Open+Sans:600'/>

      <link rel="stylesheet" href="css/style.css"/>  
</head>
<body>
    <form id="form1" runat="server">
         <div class="login-wrap">
            <div class="login-html">
                <input id="tab-1" type="radio" name="tab" class="sign-in" checked /><label for="tab-1" class="tab">Transferencias</label>                
                <input id="tab-2" type="radio" name="tab" class="sign-up" /><label for="tab-2" class="tab"></label>
                <div class="login-form">
                    <div class="sign-in-htm">
                        <div class="group">
                            <label for="cuentaOR" class="label">Cuenta Actual</label>
                            <asp:Label ID="cuentaOR" runat="server" class="label">  </asp:Label>
                        </div>                        
                        <div class="group">
                            <label for="TextBox2" class="label">Cuenta Destino</label>
                            <asp:TextBox ID="TextBox2" runat="server" class="input"></asp:TextBox>
                        </div>
                        <div class="group">
                            <label for="TextBox3" class="label">Monto</label>
                            <asp:TextBox ID="TextBox3" runat="server" class="input"></asp:TextBox>
                        </div>                        
                        <div class="group">
                            <asp:Button ID="Button1" class="button" runat="server" Text="Hecho" OnClick="Button1_Click" />
                            <asp:Label ID="info" runat="server" class="label"></asp:Label>
                        </div>
                        <div class="group">
                            <asp:Button ID="Button2" class="button" runat="server" Text="Regresar" OnClick="Button2_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div> 
        
    </form>
</body>
</html>
