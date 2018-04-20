using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

public partial class Administrador_Docentes : BaseForm
{
    #region PROPIEDADES
    private PersonaLogic _logic;
    public PersonaLogic Logic
    {
        get
        {
            if (_logic == null) _logic = new PersonaLogic();
            return _logic;
        }
    }
    #endregion

    #region MÉTODOS
    public override void LoadGrid()
    {
        try
        {
            if (Logic.GetAllDocentes().Count > 0)
            {
                this.gvPersonas.DataSource = Logic.GetAllDocentes();
                this.gvPersonas.DataBind();
                this.lblMensaje.Visible = false;
                this.gvPersonas.Visible = true;
                this.gvPersonas.SelectedIndex = -1;
            }
            else
            {
                this.lblMensaje.Visible = true;
                this.gvPersonas.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Page.Response.Redirect("~/Error.aspx");
        }
    }
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadGrid();
    }
    protected void btnInscribir_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {
            Session["docente"] = Logic.GetOne(SelectedID);
            Page.Response.Redirect("../Docentes/RegistrarNota.aspx");
        }
        else
        {
            lblMensaje.Text = "Seleccione un Docente";
            lblMensaje.Visible = true;
        }
    }
    protected void gvPersonas_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)gvPersonas.SelectedValue;
        this.btnInscribir.Enabled = true;
    }
    protected void txtBuscador_TextChanged(object sender, EventArgs e)
    {
        try
        {
            this.gvPersonas.DataSource = Logic.BuscadorDocente(Convert.ToInt32(txtBuscador.Text));
        }
        catch
        {
            this.gvPersonas.DataSource = Logic.BuscadorDocente(txtBuscador.Text);
        }
        this.gvPersonas.DataBind();
    }
    protected void gvPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPersonas.PageIndex = e.NewPageIndex;
        gvPersonas.DataSource = Logic.GetAllDocentes();
        gvPersonas.DataBind();
    }
    #endregion
}