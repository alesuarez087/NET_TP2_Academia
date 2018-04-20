<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PlantillaInscripcion.aspx.cs" Inherits="Alumnos_PlantillaInscripcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-sm-5 col-sm-offset-3 col-md-9 col-md-offset-2 main">
        <h2 class="page-header">Inscripciones</h2>
        <asp:Panel ID="pnlMateria" runat="server" Visible="true">
            <h3 class="sub-header">Materias</h3>
            <div class="btn-group navbar-btn" role="group">
                <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-info navbar-right" OnClick="btnVolver_Click" />
            </div>
            <br /><br />    
            <asp:GridView ID="gvMaterias" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Blue" DataKeyNames ="ID"
                  SelectedRowStyle-ForeColor="Black" OnSelectedIndexChanged="gvMaterias_SelectedIndexChanged" HorizontalAlign="Center" 
                  CssClass="table table-hover">
                <Columns>
                    <asp:BoundField DataField="ID" Visible="false" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Materia" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="LightBlue" ForeColor="Black"></SelectedRowStyle>
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="pnlComisiones" runat="server" Visible="false">
            <asp:Label ID="lblComisiones" runat="server" CssClass="h3 sub-header"></asp:Label><br /><br />
            <div class="btn-group" role="group">
                <asp:Button ID="btnInscribirse" runat="server" Enabled="false" Text="Inscribirse" CssClass="btn btn-default" OnClick="btnInscribir_Click" />
                <asp:Button ID="btnVolverMateria" runat="server" Text="Volver a Materias" CssClass="btn btn-default" OnClick="btnVolverMateria_Click" />
            </div>
            <asp:CustomValidator ID="cvCupo" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvCupo_ServerValidate" ForeColor="Red" CssClass="h3">* No hay cupo</asp:CustomValidator>
            <asp:CustomValidator ID="cvCurso" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvCurso_ServerValidate" ForeColor="Red" CssClass="h3">* Ya se encuentra inscripto a ese Curso</asp:CustomValidator>
            <br /><br />
            <asp:Label ID="lblVacio" Visible="false" Text="No existen comisiones disponibles" runat="server" CssClass="h3" ForeColor="Red"></asp:Label>
            <asp:GridView ID="gvComisiones" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="LightBlue"
                  DataKeyNames="ID" SelectedRowStyle-ForeColor="Black" OnSelectedIndexChanged="gvComisiones_SelectedIndexChanged" 
                  HorizontalAlign="Center" CssClass="table table-hover">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                    <asp:BoundField DataField="Comision" HeaderText="Comisiones" />
                    <asp:BoundField DataField="Año Especialidad" HeaderText="Año Especialidad" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="LightBlue" ForeColor="Black"></SelectedRowStyle>
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>

