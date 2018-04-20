<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Materias.aspx.cs" Inherits="Listados_Materias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <title>Materias</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="col-sm-4 col-sm-offset-3 col-md-10 col-md-offset-2 main">    
    <h2 class="page-header">Materias</h2>

    <asp:Panel ID="pnTabla" runat="server">
    <div class="navbar navbar-btn" role="group">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-default" OnClick="btnEditar_Click" Enabled="false" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-default" OnClick="btnEliminar_Click" Enabled="false" />
            <a href="../Default.aspx" class="btn btn-info navbar-right">Volver</a>
        </div>

        <% if(this.lblMensaje.Visible){ %>   
            <br /><br />
            <asp:Label id="lblMensaje" Visible="false" runat="server" ForeColor="Red" CssClass="h4" ></asp:Label>
        <% } %>
        <br /><br />
         <% if(this.lblVacio.Visible){ %>
        <asp:Label id="lblVacio" CssClass="h4" Visible="false" runat="server" ForeColor="Red"></asp:Label>
        <% }%>
        <asp:GridView ID="gvMaterias" runat="server" AutoGenerateColumns="False" DataKeyNames="id_materia" SelectedRowStyle-BackColor="LightBlue" 
                      SelectedRowStyle-ForeColor="Black" OnSelectedIndexChanged="gvMaterias_SelectedIndexChanged" HorizontalAlign="Center"
                      Visible ="false"  HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Left" CssClass="table table-striped"
                      AllowPaging="true" PageSize="10" OnPageIndexChanging="gvMaterias_PageIndexChanging" PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="id_materia" HeaderText="ID"/>
                <asp:BoundField DataField="desc_materia" HeaderText="Materia"/>
                <asp:BoundField DataField="hs_semanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="hs_totales" HeaderText="Horas Totales"/>
                <asp:BoundField DataField="desc_especialidad" HeaderText="Carrera"/>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="LightBlue" ForeColor="Black" />
        </asp:GridView>

        

    </asp:Panel>

    <asp:Panel ID="pnGrilla" Visible="false" runat="server">
        

        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Label ID="lblEliminar" Text="Desea Eliminar la Materia ?" CssClass="h4" Visible="false" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr><td><br /></td></tr>
            <tr>
                <td>
                    <h5 ID="lblMateria" runat="server" style="text-align:left">Nombre Materia:</h5> 
                </td>
                <td >
                    <asp:TextBox ID="txtNombreMateria" runat="server" CssClass="form-control" style="text-align:left" Width="195px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvDescripcion" CssClass="h4" runat="server" ControlToValidate="txtNombreMateria" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="text-align:left">* Ingrese Nombre de Materia</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 id="lblHsSemanales" runat="server" style="text-align:left">Horas Semanales:</h5>
                </td>
                <td>
                    <asp:TextBox ID="txtHsSemanales" runat="server" CssClass="form-control" style="text-align:left" Width="60px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvHsSemanales" runat="server" ControlToValidate="txtHsSemanales" ErrorMessage="RequiredFieldValidator" CssClass="h4" ForeColor="Red" style="text-align:left">* Ingrese cantidad de horas Semanales</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 id="lblHsTotales" runat="server" style="text-align:left">Horas Totales:</h5> 
                </td>
                <td>
                    <asp:TextBox ID="txtHsTotales" runat="server" CssClass="form-control" style="text-align:left" Width="60px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvHsTotales" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="h4" style="text-align:left" ControlToValidate="txtHsTotales">* Ingrese cantidad de horas Totales</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                
                <td>
                    <h5 id="lblEspecialidad" runat="server" style="text-align:left">Carrera:</h5>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="btn btn-default btn-sm dropdown-toggle" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="True" style="text-align:left"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="h4" InitialValue="Seleccione Especialidad" style="text-align:left">* Ingrese Carrera</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 id="lblPlan" runat="server" style="text-align:left">Plan</h5> 
                </td>
                <td>
                    <asp:DropDownList ID="ddlPlan" runat="server" CssClass="btn btn-default btn-sm dropdown-toggle" style="text-align:left"></asp:DropDownList>
                    <asp:Label ID="lblPlanVacio" runat="server" style="text-align:left" CssClass="h4" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPlan" runat="server" ControlToValidate="ddlPlan" ErrorMessage="RequiredFieldValidator" CssClass="h4" ForeColor="Red" InitialValue="Seleccionar Plan" style="text-align:left">* Ingrese Plan</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr><td colspan="3"><br /></td></tr>
            <%if(!IsValid){ %>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:CustomValidator ID="cvMateria" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvMateria_ServerValidate" ForeColor="Red" CssClass="h4">* Esta Materia ya fue creada</asp:CustomValidator>
                </td>
            </tr>
            <tr><td colspan="3"><br /></td></tr>
            <% } %>
            <tr>
                <td colspan="2" style="text-align: center">
                    <a class="btn btn-default" runat="server" onserverclick="btnAceptar_Click">Aceptar</a>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="../Administrador/Materias.aspx" class="btn btn-default">Cancelar</a>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    
</div>
</asp:Content>

