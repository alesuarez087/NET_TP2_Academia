<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Usuarios" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="col-sm-4 col-sm-offset-3 col-md-8 col-md-offset-2 main">    
    <h2 class="page-header">Usuarios</h2>
    
    <div class="navbar navbar-btn" role="group" runat="server">
        <asp:Button id="btnNuevo"  CssClass="btn btn-default" runat="server" OnClick="btnNuevo_Click" Text="Nuevo" />
        <asp:Button id="btnEditar" CssClass="btn btn-default" runat="server" OnClick="btnEditar_Click" Text="Editar" Enabled="false" />
        <asp:Button id="btnEliminar" CssClass="btn btn-default" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Enabled="false" />
        <asp:TextBox ID="txtBuscador" runat="server" AutoPostBack="True" OnTextChanged="txtBuscador_TextChanged" CssClass="form-control placeholder" style="text-align: left"  Text="Buscar" Width="190px"></asp:TextBox>
        <a href="../Default.aspx" class="btn btn-info navbar-right">Volver</a>
    </div>

    <% if(lblMensaje.Visible){ %>
    <br /><br />
    <div>
        <asp:Label ID="lblMensaje" runat="server" Text="Label" Visible="false" ForeColor="Red"></asp:Label>
    </div>
    <br /><br />
    <% } %>

    <br /><br />
    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="LightBlue" SelectedRowStyle-ForeColor="Black"
                  DataKeyNames="ID" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" HorizontalAlign="Center" CssClass="table table-striped" 
                  AllowPaging ="true" PageSize="10" OnPageIndexChanging="gvUsuarios_PageIndexChanging" PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center">
                        
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px" />
                        <asp:BoundField HeaderText="Email" DataField="Email" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px" />
                        <asp:BoundField HeaderText="NombreUsuario" DataField="NombreUsuario" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px" />
                        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" ControlStyle-Width="70px" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                    </Columns>
                    </asp:GridView>

    

</div>    
</asp:Content>

