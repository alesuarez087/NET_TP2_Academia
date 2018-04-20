<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PlantillaUsuario.aspx.cs" Inherits="Administrador_PlantillaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
        .auto-style1 {
            width: 52px;
        }
        .auto-style2 {
            width: 171px;
        }
    </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" /> 
<div class="col-sm-4 col-sm-offset-3 col-md-8 col-md-offset-2 main">    
    

    
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style3">&nbsp;
                <asp:UpdatePanel runat="server" ID="UDP" UpdateMode="Conditional">
                    <ContentTemplate>
                <table>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">
                            <h5 ID="lblNombre" runat="server" style="text-align:right">Nombre: </h5>
                        </td>
                        <td class="auto-style3">
                            &nbsp; 
                            <asp:TextBox ID="txtNombre" style="text-align:left" CssClass="form-control h5" runat="server" Enabled="true" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            &nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Button id="btnAgregarPersona" style="text-align:left" CssClass="btn btn-default h5" runat="server" Text="Agregar Persona" OnClick="btnAgregarPersona_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp; <h5 ID="lblApellido" runat="server" style="text-align:right">Apellido: </h5></td>
                        <td class="auto-style11">&nbsp; <asp:TextBox ID="txtApellido" style="text-align:left" CssClass="form-control" runat="server" Enabled="true" ReadOnly="True"></asp:TextBox></td>
                        <td class="auto-style10">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp; <h5 ID="lblEmail" runat="server" style="text-align:right">Email:</h5></td>
                        <td class="auto-style11">&nbsp; <asp:TextBox ID="txtEmail" CssClass="form-control" style="text-align:left" runat="server" ReadOnly="True"></asp:TextBox></td>
                        <td class="auto-style10">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp; <h5 ID="lblHabilitado" runat="server" style="text-align:right">Habilitado:</h5></td>
                        <td class="auto-style11">&nbsp; <asp:CheckBox ID="chckbxHabilitado" runat="server" style="text-align:left" CssClass="checkbox checkbox-inline" /></td>
                        <td class="auto-style10">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp; <h5 ID="lblNombreUsuario" runat="server">Usuario:</h5></td>
                        <td class="auto-style11">&nbsp; <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox></td>
                        <td class="auto-style10">
                            <asp:CustomValidator ID="cvNombreUsuario" runat="server" ErrorMessage=" * Ingrese Nombre de Usuario" ForeColor="Red" OnServerValidate="cvNombreUsuario_ServerValidate" ></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp; <h5 ID="lblClave" runat="server">Clave:</h5></td>
                        <td class="auto-style11">&nbsp; <asp:TextBox ID="txtClave" CssClass="form-control" runat="server"></asp:TextBox></td>
                        <td class="auto-style10">
                            <asp:CustomValidator ID="cvContrasena" runat="server" ErrorMessage="CustomValidator" style="text-align:center" OnServerValidate="cvContrasena_ServerValidate" ForeColor="Red">* Las Claves debe tener 8 caract min</asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp; <h5 ID="lblConfirmaClave" runat="server">Confirmar Clave:</h5></td>
                        <td class="auto-style11">&nbsp;<asp:TextBox ID="txtConfirmarClave" CssClass="form-control" runat="server"></asp:TextBox> </td>
                        <td class="auto-style10">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6" colspan="4">
                            <asp:CustomValidator ID="cvUsuarios" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvUsuarios_ServerValidate" ForeColor="Red">* Ya existe un Usuario con ese nombre</asp:CustomValidator>
                        </td>
                    </tr>
                </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style9">
                
                <asp:GridView ID="gvModulos" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" style="text-align: center; margin-top: 0px;" 
                              DataKeyNames ="IdModulo" OnRowCancelingEdit="gvModulos_RowCancelingEdit" OnRowEditing="gvModulos_RowEditing" OnRowUpdating="gvModulos_RowUpdating"
                              CssClass="table table-bordered" >
                    <Columns>
                        <asp:TemplateField HeaderText="IdModulo" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtIdModulo" runat="server" Text='<%# Bind("IdModulo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("IdModulo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="False" ReadOnly="true" />
                        <asp:BoundField DataField="DescripcionModulo" HeaderText="Módulo" SortExpression="DescripcionModulo" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Alta" SortExpression="PermiteAlta">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chckbxAlta" runat="server" Checked='<%# Bind("PermiteAlta") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckAlta" runat="server" Checked='<%# Bind("PermiteAlta") %>' Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Baja" SortExpression="PermiteBaja">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chckbxBaja" runat="server" Checked='<%# Bind("PermiteBaja") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBaja" runat="server" Checked='<%# Bind("PermiteBaja") %>' Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Consulta" SortExpression="PermiteConsulta">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chckbxConsulta" runat="server" Checked='<%# Bind("PermiteConsulta") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckConsulta" runat="server" Checked='<%# Bind("PermiteConsulta") %>' Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Modificación" SortExpression="PermiteModificacion">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chckbxModificacion" runat="server" Checked='<%# Bind("PermiteModificacion") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckModificacion" runat="server" Checked='<%# Bind("PermiteModificacion") %>' Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Editar">
                            <EditItemTemplate>
                                <asp:LinkButton id="LinkButton1" runat="server"  CausesValidation="True" CommandName="Update" Text="Actualizar" CssClass="btn btn-success" OnClientClick="return comprueba();"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" CssClass="btn btn-danger"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" CssClass="btn btn-info" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                        
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="text-align: center">&nbsp; </td>
            <td style="text-align: center" class="auto-style9"> 
                <asp:Button id="btnAceptar" CssClass="btn btn-default" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" /> 
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button id="btnCancelar" CssClass="btn btn-default" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" /> 
            </td>
            <td class="auto-style3" style="text-align: center">&nbsp; </td>
        </tr>
    </table>
        
</div>
</asp:Content>

