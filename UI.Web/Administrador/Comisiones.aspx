<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Comisiones.aspx.cs" Inherits="Administrador_Comisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Comisiones</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">

    <link href="assets/css/ie10-viewport-bug-workaround.css" rel="stylesheet">

    <link href="css/dashboard.css" rel="stylesheet">

    <script src="assets/js/ie-emulation-modes-warning.js"></script>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
<div class="col-sm-5 col-sm-offset-3 col-md-9 col-md-offset-2 main">
    <h2 class="page-header">Comisiones</h2>
    <asp:Panel ID="pnTabla" runat="server">
        <div class="navbar navbar-btn" role="group">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-default" OnClick="btnEditar_Click" Enabled="false" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-default" OnClick="btnEliminar_Click" Enabled="false" />
        </div>    
        <a href="../Default.aspx" class="btn btn-info navbar-right">Volver</a>
        
        
        <% if(this.lblMensaje.Visible){ %>   
            <br /><br />
            <asp:Label id="lblMensaje" Visible="false" runat="server" ForeColor="Red" CssClass="h4" ></asp:Label>
        <% } %>
        <br /><br />

        <asp:Label id="lblVacio" CssClass="h4" Visible="false" runat="server" ForeColor="Red"></asp:Label>


        <div class="table-responsive">
            <asp:GridView ID="gvComisiones" runat="server" AutoGenerateColumns="False" DataKeyNames="id_comision" HorizontalAlign="Center" 
                      OnSelectedIndexChanged="gvComisiones_SelectedIndexChanged" SelectedRowStyle-BackColor="LightBlue" SelectedRowStyle-ForeColor="Black"
                      AllowSorting="True" CssClass="table table-striped" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvComisiones_PageIndexChanging" 
                      PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center">
                            <Columns>
                                <asp:BoundField DataField="id_comision" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id_comision" />
                                <asp:BoundField DataField="desc_comision" HeaderText="Comisión" SortExpression="desc_comision" />
                                <asp:BoundField DataField="anio_especialidad" HeaderText="Año" SortExpression="anio_especialidad" />
                                <asp:BoundField DataField="desc_especialidad" HeaderText="Carrera" SortExpression="desc_especialidad" />
                                <asp:BoundField DataField="desc_plan" HeaderText="Plan" SortExpression="desc_plan" />
                                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            </Columns>
                            <SelectedRowStyle BackColor="LightBlue" ForeColor="Black" />
        </asp:GridView>
        </div>
        </asp:Panel>

    <asp:Panel ID="pnGrilla" Visible="false" runat="server">
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Label ID="lblEliminar" runat="server" CssClass="h4" Text="Desea Eliminar esta Comisión ?" ForeColor="Red" Visible="false"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr><td colspan="3"><br /></td></tr>
            <tr>
                <td>
                    <h5 ID="lblComision" runat="server" style="text-align:left">Comisión:</h5>
                </td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control placeholder:XX " style="text-align:left" Width="150px" ></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rvfComision" runat="server" CssClass="h4" ControlToValidate="txtDescripcion" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="text-align:left">* Ingrese nombre de Comisión</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 ID="lblEspecialidad" runat="server" style="text-align:left">Carrera:</h5>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEspecialidad" style="text-align:left" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" CssClass="btn btn-default btn-sm" Width="260px"></asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rvfEspecialidad" style="text-align:left" runat="server" CssClass="h4" ControlToValidate="ddlEspecialidad" ErrorMessage="RequiredFieldValidator" ForeColor="Red" InitialValue="Seleccione Especialidad">* Ingrese Carrera</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 ID="lblPlan" runat="server" style="text-align:left">Plan:</h5>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPlan" style="text-align:left" runat="server" Enabled="False" Visible="true" CssClass="btn btn-default btn-sm dropdown-toggle" Width="150px"></asp:DropDownList>
                    <asp:Label ID="lblPlanVacio" style="text-align:left" runat="server" Visible="false" CssClass="h4" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rvfPlan" style="text-align:left" runat="server" CssClass="h4" ControlToValidate="ddlPlan" ErrorMessage="RequiredFieldValidator" ForeColor="Red" InitialValue="Seleccione Plan">* Ingrese Plan</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 ID="lblAnoEspecialidad" runat="server" style="text-align:left">Año de Especialidad:</h5>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAno" runat="server" CssClass="btn btn-default btn-sm dropdown-toggle" Enabled="false" style="text-align:left">
                        <asp:ListItem>-</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                    
                    
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rvfAno" runat="server" ControlToValidate="ddlAno" CssClass="h4" ErrorMessage="RequiredFieldValidator" ForeColor="Red" InitialValue="-" style="text-align:left">* Ingrese Año de Especialidad</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <% if(!IsValid) { %>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:CustomValidator ID="cvComision" runat="server" CssClass="h4" ControlToValidate="txtDescripcion" ErrorMessage="CustomValidator" OnServerValidate="cvComision_ServerValidate" ForeColor="Red" style="text-align:left">* Ya existe esa Comisión</asp:CustomValidator>
                </td>
                <td></td>
            </tr>
            <tr><td colspan="3"><br /></td></tr>
            <% } %>
            <tr>
                <td style="text-align: center" colspan="2">
                    <a class="btn btn-default" runat="server" onserverclick="btnAceptar_Click" style="text-align: center">Aceptar</a>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="../Administrador/Planes.aspx" class="btn btn-default" style="text-align: center">Cancelar</a>
                </td>
                <td style="text-align: center">&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
        </asp:Panel>
    </asp:Panel>
    
</div>
</asp:Content>
