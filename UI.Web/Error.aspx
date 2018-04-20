<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Error</title>

    <link href="~/css/bootstrap.min.css" rel="stylesheet">

    <link href="~/assets/css/ie10-viewport-bug-workaround.css" rel="stylesheet">

    <link href="~/css/dashboard.css"   rel="stylesheet">

    <script src="<%= ResolveClientUrl("~/assets/js/ie-emulation-modes-warning.js") %>"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="titulo" Text="Error" runat="server" CssClass="h2"></asp:Label>
        </div>
        <br /><br />
        <div>
            <asp:Label ID="message" runat="server" CssClass="h4"></asp:Label>
        </div>
    </form>
</body>
</html>
