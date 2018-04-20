using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Data;

public partial class Alumnos_ResumenInscripciones : BaseForm
{
    #region PROPIEDADES
    private InscripcionLogic _logic;
    public InscripcionLogic Logic
    {
        get
        {
            if (_logic == null) _logic = new InscripcionLogic();
            return _logic;
        }
    }
 
    private Usuario UsuarioActual { get; set; }
    private AlumnoInscripcion AlumnoInscripcionActual { get; set; }
    #endregion
    
    #region METODOS
    public override void LoadGrid()
    {
        // INICIALIZO EL USUARIO AL QUE SE VA A MOSTRAR LAS INCRIPCIONES ACTUALES
        if (Session["alumno"] != null)
        {
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOneForPersona(((Persona)Session["alumno"]).ID);
        }
        else UsuarioActual = (Usuario)Session["usuario"];
        this.lblAlumno.Text = "Inscripciones de " + this.UsuarioActual.Apellido + ", " + this.UsuarioActual.Nombre;
        PersonaLogic pl = new PersonaLogic();
        
        DataTable inscripciones = Logic.GetAllInscripciones(pl.GetOne(UsuarioActual.IdPersona));

        if (inscripciones.Rows.Count == 0)
        {
            gvInscripciones.Visible = false;
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "No se enceuntra inscripto a ninguna materia durante el año lectivo";
        }
        else
        {
            //SE ESTABLECE EL NOMBRE DE LAS COLUMNAS DE LA TABLA
            inscripciones.Columns["id_inscripcion"].ColumnName = "ID";
            inscripciones.Columns["desc_materia"].ColumnName = "Materia";
            inscripciones.Columns["desc_comision"].ColumnName = "Comisión";
            inscripciones.Columns["anio_calendario"].ColumnName = "Año Cursado";
            inscripciones.Columns["condicion"].ColumnName = "Condición";
            inscripciones.Columns["nota"].ColumnName = "Nota";

            this.gvInscripciones.DataSource = inscripciones;
            this.gvInscripciones.DataBind();
        }

    }
    public override void Save()
    {
        this.AlumnoInscripcionActual = Logic.GetOne(SelectedID);
        this.AlumnoInscripcionActual.State = BusinessEntity.States.Deleted;
        Logic.GuardarCambios(this.AlumnoInscripcionActual);
    }
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadGrid();
    }
    #endregion
    protected void btnInscribirse_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("../Alumnos/PlantillaInscripcion.aspx");
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        if (Session["alumno"] != null)
        {
            Session["alumno"] = null;
            Page.Response.Redirect("../Administrador/Inscribir.aspx");
        }
        Page.Response.Redirect("../Default.aspx");
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        MateriaLogic ml = new MateriaLogic();
        CursoLogic cl = new CursoLogic();
        Curso curso = cl.GetOne(Logic.GetOne(SelectedID).IdCurso);
        this.pnGrilla.Visible = false;
        this.pnlEliminar.Visible = true;
        this.lblEliminar.Text = "¿Desea eliminar la inscripción a " + ml.GetOne(curso.IdMateria).Descripcion  + "?";
    }
    protected void gvInscripciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedID = (int)this.gvInscripciones.SelectedValue;
        this.btnEliminar.Enabled = true;
    }
    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        this.Save();
        this.LoadGrid();
        this.pnGrilla.Visible = true;
        this.pnlEliminar.Visible = false;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        this.pnGrilla.Visible = false;
        this.pnlEliminar.Visible = true;
        this.LoadGrid();
    }
}