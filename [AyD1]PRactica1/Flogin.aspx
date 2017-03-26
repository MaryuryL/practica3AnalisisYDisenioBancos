<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Flogin.aspx.cs" Inherits="_AyD1_PRactica1.Flogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8"/>
  <title>Login</title>  
  
  <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Open+Sans:600'/>

      <link rel="stylesheet" href="css/style.css"/>

  
</head>
<body>

    <form id="form1" runat="server">
        <div class="login-wrap">
            <div class="login-html">
                <input id="tab-1" type="radio" name="tab" class="sign-in" checked /><label for="tab-1" class="tab">Sign In</label>
                <input id="tab-2" type="radio" name="tab" class="sign-up" /><label for="tab-2" class="tab">Sign Up</label>
                <div class="login-form">
                    <div class="sign-in-htm">
                        <div class="group">
                            <label for="Cuenta" class="label">Cuenta</label>
                            <asp:TextBox ID="TextBox3" runat="server" class="input"></asp:TextBox>
                        </div>
                        <div class="group">
                            <label for="user" class="label">Username</label>
                            <asp:TextBox ID="TextBox1" runat="server" class="input"></asp:TextBox>
                        </div>
                        <div class="group">
                            <label for="pass" class="label">Password</label>
                            <asp:TextBox ID="TextBox2" runat="server" class="input" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="group">
                            <asp:Button ID="Button1" class="button" runat="server" Text="Ingresar" OnClick="Button1_Click" />
                            <asp:Label ID="info" runat="server" class="label"></asp:Label>
                        </div>
                    </div>
                    <div class="sign-up-htm">
                        <div class="group">
                            <label for="user" class="label">Nombre Completo</label>
                            <asp:TextBox ID="TextBox4" runat="server" class="input"></asp:TextBox>
                        </div>
                        <div class="group">
                            <label for="user" class="label">Username</label>
                            <asp:TextBox ID="TextBox5" runat="server" class="input"></asp:TextBox>
                        </div>
                        <div class="group">
                            <label for="pass" class="label">Email</label>
                            <asp:TextBox ID="TextBox6" runat="server" class="input"></asp:TextBox>
                        </div>
                        <div class="group">
                            <label for="passw" class="label">Password</label>
                            <asp:TextBox ID="TextBox7" runat="server" class="input"></asp:TextBox>
                        </div>
                        <div class="group">
                            <asp:Button ID="Button2" class="button" runat="server" Text="Registrarse" OnClick="Button2_Click" />
                            <asp:Label ID="info2" runat="server" class="label"></asp:Label>
                        </div>
                        <div class="hr"></div>
                        <div class="foot-lnk">
                            <label for="tab-1"><a>Ya tiene cuenta?</a></label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
