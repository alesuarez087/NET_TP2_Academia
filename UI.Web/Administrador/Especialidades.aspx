<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Especialidades.aspx.cs" Inherits="Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <title>Especialidades</title>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="col-sm-4 col-sm-offset-3 col-md-8 col-md-offset-2 main">
        <h2 class="page-header">Especialiades</h2>

        <asp:Panel ID="pnTabla" visible="true" runat="server">
        
            <div class="navbar navbar-btn" role="group">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-default" OnClick="btnEditar_Click" Enabled="false" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-default" OnClick="btnEliminar_Click" Enabled="false" />
                <a href="../Default.aspx" class="btn btn-info navbar-right">Volver</a>
            </div>
        
         <% if(this.lblMensaje.Visible){ %>   
            <br /><br />
            <asp:Label id="lblMensaje" Visible="false" runat="server" ForeColor="Red" CssClass="h4"></asp:Label>
         <%} %>

        <br /><br />
        <asp:Label id="lblVacio" Text="No existen Especialidades" CssClass="h4" Visible="false" runat="server" ForeColor="Red"></asp:Label>
        <div class="table-responsive">
            <asp:GridView ID="gvEspecialidades" runat="server" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" 
                          OnSelectedIndexChanged="gvEspecialidades_SelectedIndexChanged" DataKeyNames="ID" SelectedRowStyle-BackColor ="Black" 
                          SelectedRowStyle-ForeColor="White" Visible="false" CssClass="table table-striped" AllowPaging="true" PageSize="10" 
                          OnPageIndexChanging="gvEspecialidades_PageIndexChanging" PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="LightBlue" ForeColor="Black" />
            </asp:GridView>
        </div>

        </asp:Panel>
    
    

    <asp:Panel ID="pnGrilla" Visible="false" runat="server">
 
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Label id="lblEliminar" Text="Desea eliminar la Especialidad ?" CssClass="h4" Visible="false" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr><td><br /></td></tr>
            <tr>
                <td>
                    <h5 ID="lblDescripcion" runat="server" style="text-align:left">Descripción: </h5>
                </td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" style="text-align: left" ></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvEspecialiad" runat="server" CssClass="h4" ControlToValidate="txtDescripcion" ErrorMessage="RequiredFieldValidator" ForeColor="Red" style="text-align:left">* Ingrese Descripción</asp:RequiredFieldValidator>
                </td>
            </tr>
            <% if(!IsValid){ %>
            <tr>
                <td colspan="3"><br /></td>
            </tr>
             <tr>
                 <td colspan="2" style="text-align:center">
                     <asp:CustomValidator ID="cvEspecialiiadd" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvEspecialiiadd_ServerValidate" CssClass="h4" ForeColor="Red" style="text-align:center">* Ya existe esa Especialidad</asp:CustomValidator>
                 </td>
                 <td></td>
             </tr>
            <% } %>
            <tr>
                <td colspan="3"><br /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <a class="btn btn-default" runat="server" onserverclick="btnAceptar_Click" style="text-align: center">Aceptar</a>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <a href="../Administrador/Especialidades.aspx" class="btn btn-default" style="text-align: center">Cancelar</a>
                </td>
                <td></td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    
</div>
</asp:Content>


