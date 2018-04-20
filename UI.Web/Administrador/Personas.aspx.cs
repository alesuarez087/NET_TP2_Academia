using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_Personas : BaseForm
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
        gvPersonas.DataSource = Logic.GetAll();
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
    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if(IsEntitySelected)
        { 
            Session["persona"] = Logic.GetOne(SelectedID);
            Page.Response.Redirect("PlantillaUsuario.aspx");
        }
        else
        {
            lblMensaje.Text = "Seleccione una Persona";
            lblMensaje.Visible = true;
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Session["persona"] = null;
        Page.Response.Redirect("PlantillaUsuario.aspx");
    }
    protected void ddlBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Persona> lista = new List<Persona>();
        if(ddlBox.SelectedValue.Equals("Todos"))
        {
            lista = Logic.GetAll();
        }
        else if (ddlBox.SelectedValue.Equals("Administradores"))
        {
            foreach(Persona p in Logic.GetAll())
            {
                if(p.TipoPersona == Persona.TiposPersonas.Administrador)
                {
                    lista.Add(p);
                }
            }
        }
        else if (ddlBox.SelectedValue.Equals("Alumnos"))
        {
            foreach (Persona p in Logic.GetAll())
            {
                if (p.TipoPersona == Persona.TiposPersonas.Alumno)
                {
                    lista.Add(p);
                }
            }
        }
        else if (ddlBox.SelectedValue.Equals("Docentes"))
        {
            foreach (Persona p in Logic.GetAll())
            {
                if (p.TipoPersona == Persona.TiposPersonas.Profesor)
                {
                    lista.Add(p);
                }
            }
        }
        gvPersonas.DataSource = lista;
        gvPersonas.DataBind();
    }

    protected void txtBuscadorApellido_TextChanged(object sender, EventArgs e)
    {
        List<Persona> encontrados = new List<Persona>();
        foreach(Persona p in Logic.GetAll())
        {
            if(txtBuscadorApellido.Text.Equals(p.Apellido))
            {
                encontrados.Add(p);
            }
        }
        gvPersonas.DataSource = encontrados;
        gvPersonas.DataBind();
    }

    protected void gvPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPersonas.PageIndex = e.NewPageIndex;
        gvPersonas.DataSource = Logic.GetAll();
        gvPersonas.DataBind();
    }
#endregion
}