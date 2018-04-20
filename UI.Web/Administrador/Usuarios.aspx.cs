using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

public partial class Usuarios : BaseForm
{
    

    UsuarioLogic _logic;

    #region PROPIEDADES
    private UsuarioLogic Logic
    {
        get
        {
            if(_logic == null)
            {
                _logic = new UsuarioLogic();
            }
            return _logic;
        }
    }
    
    private Usuario UsuarioActual
    {
        get;set;
    }
    
    #endregion

    #region METODOS CREADOS
    public override void LoadGrid()
    {
        this.gvUsuarios.DataSource = this.Logic.GetAll();
        this.gvUsuarios.DataBind();
    }    
    public override void Save()
    {
        this.Logic.Save(UsuarioActual);
    }
    private void DeleleEntity(int id)
    {
        this.Logic.Save(this.Logic.GetOne(id));
    }
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadGrid();
    }
    protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gvUsuarios.SelectedValue;
        this.btnEditar.Enabled = this.btnEliminar.Enabled = true;
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {
            Usuario u = Logic.GetOne(SelectedID);
            Session["usuarioSeleccionado"] = u;
            Session["FormMode"] = FormModes.Modificacion;
            Page.Response.Redirect("PlantillaUsuario.aspx");
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Seleccione Usuario a Editar";
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {
            this.Logic.Delete(UsuarioActual.ID);
        }
        else
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Seleccione Usuario a Editar";
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Session["FormMode"] = FormModes.Alta;
        Page.Response.Redirect("PlantillaUsuario.aspx");
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Default.aspx");
    }

    protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsuarios.PageIndex = e.NewPageIndex;
        gvUsuarios.DataSource = Logic.GetAll();
        gvUsuarios.DataBind();
    }
    #endregion
    protected void txtBuscador_TextChanged(object sender, EventArgs e)
    {
        if (this.txtBuscador.Text.Equals("")) this.LoadGrid();
        else
        {
            List<Usuario> lista = Logic.Buscador(txtBuscador.Text);
            if (lista.Count > 0)
            {
                this.lblMensaje.Visible = false;
                this.gvUsuarios.DataSource = lista;
                this.gvUsuarios.DataBind();
            }
            else
            {
                this.gvUsuarios.Visible = false;
                this.lblMensaje.Visible = true;
                this.lblMensaje.Text = "No existen usuario con" + txtBuscador.Text;
            }
        }
        
    }
}