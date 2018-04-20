<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Planes.aspx.cs" Inherits="Planes" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Planes</title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
    <div class="col-sm-5 col-sm-offset-3 col-md-9 col-md-offset-2 main">
        <h2 class="page-header">Planes</h2>

        <asp:Panel ID="pnTabla" runat="server">
        <div class="navbar navbar-btn" role="group" style="text-align:center">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-default" OnClick="btnEditar_Click" Enabled="false" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-default" OnClick="btnEliminar_Click" Enabled="false" />
            <a href="../Default.aspx" class="btn btn-info navbar-right">Volver</a>
        </div>
        
     <% if(this.lblMensaje.Visible){ %>   
     <br /><br />
    <asp:Label id="lblMensaje" Visible="false" runat="server" ForeColor="Red" CssClass="h4"></asp:Label>
    
    <% } %>
    <br /><br />
    <asp:Label id="lblVacio" CssClass="h4" Visible="false" runat="server" ForeColor="Red"></asp:Label>

        <div class="table-responsive">

            <asp:GridView ID="gvPlanes" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" OnSelectedIndexChanged="gvPlanes_SelectedIndexChanged" 
                          SelectedRowStyle-BackColor="LightBlue" SelectedRowStyle-ForeColor="Black" DataKeyNames="id_plan" AllowSorting="True" 
                          Visible="false" CssClass="table table-striped" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvPlanes_PageIndexChanging" 
                          PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="id_plan" HeaderText="ID" />
                    <asp:BoundField DataField="desc_plan" HeaderText="Plan" />
                    <asp:BoundField DataField="desc_especialidad" HeaderText="Carrera" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="LightBlue" ForeColor="Black" />
            </asp:GridView>
        </div>
        </asp:Panel>

        <asp:Panel ID="pnForm" Visible="false" runat="server">
        
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Label ID="lblEliminar" Text="Desea Eliminar el Plan ?" CssClass="h4" Visible="false" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr><td><br /></td></tr>
            <tr>
                <td>
                    <h5 ID="lblPlan" runat="server" style="text-align:left">Plan:</h5>
                </td>
                <td>
                    <asp:TextBox ID="txtPlan" runat="server" CssClass="form-control" style="text-align:left"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvPlan" runat="server" ErrorMessage="* Ingrese nombre de Plan" ForeColor="Red" CssClass="h4" ControlToValidate="txtPlan" style="text-align:left"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <h5 id="lblEspecialidad" runat="server" style="text-align:left">Especialidad:</h5>
                </td>
                <td>
                    <div class="dropdown" >
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="btn btn-default btn-sm dropdown-toggle" style="text-align:left"></asp:DropDownList>
                    </div>
                    
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="RequiredFieldValidator" ForeColor="Red" CssClass="h4" InitialValue="Seleccione Especialidad" style="text-align:left">* Ingrese Especialidad</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3"><br /></td>
            </tr>
            <% if(!IsValid){ %>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:CustomValidator ID="cvPlanes" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvPlanes_ServerValidate" ForeColor="Red" CssClass="h4" >* Este Plan ya fue ingresado</asp:CustomValidator>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3"><br /></td>
            </tr>
            <% } %>
            <tr>
                <td colspan="2" style="text-align: center">
                    <a class="btn btn-default" runat="server" onserverclick="btnAceptar_Click" style="text-align: center">Aceptar</a>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="../Administrador/Planes.aspx" class="btn btn-default" style="text-align: center">Cancelar</a>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
        </table>
        <br />
        
    </asp:Panel>
    </div>
</asp:Content>

