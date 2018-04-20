<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Cursos.aspx.cs" Inherits="Listados_Cursos" %>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="col-sm-4 col-sm-offset-3 col-md-10 col-md-offset-2 main">    
    <asp:Panel ID="pnTabla" runat="server">
        <h2 class="page-header">Cursos</h2>
        <div class="navbar navbar-btn" role="group">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-default" OnClick="btnEditar_Click" Enabled="false"/>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-default" OnClick="btnEliminar_Click" Enabled="false" />
            <asp:Button ID="btnAgregarDocente" runat="server" Text="Agregar Docente" CssClass="btn btn-default" Visible="false" OnClick="btnAgregarDocente_Click" />
        </div>    
        <a href="../Default.aspx" class="btn btn-info navbar-right">Volver</a>

        <% if(this.lblMensaje.Visible){ %>   
            <br /><br />
            <asp:Label id="lblMensaje" Visible="false" runat="server" ForeColor="Red" CssClass="h4" ></asp:Label>
        <% } %>
        <br /><br />

        <asp:Label id="lblVacio" CssClass="h4" Visible="false" runat="server" ForeColor="Red"></asp:Label>

                    
            <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False" DataKeyNames="id_curso" HorizontalAlign="Center" 
                          OnSelectedIndexChanged ="gvCursos_SelectedIndexChanged" SelectedRowStyle-BackColor="LightBlue" SelectedRowStyle-ForeColor="Black"
                          CssClass="table table-striped" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvCursos_PageIndexChanging" 
                          PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="id_curso" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id_curso" />
                        <asp:BoundField DataField="desc_materia" HeaderText="Materia" SortExpression="desc_materia" />
                        <asp:BoundField DataField="desc_comision" HeaderText="Comisión" SortExpression="desc_comision" />
                        <asp:BoundField DataField="cupo" HeaderText="Cupo" SortExpression="cupo" />
                        <asp:BoundField DataField="desc_especialidad" HeaderText="Carrera" SortExpression="desc_especialidad" />
                        <asp:BoundField DataField="desc_plan" HeaderText="Plan" SortExpression="desc_plan" />
                        <asp:BoundField DataField="anio_calendario" HeaderText="Año Calendario" SortExpression="anio_calendario" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                    </Columns>
                <SelectedRowStyle BackColor="LightBlue" ForeColor="Black" />
            </asp:GridView>
        </asp:Panel>

    <asp:Panel ID="pnGrilla" Visible="false" runat="server">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Label ID="lblEliminar" Text="Desea Eliminar el Curso ?" CssClass="h4" Visible="false" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr><td colspan="4"><br /></td></tr>
            <tr>
                <td>
                    <h5 ID="lblEspecialidad" runat="server" style="text-align:left">Carrera:</h5>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" CssClass="btn btn-default btn-sm dropdown-toggle" style="text-align:left"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEspecialidad" CssClass="h4" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="text-align:left">* Ingrese Carrera</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 ID="lblPlan" runat="server" style="text-align:left">Plan:</h5>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPlan" runat="server" Visible="true" AutoPostBack="True" OnSelectedIndexChanged="ddlPlan_SelectedIndexChanged" CssClass="btn btn-default btn-sm dropdown-toggle" style="text-align:left"></asp:DropDownList>
                    <asp:Label ID="lblPlanVacio" runat="server" ForeColor="Red" CssClass="h4" Visible="false" Text="No existen Planes" style="text-align:left"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPlan" CssClass="h4" runat="server" ControlToValidate="ddlPlan" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="text-align:left">* Ingrese Plan</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 ID="lblComision" runat="server" style="text-align:left">Comisión:</h5>
                </td>
                <td>
                    <asp:DropDownList ID="ddlComisiones" Visible="true" runat="server" CssClass="btn btn-default btn-sm dropdown-toggle" style="text-align:left"> </asp:DropDownList>
                    <asp:Label ID="lblComisionesVacio" runat="server" ForeColor="Red" CssClass="h4" Visible="false" Text="No existen Comisiones" style="text-align:left"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvComision" CssClass="h4" runat="server" ControlToValidate="ddlComisiones" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="text-align:left">* Ingrese Comisión</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 ID="lblMateria" runat="server" style="text-align:left">Materia:</h5>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMaterias" Visible="true" runat="server" CssClass="btn btn-default btn-sm dropdown-toggle" style="text-align:left"></asp:DropDownList>
                    <asp:Label ID="lblMateriasVacio" runat="server" ForeColor="Red" CssClass="h4" Visible="false" Text="No existen Materias" style="text-align:left"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvMateria" CssClass="h4" runat="server" ControlToValidate="ddlMaterias" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="text-align:left">* Ingrese Materia</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 ID="lblAno" runat="server" style="text-align:left">Año Calendario:</h5>
                </td>
                <td>
                    <asp:TextBox ID="txtAno" runat="server" CssClass="form-control" Width="60px" style="text-align:left" ></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvAnoCalendario" CssClass="h4" runat="server" ControlToValidate="txtAno" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="text-align:left">* Ingrese Año Calendario</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 ID="lblCupo" runat="server" style="text-align:left">Cupo:</h5>
                </td>
                <td>
                    <asp:TextBox ID="txtCupo" runat="server" CssClass="form-control" Width="60px" style="text-align:left"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvCupo" CssClass="h4" runat="server" ControlToValidate="txtCupo" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="text-align:left">* Ingrese Cupo</asp:RequiredFieldValidator>
                </td>
            </tr>
            <% if(!IsValid){ %>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:CustomValidator ID="cvCurso" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvCurso_ServerValidate" CssClass="h4" ForeColor="Red">* Ya existe este Curso</asp:CustomValidator>
                </td>
            </tr>
            <% } %>
            <tr><td><br /></td></tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <a class="btn btn-default" runat="server" onserverclick="btnAceptar_Click" style="text-align: center">Aceptar</a>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="../Administrador/Cursos.aspx" class="btn btn-default" style="text-align: center">Cancelar</a>
                </td>
            </tr>
        </table>
    </asp:Panel>

</div>
</asp:Content>


