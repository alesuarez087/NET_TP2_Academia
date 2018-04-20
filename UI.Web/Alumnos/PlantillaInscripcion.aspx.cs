using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Data;

public partial class Alumnos_PlantillaInscripcion : BaseForm
{
    #region PROPIEDADES
    private UsuarioLogic _usuarioLogic;
    private PersonaLogic _personaLogic;
    private CursoLogic _cursoLogic;
    private InscripcionLogic _inscripcionLogic;
    private MateriaLogic _materiaLogic;
    private Usuario UsuarioActual { get; set; }
    private Curso CursoActual { get; set; }
    private AlumnoInscripcion AlumnoInscripcionActual { get; set; }
    private UsuarioLogic UsuarioLogic 
    { 
        get 
        { 
            if (_usuarioLogic == null) 
            { 
                _usuarioLogic = new UsuarioLogic(); 
            }
            return _usuarioLogic; 
        }
    }
    private PersonaLogic PersonaLogic
    {
        get
        {
            if (_personaLogic == null)
            {
                _personaLogic = new PersonaLogic();
            }
            return _personaLogic;
        }
    }
    private CursoLogic CursoLogic
    {
        get
        {
            if (_cursoLogic == null)
            {
                _cursoLogic = new CursoLogic();
            }
            return _cursoLogic;
        }
    }
    private InscripcionLogic InscripcionLogic
    {
        get
        {
            if (_inscripcionLogic == null)
            {
                _inscripcionLogic = new InscripcionLogic();
            }
            return _inscripcionLogic;
        }
    }
    private MateriaLogic MateriaLogic
    {
        get
        {
            if (_materiaLogic == null)
            {
                _materiaLogic = new MateriaLogic();
            }
            return _materiaLogic;
        }
    }
    
    #endregion

    #region METODOS
    private void LoadMaterias()
    {
        if (Session["alumno"] != null) UsuarioActual = UsuarioLogic.GetOneForPersona(((Persona)Session["alumno"]).ID);
        else UsuarioActual = (Usuario)Session["usuario"];

        List<Materia> materias = new List<Materia>();
        Persona alumno = PersonaLogic.GetOne(UsuarioActual.IdPersona);

        DataTable inscripciones = InscripcionLogic.GetAllInscripcionesForAlumno(alumno); //materias a las que está inscripto
        List<Materia> materiasPlan = MateriaLogic.GetAllForPlan(alumno.IdPlan); //materias del plan

        foreach (Materia materia in materiasPlan)
        {
            bool libre = true;
            foreach (DataRow row in inscripciones.Rows)
            {
                if(materia.ID == (int)row["id_materia"])
                {
                    if(((string)row["condicion"]).Equals("Inscripto") || ((string)row["condicion"]).Equals("Aprobado"))
                    {
                        libre = false;
                    }
                }
            }
            if (libre) materias.Add(materia);
        }

        this.gvMaterias.DataSource = materias;
        this.gvMaterias.DataBind();
    }

    private void LoadComisiones(int idMateria)
    {
        this.lblComisiones.Text = "Comisiones de " + MateriaLogic.GetOne(idMateria).Descripcion;
        DataTable table = InscripcionLogic.GetMateriaCursos(idMateria);
        if (table.Rows.Count == 0)
        {
            this.lblVacio.Visible = true;
            this.gvComisiones.Visible = false;
        }
        else
        {
            table.Columns["id_curso"].ColumnName = "ID";
            table.Columns["desc_comision"].ColumnName = "Comision";
            table.Columns["anio_especialidad"].ColumnName = "Año Especialidad";

            this.gvComisiones.DataSource = table;
            this.gvComisiones.DataBind();
        }
        
    }

    public override void MapearADatos()
    {
        this.AlumnoInscripcionActual = new AlumnoInscripcion();
        this.AlumnoInscripcionActual.State = BusinessEntity.States.New;
        this.AlumnoInscripcionActual.IdAlumno = this.UsuarioActual.IdPersona;
        this.AlumnoInscripcionActual.IdCurso = this.SelectedID;
        this.AlumnoInscripcionActual.Condicion = "Inscripto";
    }

    public override void Save()
    {
        if (IsValid)
        {
            this.MapearADatos();
            InscripcionLogic.GuardarCambios(this.AlumnoInscripcionActual);
            Page.Response.Redirect("ResumenInscripciones.aspx");
        }
    }
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["alumno"] != null) this.UsuarioActual = UsuarioLogic.GetOneForPersona(((Persona)Session["alumno"]).ID);
        else this.UsuarioActual = (Usuario)Session["usuario"];

        if (!IsPostBack) LoadMaterias();
    }
    protected void gvMaterias_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadComisiones((int)this.gvMaterias.SelectedValue);
        this.pnlComisiones.Visible = true;
        this.pnlMateria.Visible = false;
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("../Alumnos/ResumenInscripciones.aspx");
    }
    protected void btnVolverMateria_Click(object sender, EventArgs e)
    {
        this.LoadMaterias();
        this.pnlMateria.Visible = true;
        this.pnlComisiones.Visible = false;
    }
    protected void btnInscribir_Click(object sender, EventArgs e)
    {
        this.Save();
    }
    protected void gvComisiones_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.gvComisiones.SelectedValue;
        this.btnInscribirse.Enabled = true;
    }
    protected void cvCurso_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (pnlComisiones.Visible)
        {
            this.MapearADatos();
            bool valid = true;
            foreach (DataRow row in InscripcionLogic.GetAll(UsuarioActual.IdPersona).Rows)
            {
                if (AlumnoInscripcionActual.IdCurso == (int)row["id_curso"])
                {
                    valid = false;
                }
            }
            args.IsValid = valid;
        }
    }
    protected void cvCupo_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (pnlComisiones.Visible)
        {
            this.MapearADatos();
            int count = 0;
            foreach (DataRow row in InscripcionLogic.GetAllComisiones(SelectedID).Rows)
            {
                if ((int)row["id_curso"] == SelectedID) ++count;
            }
            CursoActual = CursoLogic.GetOne(SelectedID);
            if (CursoActual.Cupo > count) args.IsValid = true;
            else args.IsValid = false;
        }
    }
    #endregion
}