using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

public partial class Administrador_Inscribir : BaseForm
{
    #region PROPIEDADES
    private PersonaLogic _logic;

    public PersonaLogic Logic
    {
        get
        {
            if (_logic == null)
            {
                _logic = new PersonaLogic();
            }
            return _logic;
        }
    }
    #endregion

    #region MÉTODOS
    public override void LoadGrid()
    {
        gvPersonas.DataSource = Logic.GetAllAlumnos();
        gvPersonas.DataBind();
    }
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadGrid();
        }
    }
    protected void gvPersonas_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gvPersonas.SelectedValue;
        this.btnInscribir.Enabled = Visible;
    }


    protected void btnInscribir_Click(object sender, EventArgs e)
    {
        if (IsEntitySelected)
        {
            Session["alumno"] = Logic.GetOne(SelectedID);
            Page.Response.Redirect("../Alumnos/ResumenInscripciones.aspx");
        }
        else
        {
            lblMensaje.Text = "Seleccione un Alumno";
            lblMensaje.Visible = true;
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Session["alumno"] = null;
        Page.Response.Redirect("Default.aspx");
    }

    protected void txtBuscador_TextChanged(object sender, EventArgs e)
    {
        if (!txtBuscador.Text.Equals(""))
        {
            List<Persona> lista = new List<Persona>();
            try
            {
                lista = Logic.BuscadorAlumno(Convert.ToInt32(this.txtBuscador.Text));
            }
            catch
            {
                lista = Logic.BuscadorAlumno(this.txtBuscador.Text);
            }
            this.gvPersonas.DataSource = lista;
            this.gvPersonas.DataBind();
        }
        else this.LoadGrid();
    }

    protected void gvPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPersonas.PageIndex = e.NewPageIndex;
        gvPersonas.DataSource = Logic.GetAllAlumnos();
        gvPersonas.DataBind();
    }
    #endregion
}