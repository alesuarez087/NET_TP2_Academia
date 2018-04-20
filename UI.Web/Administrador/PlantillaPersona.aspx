<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PlantillaPersona.aspx.cs" Inherits="PlantillaPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-sm-5 col-sm-offset-3 col-md-9 col-md-offset-2 main">
        <h2 class="page-header">Personas</h2>
    <asp:Panel ID="pnTabla" runat="server">
        <div class="navbar navbar-btn" role="group">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-default" OnClick="btnEditar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-default" OnClick="btnEliminar_Click" />
            <a href="../Default.aspx" class="btn btn-info navbar-right">Volver</a>
        </div>

        <% if(this.lblMensaje.Visible){ %>   
            <br /><br />
            <asp:Label id="lblMensaje" Visible="false" runat="server" ForeColor="Red" CssClass="h4" ></asp:Label>
        <% } %>
        <br /><br /><br />

        <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" DataKeyNames="ID" SelectedRowStyle-BackColor ="Black"
                      SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged" CssClass="table table-striped" 
                      AllowPaging="true" PageSize="10" OnPageIndexChanging="gvPersonas_PageIndexChanging" PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center">
                      <Columns>
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="TipoPersona" HeaderText="Tipo de Persona" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                      </Columns>
                      <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>

    </asp:Panel>
    
    <asp:Panel ID="pnGrilla" runat="server" Visible ="false">
        <table style="width:100%;">
            <tr>
                <td>
                    <h5 style="text-align:left">Legajo</h5></td>
                <td>
                    <asp:TextBox ID="txtLegajo" CssClass="form-control h5" style="text-align: left"  runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CustomValidator ID="cvLegajo" runat="server" ControlToValidate="txtLegajo" ErrorMessage="CustomValidator" OnServerValidate="cvLegajo_ServerValidate" ForeColor="Red" style="text-align:left" CssClass="h4">* Ya ingresó ese Legajo</asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ErrorMessage="RequiredFieldValidator" CssClass="h4" ForeColor="Red" style="text-align:left">* Ingrese Legajo</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 style="text-align:left">Nombre:</h5></td>
                <td>
                    <asp:TextBox ID="txtNombre" CssClass="form-control h5" style="text-align:left" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="h4" style="text-align:left">* Ingrese Nombre</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><h5 style="text-align:left">Apellidos:</h5></td>
                <td>
                    <asp:TextBox ID="txtApellido" style="text-align:left" CssClass="form-control h5" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="h4" style="text-align:left">* Ingrese Apellido</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><h5 style="text-align:left">Fecha de Nacimineto:</h5></td>
                <td>
                    <asp:TextBox ID="txtDia" CssClass="form-control h5" runat="server" Width="50px" style="text-align:left">DD</asp:TextBox>
                    <asp:TextBox ID="txtMes" CssClass="form-control h5" runat="server" Width="50px" style="text-align:left">MM</asp:TextBox>
                    <asp:TextBox ID="txtAno" CssClass="form-control h5" runat="server" Width="58px" style="text-align:left">AAAA</asp:TextBox>
                </td>
                <td>
                    <asp:CustomValidator ID="cvFechaNacimineto" runat="server" ControlToValidate="txtDia" ErrorMessage="CustomValidator" OnServerValidate="cvFechaNacimineto_ServerValidate" ForeColor="Red" CssClass="h4" style="text-align:left">* Error en fecha de nacimiento</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td><h5 style="text-align:left">Dirección:</h5></td>
                <td>
                    <asp:TextBox ID="txtDireccion" CssClass="form-control h5" style="text-align:left" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="text-align:left" CssClass="h4">* Ingrese Dirección</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><h5 style="text-align:left">Email:</h5></td>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="form-control h5" style="text-align:left" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" style="text-align:left" CssClass="h4">* El Email no posee el formato</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><h5 style="text-align:left">Teléfono</h5></td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control h5" style="text-align:left"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelefono" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="h4" style="text-align:left">* Ingrese Teléfono</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><h5 style="text-align:left">Carrera:</h5></td>
                <td>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" CssClass="btn btn-default btn-sm dropdown-toggle h5" style="text-align:left"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="h4" style="text-align:left">* Ingrese Especialidad</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><h5 style="text-align:left">Plan:</h5></td>
                <td>
                    <asp:DropDownList ID="ddlPlan" runat="server" CssClass=" btn btn-default btn-sm dropdown-toggle h5" style="text-align:left"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPlan" runat="server" ControlToValidate="ddlPlan" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="h4" style="text-align:left">* Ingrese Plan</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td><h5 style="text-align:left">Tipo de Persona</h5></td>
                <td>
                    <asp:DropDownList ID="ddlTipoPersona" runat="server" CssClass="btn btn-default btn-sm dropdown-toggle h5" style="text-align:left"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvTipoPersona" runat="server" ControlToValidate="ddlTipoPersona" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="h4" style="text-align:left">* Ingrese Tipo de Persona</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:center" colspan="2">
                   <a ID="btnAceptar" runat="server" class="btn btn-default" onserverclick="btnAceptar_Click">Aceptar</a>
                   &nbsp;&nbsp;&nbsp;&nbsp;
                   <a ID="btnCancelar" runat="server" class="btn btn-default">Cancelar</a>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </asp:Panel>
        </div>
</asp:Content>

