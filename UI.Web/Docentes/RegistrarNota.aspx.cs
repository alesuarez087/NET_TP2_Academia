using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Docentes_RegistrarNota : BaseForm
{
    private InscripcionLogic _logic;

    #region PROPIEDADES
    private InscripcionLogic Logic
    {
        get
        {
            if (_logic == null)
            {
                _logic = new InscripcionLogic();
            }
            return _logic;
        }
    }
    public Usuario UsuarioActual
    {
        get; set;
    }
    public AlumnoInscripcion AlumnoInscripcionActual
    {
        get;set;
    }
    #endregion

    #region MÉTODOS
    private void LoadCurso()
    {
        CursoLogic cl = new CursoLogic();
        DataTable table = cl.GetAll(UsuarioActual.IdPersona);

        table.Columns["id_curso"].ColumnName = "ID";
        table.Columns["desc_materia"].ColumnName = "Materia";
        table.Columns["desc_comision"].ColumnName = "Comision";

        this.gvCurso.DataSource = table;
        this.gvCurso.DataBind();
    }
    private void LoadAlumnos()
    {
        InscripcionLogic il = new InscripcionLogic();
        int ID = Convert.ToInt32(this.gvCurso.DataKeys[this.gvCurso.SelectedRow.RowIndex].Value);
        if(il.GetAllComisiones(ID).Rows.Count != 0)
        {
            DataTable table = il.GetAllComisiones(ID);

            table.Columns["id_inscripcion"].ColumnName = "ID";
            table.Columns["apellido"].ColumnName = "Apellido";
            table.Columns["nombre"].ColumnName = "Nombre";
            table.Columns["nota"].ColumnName = "Nota";
            table.Columns["condicion"].ColumnName = "Condicion";

            this.gvAlumnos.DataSource = table;
            this.gvAlumnos.DataBind();
        }
        else
        {
            this.lblVacio.Text = "No existen Alumnos inscriptos";
            this.lblVacio.Visible = true;
            this.gvAlumnos.Visible = false;
        }
        
    }
    public override void MapearDeDatos()
    {   
        ddlNota.SelectedItem.Value = AlumnoInscripcionActual.Nota.ToString();
        ddlCondicion.SelectedItem.Value = AlumnoInscripcionActual.Condicion;
    }
    public override void MapearADatos()
    {
        InscripcionLogic il = new InscripcionLogic();
        AlumnoInscripcionActual = il.GetOne(Convert.ToInt32(this.gvAlumnos.DataKeys[this.gvAlumnos.SelectedRow.RowIndex].Value));
        AlumnoInscripcionActual.Nota = int.Parse(this.ddlNota.SelectedItem.Value);
        AlumnoInscripcionActual.Condicion = this.ddlCondicion.SelectedItem.Value;
        AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
    }
    public override void Save()
    {
        this.MapearADatos();
        if(IsValid)
        {
            this.Logic.GuardarCambios(AlumnoInscripcionActual);
            this.LoadAlumnos();
            this.pnNota.Visible = false;
        }
    }
    #endregion

    #region EVENTOS
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            UsuarioActual = (Usuario)Session["usuario"];
            CursoLogic cl = new CursoLogic();
            DataTable comisiones = cl.GetAll(UsuarioActual.IdPersona).Clone();
            foreach (DataRow row in cl.GetAll(UsuarioActual.IdPersona).Rows)
            {
                if ((int)row["cargo"] == 1)
                {
                    comisiones.ImportRow(row);
                }   
            }
            if (comisiones.Rows.Count == 0)
            {
                pnTabla.Visible = false;
                lblError.Visible = true;
                lblError.Text = "No posee materias a su titularidad. No puede agregar notas";
            }
            else this.LoadCurso();
            
        }
        else Page.Response.Redirect("~/Login.aspx");
    }
    protected void gvMaterias_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.pnGrilla.Visible = true;
        this.pnTabla.Visible = false;
        this.LoadAlumnos();
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        InscripcionLogic il = new InscripcionLogic();
        AlumnoInscripcionActual = il.GetOne(Convert.ToInt32(this.gvAlumnos.DataKeys[this.gvAlumnos.SelectedRow.RowIndex].Value));
        AlumnoInscripcionActual.Condicion = "Inscripto";
        AlumnoInscripcionActual.Nota = 0;
        this.FormMode = FormModes.Baja;
        this.Save();
    }
    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        this.Save();
    }
    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Default.aspx");
    }
    protected void btnDeshacer_Click(object sender, EventArgs e)
    {
        this.pnTabla.Visible = true;
        this.pnGrilla.Visible = false;
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Default.aspx");
    }


    #endregion
    protected void gvAlumnos_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.pnNota.Visible = true;
        this.AlumnoInscripcionActual = Logic.GetOne(Convert.ToInt32(this.gvAlumnos.DataKeys[this.gvAlumnos.SelectedRow.RowIndex].Value));
        this.MapearDeDatos();
    }

    protected void gvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAlumnos.PageIndex = e.NewPageIndex;
        this.LoadAlumnos();
    }
}