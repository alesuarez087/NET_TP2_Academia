<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ResumenInscripciones.aspx.cs" Inherits="Alumnos_ResumenInscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-sm-5 col-sm-offset-3 col-md-9 col-md-offset-2 main">
        <h2 class="page-header">Inscripciones</h2>
        <asp:Panel ID="pnGrilla" runat="server" Visible="true">
        <div class="btn-group" role="group">
            <asp:Button ID="btnInscribirse" runat="server" Text="Inscribirse" CssClass="btn btn-default" OnClick="btnInscribirse_Click" />
            <asp:Button ID="btnEliminar" runat="server" Enabled="false" Text="Eliminar" CssClass="btn btn-default" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-info navbar-right" OnClick="btnVolver_Click" />
        </div>    
        <br /><br />
        <%if(lblMensaje.Visible){ %>
        <div>
            <asp:Label id="lblMensaje" Visible="false" runat="server" ForeColor="Red" CssClass="h3"></asp:Label>
            <br /><br />
        </div>
        <% } %>
        <asp:Label id="lblAlumno" runat="server" CssClass="h4"></asp:Label>
        <br /><br />
        <asp:GridView ID="gvInscripciones" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                  SelectedRowStyle-BackColor="LightBlue" SelectedRowStyle-ForeColor="Black" CssClass="table table-hover"
                  HorizontalAlign="Center" style="text-align: center" OnSelectedIndexChanged="gvInscripciones_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false"/>
            <asp:BoundField DataField="Materia" HeaderText="Materia" />
            <asp:BoundField DataField="Comisión" HeaderText="Comisión" />
            <asp:BoundField DataField="Año Cursado" HeaderText="Año de Cursado" />
            <asp:BoundField DataField="Condición" HeaderText="Condición" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>

        <SelectedRowStyle BackColor="LightBlue" ForeColor="Black"></SelectedRowStyle>

    </asp:GridView>
            </asp:Panel>
        
        <asp:Panel ID="pnlEliminar" runat="server" Visible="false">
            <asp:Label ID="lblEliminar" runat="server" CssClass="h3"></asp:Label>
            <br /><br />
            <asp:Button ID="btnConfirmar" runat="server" CssClass="btn btn-danger" Text="Confirmar" OnClick="btnConfirmar_Click"  />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" OnClick="btnCancelar_Click" />
        </asp:Panel>
    </div>
</asp:Content>

