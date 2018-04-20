using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    public Usuario UsuarioActual
    {
        get;
        set;
    }
    public Persona PersonaActual
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["error"] == null)
        {
            if (Session["usuario"] != null)
            {
                UsuarioActual = (Usuario)Session["usuario"];
                CargaPaneles();
            }
            else
            {
                Page.Response.Redirect("Login.aspx");
            }
        }
        else Session["error"] = null;
    }

    private void CargaPaneles()
    {
//        this.pnUsuario.Visible = true;
        this.pnAlumno.Visible = this.pnDocente.Visible = this.pnAdmin.Visible = false;
        PersonaLogic pl = new PersonaLogic();
        PersonaActual = pl.GetOne(UsuarioActual.IdPersona);
        if (PersonaActual.TipoPersona == Persona.TiposPersonas.Alumno)
        {
            this.pnAlumno.Visible = true;
            
        }
        else if (PersonaActual.TipoPersona == Persona.TiposPersonas.Profesor)
        {
            this.pnDocente.Visible = true;
        }
        else if (PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
        {
            this.pnAdmin.Visible = true;
        }
        this.pnComun.Visible = true;
    }

    protected void btnPlanes_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Administrador/Planes.aspx");
    }
}
