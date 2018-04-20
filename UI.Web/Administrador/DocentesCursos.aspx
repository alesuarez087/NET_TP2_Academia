<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DocentesCursos.aspx.cs" Inherits="Administrador_DocentesCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="col-sm-4 col-sm-offset-3 col-md-8 col-md-offset-2 main">
    
    <asp:Panel ID="pnTabla" runat="server">
        <h2 class="page-header">Cursos</h2>
        <div class="navbar navbar-btn" role="group">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-default" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-default" OnClick="btnEditar_Click" Enabled="false" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-default" OnClick="btnEliminar_Click" Enabled="false" />
            <a href="../Administrador/Cursos.aspx" class="btn btn-info navbar-right">Volver</a>
        </div>

        <% if(this.lblMensaje.Visible){ %>   
            <br /><br />
            <asp:Label id="lblMensaje" Visible="false" runat="server" ForeColor="Red" CssClass="h4" ></asp:Label>
        <% } %>
        <br /><br /><br />

        <asp:Label id="lblVacio" CssClass="h4" Visible="false" runat="server" ForeColor="Red"></asp:Label>
        <asp:GridView ID="gvDocentesCurso" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" style="text-align: center" 
                        SelectedRowStyle-BackColor="LightBlue" 
                        SelectedRowStyle-ForeColor="Black" CssClass="table table-hover"
                        DataKeyNames="IdDictado" OnSelectedIndexChanged="gvDocentesCurso_SelectedIndexChanged" Visible="false">
                        <Columns>
                            <asp:BoundField DataField="IdDictado" Visible="false" />
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                        </Columns>
                        <SelectedRowStyle BackColor="LightBlue" ForeColor="Black" />
                    </asp:GridView>

        
    </asp:Panel>
    <br />


    <asp:Panel ID="pnDocentes" runat="server" Visible="false">
        <h2 class="page-header">Docentes</h2>
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <% if(this.lblMensajeDocente.Visible){ %>   
                        <asp:Label id="lblMensajeDocente" Text="No hay Docentes" Visible="false" runat="server" ForeColor="Red" CssClass="h4" ></asp:Label>
                    <% } %>
                    <br /><br /><br />
                 <asp:GridView ID="gvDocentes" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" style="text-align: center" 
                        SelectedRowStyle-BackColor="LightBlue"
                        SelectedRowStyle-ForeColor="Black" CssClass="table table-hover"
                        DataKeyNames="ID" OnSelectedIndexChanged="gvDocentes_SelectedIndexChanged" >
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                        </Columns>
                        <SelectedRowStyle BackColor="LightBlue" ForeColor="Black" />
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <br />

    <asp:Panel ID="pnDesktop" runat="server" Visible="false">
        <table style="width:100%;">
            <tr>
                <td>
                    <a ID="btnAgregarDocente" class="btn btn-default" runat="server" onserverclick="btnAgregarDocente_Click" style="position:center">Agregar Docente</a>
                </td>
                <td style="text-align:left">
                    <asp:Label ID="lblDocente" Visible="false" runat="server" CssClass="h4" style="text-align:center"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="text-align:left" class="auto-style10">
                    <asp:Label ID="lblCargo" Text="Cargo" runat="server" CssClass="h4" style="text-align:center"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTipoCargo" runat="server" CssClass="btn btn-default btn-sm dropdown-toggle h4">
                        <asp:ListItem>Seleccionar Cargo</asp:ListItem>
                        <asp:ListItem>Auxiliar</asp:ListItem>
                        <asp:ListItem>Ayudante</asp:ListItem>
                        <asp:ListItem>Titular</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvTipoDocente" runat="server" ControlToValidate="ddlTipoCargo" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="h4" InitialValue="Seleccionar Cargo">* Seleccione Cargo</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvCargo" runat="server" ErrorMessage="* Ya se ha asignado ese Cargo a otro docente en el Curso" ForeColor="Red" OnServerValidate="cvCargo_ServerValidate" CssClass="h4"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:CustomValidator ID="cvDocenteCurso" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvDocenteCurso_ServerValidate" ForeColor="Red" CssClass="h4">* Ya fue agreado a este curso con este cargo</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="2">
                    <asp:Button ID="btnAgregarDocenteCurso" style="position:center" CssClass="btn btn-default" runat="server" OnClick="btnAgregarDocenteCurso_Click" Text="Agregar" Width="90px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancelar" style="position:center" CssClass="btn btn-default" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" Width="90px" />
                </td>
            </tr>
        </table>

    </asp:Panel>

</div>
</asp:Content>

