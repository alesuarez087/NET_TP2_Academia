<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EstadoAcademico.aspx.cs" Inherits="Alumnos_EstadoAcademico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-sm-5 col-sm-offset-3 col-md-9 col-md-offset-2 main">

    <h2 class="page-header">Estado Académico</h2> 
        <a href="../Default.aspx" class="btn btn-info navbar-right">Volver</a><br /><br /><br />
    <asp:GridView ID="gvEstadoAcademico" runat="server" AutoGenerateColumns="False" CssClass="table table-hover">
        <Columns>
            <asp:BoundField DataField="Materia" HeaderText="Materia" />
            <asp:BoundField DataField="Texto" HeaderText="Condición" />
        </Columns>
    </asp:GridView>
        </div>
</asp:Content>

