using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    /*
    public Usuario UsuarioActual
    {
        get;set;
    }

    public Persona PersonaActual
    {
        get;
        set;
    }

    public List<ModuloUsuario> ModulosUsuarioActual
    {
        get;
        set;
    }

    private void Permisos()
    {
        
        this.lnkbtnInscripcion.Visible =
        this.lnkbtnReportes.Visible = 
        this.lnkRegistrarNotas.Visible =
        this.lnkbtnComisiones.Visible =  
        this.lnkbtnCursos.Visible =
        this.lnkbtnEspecialidades.Visible =
        this.lnkbtnMaterias.Visible =
        this.lnkbtnReportes.Visible =
        this.lnkbtnPersonas.Visible =
        this.lnkPlanes.Visible = false;

        ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
        PersonaLogic pl = new PersonaLogic();
        ModulosUsuarioActual = mul.GetAll(UsuarioActual.ID);
        PersonaActual = pl.GetOne(UsuarioActual.IdPersona);

        if (PersonaActual.TipoPersona == Persona.TiposPersonas.Alumno)
        {
            this.lnkbtnInscripcion.Visible = true;
            this.lnkbtnUsuarios.Text =  "Cambiar Contraseña";
        }
        else if (PersonaActual.TipoPersona == Persona.TiposPersonas.Profesor)
        {
            this.lnkRegistrarNotas.Visible = true;
            this.lnkbtnUsuarios.Text = "Cambiar Contraseña";
        }
        else if (PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
        {
            this.lnkbtnReportes.Visible = this.lnkbtnComisiones.Visible =
            this.lnkbtnCursos.Visible = this.lnkbtnEspecialidades.Visible =
            this.lnkbtnMaterias.Visible = this.lnkbtnReportes.Visible =
            this.lnkPlanes.Visible = this.lnkbtnPersonas.Visible = true;
            this.lnkbtnUsuarios.Text = "Usuarios";
        }
                
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        UsuarioActual = (Usuario)Session["usuario"];
        this.Permisos();
    }
    protected void lnkbtnInscripcion_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Alumnos/Inscripciones.aspx");
    }
    protected void lnkbtnUsuarios_Click(object sender, EventArgs e)
    {
        if(PersonaActual.TipoPersona == Persona.TiposPersonas.Administrador)
        {
            Page.Response.Redirect("Administrador/Usuarios.aspx");
        }
        else
        {
            Session["FormMode"] = BaseForm.FormModes.Modificacion;
            Page.Response.Redirect("Administrador/PlantillaUsuario.aspx");
        }
        
    }
    protected void lnkRegistrarNotas_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Docentes/RegistrarNota.aspx");
    }
    protected void lnkbtnCursos_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Administrador/Cursos.aspx");
    }
    protected void lnkbtnMaterias_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Administrador/Materias.aspx");
    }
    protected void lnkPlanes_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Administrador/Planes.aspx");
    }
    protected void lnkbtnEspecialidades_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Administrador/Especialidades.aspx");
    }
    protected void lnkbtnComisiones_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Administrador/Comisiones.aspx");
    }
    protected void lnkbtnPersonas_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Administrador/PlantillaPersona.aspx");
    }*/
}