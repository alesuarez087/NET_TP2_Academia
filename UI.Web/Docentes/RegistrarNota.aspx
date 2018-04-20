<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RegistrarNota.aspx.cs" Inherits="Docentes_RegistrarNota" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="col-sm-5 col-sm-offset-3 col-md-9 col-md-offset-2 main">
    


            <br /><br />
        <% if(this.lblError.Visible){ %>
        
        <asp:Label ID="lblError" Visible="false" runat="server" CssClass="h2" ForeColor="Red"></asp:Label>
        <% } %>

    <asp:Panel ID="pnTabla" runat="server" Visible =" true">
        <h2 class="page-header">Materias</h2>

        <br /><br />
        <div></div>
        <asp:GridView runat="server" ID="gvCurso" AutoGenerateColumns="False" SelectedRowStyle-BackColor ="Black" DataKeyNames ="ID"
                      SelectedRowStyle-ForeColor="Black" OnSelectedIndexChanged="gvMaterias_SelectedIndexChanged" HorizontalAlign="Center"
                      CssClass="table table-hover">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False"/>
                <asp:BoundField DataField="Materia" HeaderText="Materia" />
                <asp:BoundField DataField="Comision" HeaderText="Comisión" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="LightBlue" ForeColor="Black"></SelectedRowStyle>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="pnGrilla" runat="server" Visible="false">
            <h2 class="page-header">Alumnos</h2>
            <a runat="server" onserverclick="btnVolver_Click" class="btn btn-info navbar-right">Volver</a>
        <% if(this.lblVacio.Visible){ %>
        <br /><br />
        <asp:Label ID="lblVacio" Visible="false" runat="server" CssClass="h3" ForeColor="Red"></asp:Label>
        <% } %>
        <br /><br />
        <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" SelectedRowStyle-BackColor="LightBlue" 
                      SelectedRowStyle-ForeColor="Black" HorizontalAlign="Center" OnSelectedIndexChanged="gvAlumnos_SelectedIndexChanged"
                      CssClass="table table-striped" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvAlumnos_PageIndexChanging" 
                      PagerSettings-Position="Bottom" PagerStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condición" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style13">&nbsp;
                        <asp:Panel id="pnNota" Visible="false" runat="server" Width="772px">
                        <table style="width:100%;">
                <tr>
                    <td class="auto-style3">
                        <h5 ID="lblNota" runat="server" style="text-align:center">Nota</h5>
                    </td>
                    <td class="auto-style9">
                       
                        <asp:DropDownList ID="ddlNota" runat="server" AutoPostBack="True" CssClass="btn btn-default btn-sm dropdown-header">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        
                        <h5 ID="lblCondicion" runat="server" style="text-align:center" >Condición</h5>
                        
                    </td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddlCondicion" runat="server" AutoPostBack="True" CssClass="btn btn-default btn-sm dropdown-header">
                            <asp:ListItem>Inscripto</asp:ListItem>
                            <asp:ListItem>Regular</asp:ListItem>
                            <asp:ListItem>Aprobado</asp:ListItem>
                            <asp:ListItem>Libre</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td >
                        <asp:Button ID="btnBorrar" runat="server" class="btn btn-danger center-block" Text="Borrar Nota" OnClick="btnBorrar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnConfirmar" runat="server" class="btn btn-primary center-block" Text="Confirmar" OnClick="btnConfirmar_Click" />
                    </td>
                    <td class="auto-style2"></td>
                </tr>
            </table>
        </asp:Panel>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
            </div>
</asp:Content>

