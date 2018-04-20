<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Docentes.aspx.cs" Inherits="Administrador_Docentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-sm-5 col-sm-offset-3 col-md-9 col-md-offset-2 main">
        
        <div class="navbar navbar-btn" role="group" runat="server">
            <h2 class="page-header">Docentes</h2>
            <asp:Button ID="btnInscribir" runat="server" Text="Inscribir" CssClass="btn btn-default navbar-left" OnClick="btnInscribir_Click" Enabled="false" />
            <asp:TextBox ID="txtBuscador" runat="server" AutoPostBack="True" OnTextChanged="txtBuscador_TextChanged" CssClass="form-control navbar-left" style="text-align: left" Text="Buscar" Width="190px"></asp:TextBox>
            <a href="../Default.aspx" class="btn btn-info navbar-right">Volver</a>    
        </div>
    
        <% if(this.lblMensaje.Visible){ %>
            <br />
            <asp:Label id="lblMensaje" Visible="false" runat="server" Text="No existen Docentes" CssClass="navbar-left h4" ForeColor="Red" ></asp:Label>
        <% } %>
        <br />
        <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" style="text-align: center"
                  SelectedRowStyle-BackColor="LightBlue" SelectedRowStyle-ForeColor="Black" DataKeyNames="ID" OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged"
                  CssClass="table table-hover" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvPersonas_PageIndexChanging" 
                  PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo"/>
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                    </Columns>
        </asp:GridView>
    </div>
</asp:Content>

