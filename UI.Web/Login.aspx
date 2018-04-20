<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Login</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="assets/css/ie10-viewport-bug-workaround.css" rel="stylesheet">
    <link href="css/signin.css" rel="stylesheet">
    <script src="assets/js/ie-emulation-modes-warning.js"></script>

  </head>
<body>
    <div class="container">
    <form class="form-signin" runat="server">
        <h4 class="form-signin-heading">Bienvenido al sistema</h4>
            <input type="text" name="txtUsuario" class="form-control" placeholder="Usuario"  required autofocus />
            <input type="password" name="txtContrasena" class="form-control" placeholder="Contraseña" required />
            <button id="btnIngresar" runat="server" type="submit" class="btn btn-lg btn-primary btn-block" onserverclick="btnIngresar_Click">Ingresar</button>
            <asp:Label ID="lblMensaje" runat="server" Visible="false" ForeColor="Red" CssClass="h4"></asp:Label>
        </form>
    </div>

      <script src="assets/js/ie10-viewport-bug-workaround.js"></script>
</body>
</html>
