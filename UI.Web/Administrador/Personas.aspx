<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Personas.aspx.cs" Inherits="Administrador_Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="col-sm-5 col-sm-offset-3 col-md-9 col-md-offset-2 main">
    <h2 class="page-header">Personas</h2>
    <div class="navbar navbar-btn" role="group" runat="server">
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-default navbar-left" OnClick="btnAgregar_Click" />
        <asp:Label id="lblMensaje" Visible="false" runat="server" CssClass="navbar-left" ForeColor="Red" ></asp:Label>
        <asp:DropDownList ID="ddlBox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBox_SelectedIndexChanged" style="text-align: left" CssClass="btn btn-default dropdown">
            <asp:ListItem>Todos</asp:ListItem>
            <asp:ListItem>Administradores</asp:ListItem>
            <asp:ListItem>Alumnos</asp:ListItem>
            <asp:ListItem>Docentes</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtBuscadorApellido" runat="server" AutoPostBack="True" OnTextChanged="txtBuscadorApellido_TextChanged" CssClass="form-control navbar-left" style="text-align: left" Text="Buscar" Width="190px"></asp:TextBox>
        <a href="PlantillaUsuario.aspx" class="btn btn-info navbar-right">Volver</a>    
    </div>
    
    <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" style="text-align: center"
                  SelectedRowStyle-BackColor="LightBlue" SelectedRowStyle-ForeColor="Black" DataKeyNames="ID" OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged"
                  CssClass="table table-striped" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvPersonas_PageIndexChanging" 
                  PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="TipoPersona" HeaderText="Tipo de Persona" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
        
 

</div>
</asp:Content>

