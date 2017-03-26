<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consultaSaldo.aspx.cs" Inherits="_AyD1_PRactica1.consultaSaldo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8"/>
  <title>Consulta de Saldo</title>  
  
  <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Open+Sans:600'/>

      <link rel="stylesheet" href="css/style.css"/>  
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-wrap">
            <div class="login-html">
                <input id="tab-1" type="radio" name="tab" class="sign-in" checked /><label for="tab-1" class="tab">Consulta de Saldo</label>                
                <input id="tab-2" type="radio" name="tab" class="sign-up" /><label for="tab-2" class="tab"></label>
                <div class="login-form">
                    <div class="sign-in-htm">
                        <div class="group">
                            <label for="cuentaOR" class="label">Cuenta Actual</label>
                            <asp:Label ID="cuentaOR" runat="server" class="input">  </asp:Label>
                        </div>      
                        <div class="group">
                            <label for="info" class="label">Saldo Actual</label>
                            <asp:Label ID="info" runat="server" class="input">  </asp:Label>
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
