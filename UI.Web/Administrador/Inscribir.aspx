<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Inscribir.aspx.cs" Inherits="Administrador_Inscribir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-sm-5 col-sm-offset-3 col-md-9 col-md-offset-2 main">
        <h2 class="page-header">Alumnos</h2>
        <div class="navbar navbar-btn" role="group" runat="server">
            <asp:Button ID="btnInscribir" runat="server" Text="Inscribir" CssClass="btn btn-default navbar-left" OnClick="btnInscribir_Click" Enabled="false" />
            <asp:Label id="lblMensaje" Visible="false" runat="server" CssClass="navbar-left" ForeColor="Red" ></asp:Label>
            <asp:TextBox ID="txtBuscador" runat="server" AutoPostBack="True" OnTextChanged="txtBuscador_TextChanged" CssClass="form-control navbar-left" style="text-align: left" Text="Buscar" Width="190px"></asp:TextBox>
            <a href="../Default.aspx" class="btn btn-info navbar-right">Volver</a>    
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

